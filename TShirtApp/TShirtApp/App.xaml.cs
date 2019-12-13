using System;
using System.IO;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TShirtApp.data;

namespace TShirtApp
{
    public partial class App : Application
    {
        private static TShirtDatabase tshirtdatabase;
        public static TShirtDatabase Database
        {
            get
            {
                if (tshirtdatabase == null)
                {
                    tshirtdatabase = new TShirtDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return tshirtdatabase;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

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
