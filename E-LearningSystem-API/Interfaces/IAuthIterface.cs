using E_LearningSystem_API.DTOs.Request.Verfication;

namespace E_LearningSystem_API.Interfaces
{
    public interface IAuthIterface
    {

        Task<string> Verification(VerificationInputDTO input);

        Task<string> ResetPersonPassword(ResetPersonPasswordInputDTO input);
    }
}
