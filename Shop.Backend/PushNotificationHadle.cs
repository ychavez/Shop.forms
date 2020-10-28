using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;


namespace Shop.Backend
{
    public class PushNotificationHandle
    {
        public bool Successful { get; set; }

        public string Response { get; set; }
        public Exception Error { get; set; }

        public PushNotificationHandle SendNotification(string _title, string _message, string _topic)
        {
            PushNotificationHandle result = new PushNotificationHandle();
            try
            {
                result.Successful = true;
                result.Error = null;
                // var value = message;
                var requestUri = "https://fcm.googleapis.com/fcm/send";

                WebRequest webRequest = WebRequest.Create(requestUri);
                webRequest.Method = "POST";
                webRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAi03OdA8:APA91bHSzuXZwMLVcsn8qbITdF0_cnwRPkg9eneLuY8DoCtxpO7qEBt3b2cBJNdi1rR5PZsrBusGk5Y12enx9EUD1nSaABCgc0OqhHxX6wkT_M5HI-YY3sI9e-j1KceURJZnuH3YqtJl"));
                webRequest.Headers.Add(string.Format("Sender: id={0}", "598305829903"));
                webRequest.ContentType = "application/json";

                var data = new
                {
                    to = "fJQqW0xSSXylCu9KksrcEd:APA91bFygDyo2Q0Ns6M9sNqxgGwFk7p53KGEdRDbHaFniSNbwd1h4tkh0UXRz8ClPn9Y1XvUGfDhRSIrqe5hx_bYXGBaqAlHy64mSBQi8AHUHTmjuNycyqPPQdCBSBM00c753eR2-ghb", // Uncoment this if you want to test for single device
                    //to = "/topics/" + _topic,
                    notification = new
                    {
                        title = _title,
                        body = _message,
                        //icon="myicon"
                    },
                    priority = "high"
                };
                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);

                Byte[] byteArray = Encoding.UTF8.GetBytes(json);

                webRequest.ContentLength = byteArray.Length;
                using (Stream dataStream = webRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);

                    using (WebResponse webResponse = webRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = webResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                result.Response = sResponseFromServer;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                result.Successful = false;
                result.Response = null;
                result.Error = ex;
            }
            return result;
        }
    }
}
