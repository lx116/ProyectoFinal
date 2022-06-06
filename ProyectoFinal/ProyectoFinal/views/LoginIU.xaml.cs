﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProyectoFinal.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginIU : ContentPage
    {
        private HttpClient Client = new HttpClient();
        public LoginIU()
        {
            InitializeComponent();
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            Login login = new Login
            {
                username = txt_user.Text,
                password = txt_pass.Text
            };
            Uri RequestUri = new Uri(App.GlobalUrl + "login/");

            string JsonSerilizer = JsonConvert.SerializeObject(login);
            var contentJson = new StringContent(JsonSerilizer, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(RequestUri, contentJson);

            
            if (response.StatusCode == HttpStatusCode.OK)
            {
                await Navigation.PushAsync(new MainPage());
            }
            
        }

        private async void Register_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterIU());
        }

        private void LoginG_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Iniciar con Google", "Iniciando sesion con Google...", "OK!");
        }

        private void LoginT_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Iniciar con Twitter", "Iniciando sesion con Twitter...", "OK!");
        }

        private void LoginF_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Iniciar con Facebook", "Iniciando sesion con Facebook...", "OK!");
        }
    }
}
