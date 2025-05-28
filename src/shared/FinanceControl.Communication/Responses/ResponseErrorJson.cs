namespace FinanceControl.Communication.Responses;

public class ResponseErrorJson
{
    public IList<string> Errors { get; set; }
    public ResponseErrorJson(IList<string> errors) => Errors = errors;
    public ResponseErrorJson(string error) 
    {
        Errors = new List<string>(); // Inicializa a lista
        Errors.Add(error);
    }
}