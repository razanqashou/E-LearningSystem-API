namespace E_LearningSystem_API.DTOs.Request.Verfication
{
    public class ResetPersonPasswordInputDTO
    {

        public int UserId { get; set; }   
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }


    }
}
