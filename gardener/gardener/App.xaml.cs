using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using gardener.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace gardener
{
    public partial class App : Application
    {
        public Color Barbackgroundcolor { get; }

        public App()
        {
            InitializeComponent();


            MainPage = new MainPage();
            {
                Barbackgroundcolor = Color.FromRgb(252,247,241);
            }
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
