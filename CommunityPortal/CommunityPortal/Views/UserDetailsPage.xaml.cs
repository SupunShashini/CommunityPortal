using CommunityPortal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CommunityPortal.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserDetailsPage : ContentPage
	{
        private User user;
        private User receivedUser;
        private const string url = "https://testapi01-vt5.conveyor.cloud/api/user";
        private HttpClient httpClient = new HttpClient();

        public UserDetailsPage ()
		{
			InitializeComponent ();
            this.BindingContext = this;
            this.IsBusy = true;

            setValues();
		}

        private async void setValues()
        {
            if (Application.Current.Properties.ContainsKey("userId"))
            {
                var idStr = Convert.ToString(Application.Current.Properties["userId"]);
                user = new User() { userId = System.Convert.ToInt32(idStr) };
                Console.WriteLine("idddddddddd : " + user.userId.ToString());

                try
                {
                    var response = await httpClient.GetStringAsync(url + "/" + user.userId.ToString());
                    receivedUser = JsonConvert.DeserializeObject<User>(response);

                    nameLbl.Text = receivedUser.firstName + " " + receivedUser.lastName;
                    emailLbl.Text = "EMAIL : "+receivedUser.email;
                    usernameLbl.Text = "USERNAME : "+receivedUser.username;
                    phoneNumberLbl.Text = "PHONE NUMBER : "+receivedUser.phoneNumber;
                    addressLbl.Text = "ADDRESS : "+receivedUser.address;

                    this.IsBusy = false;
                }
                catch(Exception e)
                {
                    Debug.WriteLine("" + e);
                }

            }
            
        }

        private void editBtn_Clicked(object sender, EventArgs e)
        {

        }
    }
}