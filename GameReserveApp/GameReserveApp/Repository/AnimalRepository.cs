using GameReserveApp.Helper;
using GameReserveApp.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameReserveApp.Repository
{
    class AnimalRepository
    {
        public static AnimalView[] GetAllAnimals()
        {
            string animalurl = config.serverUrl + config.animalUri;
            string animalListInJson = RequestClient.getRequest(animalurl);
            AnimalView[] allAnimals =  JObject.Parse(animalListInJson)["GetAllAnimalsResult"].ToObject<AnimalView[]>();
            return allAnimals;
        }

        public static AnimalView DeleteAnimal(int animalId)
        {
            string animalurl = config.serverUrl + config.deleteAnimalUri + "/" + animalId.ToString();
            string deleteAnimalInJson = RequestClient.getRequest(animalurl);
            AnimalView deletedAnimal = JsonConvert.DeserializeObject<AnimalView>(deleteAnimalInJson);
            return deletedAnimal;
        }

        public static AnimalView AddAnimal(AnimalView animal)
        {
            string animalurl = config.serverUrl + config.addAnimalUri;
            string postData = JsonConvert.SerializeObject(animal);
            string addAnimalInJson = RequestClient.postRequest(animalurl,postData);
            AnimalView addAnimal = JsonConvert.DeserializeObject<AnimalView>(addAnimalInJson);
            return addAnimal;
        }

        public static AnimalView[] GetTotalCountOfAnimalsByCategory(string startDate, string endDate)
        {
            string animalurl = config.serverUrl + config.getTotalCount + '/' + endDate + '/' + startDate;
            string animalListInJson = RequestClient.getRequest(animalurl);
            AnimalView[] allAnimals = JObject.Parse(animalListInJson)["GetTotalCountOfAnimalsByCategoryResult"].ToObject<AnimalView[]>();
            return allAnimals;
        }


    }
}
