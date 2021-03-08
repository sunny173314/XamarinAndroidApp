using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinAndroidApp.Model;

namespace XamarinAndroidApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserProfile : ContentPage
    {
       

        public UserProfile()
        {
            InitializeComponent();
            LoadData();
            LabTestData.RefreshCommand=new Command(() => {
                LoadData();
                LabTestData.IsRefreshing = false;

            });

           
        }
        SQLiteAsyncConnection dataBase;
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var databasePath = Path.Combine(basePath, "SQLite.db3");

            dataBase = new SQLiteAsyncConnection(databasePath);
            await dataBase.CreateTableAsync(typeof(LabTestData));
        }

        public async void LoadData()
        {



            string myData = "{\"filter\": {\"labtestName\": [{\"labtestName\": \"Ada\"}]}}";
            //string data1 = "{\filter\":  {\"labtestName\": [{\"labtestName\": \"Ada\"}]}}";
            var RestURL = "https://tcdevapi.iworktech.net/v1api/LabTest/HSCLabTests";
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(RestURL);

            StringContent content1 = new StringContent(myData, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Add("apptoken", "72f303a7-f1f0-45a0-ad2b-e6db29328b1a");
            //client.DefaultRequestHeaders.Add("usertoken", "cZJqFMitFdVz5MOvRLT7baVTJa+yZffc5eVoU91OqkMYl6//cQmgIVkHOyRZ7rWTXi66WV4tMEuj+0oHIyPS6hBvPUY5/RJ7oWnTr4LuzlKU1H7Cp68za57O9AatAJJHiVPowlXwoPUohqe8Ad2u0A==");
            HttpResponseMessage response = await client.PostAsync(RestURL, content1);
            var result = await response.Content.ReadAsStringAsync();
            UserData responseData = JsonConvert.DeserializeObject<UserData>(result);
            var lab = await dataBase.Table<LabTestData>().ToListAsync();

            if (lab.Count == 0)
            {
                await dataBase.InsertAllAsync(responseData.Results.LabTestData);
                LabTestData.ItemsSource = lab;
            }
            else
            {
                //Get The Data From Database                
                LabTestData.ItemsSource = lab;                
            }
        }

    }
}