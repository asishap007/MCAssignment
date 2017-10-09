using GameReserveService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GameReserveService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGPSDeviceAllocationService" in both code and config file together.
    [ServiceContract]
    public interface IAnimalService
    {
        
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetAllAnimals")]
        List<Animal>GetAllAnimals();

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/AddAnimal")]
        Animal AddAnimal(Animal animalDetails);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/UpdateAnimal")]
        Animal UpdateAnimal(Animal animalDetails);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/DeleteAnimal/{animalId}")]
        Animal DeleteCategory(string animalId);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetTotalCountOfAnimalsByCategory/{endDate}/{fromDate}")]
        List<AnimalCategory> GetTotalCountOfAnimalsByCategory(string endDate, string fromDate);


        

    }
}
