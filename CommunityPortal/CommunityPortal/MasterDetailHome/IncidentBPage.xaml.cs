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
	public partial class IncidentBPage : ContentPage
	{
		public IncidentBPage ()
		{
			InitializeComponent ();
            Title = "Incidents";
        }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new HomePageDetail());
        }

        async void AddIncident_Clicked(object sender, EventArgs e)
        {
            var disp = new AddIncidentPage();
            await Navigation.PushModalAsync(disp);
        }

      
    }
}