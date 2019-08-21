
using System.ComponentModel;
using gardener;
using UIKit;  
using Xamarin.Forms;  
using Xamarin.Forms.Platform.iOS;
using XamarinEntry.iOS.Renderers;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(CustomEntryRenderer))]  
    namespace XamarinEntry.iOS.Renderers
{  
        public class CustomEntryRenderer: EntryRenderer  
        {  
            protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)  
            {  
                base.OnElementPropertyChanged(sender, e);

                Control.BackgroundColor = UIColor.FromRGB(255, 236, 209);
            }  
        }  
    }  
