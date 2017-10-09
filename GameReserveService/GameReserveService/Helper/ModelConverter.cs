using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace GameReserveService.Helper
{
    public class ModelConverter
    {
        /// <summary>
        /// Helper method to deserialize the Json string to Object.
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static K DeSerializeObject<K>(string jsonString){
            var deserializedOutput = JsonConvert.DeserializeObject<K>(jsonString);
            return (K)Convert.ChangeType(deserializedOutput, typeof(K));
        }

    }
}