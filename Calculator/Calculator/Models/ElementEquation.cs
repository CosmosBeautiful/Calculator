using System;

namespace Calculator.Models
{
    public class ElementEquation
    {
        public double Number { get; private set; }
        public Operation Operation { get; private set; }
        public string NestedEquation { get; private set; }


        public ElementEquation(double number, OperatorType operatorType)
        {
            this.Number = number;
            this.Operation = new Operation(operatorType);
        }

        public ElementEquation( OperatorType operatorType, string nestedEquation)
        {
            this.Operation = new Operation(operatorType);
            this.NestedEquation = nestedEquation;
        }
    }
}
