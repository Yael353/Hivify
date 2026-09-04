namespace BuildingBlocks.ApplicationPorts.Messeging;

public interface IQuerySender
{
    Task<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default);
}