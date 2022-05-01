using CMD.Model.Appointments;
using System.Data.Entity;

namespace CMD.Repository.Appointments
{
    public class CMDContext : DbContext
    {
        // Your context has been configured to use a 'CMDContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CMD.Repository.Appointments.CMDContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CMDContext' 
        // connection string in the application configuration file.
        public CMDContext()
            : base("name=DefaultConnection")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Recommendation> Recommendations { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<Vital> Vitals { get; set; }
        public virtual DbSet<TestReport> TestReports { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
       
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}