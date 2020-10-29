using Shop.forms.Data;
using Shop.forms.Models;
using Shop.forms.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Xamarin.Forms;

namespace Shop.forms.ViewModels
{
    public class ProductItemViewModel : BaseViewModel
    {
        private Context _Context;
        public Product Product { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ProductItemViewModel(Product product = null)
        {
            Product = product ?? new Product();
            _Context = new Context();
            SaveCommand = new Command(Save);
        }

        private async void Save()
        {
            IsBusy = true;
            if (Product.Id == 0)
            {
                await _Context.AddProduct(Product);
            }
            else
            {
                await _Context.UpdateProduct(Product);
            }
            IsBusy = false;
            await Navigation.PopAsync();
        }

    }
}
