using Hivify.UseCases.Abstractions.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace Hivify.UseCases.Common.Messaging
{
    public sealed class Sender : ISender
    {
        private readonly IServiceProvider _serviceProvider;

        public Sender(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public async Task<TResponse> Send<TResponse>(
            ICommand<TResponse> command,
            CancellationToken cancellationToken = default)
        {
            var commandType = command.GetType();

            var handlerType =
                typeof(ICommandHandler<,>)
                .MakeGenericType(
                    commandType,
                    typeof(TResponse));


            dynamic handler =
                _serviceProvider.GetRequiredService(handlerType);


            return await handler.Handle(
                (dynamic)command,
                cancellationToken);
        }
    }

}
