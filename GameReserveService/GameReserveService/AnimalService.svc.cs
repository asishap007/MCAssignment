using GameReserveService.Models;
using GameReserveService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GameReserveService
{
    
    public class AnimalService : IAnimalService
    {
        /// <summary>
        /// Serive to add new animal and map a GPS device.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Animal AddAnimal(Animal request)
        {
           return AnimalRepository.AddNewAnimal(request);
        }

        /// <summary>
        /// Service to update animal details.
        /// </summary>
        /// <param name="animalDetails"></param>
        /// <returns></returns>
        public Animal UpdateAnimal(Animal animalDetails)
        {
            return AnimalRepository.UpdateAnimal(animalDetails);
        }
        /// <summary>
        /// Service to delete animal.
        /// </summary>
        /// <param name="animalId"></param>
        /// <returns></returns>
        public Animal DeleteCategory(string animalId)
        {
            return AnimalRepository.DeleteAnimal(animalId);
        }

        /// <summary>
        /// Get all animal details like category name , GPS device numer etc.
        /// </summary>
        /// <returns></returns>
        public List<Animal> GetAllAnimals()
        {
            return AnimalRepository.AnimalList();
        }

        /// <summary>
        /// Get the count of animals in each category for a particular time duration.
        /// </summary>
        /// <param name="endDate"></param>
        /// <param name="fromDate"></param>
        /// <returns></returns>
        public List<AnimalCategory> GetTotalCountOfAnimalsByCategory(string endDate, string fromDate)
        {
            return AnimalRepository.GetTotalCountOfAnimalsByCategory(endDate, fromDate);
        }
    }
}
