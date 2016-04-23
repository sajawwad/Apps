using Microsoft.WindowsAzure.Mobile.Service;

namespace xPlatAuctionT.Entities
{
    public class AuctionItem : EntityData
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double StartingBid { get; set; }

        public double CurrentBid { get; set; }

        public string AuctionId { get; set; }
    }
}
