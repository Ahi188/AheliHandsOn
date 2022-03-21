using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace BO
{
    [MessageContract]
    public class StudentInfoResponse
    {
        [MessageHeader]
        public HeaderInfo Header { get; set; }
    }
}
