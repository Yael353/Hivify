namespace Ansjon.UseCases.Communications.InterFaces
{
    public interface IFeedGenerator
    {
        Task<CreateFeedDto> GenerateAsync(
            string instruction);
    }
}
