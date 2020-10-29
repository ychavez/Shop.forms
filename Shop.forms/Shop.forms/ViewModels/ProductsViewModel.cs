using Shop.forms.Data;
using Shop.forms.Models;
using Shop.forms.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Shop.forms.ViewModels
{
   public class ProductsViewModel:BaseViewModel
    {

        private Context _Context;


        public ProductsViewModel()
        {
            _Context = new Context();
            LoadProducts();
        }

        private ObservableCollection<Product> _Products;
        public ObservableCollection<Product> Products { get => _Products; set { SetProperty(ref _Products, value); } }
        public async void LoadProducts() 
        {
            IsBusy = true;
            Products = new ObservableCollection<Product>( await _Context.GetProducts());
            IsBusy = false;
        }

    }
}
