using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreEFW.BO
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
            public String DateOfBirth
            {
                get
                {
                    if (_DOB == null)
                        return string.Empty;
                    return _DOB.Value.ToString("dd-mm-yyyy");
                }
                set
                {
                    _DOB = Convert.ToDateTime(value);

                } //dd-mm-yyyy
            }
            public string Branch { get; set; }
        }
    }
