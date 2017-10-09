using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameReserveApp
{
    class config
    {
        public const string categoryUri = "CategoryService.svc/GetAllCategories";
        public const string addCategoryUri = "CategoryService.svc/SaveCategory";
        public const string deleteCategoryUri = "CategoryService.svc/DeleteCategory";

        public const string animalUri = "AnimalService.svc/GetAllAnimals";
        public const string deleteAnimalUri = "AnimalService.svc/DeleteAnimal";
        public const string addAnimalUri = "AnimalService.svc/AddAnimal";
        public const string getTotalCount = "AnimalService.svc/GetTotalCountOfAnimalsByCategory";

        public const string trackingUri = "TrackingService.svc/GetLatestPositionOfAnimal";
        public const string addTrackingUri = "TrackingService.svc/AddTracking";

        public const string csvfilePath = "./CsvFile/File";
        public const string serverUrl = "http://localhost:50059/";
        public const double SALatitude = -30.5595;
        public const double SALongitude = 22.9375;

        public static readonly string[] CategoryColors = {
              "orange",
              "blue",
              "blue_small",
              "blue_pushpin",
              "brown_small",
              "gray_small",
              "green",
              "green_small",
              "green_dot",
              "green_pushpin",
              "green_big_go",
              "yellow",
              "yellow_small",
              "yellow_dot",
              "yellow_big_pause",
              "yellow_pushpin",
              "lightblue",
              "lightblue_dot",
              "lightblue_pushpin",
              "orange",
              "orange_small",
              "orange_dot",
              "pink",
              "pink_dot",
              "pink_pushpin",
              "purple",
              "purple_small",
              "purple_dot",
              "purple_pushpin",
              "red",
              "red_small",
              "red_dot",
              "red_pushpin",
              "red_big_stop",
              "black_small",
              "white_small",
              "arrow",
              "blue_dot",
        };
    }
}
