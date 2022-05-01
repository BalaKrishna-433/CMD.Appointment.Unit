using CMD.Model.Appointments;
using CMD.Repository.Appointments.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CMD.Repository.Appointments.Implementations
{
    public class TestRepository : ITestRepository
    {
        private CMDContext db;
        public TestRepository()
        {
            this.db = new CMDContext();
        }

        public TestReport AddTest(Test test, int appointmentId)
        {
            var tr = db.TestReports.Add(new TestReport());
            tr.TestId = test.Id;
            var appointment = db.Appointments.Where(p => p.Id == appointmentId).FirstOrDefault();
            appointment.TestReports.Add(tr);
            db.SaveChanges();
            return tr;
        }


        public TestReport DeleteTest(int appointmnetId, int testReportId)
        {

            var appointment = db.Appointments.Find(appointmnetId);
            if (appointment == null)
            {
                return null;
            }
            var result = db.TestReports.Find(testReportId);
            if (result == null)
            {
                return null;
            }
            db.TestReports.Remove(result);
            db.SaveChanges();
            return result;

        }

        public ICollection<Test> GetAllTests()
        {
            return db.Tests.ToList();
        }

        public ICollection<TestReport> GetRecommendedTests(int appointmentId)
        {
            var testReports = db.Appointments.Where(a => a.Id == appointmentId)
                .SelectMany(t => t.TestReports).Include(t => t.Test)
                .ToList();
            return testReports;
        }

        public ICollection<TestReport> GetTestReports()
        {
            var testreports = db.TestReports.ToList();
            return testreports;
        }
    }
}
