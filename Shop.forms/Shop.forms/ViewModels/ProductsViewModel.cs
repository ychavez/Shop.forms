using Shop.forms.Data;
using Shop.forms.Models;
using Shop.forms.ViewModels.Base;
using Shop.forms.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Shop.forms.ViewModels
{
   public class ProductsViewModel:BaseViewModel
    {

        private Context _Context;
        private ObservableCollection<Product> _Products;
        public ProductsViewModel()
        {
            _Context = new Context(Globals.ApiToken);
            LoadProducts();
            Refresh = new Command(LoadProducts);
        }
        public ICommand Refresh { get; set; }
        public ICommand AddCommand { get; set; }
        public ObservableCollection<Product> Products { get => _Products; set { SetProperty(ref _Products, value); } }
        public async void LoadProducts() 
        {
            IsBusy = true;
            Products = new ObservableCollection<Product>( await _Context.GetProducts());
            AddCommand = new Command(Add);
            IsBusy = false;
        }
        private void Add() => Navigation.PushAsync(new ProductItemView());
    }
}
