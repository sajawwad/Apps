using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using xPlatAuctionT.Entities;
using xPlatAuctionT.Models;

namespace xPlatAuctionT.Controllers
{
    public class MyItemsController : ApiController
    {
        public ApiServices Services { get; set; }

        public IEnumerable<MyAuctionItem> Get()
        {
            
            MobileServiceContext ctx = new MobileServiceContext();
            var myItems = from ai in ctx.AuctionItems
                          select new MyAuctionItem
                          {
                              Id = ai.Id,
                              Name = ai.Name,
                              Description = ai.Description,
                              CurrentBid = ai.Bids.Count == 0 ? 0 : ai.Bids.Max(b => b.BidAmount),
                              MyHighestBid = 0 //we'll fix this later
                          };

            return myItems;
        }

    }
}
