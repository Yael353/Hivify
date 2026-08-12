namespace Ansjon.UseCases.Abstractions.Messaging;

public interface IQuerySender
{
    Task<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default);
}