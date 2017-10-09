using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;

namespace GameReserveApp.Helper
{
    class RequestClient
    {
        public static string getRequest(string url)
        {

            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string json = reader.ReadToEnd();
            return json;
        }


        public static void postRequest(string url)
        {
            //var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://url");
            //httpWebRequest.ContentType = "application/json";
            //httpWebRequest.Method = "POST";

            //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            //{
            //    string json = new JavaScriptSerializer().Serialize(new
            //    {
            //        user = "Foo",
            //        password = "Baz"
            //    });

            //    streamWriter.Write(json);
            //}

            //var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            //{
            //    var result = streamReader.ReadToEnd();
            //}
        }
    }
}
