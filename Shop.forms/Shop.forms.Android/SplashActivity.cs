﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Shop.forms.Droid
{
    [Activity(Label = "Tienda", MainLauncher = true, Theme = "@style/SplashTheme")]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }

        protected override void OnResume()
        {
            base.OnResume();
            Task startup = new Task(StartUp);
            startup.Start();
        }


        async void StartUp()
        {
            await Task.Delay(2000);
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));

        }

    }
}