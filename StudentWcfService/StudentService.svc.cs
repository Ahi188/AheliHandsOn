using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BO;
using DAL;

namespace StudentWcfService
{
    
    public class StudentService: IStudentService
    {
        private readonly StudentDAL _studentDAL;
        public StudentService()
        {
            _studentDAL = new StudentDAL();
        }
        public StudentInfoResponse CreateStudent(StudentInfoRequest request)
        {
            var response = _studentDAL.CreateStudent(request);
            return response;
        }
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        public string Welcome()
        {
            return "Welcome to WCF coding";
        }
        public StudentInfoResponse UpdateStudent(StudentInfoRequest request)
        {
            var response = _studentDAL.UpdateStudent(request);
            return response;
        }
        public StudentInfoResponse DeleteStudent(StudentInfoRequest request)
        {
            var response = _studentDAL.DeleteStudent(request);
            return response;
        }
    }
}
