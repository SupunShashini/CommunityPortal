using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CommunityPortal.MasterDetailHome
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PropertyBPage : ContentPage
	{
        public PropertyBPage()
        {
            InitializeComponent();
            Title = "Property Details";
           
            Button button = new Button
            {
                Text = "Back",
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };

            button.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new HomePageDetail());
            };

            Content = button;

        }
        private void GoBack_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new HomePageDetail());
        }


    }
}