namespace SharedKernel.Messaging
{
    public interface ISender
    {
        Task<TResponse> Send<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default);
    }
}
