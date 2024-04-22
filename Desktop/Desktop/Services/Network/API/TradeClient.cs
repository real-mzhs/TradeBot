using Desktop.Services.Network.Responses;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Network.API;

class TradeClient : ITradeClient
{
    private readonly RestClient _client = new("https://API.com");

    //public TradeClient(string baseUrl)
    //{
    //    _client = new RestClient(baseUrl);
    //}

    
    private async Task<DataResponse<T>> Execute<T>(RestRequest request) where T : new()
    {
        var response = await _client.ExecuteAsync<T>(request);

        return new DataResponse<T>
        {
            StatusCode = response.StatusCode,
            Data = response.Data,
            ErrorMessage = response.ErrorMessage
        };
    }

    public async Task<DataResponse<T>> Get<T>(string resource, Parameter[]? parameters = null) where T : new()
    {
        var request = new RestRequest(resource, Method.Get);
        if (parameters != null)
        {
            foreach (var parameter in parameters)
            {
                request.AddParameter(parameter);
            }
        }
        return await Execute<T>(request);
    }

    public async Task<DataResponse<T>> Post<T>(string resource, object body = null, Parameter[]? parameters = null) where T : new()
    {
        var request = new RestRequest(resource, Method.Post);
        if (body != null)
        {
            request.AddJsonBody(body);
        }
        if (parameters != null)
        {
            foreach (var parameter in parameters)
            {
                request.AddParameter(parameter);
            }
        }
        return await Execute<T>(request);
    }

    public async Task<DataResponse<T>> Put<T>(string resource, object body = null, Parameter[]? parameters = null) where T : new()
    {
        var request = new RestRequest(resource, Method.Put);
        if (body != null)
        {
            request.AddJsonBody(body);
        }
        if (parameters != null)
        {
            foreach (var parameter in parameters)
            {
                request.AddParameter(parameter);
            }
        }
        return await Execute<T>(request);
    }

    public async Task<DataResponse<T>> Delete<T>(string resource, Parameter[]? parameters = null) where T : new()
    {
        var request = new RestRequest(resource, Method.Delete);
        if (parameters != null)
        {
            foreach (var parameter in parameters)
            {
                request.AddParameter(parameter);
            }
        }
        return await Execute<T>(request);
    }

}
