using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinAndroidApp.Model;

namespace XamarinAndroidApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            
        }

        private async void Load()
        {
            var lab = await dataBase.Table<Results>().ToListAsync();
            //await Navigation.PushAsync(new LoginPage());
            ListView1.ItemsSource = lab;
        }

        SQLiteAsyncConnection dataBase;
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var databasePath = Path.Combine(basePath, "SQLite.db3");

            dataBase = new SQLiteAsyncConnection(databasePath);
            //await dataBase.Table(typeof(Results));
            var lab = await dataBase.Table<Results>().ToListAsync();
            Load();

        }


        //SQLiteAsyncConnection dataBase;
        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        //    var databasePath = Path.Combine(basePath, "SQLite.db3");

        //    dataBase = new SQLiteAsyncConnection(databasePath);
        //    await dataBase.CreateTableAsync(typeof(Results));
        //}



        //public async void LoadData()
        //{
        //    Login lg = new Login();

        //    var data = new
        //    {
        //        phleboMobileNumber = lg.number.Text,
        //        mpinCode =pin.Text
        //    };

        //    var RestURL = "https://tcdevapi.iworktech.net/v1api/Phlebotomists/phlebotomistLogin";
        //    HttpClient client = new HttpClient();
        //    string jsonData = JsonConvert.SerializeObject(data);
        //    client.BaseAddress = new Uri(RestURL);

        //    StringContent content1 = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //    client.DefaultRequestHeaders.Add("apptoken", "72f303a7-f1f0-45a0-ad2b-e6db29328b1a");
        //    //client.DefaultRequestHeaders.Add("usertoken", "51QA3gF4ZjnDsUL4q8g84t1QcTTlhCGiEdqBcbrIDULqSKHDjOVBY98XsOqXWbWKKQjHoedkt38tsUj9MylnsA5GXtcQQOopimk5IcihfGGessmP6lMs6unVvE30kPWWxMKf0M0zJZEPzUgKGokz9Q==");
        //    HttpResponseMessage response = await client.PostAsync(RestURL, content1);            
        //   var  result = await response.Content.ReadAsStringAsync();
        //       Response responseData = JsonConvert.DeserializeObject<Response>(result);

        //    if (responseData.Status == true)
        //    {
        //        //var user = UserInput.Text;
        //        // user is just a string
        //        //await dataBase.InsertAsync(responseData.Results);
        //        var lab = await dataBase.Table<Results>().ToListAsync();
        //        ListView1.ItemsSource = lab;
        //    }
        //    else
        //    {
        //        DisplayAlert("Result", responseData.Message, "OK");
        //    }

        //}

        //private void Button_Clicked(object sender, EventArgs e)
        //{
        //    LoadData();
        //}
    }


}