using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calculator.Models
{
    public class CalculatorModel
    {
        public string Result { get; set; }
        public string current_number { get; set; }
        public Stack<string> calculation_stack { get; set; }
        public Stack<string> operator_stack { get; set; }

        public string Current_string { get; set; }
        public CalculatorModel() {
            calculation_stack = new Stack<string>();
            operator_stack = new Stack<string>();   
            current_number = String.Empty;
            Result = String.Empty;
        }

        public bool IsOperator(string input)
        {
            if (input == "+" || input == "-" || input == "*" || input == "/")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsEqual(string input) 
        {
            if(input == "=")
            { 
                return true;
            }
            return false;
        }

        public bool IsClear(string input)
        {
            if (input == "C")
            {
                return true;
            }
            return false;
        }

        public void CalculateResult()
        {
            while (operator_stack.Count>0)
            {
                int number1 = Convert.ToInt32(this.calculation_stack.Pop());
                int number2 = Convert.ToInt32(this.calculation_stack.Pop());
                int result = 0;

                string operation = this.operator_stack.Pop();
                if (operation == "+")
                {
                    result = number2 + number1;
                    calculation_stack.Push(Convert.ToString(result));
                }
                else if (operation == "-")
                {
                    result = number2 - number1;
                    calculation_stack.Push(Convert.ToString(result));

                }
                else if (operation == "*")
                {
                    result = number2 * number1;
                    calculation_stack.Push(Convert.ToString(result));

                }
                else if (operation == "/")
                {
                    result = number2 / number1;
                    calculation_stack.Push(Convert.ToString(result));
                }
            }

            Result = calculation_stack.Peek();
        }
    }
}