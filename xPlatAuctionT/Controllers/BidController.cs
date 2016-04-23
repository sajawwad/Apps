using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Security;
using xPlatAuctionT.DataObjects;
using xPlatAuctionT.Models;

namespace xPlatAuctionT.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.Anonymous)]
    public class BidController : TableController<Bid>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Bid>(context, Request, Services);
        }

        // GET tables/Bid
        public IQueryable<Bid> GetAllBid()
        {
            return Query(); 
        }

        // GET tables/Bid/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Bid> GetBid(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Bid/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Bid> PatchBid(string id, Delta<Bid> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Bid
        public async Task<IHttpActionResult> PostBid(Bid item)
        {
          //  var user = this.User as ServiceUser;

            //if (user != null && user.Id != null)
            {
                item.Bidder = "jawad";
                var current = await InsertAsync(item);
                return CreatedAtRoute("Tables", new {id = current.Id}, current);
            }
            //else
            //{
            //    Services.Log.Info("identity is not present");
            //    return base.StatusCode(System.Net.HttpStatusCode.BadRequest);
            //}
        }

        // DELETE tables/Bid/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteBid(string id)
        {
             return DeleteAsync(id);
        }

    }
}