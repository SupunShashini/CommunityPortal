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
	public partial class CommitteeABPage : ContentPage
	{
		public CommitteeABPage ()
		{
			InitializeComponent ();
            Title = "Committee Area";
		}

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new HomePageDetail());
        }
    }
}