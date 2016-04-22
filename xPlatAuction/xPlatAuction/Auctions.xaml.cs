using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace xPlatAuction
{
	public partial class Auctions : ContentPage
	{
		public Auctions ()
		{
			InitializeComponent ();
		}

		public async void Button_Clicked(object sender, EventArgs e)
		{
			 var client = new MobileServiceClient ("http://10.0.2.2//xPlatAuctionT/");

		    var todoItems = await client.GetTable<ToDoItem>().ReadAsync();
		    message.Text = todoItems.First().Text;

		}
	}


}

