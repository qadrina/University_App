using System;
using System.Collections.Generic;

namespace University_App.Shared.Models
{
    public partial class Student
    {
        public string Student_Id { get; set; } = null!;
        public string? Student_Name { get; set; }
        public DateTime? Birth_Date { get; set; }
        public string? Faculty_Id { get; set; }
        public string? Nationality { get; set; }
        public int ? Class_Year { get; set; }
    }
}
