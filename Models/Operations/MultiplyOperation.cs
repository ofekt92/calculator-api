public class MultiplyOperation : IOperation
{
    private const OperationAsciiCodes code = OperationAsciiCodes.Multiply;
    public int OperationAsciiCode
    {
        get => (int)code;
    }

    public double Calculate(double firstN, double secondN) => firstN * secondN;

}