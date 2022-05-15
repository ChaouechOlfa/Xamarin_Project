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
    public partial class Modifier : ContentPage
    {
        Boolean trouve = false;
        public Modifier()
        {
            InitializeComponent();
        }

        private async void btnModifier_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(modNom.Text)|| string.IsNullOrEmpty(anpass.Text)|| string.IsNullOrEmpty(nvpass.Text))
            {
                await DisplayAlert("Attention!", "Vous devez remplir les champs ", "OK");
            }
            else
            {
                trouve = false;
                User u = new User();
                List<User> Users = await App.UserRegistration.GetAllUserAsync();
                
                foreach (User user in Users)
                {

                    if (modNom.Text == user.Name)
                    {
                        trouve = true;
                        u = user;

                    }


                }
                if (trouve == false)
                {
                    await DisplayAlert("Attention!", "cet utilisiteur n'existe pas dans la base", "OK");
                    statusMessage.Text = "";

                }
                else
                {
                    u.Password = nvpass.Text;
                    statusMessage.Text = "";
                    await App.UserRegistration.UpdateUserAsync(u);
                    statusMessage.Text = App.UserRegistration.StatusMessage;
                }

            }


        }

        private async void RetourLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}