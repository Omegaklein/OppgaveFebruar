public class ApiEndpoint
{
    public string Url { get; set; }
    public HttpMethod Method { get; set; }
    public Dictionary<string, string> Headers { get; set; }
    public object RequestBody { get; set; }
    public Type ExpectedResponseType { get; set; }

    public ApiEndpoint(string url, HttpMethod method)
    {
        Url = url;
        Method = method;
        Headers = new Dictionary<string, string>();
        RequestBody = null;
        ExpectedResponseType = typeof(string); // Default expected response type is string
    }
}
