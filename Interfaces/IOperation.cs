public interface IOperation
{
    int OperationAsciiCode { get; }
    double Calculate(double firstN, double secondN);
}