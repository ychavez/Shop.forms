using Shop.forms.Models;
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
    public partial class ProductItemView : ContentPage
    {
        private ProductItemViewModel viewModel;
        public ProductItemView(Product product = null)
        {
            InitializeComponent();
            BindingContext = viewModel = new ProductItemViewModel(product) { Navigation = Navigation };
        }
    }
}