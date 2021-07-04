using System.Collections.Generic;

public interface IHistoryManager
{
    List<CalculationRecord> History { get; }
    void Add(CalculationRecord newRecord);
    bool Delete(int recordId);
    int NextId();
    CalculationRecord UpdateRecord(UpdateRecordRequest request, double newResult);
}