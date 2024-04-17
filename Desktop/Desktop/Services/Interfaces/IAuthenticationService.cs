using Desktop.Models.MainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services.Interfaces;

interface IAuthenticationService
{
    public Task<bool> Authentication(User user);
}
