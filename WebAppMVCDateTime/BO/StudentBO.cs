using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMVCDateTime.BO
{
    public class StudentBO
    {
        private string _FirstName;
        private string _LastName;
        private int? _Roll;
        private decimal? _MarksSecured;
        private DateTime? _DOB;
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

        public int? Roll
        {
            get { return _Roll; } //getter for rollnumber
            set { _Roll = value; } //setter for rollnumber
        }


        public decimal? MarksSecured
        {
            get { return _MarksSecured; }//getter for marks secured
            set { _MarksSecured = value; } //setter for marks secured
        }
        public int Id { get; set; }
        public DateTime? DateOfBirth
        {
            get
            {

                return _DOB;
                
            }
            set
            {
                _DOB = value;

            } //dd-mm-yyyy
        }
        public string Branch { get; set; }
        public int? BranchId { get; set; }
    }

}