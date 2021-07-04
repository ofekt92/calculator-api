public class CalculationRecord
{
    public int Id { get; }
    public double firstN { get; set; }
    public double secondN { get; set; }
    public int operationAsciiCode { get; set; }
    public double result { get; set; }

    public CalculationRecord(double firstN, double secondN, int operationAsciiCode, double result, int recordId)
    {
        this.firstN = firstN;
        this.secondN = secondN;
        this.operationAsciiCode = operationAsciiCode;
        this.result = result;
        this.Id = recordId;
    }
}