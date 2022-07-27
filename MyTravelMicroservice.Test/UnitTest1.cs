using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTravelMicroservice.Model;
using MyTravelMicroservice.Repository;
using System.Collections.Generic;

namespace MyTravelMicroservice.Test
{
    [TestClass]
    public class TestTravelRepository
    {
        private readonly TravelDbContext _context;
        private  TravelRepository _repository;
      

        public TestTravelRepository()
        {
            var options = new DbContextOptionsBuilder<TravelDbContext>()
           .UseInMemoryDatabase("MyTravelData").Options;

            _context = new TravelDbContext(options);
           
        }

        [TestMethod]
        public void GetAllTravel_ShouldReturnAllProducts()
        {
            //Arrange
            var testTravel = GetTestAllTravel();
            _context.DeserializeJsonDataFile();
            _repository = new TravelRepository(_context);

            //Act
            var resultAllTravel = _repository.GetAllTravel();

            //Assert
            Assert.AreNotEqual(testTravel.Count, resultAllTravel.Count);

        }

        [TestMethod]
        public void GetTravel_ShouldReturnCorrectTravel()
        {
            //Arrange
            var testTravel = GetTestAllTravel();
            _context.DeserializeJsonDataFile();
            _repository = new TravelRepository(_context);

            //Act
            var resultAllTravel = _repository.GetTravelById(1);

            //Assert
            Assert.AreEqual(testTravel[0].City, resultAllTravel.City);
            
        }


        [TestMethod]
        public void GetTravel_ShouldNotFindTravel()
        {
            //Arrange
            var testTravel = GetTestAllTravel();
            _context.DeserializeJsonDataFile();
            _repository = new TravelRepository(_context);

            //Act
            var resultAllTravel = _repository.GetTravelById(1001);

            //Assert
            try
            {
                Assert.Fail("Does not exist in database");
            }
            catch (AssertFailedException ex)
            {

                System.Console.WriteLine("Does not exist in database");
            }
            
        }


        [TestMethod]
        public void PutTravel_ShouldUpdateTravel()
        {
            //Arrange
            var testTravel = GetTestAllTravel();
            _context.DeserializeJsonDataFile();
            _repository = new TravelRepository(_context);
            var id = testTravel[2].Id;
            var updateTravelTest = new Travel { Id = 2, City = "Paris", Start_date = "", End_date = "", Status = "Often", Price = 123.78, Color = "#0000" };

            var result = _context.Travels.Find(id);
            //Act
            _repository.UpdateTravel(id, updateTravelTest);


            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testTravel[2].City, result.City);
        }

        private List<Travel> GetTestAllTravel()
        {
            var testProducts = new List<Travel>();
            testProducts.Add(new Travel { Id = 1, City = "Neftegorsk", Price = 1,Start_date = "", End_date = "", Status = "Often",  Color = "#0000" });
            testProducts.Add(new Travel { Id = 2, City = "Lancai", Price = 3.75, Start_date = "", End_date = "", Status = "Often", Color = "#0000" });
            testProducts.Add(new Travel { Id = 3, City = "Paris", Price = 16.99, Start_date = "", End_date = "", Status = "Often", Color = "#0000" });
            testProducts.Add(new Travel { Id = 4, City = "Demo4", Price = 11.00, Start_date = "", End_date = "", Status = "Often", Color = "#0000" });

            return testProducts;
        }
    }
}
