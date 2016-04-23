using Android.App;
using Android.Content;
using Android.OS;
using Microsoft.WindowsAzure.MobileServices;

namespace xPlatAuction.Droid
{
	[Activity (Label = "Login", MainLauncher=true, NoHistory=true)]			
	public class LoginActivity : Activity
	{
		protected async override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			CurrentPlatform.Init ();
			// Create your application here
			//var service = App.GetAuctionService();
			//await service.Login(this);

			//after login succeeds, move on to the main activity
			var intent = new Intent(this, typeof(MainActivity));
			StartActivity(intent);
		}
	}
}

