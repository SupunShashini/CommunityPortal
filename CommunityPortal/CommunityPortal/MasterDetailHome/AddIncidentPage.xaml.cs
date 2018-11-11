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
	public partial class AddIncidentPage : ContentPage
	{
		public AddIncidentPage ()
		{
			InitializeComponent ();
            Title = "Add Incident";
           
        }

        async void dismissButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void save_Clicked(object sender, EventArgs e)
        {

        }
    }
}