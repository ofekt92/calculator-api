using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace calculator.Controllers
{
    [ApiController]
    [Route("calculator")]
    public class CalculatorController : ControllerBase
    {
        ICalculator calculator;
        IHistoryManager historyManager;
        public CalculatorController(ICalculator calculator, IHistoryManager history)
        {
            this.calculator = calculator;
            this.historyManager = history;
        }

        [HttpPost]
        public CalculationResponse Calculate(CalculationRequest request)
        {
            CalculationResponse response = new CalculationResponse();
            try
            {
                double? res = calculator.Execute(request.FirstNum, request.SecondNum, request.OperandAsciiCode);
                if (res != null)
                {
                    CalculationRecord newRecord = new CalculationRecord(request.FirstNum,
                                                                        request.SecondNum,
                                                                        request.OperandAsciiCode,
                                                                        res.Value,
                                                                        historyManager.NextId());
                    historyManager.Add(newRecord);
                    response.NewCalculationRecord = newRecord;
                    response.IsSuccess = true;
                    response.ErrorMessage = null;
                }
            }
            catch (Exception exc)
            {
                response.ErrorMessage = exc.Message;
            }
            return response;
        }

        [HttpPost]
        [Route("/History/Update")]
        public UpdateRecordResponse UpdateRecord(UpdateRecordRequest request)
        {
            UpdateRecordResponse response = new UpdateRecordResponse() { UpdatedResult = null };
            try
            {
                CalculationRecord recordToUpdate = historyManager.History.SingleOrDefault(rec => rec.Id == request.RecordId);
                if (recordToUpdate != null)
                {
                    response.UpdatedResult = calculator.Execute(request.FirstNum, request.SecondNum, request.OperandAsciiCode);
                    if (response.UpdatedResult != null)
                    {
                        historyManager.UpdateRecord(request, response.UpdatedResult.Value);
                        response.IsSuccess = true;
                        response.ErrorMessage = null;
                    }
                }
                else
                {
                    response.ErrorMessage = $"Could not find a record with ID {request.RecordId}";
                }
            }
            catch (Exception exc)
            {
                response.ErrorMessage = exc.Message;
            }
            return response;
        }

        [HttpDelete]
        [Route("/History/Delete/")]
        public DeleteRecordResponse DeleteRecord(int id)
        {
            DeleteRecordResponse response = new DeleteRecordResponse();
            try
            {
                if (historyManager.Delete(id))
                {
                    response.IsSuccess = true;
                    response.ErrorMessage = null;
                }
                else
                {
                    response.ErrorMessage = $"Could not find a record with the given id ({id})";
                }
            }
            catch (Exception exc)
            {
                response.ErrorMessage = exc.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("/Operations")]
        public List<int> GetOperations() => calculator.GetOperations();

        [HttpGet]
        [Route("/History")]
        public List<CalculationRecord> GetHistory() => historyManager.History;
    }
}