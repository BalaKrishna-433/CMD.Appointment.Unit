using CMD.Business.Appointments.Interfaces;
using CMD.DTO.Appointments;
using CMD.Model.Appointments;
using CMD.Repository.Appointments.Implementations;
using CMD.Repository.Appointments.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMD.Business.Appointments.Implementations
{
    public class TestService : ITestService
    {
        private ITestRepository repo;

        public TestService()
        {
            this.repo = new TestRepository();
        }
        public TestReport AddTest(Test test, int appointmentId)
        {
            try
            {
                return repo.AddTest(test, appointmentId);
            }
            catch (Exception e)
            {
                throw new Exception("Invalid data" + e.Message);
            }
        }

        public ICollection<Test> GetAllTests()
        {
            return repo.GetAllTests();
        }

        public ICollection<Test> GetRecommendedTests(int appointmentId)
        {
            return repo.GetRecommendedTests(appointmentId).Select(t => t.Test).ToList();
        }

        public TestReport DeleteTest(int appointmentId, int testReportId)
        {

            return repo.DeleteTest(appointmentId, testReportId);

        }

        public ICollection<TestReportDTO> GetTestReports()
        {

            var testReports = repo.GetTestReports();
            return ToTestReportDTOList(testReports);
        }

        public ICollection<TestReportDTO> ToTestReportDTOList(ICollection<TestReport> testReports)
        {
            if (testReports == null)
            {
                return null;
            }
            List<TestReportDTO> testReportDTOs = new List<TestReportDTO>();
            foreach (TestReport report in testReports)
            {
                testReportDTOs.Add(ToTestReportDTO(report));
            }
            return testReportDTOs;
        }

        public TestReportDTO ToTestReportDTO(TestReport testReport)
        {
            if (testReport == null)
            {
                return null;
            }
            TestReportDTO testReportDTO = new TestReportDTO
            {
                Id = testReport.Id,
                TestId = testReport.TestId,
            };
            return testReportDTO;
        }
    }
}
