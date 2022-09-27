using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_App.Shared.StoredProcedures
{
    public partial class spFaculty
    {
        public string? Faculty_Id { get; set; }
        public string? Faculty_Title { get; set; }
        public string? Dean_Id { get; set; }
        public string? Dean_Name { get; set; }
    }
}
