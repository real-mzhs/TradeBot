using Desktop.Models.MainModels;
using Desktop.Services.Network.Responses;

namespace Desktop.Services.Interfaces;

public interface IRegistrationService
{
    public Task<DataResponse<RegistrationResponse>> Registration(User user)
;

}
