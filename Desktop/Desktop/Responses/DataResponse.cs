using System.Net;

namespace Desktop.Responses;

public class DataResponse<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public string? ErrorMessage { get; set; }
    public T? Data { get; set; }
    public string? Content { get; set; }
}
