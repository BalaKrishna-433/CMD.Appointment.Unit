using CMD.Business.Appointments.Interfaces;
using CMD.DTO.Appointments;
using CMD.Model.Appointments;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace CMD.API.Appointments.Controllers
{
    public class TestController : ApiController
    {
        protected ITestService manager;
        public TestController(ITestService manager)
        {
            this.manager = manager;
        }

        [Route("AddTest/{appointmnetId}")]
        [HttpPost]
        [ResponseType(typeof(TestReport))]
        public IHttpActionResult AddTest(int appointmnetId, Test test)
        {
            if (test == null)
                return BadRequest("Invalid input");
            if (appointmnetId < 0)
            {
                return BadRequest("Invalid input");
            }
            var testReport = manager.AddTest(test, appointmnetId);

            return Ok(testReport);
        }

        [HttpGet]
        [Route("GetTest")]
        [ResponseType(typeof(ICollection<Test>))]
        public IHttpActionResult GetTests()
        {
            var tests = manager.GetAllTests();
            return Ok(tests);
        }

        [Route("GetRecommendedTest/{appointmentId}")]
        [HttpGet]
        [ResponseType(typeof(ICollection<Test>))]
        public IHttpActionResult GetRecommendedTest(int appointmentId)
        {
            var tests = manager.GetRecommendedTests(appointmentId);
            return Ok(tests);
        }

        [Route("RemoveTest/testReportid/{testReportId}/appointmentid/{appointmentId}")]
        [HttpDelete]
        [ResponseType(typeof(TestReport))]
        public IHttpActionResult RemoveTest(int testReportId, int appointmentId)
        {
            var result = manager.DeleteTest(appointmentId, testReportId);
            return Ok(result);
        }

        [Route("GetTestReports")]
        [HttpGet]
        [ResponseType(typeof(ICollection<TestReportDTO>))]
        public IHttpActionResult GetTestReports()
        {
            var testReport = manager.GetTestReports();
            return Ok(testReport);
        }
    }
}
