using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System;
using Android.Runtime;

namespace gardener.Droid
{
	[Activity(Label = "gardener",
		Icon = "@mipmap/pict_1",
		Theme = "@style/MainTheme",
		MainLauncher = true,
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : FormsAppCompatActivity
	{
		#region Overrided
		protected override void OnCreate(Bundle savedInstanceState)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(savedInstanceState);
			Forms.Init(this, savedInstanceState);
			LoadApplication(new App());

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
        }
        #endregion
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}
