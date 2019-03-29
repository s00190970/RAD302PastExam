using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ModelContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        public ModelContext() : base("RAD302PastExam")
        {
            Database.SetInitializer(new ModelInitializer());
            Database.Initialize(true);
        }
    }
}
