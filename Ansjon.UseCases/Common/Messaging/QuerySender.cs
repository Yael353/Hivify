using Ansjon.UseCases.Abstractions.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace Ansjon.UseCases.Common.Messaging;

public sealed class QuerySender : IQuerySender
{
    private readonly IServiceProvider _serviceProvider;

    public QuerySender(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default)
    {
        var queryType = query.GetType();

        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(
                    queryType,
                    typeof(TResponse));

        dynamic handler = _serviceProvider.GetRequiredService(handlerType);

        return await handler.Handle(
            (dynamic)query,
            cancellationToken);
    }
}