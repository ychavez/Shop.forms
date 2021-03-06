﻿using Shop.forms.Models;
using Shop.forms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Shop.forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProducstList : ContentPage
    {
        private ProductsViewModel viewModel;
        public ProducstList()
        {
            InitializeComponent();
            BindingContext = viewModel = new ProductsViewModel() { Navigation = Navigation };
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadProducts();
        }

        private async void ProductList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (!(e.Item is Product item))
                return;
            await Navigation.PushAsync(new ProductItemView(item));
            ListProduct.SelectedItem = null;
        }
    }
}