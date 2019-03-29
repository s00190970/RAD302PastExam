using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Models
{
    public class ModelInitializer : DropCreateDatabaseIfModelChanges<ModelContext>
    {
        protected override void Seed(ModelContext context)
        {
            context.Attendances.AddRange(new List<Attendance>()
            {
                new Attendance
                {
                    AttendanceDateTime = DateTime.Now.AddHours(-1),
                    ModuleAttended = new Module
                    {
                        ModuleName = "RAD"
                    },
                    StudentAttended = new Student
                    {
                        StudentID = "S00123",
                        FirstName = "Cristian",
                        LastName = "Beckert"
                    },
                    Present = true
                }, new Attendance
                {
                    AttendanceDateTime = DateTime.Now.AddHours(-2),
                    ModuleAttended = new Module
                    {
                        ModuleName = "Database"
                    },
                    StudentAttended = new Student
                    {
                        StudentID = "S00345",
                        FirstName = "Cristina",
                        LastName = "Mihaila"
                    },
                    Present = false
                }
            });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}