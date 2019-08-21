using System;
using Android.Util;
using gardener.Droid;
using gardener.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneCallDroid))]
namespace gardener.Droid
{
    public class PhoneCallDroid : IPhoneCall
    {
        public PhoneCallDroid()
        { }

        public void MakeQuickCall(string phoneNumber)
        {
            try
            {
                PhoneDialer.Open(phoneNumber);
            }
            catch (ArgumentNullException anEx)
            {
                Log.Debug("Number was null or white space", anEx.ToString());
            }
            catch (FeatureNotSupportedException ex)
            {
                Log.Debug("PhoneNumber Dialer is not supported on this device", ex.ToString());
            }
            catch (Exception ex)
            {
                Log.Debug("PhoneNumber", ex.ToString());
            }
        }
    }
}
