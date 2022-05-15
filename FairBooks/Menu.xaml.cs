using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FairBooks
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
        }

        private async void btnLibraryMasterDetail_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FlyoutPage1());
        }

        private async void btnISETTabbedPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ISETTabbedPage());

        }

        private async void btnBookFairCarouselPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BookFairCarouselPage());
        }

        private async void btnQuitter_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();

        }
    }
}