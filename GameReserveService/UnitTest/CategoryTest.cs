using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
namespace UnitTest
{
    [TestFixture]
    public class CategoryTest
    {
        [Test]
        public void SingleCategoryTestMethod()
        {
            GameReserveService.CategoryService categories = new GameReserveService.CategoryService();
            GameReserveService.Category singleCategory = new GameReserveService.Category();
            singleCategory = categories.GetCategory("1");
            NUnit.Framework.Assert.IsTrue(categories.GetCategory("1").categoryName.Equals("Tiger"));
        }
        [Test]
        public void GetCategoryListTestMethod()
        {
            GameReserveService.CategoryService categories = new GameReserveService.CategoryService();
            var categoryList = categories.GetAllCategories();
            NUnit.Framework.Assert.NotZero(categoryList.Count);
        }
    }
}
