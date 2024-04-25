using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassionateApps.MathExpressionEvaluator
{
    internal class App
    {
         public static void Run(string[] args) {
            while (true)
            {
                Console.Title = "Math Expression Evaluator";
                Console.Write("Enter The Expression:");
                var input = Console.ReadLine();
                var expr = ExpressionParser.Parse(input);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Left Side = {expr.LeftSideOperand} , Operation = {expr.Operation} , Right side {expr.RightSideOperand}");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Your Expression: {input} == {EvaluateExpression(expr)}");
                Console.ForegroundColor = ConsoleColor.White;


            }
            
        }

        public static object EvaluateExpression(MathExpression expr)
        {
            if (expr.Operation == MathOperation.Addition)
                return expr.LeftSideOperand + expr.RightSideOperand;

            if (expr.Operation == MathOperation.Subtraction)
                return expr.LeftSideOperand - expr.RightSideOperand;

            if (expr.Operation == MathOperation.Multiplication)
                return expr.LeftSideOperand * expr.RightSideOperand;

            if (expr.Operation == MathOperation.Division)
                return expr.LeftSideOperand / expr.RightSideOperand;

            if (expr.Operation == MathOperation.Modulus)
                return expr.LeftSideOperand % expr.RightSideOperand;

            if (expr.Operation == MathOperation.Power)
                return Math.Pow(expr.LeftSideOperand, expr.RightSideOperand);

            if (expr.Operation == MathOperation.Sin)
                return Math.Sin(expr.RightSideOperand);

            if (expr.Operation == MathOperation.Cos)
                return Math.Cos(expr.RightSideOperand);

            if (expr.Operation == MathOperation.Tan)
                return Math.Tan(expr.RightSideOperand);

            else
                return 0;
        }
    }

    
}
