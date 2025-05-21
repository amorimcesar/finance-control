namespace FinanceControl.Exceptions.ExceptionsBase;

public class ErrorOnValidationException : FinanceControlExcpetion
{
    public IList<string> ErrorMessages { get; set; }
    public ErrorOnValidationException(IList<string> errorMessages) => ErrorMessages = errorMessages;
}