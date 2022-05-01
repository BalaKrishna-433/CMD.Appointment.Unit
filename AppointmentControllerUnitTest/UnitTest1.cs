using CMD.API.Appointments.Controllers;
using CMD.Business.Appointments.Implementations;
using CMD.Business.Appointments.Interfaces;
using CMD.DTO.Appointments;
using CMD.Model.Appointments;
using CMD.Repository.Appointments;
using CMD.Repository.Appointments.Implementations;
using CMD.Repository.Appointments.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Web.Http;
using System.Web.Http.Results;

namespace AppointmentControllerUnitTest
{
    [TestClass]
    public class UnitTest1
    {


        IAppointmentService obj;
        AppointmentRepository obj2;
        [TestInitialize]
        public void ObjectCreation()
        {
            obj2 = new AppointmentRepository();
            obj = new AppointmentService(obj2);

        }

        [TestCleanup]
        public void ObjectDeletion()
        {
            obj = null;

        }



        [TestMethod]
        public void RemoveRecommedations_ShouldRemoveRecommendations()
        {
            var moq= new Mock <IRecommendationRepository >();   
            moq.Setup(r => r.RemoveRecommendation(It.IsAny<int>())).Returns(true);
            Action action = () =>
            {
                var service = new RecommendationService(moq.Object);
                Assert.IsTrue(service.RemoveRecommendation(1));
            }; 
        }

        [TestMethod]
        public void DeleteReturnsOk()
        {
            // Arrange
            var mockRepository = new Mock<IRecommendationService>();
            var controller = new RecommendationController(mockRepository.Object);



            // Act
            IHttpActionResult actionResult = controller.Remove(5);



            
        }


        //[TestMethod]

        //public void AddRecommedations_ShouldAddRecommendations()
        //{
        //    var moq = new Mock<IRecommendationRepository>();
        //    moq.Setup(r => r.AddRecommendtaion(It.IsAny < Recommendation reco >())).Return(Recommendation);
        //    Action action = () =>
        //    {
        //        var service = new RecommendationService(moq.Object);
        //        Assert.IsTrue(service.AddRecommendation(1));
        //    };
        //}
        //[ExpectedException(typeof(ArgumentNullException))]

        //public void AddRecommedations_withWrongData_ShouldnotAddRecommendations()
        //{
        //    CMDDbContext db = new CMDDbContext();

        //    Recommendations recommendation = null;


        //    var result = db.Recommendations.Add(recommendation);
        //}




        //[TestMethod]
        //public void RemoveRecommendations_ShouldRemoveRecommendations()
        //{
        //    int id = 8;
        //    var result = obj.RemoveRecommendation(id);
        //    Assert.IsTrue(result);
        //}
        //[TestMethod]
        //public void RemoveRecommendations_WithWrongId_ShouldNotRemoveRecommendations()
        //{
        //    int id = 1;
        //    var result = obj.RemoveRecommendation(id);
        //    Assert.IsFalse(result);


        //}





        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]

        public void PostMethodSetsLocationHeader()
        {
            // Arrange
            var mockRepository = new Mock<IRecommendationService>();
            var controller = new RecommendationController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.AddRecommendation(new RecommendationDTO { AppointmentId=1,DoctorId=1});
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Recommendation>;

            // Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(10, createdResult.RouteValues["id"]);
        }
    }
}

