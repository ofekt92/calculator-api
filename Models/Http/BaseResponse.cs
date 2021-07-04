public abstract class BaseResponse
{
    public bool IsSuccess { get; set; }
    public string ErrorMessage { get; set; }
    public BaseResponse()
    {
        IsSuccess = false;
        ErrorMessage = "Internal Server Error. Please try again later.";
    }
}