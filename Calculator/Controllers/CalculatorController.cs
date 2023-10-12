using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        public static CalculatorModel calculator = new CalculatorModel();
   
        public ActionResult Index()
        {
            return View(calculator);
        }

        /*[HttpPost]
        public ActionResult Index(CalculatorModel cal)
        {
            calculator.Number_1 = cal.Number_1;
            calculator.Number_2 = cal.Number_2;

            if (ModelState.IsValid)
            {
                calculator.Result = calculator.Number_1 + calculator.Number_2;
            }
            return View(calculator);
        }*/

        [HttpPost]
        public ActionResult Update(string dataValue)
        {
            if (calculator.IsOperator(dataValue))
            {
                if (calculator.current_number != String.Empty)
                {
                    calculator.calculation_stack.Push(calculator.current_number);
                    calculator.operator_stack.Push(dataValue);
                    calculator.Current_string = calculator.Current_string + " " + dataValue + " ";
                    calculator.current_number = string.Empty;
                }
                return Content(calculator.Current_string);
            }
            else if (calculator.IsEqual(dataValue))
            {
                if (calculator.current_number != String.Empty)
                {
                    calculator.calculation_stack.Push(calculator.current_number);
                    calculator.current_number = String.Empty;
                    calculator.Current_string = String.Empty;
                }
                calculator.CalculateResult();
                return Content(calculator.Result);
            }
            else if (calculator.IsClear(dataValue))
            {
                calculator.current_number= String.Empty;
                calculator.Result = String.Empty;
                calculator.Current_string = String.Empty;   
                calculator.operator_stack.Clear();
                calculator.calculation_stack.Clear();
                return Content(calculator.Current_string);
            }
            else
            {
                calculator.current_number += dataValue;
                calculator.Current_string += dataValue;
                return Content(calculator.Current_string);
            }
        }
    }
}