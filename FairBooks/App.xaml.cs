using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FairBooks
{
    public partial class App : Application
    {
        private String dbPath = Path.Combine(FileSystem.AppDataDirectory, "fairBooks.db3");
        public static UserRegistration UserRegistration { get; private set; }

        public App()
        {
        InitializeComponent();
            UserRegistration = new UserRegistration(dbPath);


            MainPage = new NavigationPage(new Accueil());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
