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
    public partial class enregistrement : ContentPage
    {
        Boolean trouve = false;
        public enregistrement()
        {
            InitializeComponent();
        }

        private async void AddIn_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RegistrationName.Text)||string.IsNullOrEmpty(RegistrationPassword.Text))
            {
                await DisplayAlert("Attention!", "Vous devez remplir les champs ", "OK");

            }
            else 
            {
                trouve = false;
                List<User> Users = await App.UserRegistration.GetAllUserAsync();
                foreach(User user in Users)
                {

                    if (RegistrationName.Text == user.Name)
                    {
                        trouve = true;
                        
                    }
                    
                        
                }
                if (trouve == true)
                {
                    await DisplayAlert("Attention!", "cet utilisiteur existe dans la base", "OK");
                    statusMessage.Text = "";

                }
                else
                {
                    statusMessage.Text = "";
                    await App.UserRegistration.AddNewUserAsync(RegistrationName.Text, RegistrationPassword.Text);
                    statusMessage.Text = App.UserRegistration.StatusMessage;
                }
                
             }
            
        }

        private void Retour_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}