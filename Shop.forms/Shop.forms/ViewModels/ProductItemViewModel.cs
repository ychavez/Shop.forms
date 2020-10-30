using Plugin.Media;
using Shop.forms.Data;
using Shop.forms.Models;
using Shop.forms.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Xamarin.Forms;

namespace Shop.forms.ViewModels
{
    public class ProductItemViewModel : BaseViewModel
    {


        private ImageSource _ImgSource;
        private Context _Context;
        public ImageSource ImgSource { get => _ImgSource; set => SetProperty(ref _ImgSource, value); }
        public Product Product { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand TakePicture { get; set; }
        public ICommand UploadPicture { get; set; }

        public ProductItemViewModel(Product product = null)
        {
            Product = product ?? new Product();
            _Context = new Context();
            SaveCommand = new Command(Save);
            DeleteCommand = new Command(Delete);
            TakePicture = new Command(takePicture);
        }
        private async void takePicture()
        {
            IsBusy = true;
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Camara no disponible", "La camara no esta disponible en este dispositivo", "OK");
                IsBusy = false;
                return;
            }
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Shop",
                Name = $"{Guid.NewGuid().ToString()}.jpg",
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small,
                SaveToAlbum = true
            });
            if (file == null)
            {
                IsBusy = false;
                return;
            }
            ImgSource = ImageSource.FromStream(() =>
            {
                using (var memoryStream = new MemoryStream())
                {
                    file.GetStream().CopyTo(memoryStream);
                    Product.Picture = memoryStream.ToArray();
                }
                var stream = file.GetStream();
                IsBusy = false;
                return stream;
            });
            IsBusy = false;
        }


        private async void Delete()
        {
            IsBusy = true;
            bool answer = await Application.Current.MainPage.DisplayAlert("Atencion", $"¿Estas seguro que quieres borrar el producto {Product.Name} ?", "Yes", "No");
            if (!answer)
                return;
            await _Context.DeleteProduct(Product);
            await Navigation.PopAsync();
            IsBusy = false;
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
