using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.WindowsAzure.Mobile.Service;

namespace xPlatAuctionT.DataObjects
{
    public class Bid : EntityData
    {
        public double BidAmount { get; set; }

        public string Bidder { get; set; }


        //EF properties
        [Column("AuctionItem_Id")]
        public string AuctionItemId  { get; set; }

        [ForeignKey("AuctionItemId")]
        public virtual AuctionItemDBEntity AuctionItem { get; set; }


    }
}
