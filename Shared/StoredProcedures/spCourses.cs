using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_App.Shared.StoredProcedures
{
    public partial class spCourses
    {
        public string Course_Id { get; set; } = null!;
        public string? Course_Title { get; set; }
    }
}
