using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDefinedDataType
{
    public class Student
    {
        private string _FirstName; 
        private string _LastName;
        private int _Roll; 
        private double _MarksSecured;
        public string FirstName 
        { 
            get
            {
                return _FirstName;
            } //getter for firstname
            set
            {
                _FirstName = value;
            } //setter for firstname
        }
        
        public string LastName
        {
            get { return _LastName; } //getter for lastname
            set { _LastName = value; } //setter for lastname
        }
        
        public int Roll 
        { 
            get { return _Roll; } //getter for rollnumber
            set { _Roll = value; } //setter for rollnumber
        }

       
        public double MarksSecured
        {
            get { return _MarksSecured; }//getter for marks secured
            set { _MarksSecured = value; } //setter for marks secured
        }
    }
}
