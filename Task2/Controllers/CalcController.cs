using Microsoft.AspNetCore.Mvc;

namespace Task2.Controllers
{
    public class CalcController : Controller
    {

        // Calc/Calc/add/5/6
        // Calc/mul/6/7
        // Calc/div/8/4
        // Calc/sub/8/3
        public IActionResult Calc(string operand, double x, double y)
        {
            double result;

            switch (operand.ToLower())
            {
                case "add":
                    result = x + y;
                    break;
                case "mul":
                    result = x * y;
                    break;
                case "div":
                    result = x / y;
                    break;
                case "sub":
                    result = x - y;
                    break;
                default:
                    return BadRequest("Invalid operation.");
            }

            return View(result);
        }
    }
}
