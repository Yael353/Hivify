namespace BuildingBlocks.ApplicationPorts.Messeging
{
    public interface ISender
    {
        Task<TResponse> Send<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default);
    }
}
