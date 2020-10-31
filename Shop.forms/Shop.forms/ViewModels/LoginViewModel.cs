using Shop.forms.Data;
using Shop.forms.Models;
using Shop.forms.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Shop.forms.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        private Context _Context;
        public Login User { get; set; }
        public ICommand Login { get; set; }

        public LoginViewModel()
        {
            User = new Login();
            _Context = new Context();
            Login = new Command(login);
        }
        private async void login()
        {
            IsBusy = true;
           // string Token = await _Context.Login(User);
            //if (Token == "")
            //{
            //    await Application.Current.MainPage.DisplayAlert("Datos no validos", "Usuario no valido, intente de nuevo", "OK");
            //    User = new Login();
            //    IsBusy = false;
            //    return;
            //}
           /// Application.Current.Properties["token"] = Token;
           // Globals.ServiceApiKey = Token;
            await Application.Current.SavePropertiesAsync();
            Application.Current.MainPage = new MainPage();
            IsBusy = false;
        }
    }
}
