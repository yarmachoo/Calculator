//using Microsoft.UI.Xaml.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1;
public static class Calculate
{
    public static string Solve(double num1, double num2, string mathOperator)
    {
        double result = 0.0;
        switch(mathOperator) 
        {
            case "+" :
                result = num1+num2;
                return result.ToString();
            case "-" :
                result = num1-num2;
                return result.ToString();
            case "*" :
                result = num1*num2;
                return result.ToString();
            case "/" :
                if (num2 == 0)
                    result = double.PositiveInfinity;
                result = num1/num2;
                return result.ToString();
            case "%" :
                result = num2 * num1 / 100;
                return result.ToString();
            

            default: break;
        }
        return result.ToString();
    }
    public static string UnaryOperator(double num1, string mathOperator) 
    {
        double result = 0.0;
        switch (mathOperator)
        {
            case "1/x":
                result = 1/num1;
                return result.ToString();
            case "x^2":
                result = Math.Pow(num1, 2);
                return result.ToString();
            case "(x)^(1/2)":
                result = Math.Sqrt(num1);
                return result.ToString();
            default: break;
        }
        return result.ToString();
    }
}
