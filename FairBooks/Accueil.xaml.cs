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
    public partial class Accueil : ContentPage
    {
        Boolean b;
        public Accueil()
        {
            InitializeComponent();
        }

        private async void LogIn_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new Menu());
            List<User> users = await App.UserRegistration.GetAllUserAsync();
            foreach (User user in users)
            {
                if (Username.Text == $"{user.Name}" && Password.Text == $"{user.Password}")
                {
                    b = true;
                    await Navigation.PushAsync(new Menu());
                }
            }
            if (! b)
            {
                await DisplayAlert("Attention!", "Nom d'utilisateur ou mot de passe erronnés! ", "OK");
            }


        }

        private async void Inscrire_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new enregistrement());

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Modifier());

        }
    }
}