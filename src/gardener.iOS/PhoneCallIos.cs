using System;
using gardener.iOS;
using gardener.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneCallIos))]
namespace gardener.iOS
{
    public class PhoneCallIos : IPhoneCall
    {
        public PhoneCallIos()
        {
        }

        public void MakeQuickCall(string phoneNumber)
        {
            UIApplication.SharedApplication.OpenUrl(new Uri($"tel:{phoneNumber}"));
        }
    }
}
