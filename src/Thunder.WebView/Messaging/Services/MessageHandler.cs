using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Thunder.WebView.Extensions;

namespace Thunder.WebView.Messaging
{
    public class MessageHandler : IMessageHandler
    {
        private readonly IServiceProvider _serviceProvider;

        public MessageHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IMessageResult HandleMessage(Message message)
        {
            var parsedAction = this.ParseAction(message);
            var matchingHandler = this.GetMatchingHandler(parsedAction);
            var matchingMethod = this.GetMatchingMethod(matchingHandler, parsedAction);
            var args = this.GetArguments(matchingMethod, parsedAction);

            var response = matchingMethod.Invoke(matchingHandler, args);
            return new ResponseMessageResult(response);
        }

        private ParsedAction ParseAction(Message message)
        {
            var split = message.Action.Split('.', StringSplitOptions.RemoveEmptyEntries);
            if (split.Length != 2)
            {
                throw new ImproperActionMessageException(message);
            }
            return new ParsedAction
            {
                Message = message,
                Key = split[0],
                Method = split[1]
            };
        }

        private Object[] GetArguments(MethodInfo matchingMethod, ParsedAction parsedAction)
        {
            var parameters = matchingMethod.GetParameters();
            var args = ((JsonElement)parsedAction.Message.Data).ToObject<Object[]>()
                .Select((c, index) =>
                {
                    var parameter = parameters[index];
                    return ((JsonElement)c).ToObject(parameter.ParameterType);
                }).ToArray();

            return args;
        }

        private MethodInfo GetMatchingMethod(IMessageController matchingHandler, ParsedAction parsedAction)
        {
            var matchingMethod = matchingHandler.GetType().GetMethods().FirstOrDefault(c => String.Equals(
                c.GetCustomAttributes<HandlerAttribute>().FirstOrDefault()?.Name ?? c.Name,
                parsedAction.Method,
                StringComparison.InvariantCultureIgnoreCase));

            if (matchingMethod == null)
            {
                throw new NoMatchingActionOnControllerFoundException(parsedAction.Message, matchingHandler);
            }
            return matchingMethod;
        }

        private IMessageController GetMatchingHandler(ParsedAction parsedAction)
        {
            var handlers = _serviceProvider.GetServices<IMessageController>();
            var matchingHandler = handlers.FirstOrDefault(c => String.Equals(
                c.GetType().GetCustomAttributes<HandlerAttribute>().FirstOrDefault()?.Name ?? c.GetType().Name,
                parsedAction.Key,
                StringComparison.InvariantCultureIgnoreCase));

            if (matchingHandler == null)
            {
                throw new NoMatchingControllerFoundException(parsedAction.Message);
            }
            return matchingHandler;
        }
    }
}