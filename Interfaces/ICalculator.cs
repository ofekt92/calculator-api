using System.Collections.Generic;

public interface ICalculator
{
    double? Execute(double firstN, double secondN, int operandAsciiCode);

    List<int> GetOperations();
}