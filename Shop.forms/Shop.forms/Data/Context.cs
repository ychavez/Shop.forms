﻿using Shop.forms.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.forms.Data
{
    public class Context
    {
        private RestService _RestService;
        public Context() => _RestService = new RestService(Globals.ServiceBase);
        public Context(string token) => _RestService = new RestService(Globals.ServiceBase, token); 
        public async Task<List<Product>> GetProducts() => await _RestService.GetDataAsync<Product>(Globals.ProductsUri);
        public async Task AddProduct(Product product) =>  await _RestService.PostDataAsync<Product>(product, Globals.ProductsUri);
        public async Task UpdateProduct(Product product)
        {
            if (product.Id != 0)
                await _RestService.PutDataAsync<Product>(product, Globals.ProductsUri, product.Id);
        }
        public async Task DeleteProduct(Product product) => await _RestService.DeleteDataAsync(Globals.ProductsUri, product.Id);
        public async Task<string> Login(Login user) => await _RestService.PostDataAsync<Login>(user,Globals.LoginUri);
        public bool CheckToken(string token) => _RestService.CheckToken(token);

        public bool ChechService() => _RestService.CheckService();
    }
}
