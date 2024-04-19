using Desktop.Models.MainModels;
using Desktop.Services.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Interfaces;

interface IRegistrationService
{
    public Task<DataResponse<RegistrationResponse>> Registration(User user);

}
