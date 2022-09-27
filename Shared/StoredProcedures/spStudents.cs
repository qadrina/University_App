using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_App.Shared.StoredProcedures
{
    public partial class spStudents
    {
        public string Student_Id { get; set; } = null!;
        public string? Student_Name { get; set; }
        public DateTime? Birth_Date { get; set; }
        public string? Faculty_Id { get; set; }
    }
}
