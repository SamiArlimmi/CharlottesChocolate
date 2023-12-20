using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChocolateLibrary;
namespace EasterEggRepositoryTests.cs
{
    [TestClass]
    public class EasterEggRepositoryTests
    {
        private EasterEggRepository repository;

        [TestInitialize]
        public void Setup()
        {
            // Initialiser repository
            repository = new EasterEggRepository();
        }

        //GET Test metode
        [TestMethod]
        public void TestGet()
        {
            List<EasterEgg> eggs = repository.Get();

            Assert.IsNotNull(eggs);
            Assert.AreEqual(7, eggs.Count);
        }

        //Hvis productno allerede eksistere
        [TestMethod]
        public void TestGetByProductNo_Existing()
        {
            int existingProductNo = 1;

            EasterEgg egg = repository.GetByProductNo(existingProductNo);

            Assert.IsNotNull(egg);
            Assert.AreEqual(existingProductNo, egg.ProductNo);
        }

        //Hvis productno ikke eksitere
        [TestMethod]
        public void TestGetByProductNo_NonExisting()
        {
            int nonExistingProductNo = 1;

            EasterEgg egg = repository.GetByProductNo(nonExistingProductNo);
        }

        //Test LowStock
        [TestMethod]
        public void TestGetLowStock()
        {
            int lowStock = 1;

            repository.GetLowStock(lowStock);
        }

        //Test Update metode 
        [TestMethod]
        public void TestUpdate()
        {
            int existingProductNo = 1;
            string updatedChocolateType = "Updated Chocolate";
            int updatedPrice = 9;
            int updatedInStock = 20;

            EasterEgg EggUpdated = new EasterEgg(existingProductNo, updatedChocolateType, updatedPrice, updatedInStock);
            repository.Update(EggUpdated);
            EasterEgg EggRetrived = repository.GetByProductNo(existingProductNo);

            Assert.IsNotNull(EggRetrived);
            Assert.AreEqual(EggUpdated.ProductNo, EggRetrived.ProductNo);
            Assert.AreEqual(EggUpdated.ChocolateType, EggRetrived.ChocolateType);
            Assert.AreEqual(EggUpdated.Price, EggRetrived.Price);
            Assert.AreEqual(EggUpdated.InStock, EggRetrived.InStock);
        }
    }
}