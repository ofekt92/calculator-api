public class SubstractOperation : IOperation
{
    private const OperationAsciiCodes code = OperationAsciiCodes.Substract;
    public int OperationAsciiCode
    {
        get => (int)code;
    }

    public double Calculate(double firstN, double secondN) => firstN - secondN;
}