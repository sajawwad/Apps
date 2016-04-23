using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace xPlatAuction
{
    public class App : Application
    {
        private static AuctionService azService;

        public App()
        {
            // The root page of your application
            MainPage = new ContentPage();
        }

        public void LoadMainPage()
        {
            MainPage = new NavigationPage(new Auctions());
        }
        public static AuctionService GetAuctionService()
        {
            //return azService ??
            //       (azService = new AuctionService("http://10.0.2.2/xPlatAuctionT/"));

            //return azService ??
            //       (azService = new AuctionService("http://169.254.80.80/xPlatAuctionT/"));

            //return azService ??
            //  (azService = new AuctionService("http://192.168.1.172/xPlatAuctionT/"));

            return azService ??
                   (azService = new AuctionService("https://xplatauctiont.azure-mobile.net"));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
