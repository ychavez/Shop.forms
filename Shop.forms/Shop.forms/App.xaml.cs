using Shop.forms.Data;
using Shop.forms.Views;
using System;
using Xamarin.Forms;


namespace Shop.forms
{
    public partial class App : Application
    {
       private Context _Context;
        public App()
        {
            InitializeComponent();

                _Context = new Context();
            if (!_Context.ChechService())
            {
                MainPage = new MainPage();
                return;
            }

            if (Xamarin.Forms.Application.Current.Properties.ContainsKey("token"))
            {
                string Token = Xamarin.Forms.Application.Current.Properties["token"].ToString();
                if (_Context.CheckToken(Token))
                {
                    Globals.ApiToken = Xamarin.Forms.Application.Current.Properties["token"].ToString();
                    MainPage = new NavigationPage(new ProducstList());
                    return;
                }
            }
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
