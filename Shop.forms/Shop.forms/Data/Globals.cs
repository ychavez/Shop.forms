using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.forms.Data
{
    public static class Globals
    {
        public const string ServiceBase = "https://productsapidw.azurewebsites.net/";
        public const string ProductsUri = "Api/Products";
        public const string LoginUri = "Api/Account/Login";
        public const string HelatyUrl = "healty/ok";
        public static string ApiToken { get; set; }
    }
}
