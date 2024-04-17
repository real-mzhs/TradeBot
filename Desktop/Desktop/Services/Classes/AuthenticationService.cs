using Desktop.Models.MainModels;
using Desktop.Services.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Classes;

class AuthenticationService : IAuthenticationService
{  
    public async Task<bool> Authentication (User user)
    {



        return true;
    }

}
