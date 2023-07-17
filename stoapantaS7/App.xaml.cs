﻿using stoapantaS7.vistas;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace stoapantaS7
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
