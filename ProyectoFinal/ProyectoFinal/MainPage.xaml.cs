using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProyectoFinal.Models;
using Xamarin.Forms;

namespace ProyectoFinal
{
    public partial class MainPage : ContentPage
    {
        private string url = "https://9d5b-181-78-13-143.ngrok.io/api/products-list/";
        
        private HttpClient Client = new HttpClient();
        public MainPage()
        {
            InitializeComponent();
            
        }

        protected override async void OnAppearing()
        {
            string content = await Client.GetStringAsync(url);
            string categoryContent = await Client.GetStringAsync("https://9d5b-181-78-13-143.ngrok.io/api/categories/");

            IEnumerable<Category> categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(categoryContent);
            
            IEnumerable<Product> productList = JsonConvert.DeserializeObject<IEnumerable<Product>>(content);
            LVproducts.ItemsSource = new ObservableCollection<Product>(productList);
            base.OnAppearing();
        }
    }
}