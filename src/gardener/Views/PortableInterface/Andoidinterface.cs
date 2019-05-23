using Xamarin.Forms;
using System.Threading.Tasks;
using Xamarin.Forms.PlatformConfiguration;
/*
[assembly: Dependency(typeof(gardener.Views.PortableInterface.CallMaster))]
namespace gardener.Views.PortableInterface
{
    public class Andoidinterface : CallMaster
    {
        public Task Call(string phoneNumber)
        {
           var packageManager = Android.Context.PackageManager;
            Android.Net.Uri telUri = Android.Net.Uri.Parse($"tel:{phoneNumber}");
            var callIntent = new Intent(Intent.ActionCall, telUri);

            callIntent.AddFlags(ActivityFlags.NewTask);
            // проверяем доступность
            var result = null != callIntent.ResolveActivity(packageManager);

            if (!string.IsNullOrWhiteSpace(phoneNumber) && result == true)
            {
                Android.App.Application.Context.StartActivity(callIntent);
            }

            return Task.FromResult(true);
        }
    }
}*/
