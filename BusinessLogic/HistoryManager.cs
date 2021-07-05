using System.Collections.Generic;
using System.Linq;

///<summary>Manages the calculator's history.</summary>
public sealed class HistoryManager : IHistoryManager
{
    public List<CalculationRecord> History { get; }
    private int currentId = 0;
    public HistoryManager()
    {
        History = new List<CalculationRecord>();
    }

    ///<summary>Adds one record to the history.</summary>
    public void Add(CalculationRecord record) => History.Add(record);


    ///<summary>Removes one record from the history.</summary>
    public bool Delete(int recordId)
    {
        CalculationRecord itemToRemove = History.SingleOrDefault(op => op.Id == recordId);
        if (itemToRemove != null)
        {
            return History.Remove(itemToRemove);
        }
        return false;
    }

    public int NextId() => currentId++;

    public CalculationRecord UpdateRecord(UpdateRecordRequest request, double newResult)
    {
        CalculationRecord recordToUpdate = History.SingleOrDefault(rec => rec.Id == request.RecordId);
        if (recordToUpdate != null)
        {
            recordToUpdate.firstN = request.FirstNum;
            recordToUpdate.secondN = request.SecondNum;
            recordToUpdate.operationAsciiCode = request.OperandAsciiCode;
            recordToUpdate.result = newResult;
        }
        return recordToUpdate;
    }
}