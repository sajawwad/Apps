using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Security;
using xPlatAuctionT.Entities;
using xPlatAuctionT.Models;

namespace xPlatAuctionT.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.Anonymous)]
    public class MyItemsController : ApiController
    {
        public ApiServices Services { get; set; }

        public IEnumerable<MyAuctionItem> Get()
        {

           // ServiceUser user = this.User as ServiceUser;

            MobileServiceContext ctx = new MobileServiceContext();
            var myItems = from ai in ctx.AuctionItems
                          join bid in ctx.Bids on ai.Id equals bid.AuctionItemId
                          where bid.Bidder == "jawad"
                          select new MyAuctionItem
                          {
                              Id = ai.Id,
                              Name = ai.Name,
                              Description = ai.Description,
                              CurrentBid = ai.Bids.Count == 0 ? 0 : ai.Bids.Max(b => b.BidAmount),
                              MyHighestBid = ai.Bids.Where(
                                b => b.Bidder == "jawad").Max(
                                    bi => bi.BidAmount)
                          };

            return myItems;
        }

    }
}
