using Desktop.Models.MainModels;
using Desktop.Services.Network;
using Desktop.Services.Network.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Interfaces;

interface IAuthenticationService
{
    public Task<DataResponse<AuthResponse>> Authentication(User user);

}
