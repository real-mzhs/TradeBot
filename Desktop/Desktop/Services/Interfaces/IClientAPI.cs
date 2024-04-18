using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Interfaces;

interface IClientAPI
{
    public Task<T> Get<T>(string resource, Parameter[] parameters = null) where T : new();
    public Task<T> Post<T>(string resource, object body = null, Parameter[] parameters = null) where T : new();
    public Task<T> Put<T>(string resource, object body = null, Parameter[] parameters = null) where T : new();
    public Task<T> Delete<T>(string resource, Parameter[] parameters = null) where T : new();

}
