using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApplicationMVCDotNetFramework.BO
{
    public class ResultBO
    {
        private string _FirstName;
        private string _LastName;
        private string _Email;
        private int? _marks;
        private int _fullmarks;
        private int _userid;
        private IEnumerable<AnswerBO> answers;

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public int? Marks
        {
            get { return _marks; }
            set { _marks = value; }
        }
        public int Fullmarks
        {
            get { return _fullmarks; }
            set { _fullmarks = value; }
        }
        public IEnumerable<AnswerBO> Answers
        {
            get { return answers; }
            set { answers = value; }
        }
        public int UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }
    }
}