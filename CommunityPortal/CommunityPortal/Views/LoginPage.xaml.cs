using CommunityPortal.MasterDetailHome;
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

namespace CommunityPortal
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        private const string url = "https://testapi01-vt5.conveyor.cloud/api/user/authenticate";
        private HttpClient httpClient = new HttpClient();


        public LoginPage ()
		{
			InitializeComponent ();
            logo.Source = ImageSource.FromResource("CommunityPortal.Images.logo.png");
            this.BindingContext = this;
            this.IsBusy = false;
		}

        private void LoginBtn_Clicked(object sender, EventArgs e)
        {
            this.IsBusy = true;
            LoginBtn.IsEnabled = false;
            if (Validate())
            {
                ApiCall();
            }
            
        }

        private bool Validate()
        {
            if (string.IsNullOrEmpty(usernameEntry.Text))
            {
                DisplayAlert("Login", "Please Enter Uername!", "Ok");
                return false;
            }
            else if (string.IsNullOrEmpty(passwordEntry.Text))
            {
                DisplayAlert("Login", "Please Enter Password!", "Ok");
                return false;
            }
            else
            {
                return true;
            }          
        }

        private async void ApiCall()
        {
            try
            {
                var user = new User() { username = usernameEntry.Text, password = passwordEntry.Text };
                var data = JsonConvert.SerializeObject(user);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, content);
                var received = await response.Content.ReadAsStringAsync();
                User receivedUser = JsonConvert.DeserializeObject<User>(received);
                //Console.WriteLine("username : "+receivedUser.username);

                Application.Current.Properties["userId"]= receivedUser.userId.ToString();
                //Application.Current.Properties["username"] = receivedUser.username;
                //Application.Current.Properties["name"] = receivedUser.firstName + " " + receivedUser.lastName;
                //Application.Current.Properties["isLoggedIn"] = "true";

                //Console.WriteLine(receivedUser.firstName + " " + receivedUser.lastName + " "+receivedUser.username+" " +receivedUser.id+"  "+Application.Current.Properties["isLoggedIn"]);

                if (response.IsSuccessStatusCode)
                {
                    this.IsBusy = false;
                    LoginBtn.IsEnabled = true;
                    await Navigation.PushAsync(new HomePage(), true);
                }
                else
                {
                    await DisplayAlert("Login Failed", "Username or password is incorrect", "Ok");
                    this.IsBusy = false;
                    LoginBtn.IsEnabled = true;
                }
            }
            catch (Exception e) {
                Debug.WriteLine("" + e);
            }
            

            

        }

    }
}