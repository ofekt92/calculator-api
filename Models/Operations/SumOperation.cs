public class SumOperation : IOperation
{
    private const OperationAsciiCodes code = OperationAsciiCodes.Sum;
    public int OperationAsciiCode
    {
        get => (int)code;
    }

    public double Calculate(double firstN, double secondN) => firstN + secondN;
}