namespace SharedKernel.Messaging;

public interface IQuerySender
{
    Task<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default);
}