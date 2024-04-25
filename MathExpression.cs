using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassionateApps.MathExpressionEvaluator
{
    internal class MathExpression
    {
        public double LeftSideOperand { set; get; }
        public double RightSideOperand {  set; get; }
        public MathOperation Operation { set; get; }    
    }
}
