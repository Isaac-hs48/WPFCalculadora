using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraProgramacion.Clases
{
    class ClsCalculator
    {
        private double Value { get; set; }
        public string Operator { get; set; }
        public double Result { get; set; }
        public bool IsFirstValue { get; set; }
        public bool IsFirstOperator { get; set; }
        public List<string> Operators { get; set; }
        public ClsCalculator()
        {
            Operators = new List<string> { "+", "-", "×", "÷" };

            Result = 0;

            IsFirstValue = true;

            IsFirstOperator = true;
        }

        public void ExecuteOperation()
        {
            if(IsFirstOperator)
            {
                IsFirstOperator = false;

                return;
            }

            switch (Operator)
            {
                case "+":
                    Result += Value;
                    break;
                case "-":
                    Result -= Value;
                    break;
                case "×":
                    Result *= Value;
                    break;
                case "÷":
                    Result /= Value;
                    break;
            }
        }

        public void SetValue(double pValue)
        {
            if (IsFirstValue)
            {
                Result = pValue;

                IsFirstValue = false;

                pValue = 0;
            }

            Value = pValue;
        }

        public void Reset()
        {
            Value = 0;
            Result = 0;
            IsFirstValue = true;
            Operator = string.Empty;
            IsFirstOperator = true;
        }
    }

}
