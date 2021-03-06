using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    [DataContract]
    public class StudentBO
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }


        [DataMember(Order = 2, IsRequired = true, Name = "FirstName")]
        public string First_name { get; set; }

        [DataMember(Order = 3, IsRequired = true, Name = "LastName")]
        public string Last_name { get; set; }

        [DataMember(Order = 4, IsRequired = true)]
        public int? Roll_number { get; set; }

        [DataMember(Order = 5)]
        public decimal? Marks { get; set; }

        public int? BranchId { get; set; }
        public string BranchName { get; set; }

    }
}

