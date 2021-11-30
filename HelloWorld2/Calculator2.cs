using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld2
{
    
    public class Calculator2

    {
        private int _number1;
        private int _number2;

        public int Number1
        {
            get
            {
                return _number1;
            }
            set
            {
                _number1 = value;
            }
        }
        public int Number2 
        { 
            get
            {
                return _number2;
            }
            set
            {
                _number2 = value;
            }
        }
        public Calculator2()
        {
            _number1 = 10;
            _number2 = 20;
        }
        public Calculator2(int num1, int num2)
        {
            _number1 = num1;
            _number2 = num2;
        }

        public int Add()
        {
            //_number1 = 1;
            return _number1 + _number2;
        }

        public int Subtract()
        {
            return _number2 - _number1;
        }
    }
}
