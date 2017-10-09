using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
namespace UnitTest
{
    [TestFixture]
    public class AnimalTest
    {
        [Test]
        public void GetTotalCountOfAnimalsByCategoryTestMethod()
        {
            GameReserveService.AnimalService animalService = new GameReserveService.AnimalService();
            var animals = animalService.GetTotalCountOfAnimalsByCategory("2017-10-05", "2017-10-10");
            NUnit.Framework.Assert.NotZero(animals.Count);
        }
        [Test]
        public void GetAllAnimalsTestMethod()
        {
            GameReserveService.AnimalService animalService = new GameReserveService.AnimalService();
            var animals = animalService.GetAllAnimals();
            NUnit.Framework.Assert.NotZero(animals.Count);
        }
    }
}
