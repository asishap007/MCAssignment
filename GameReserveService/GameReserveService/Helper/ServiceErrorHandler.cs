using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;

namespace GameReserveService.ErrorHandler
{
    [DataContract]
    public class ServiceErrorHandler
    {
        /// <summary>
        /// Method to generate custom error handler.
        /// </summary>
        /// <param name="errorInfo"></param>
        /// <param name="errorDetails"></param>
        public ServiceErrorHandler(string errorInfo, string errorDetails)
        {
            ErrorInfo = errorInfo;
            ErrorDetails = errorDetails;
        }

        [DataMember]
        public string ErrorInfo { get; private set; }

        [DataMember]
        public string ErrorDetails { get; private set; }
    }
}