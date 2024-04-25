using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassionateApps.MathExpressionEvaluator
{
    internal class ExpressionParser
    {
        private const string MathSymbols = "+*^%/";
        public static MathExpression Parse(string input)
        {
            input = input.Trim();
            var expr  = new MathExpression();
            string token = "";
            bool LeftSideIntialed = false;

            for(int i = 0; i < input.Length; i++)
            {
                var CurChar = input[i];
                if (Char.IsDigit(CurChar))
                {
                    token += CurChar;
                  
                    if(i==input.Length-1 && LeftSideIntialed)//reach last letter
                    {
                        expr.RightSideOperand = double.Parse(token);
                        break;
                    }
                }
                else if (MathSymbols.Contains(CurChar))
                {
                    if (!LeftSideIntialed)
                    {
                        expr.LeftSideOperand = double.Parse(token);
                        LeftSideIntialed = true;
                    }
                    expr.Operation = ParseMathOperation(CurChar.ToString());
                    token = "";

                }
                else if(CurChar =='-' && i > 0)
                {
                    if (expr.Operation == MathOperation.None)
                        
                    {
                        expr.Operation = MathOperation.Subtraction;
                        expr.LeftSideOperand = double.Parse(token);
                        LeftSideIntialed = true;
                        token = "";
                    }
                    else
                        token += CurChar;
                }
                else if (char.IsLetter(CurChar))
                {
                    token += CurChar;
                    LeftSideIntialed = true;
                }
                else if(CurChar ==' ')
                {
                    if (!LeftSideIntialed)
                    {
                        expr.LeftSideOperand = double.Parse(token);
                        LeftSideIntialed = true;
                        token = "";

                    }
                    else if (expr.Operation == MathOperation.None)
                    {
                        expr.Operation = ParseMathOperation(token);
                        token = "";
                    }
                   
                }
                else
                    token += CurChar;
            }


            return expr;
        }

        public static MathOperation ParseMathOperation(string token)
        {
            switch (token.ToLower())
            {
                case "+":
                case "add":
                    return MathOperation.Addition;
                case "-":
                case "sub":
                    return MathOperation.Subtraction;
                case "*":
                case "mul":
                    return MathOperation.Multiplication;
                case "/":
                case "div":
                    return MathOperation.Division;
                case "%":
                case "mod":
                    return MathOperation.Modulus;
                case "^":
                case "pow":
                    return MathOperation.Power;
                case "sin":
                    return MathOperation.Sin;
                case "cos":
                    return MathOperation.Cos;
                case "tan":
                    return MathOperation.Tan;
                default:
                    return MathOperation.None;

            }
        }
    }
}
