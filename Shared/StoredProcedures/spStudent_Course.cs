using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_App.Shared.StoredProcedures
{
    public partial class spStudent_Course
    {
        public string Student_Id { get; set; } = null!;
        public string? Student_Name { get; set; }
        public string Course_Id { get; set; } = null!;
        public string? Course_Title { get; set; }
    }
}
