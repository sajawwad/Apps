using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Mobile.Service;

namespace xPlatAuctionT.DataObjects
{
    public class Auction : EntityData
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual Collection<AuctionItemDBEntity> Items { get; set; } 
    }
}