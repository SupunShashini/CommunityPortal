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
    public partial class HomePageDetail : ContentPage
    {
        public HomePageDetail()
        {
            InitializeComponent();
        }



        private void Homebtn_Clicked(object sender, EventArgs e)
        {
           App.Current.MainPage= new NavigationPage(new HomeBPage());
        }

        private void PrptyDbtn_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new PropertyBPage());
        }

        private void DashBbtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new DashboardBPage());
        }

        private void AccSbtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new AccountSBPage());
        }

        private void Incidentbtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new IncidentBPage());
        }

        private void MyLevybtnbtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new MyLevyBPage());
        }

        private void MyDocuments_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new MyDocumentsBPage());
        }

        private void CommAbtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new CommitteeABPage());
        }

    }
}