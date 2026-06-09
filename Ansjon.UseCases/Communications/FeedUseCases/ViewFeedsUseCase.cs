using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ansjon.Core.Entities;


namespace Ansjon.UseCases.Communications.FeedUseCases
{
    public class ViewFeedsUseCase
    {
        //GetAllFeeds
        // A feed can be a post, an article, etc. has a title, post-date(CreatedAt) and a discription.It will be created by the system.  It will only be displayed in a feedcomponent for the users.
        public async Task<IEnumerable<Feed>> GetAllFeeds()
        {
            throw new NotImplementedException();
        }
    }
}
