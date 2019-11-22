using gardener.Models;
using gardener.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gardener.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage(MasterViewModel mvm)
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(mvm);
        }
    }
}