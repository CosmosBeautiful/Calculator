using System;

namespace Calculator.Models
{
    public class Operation
    {
        public OperatorType Operator { get; private set; }
        public LevelType Level { get; private set; }

        public Operation(OperatorType operatorType)
        {
            this.Operator = operatorType;

            switch (operatorType)
            {
                case OperatorType.Brackets:
                    this.Level = LevelType.High;
                    break;
                case OperatorType.Mul:
                    this.Level = LevelType.Normal;
                    break;
                case OperatorType.Del:
                    this.Level = LevelType.Normal;
                    break;
                case OperatorType.Sum:
                    this.Level = LevelType.Low;
                    break;
                case OperatorType.Sub:
                    this.Level = LevelType.Low;
                    break;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
