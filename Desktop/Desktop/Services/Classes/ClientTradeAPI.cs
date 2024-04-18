using Desktop.Services.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Classes;

class ClientTradeAPI : IClientAPI
{
    private readonly RestClient _client;

    public ClientTradeAPI(string baseUrl)
    {
        _client = new RestClient(baseUrl);
    }

    private async Task<T> Execute<T>(RestRequest request) where T : new()
    {
        var response = await _client.ExecuteAsync<T>(request);
        if (response.ErrorException != null)
        {
            throw new ApplicationException("Error retrieving response. Check inner exception for details.", response.ErrorException);
        }
        return response.Data;
    }


    public async Task<T> Get<T>(string resource, Parameter[] parameters = null) where T : new()
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

    public async Task<T> Post<T>(string resource, object body = null, Parameter[] parameters = null) where T : new()
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

    public async Task<T> Put<T>(string resource, object body = null, Parameter[] parameters = null) where T : new()
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

    public async Task<T> Delete<T>(string resource, Parameter[] parameters = null) where T : new()
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
