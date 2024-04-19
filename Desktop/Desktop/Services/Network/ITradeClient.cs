using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Network;

interface ITradeClient
{
    public Task<DataResponse<T>> Get<T>(string resource, Parameter[] parameters = null) where T : new();
    public Task<DataResponse<T>> Post<T>(string resource, object body = null, Parameter[] parameters = null) where T : new();
    public Task<DataResponse<T>> Put<T>(string resource, object body = null, Parameter[] parameters = null) where T : new();
    public Task<DataResponse<T>> Delete<T>(string resource, Parameter[] parameters = null) where T : new();

}
