namespace CMD.Repository.Appointments.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CMD.Repository.Appointments.CMDContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CMD.Repository.Appointments.CMDContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Medicines.AddOrUpdate
            (
                x => x.Name,
                new Model.Appointments.Medicine()
                {
                    Name = "Vicodin"
                },
                new Model.Appointments.Medicine()
                {
                    Name = "Albuterol"
                },
                new Model.Appointments.Medicine()
                {
                    Name = "Lisinopril"
                },
                new Model.Appointments.Medicine()
                {
                    Name = "Levothyroxine"
                },
                new Model.Appointments.Medicine()
                {
                    Name = "Gabapentin"
                },
                new Model.Appointments.Medicine()
                {
                    Name = "Metformin"
                },
                new Model.Appointments.Medicine()
                {
                    Name = "Lipitor"
                },
                new Model.Appointments.Medicine()
                {
                    Name = "Amlodipine"
                },
                new Model.Appointments.Medicine()
                {
                    Name = "Omeprazole"
                },
                new Model.Appointments.Medicine()
                {
                    Name = "Losartan"
                }

            );
            context.Tests.AddOrUpdate
            (
                x => x.Name,
                new Model.Appointments.Test()
                {
                    Name = "Blood Sugar"
                },
                new Model.Appointments.Test()
                {
                    Name = "Bone Density"
                },
                new Model.Appointments.Test()
                {
                    Name = "Calcium Test"
                },
                new Model.Appointments.Test()
                {
                    Name = "Cholesterol"
                },
                new Model.Appointments.Test()
                {
                    Name = "Creatinine"
                },
                new Model.Appointments.Test()
                {
                    Name = "CT Scan"
                },
                new Model.Appointments.Test()
                {
                    Name = "ECG"
                },
                new Model.Appointments.Test()
                {
                    Name = "ESR (Erythrocyte Sedimentation Rate)"
                },
                new Model.Appointments.Test()
                {
                    Name = "Hemoglobin (Hb)"
                },
                new Model.Appointments.Test()
                {
                    Name = "Hepatitis A "
                },
                new Model.Appointments.Test()
                {
                    Name = "Insulin"
                }
            );

            context.Questions.AddOrUpdate
            (
                x => x.Statement,
                new Model.Appointments.Question()
                {
                    Statement = "How did you find the experience of booking appointments?"
                },
                new Model.Appointments.Question()
                {
                    Statement = "How long did you have to wait until the doctor attends to you?"
                },
                new Model.Appointments.Question()
                {
                    Statement = "Were you satisfied with the doctor you were allocated with? "
                },
                new Model.Appointments.Question()
                {
                    Statement = "How easy is it to navigate our facility?"
                }
            );
        }
    }
}
