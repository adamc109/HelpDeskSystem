using Domain.DTO.Request;
using Domain.DTO.Response;


namespace Domain.Interface
{
    public interface IAccountService
    {
        //base response
        Task<BaseResponse<string>> VerifyUser(string username, string password);
        Task<BaseResponse> RegisterUser(RegisterUserRequest request);
    }
}
