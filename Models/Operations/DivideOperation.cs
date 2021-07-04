using System;

public class DivideOperation : IOperation
{
    private const OperationAsciiCodes code = OperationAsciiCodes.Divide;
    public int OperationAsciiCode
    {
        get => (int)code;
    }

    public double Calculate(double firstN, double secondN)
    {
        if (secondN == 0)
        {
            throw new DivideByZeroException("Cannot divide by 0.");
        }
        return firstN / secondN;
    }
}