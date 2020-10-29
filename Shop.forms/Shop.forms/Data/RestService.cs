using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModernHttpClient;
using Newtonsoft.Json;

namespace Shop.forms.Data
{
    /// <summary>
    /// Clase reutilizable para consumo de servicios web
    /// </summary>
    public class RestService
    {
        private HttpClient _client;
        private Uri _UrlBase;


        public RestService(string uri)
        {
            _UrlBase = new Uri(uri);
            _client = new HttpClient(new NativeMessageHandler());
            _client.BaseAddress = _UrlBase;
        }
        /// <summary>
        /// Obtiene una lista de elementos especificados como T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<List<T>> GetDataAsync<T>(string uri) //"Api/products"
        {
            List<T> TData = null;
            try
            {
                var response = _client.GetAsync(uri).ConfigureAwait(false).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    TData = JsonConvert.DeserializeObject<List<T>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error {0}", ex.Message);
            }
            return TData;
        }
        /// <summary>
        /// Realiza el post al servidor mandando un objeto de tipo T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<string> PostDataAsync<T>(T data, string uri) 
        {
            var json = JsonConvert.SerializeObject(data);
            var Data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(uri, Data).ConfigureAwait(false);
            string content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return content;
            }
            Debug.WriteLine("Error al dar de alta el elemento {0}",content);
            return "";       
        }

        /// <summary>
        /// realiza put al servidor mandando un objeto de tipo T y un id en la URL
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Data"></param>
        /// <param name="uri"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<string> PutDataAsync<T>(T Data, string uri, int Id)
        {
            var json = JsonConvert.SerializeObject(Data);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(string.Concat(uri, "/", Id.ToString()),data);
            string content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return content;
            }
            Debug.WriteLine("Error al dar de modificar el elemento {0}", content);
            return "";
        }

        /// <summary>
        /// Elimina un objeto tomando como id el parametro id en la URL
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteDataAsync (string uri, int id)
        {
            var response = await _client.DeleteAsync(string.Concat(uri, "/", id.ToString()));
            if (!response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Error al eliminar el elemento {0}", await response.Content.ReadAsStringAsync());
            }
        }
    }
}
