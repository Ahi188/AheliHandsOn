using System;
using System.Collections.Generic;

namespace ConsoleAppEFWDNC.DB
{
    public partial class Branch
    {
        public Branch()
        {
            Student1 = new HashSet<Student1>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Student1> Student1 { get; set; }
    }
}
