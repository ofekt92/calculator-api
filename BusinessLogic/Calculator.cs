using System;
using System.Collections.Generic;
using System.Linq;

namespace calculator.businesslogic
{
    public class Calculator : ICalculator
    {
        List<IOperation> operations;
        public Calculator()
        {
            operations = new List<IOperation>()
            {
                new SumOperation(),
                new SubstractOperation(),
                new MultiplyOperation(),
                new DivideOperation()
            };
        }

        public double? Execute(double firstN, double secondN, int operandAsciiCode)
        {
            double? result = null;

            IOperation operation = operations.FirstOrDefault(op => op.OperationAsciiCode == operandAsciiCode);
            if (operation != null)
            {
                result = operation.Calculate(firstN, secondN);
            }
            else
            {
                throw new Exception("Unkown operation. Please refer to the list of valid operation codes.");
            }
            return result;
        }

        ///<summary>
        /// Returns a list of operands using their ascii codes for the client to convert to chars.
        ///</summary>
        public List<int> GetOperations() => operations.Select(op => op.OperationAsciiCode).ToList();
    }
}