using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TShirtApp.models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TShirtApp.data;

namespace TShirtApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : ContentPage
    {
        public OrderPage()
        {
            InitializeComponent();
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            //  BindingContext = new TShirtDetails();
            var shirtItem = BindingContext as TShirtDetails;
           // var shirtItem = (TShirtDetails)BindingContext;
            App.Database.UpdateProduct(shirtItem);
            
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            var shirtItem = (TShirtDetails)BindingContext;
            await App.Database.DeleteTShirtAsync(shirtItem);
            await Navigation.PopModalAsync();
        }

        private async void ViewInfo_Clicked(object sender, EventArgs e)
        {
            // var  latestProduct = await App.Database.GetItemAsync();
            BindingContext = new TShirtDetails();



        }
    }
}