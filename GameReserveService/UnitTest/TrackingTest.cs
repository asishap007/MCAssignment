using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class TrackingTest
    {
        [Test]
        public void GetAllLocationOfAnimalTestMethod()
        {
            GameReserveService.TrackingService trackingService = new GameReserveService.TrackingService();
            var animalList = trackingService.GetLatestPositionOfAnimal();
            NUnit.Framework.Assert.NotZero(animalList.Count);
        }
    }
}
