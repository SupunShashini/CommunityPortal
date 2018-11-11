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
	public partial class MyLevyBPage : ContentPage
	{
		public MyLevyBPage ()
		{
			InitializeComponent ();
            Title = "My Lavy";
            
        }
        

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new HomePageDetail());
        }
    }
}