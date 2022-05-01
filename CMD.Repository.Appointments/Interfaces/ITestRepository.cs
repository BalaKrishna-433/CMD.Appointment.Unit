using CMD.Model.Appointments;
using System.Collections.Generic;

namespace CMD.Repository.Appointments.Interfaces
{
    public interface ITestRepository
    {
        TestReport AddTest(Test test, int appointmentId);
        TestReport DeleteTest(int appointmnetId, int testReportId);
        ICollection<Test> GetAllTests();
        ICollection<TestReport> GetRecommendedTests(int appointmentId);
        ICollection<TestReport> GetTestReports();
    }
}
