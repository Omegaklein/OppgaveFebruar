using System;
using System.Net.Http;
using System.Threading.Tasks;

public class ApiCaller
{
    private readonly HttpClient _httpClient;
    private string _bearerToken;

    public ApiCaller()
    {
        _httpClient = new HttpClient();
    }

    public void SetBearerToken(string token)
    {
        _bearerToken = token;
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _bearerToken);
    }

    // Implement methods for making API calls using _httpClient...
}
