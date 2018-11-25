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

namespace CommunityPortal.MasterDetailHome
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddIncidentPage : ContentPage
    {
        private const string postIncidentUrl = "https://testapi01-vt5.conveyor.cloud/api/incident";
        private const string getMyListUrl = "https://testapi01-vt5.conveyor.cloud/api/incident/getMyIncidents";
        private HttpClient httpClient = new HttpClient();
        string today;

        public AddIncidentPage()
        {
            InitializeComponent();
            Title = "Add Incident";
            this.IsBusy = false;
            getMyIncidentsList();
        }

        async void dismissButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void save_Clicked(object sender, EventArgs e)
        {
            this.IsBusy = true;
            saveBtn.IsEnabled = false;
            if (validate())
            {
                addIncident();
            }
        }

        private bool validate()
        {
            if (string.IsNullOrEmpty(titleEntry.Text))
            {
                DisplayAlert("Error", "Please Enter Title!", "Ok");
                return false;
            }
            else if (string.IsNullOrEmpty(discriptionEntry.Text))
            {
                DisplayAlert("Error", "Please Enter Discription!", "Ok");
                return false;
            }
            else if (string.IsNullOrEmpty(addressEntry.Text))
            {
                DisplayAlert("Error", "Please Enter Address!", "Ok");
                return false;
            }
            else
            {
                return true;
            }
        }

        private async void addIncident()
        {
            today = DateTime.Today.ToString("dd/MM/yyyy");
            try
            {
                var incident = new Incident()
                {
                    title = titleEntry.Text,
                    date = today,
                    address = addressEntry.Text,
                    description = discriptionEntry.Text
                };
                var data = JsonConvert.SerializeObject(incident);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(postIncidentUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Success", "Incident added successfully!", "Ok");
                    this.IsBusy = false;
                    saveBtn.IsEnabled = true;

                    titleEntry.Text = "";
                    addressEntry.Text = "";
                    discriptionEntry.Text = "";
                }
                else
                {
                    this.IsBusy = false;
                    saveBtn.IsEnabled = true;
                }

            }
            catch (Exception e)
            {
                
                saveBtn.IsEnabled = true;
                Debug.WriteLine("" + e);
            }
        }
        private async void getMyIncidentsList()
        {
            try
            {
                string id = Application.Current.Properties["userId"].ToString();
                var user = new User()
                {
                    userId = Int32.Parse(id)
                };
                {
                    var data = JsonConvert.SerializeObject(user);
                    var content = new StringContent(data, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(postIncidentUrl,content);
                    Debug.Write(response);
                }
                
            }
            catch (Exception e)
            {
                Debug.WriteLine("" + e);
            }
            
         

        }
        
        
    }
}