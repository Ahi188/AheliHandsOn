using System;
using System.Collections.Generic;

namespace ConsoleAppEFWDNC.DB
{
    public partial class Student1
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? RollNumber { get; set; }
        public decimal? Marks { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? BranchId { get; set; }

        public virtual Branch? Branch { get; set; }
    }
}
