using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ForeignKey("ModuleAttended")]
        public int ModuleID { get; set; }
        [ForeignKey("StudentAttended")]
        public string StudentID { get; set; }
        [Required]
        public DateTime AttendanceDateTime { get; set; }
        public bool Present { get; set; }
        public virtual Module ModuleAttended { get; set; }
        public virtual Student StudentAttended { get; set; }
    }
}
