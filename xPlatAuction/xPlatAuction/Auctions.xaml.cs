using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.MobileServices;
using xPlatAuction.ViewModel;
using Xamarin.Forms;

namespace xPlatAuction
{
	public partial class Auctions
	{
		public Auctions ()
		{
            this.BindingContext = new AuctionsViewModel(this.Navigation);
            InitializeComponent ();
		}

		//public async void Button_Clicked(object sender, EventArgs e)
		//{
		//	 var client = new MobileServiceClient ("http://10.0.2.2//xPlatAuctionT/");

		//    var todoItems = await client.GetTable<ToDoItem>().ReadAsync();
		//    message.Text = todoItems.First().Text;

		//}


        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((AuctionsViewModel)BindingContext).Load();
        }

        protected void Auction_Tapped(object sender, ItemTappedEventArgs e)
        {
            Auction auction = e.Item as Auction;
            Navigation.PushAsync(
                new AuctionItems(auction));
        }

        protected void MyItem_Tapped(object sender, ItemTappedEventArgs e)
        {
            MyAuctionItem item = e.Item as MyAuctionItem;

            var targetItem = new AuctionItem
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                CurrentBid = item.CurrentBid
            };

            Navigation.PushAsync(new PlaceBid(targetItem));
        }

    }


}

