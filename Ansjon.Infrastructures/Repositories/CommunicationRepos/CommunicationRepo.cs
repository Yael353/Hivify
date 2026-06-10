using Ansjon.Core.Entities;
using Ansjon.UseCases.Communications;

namespace Ansjon.Infrastructures.Repositories.CommunicationRepos
{
    public class CommunicationRepo : ICommunicationRepo
    {
        //private readonly  

        //public CommunicationRepo(ICommunicationRepo communicationRepo)
        //{
        //    _communicationRepo = communicationRepo;
        //}

        //public Task GetAllFeedsAsync()
        //{
        //    return _communicationRepo.GetAllFeedsAsync();
        //}
        public Task<IEnumerable<Feed>> GetAllFeedsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
