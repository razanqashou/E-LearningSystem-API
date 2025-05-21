using E_LearningSystem_API.Context;
using E_LearningSystem_API.DTOs.Request.Verfication;
using E_LearningSystem_API.Entities;
using E_LearningSystem_API.Helpers.Hashing;
using E_LearningSystem_API.Helpers.Token;
using E_LearningSystem_API.Helpers.Validations;
using E_LearningSystem_API.Interfaces;

namespace E_LearningSystem_API.Services
{
    public class AuthServices : IAuthIterface
    {
        private readonly E_LearnningContext _context;
        public AuthServices(E_LearnningContext context) {

            _context = context;
        
        }


        public async  Task<string> ResetPersonPassword(ResetPersonPasswordInputDTO input)
        {

            try
            {
                var user=_context.Users.Where(x=>x.Id==input.UserId 
                && x.IsLoggedIn == false 
                && x.OTPExipry ==null
                && x.IsVerfied==true
                ).SingleOrDefault();

                if (user == null)
                {
                    return "User Not Found";

                }
                 Validation.IsValidPass(input.Password);


                if (input.Password != input.ConfirmPassword)
                {
                    return "not compatable";
                }

                user.Password =HashingHelper.HashValue384( input.ConfirmPassword);

                _context.Update(user);
                _context.SaveChanges();


                return "Your pass change successfully";
            }
            catch (Exception ex)
            {
                {

                    return $"500, {ex.Message}";

                }


            }

        }


        public async Task<string> Verification(VerificationInputDTO input)
        {
            try
            {
                var user = _context.Users.Where(x=> x.Id==input.UserId
                && x.OTPCode==input.OTP
                && x.IsLoggedIn==false 
                && x.OTPExipry > DateTime.Now
                ) .SingleOrDefault();

                if (user == null)
                {
                    return "User Not Found";

                }

                if (input.Type == "SignUp")
                {
                    user.IsVerfied = true;
                    user.OTPExipry = null;
                    user.OTPCode = null;
                    _context.Update(user);
                    _context.SaveChanges();
                    return "Your Account Is Verifyed";


                }
                else if(input.Type == "login")
                {
                    user.LastLoginTime = DateTime.Now;
                    user.IsLoggedIn = true;
                    user.OTPExipry = null;
                    user.OTPCode = null;

                    _context.Update(user);
                    _context.SaveChanges();

                    var response = TokenHelper.GenerateJWTToken(user.Id.ToString(), "Client");
                   if(  TokenHelper.IsValidToken(response)!= "Valid")
                    {
                        return TokenHelper.IsValidToken(response) ;

                    }
  
                       return response;
                   

                }
                else if (input.Type == "ResetPass")
                {
                    user.OTPExipry = null;
                    user.OTPCode = null;

                    _context.Update(user);
                    _context.SaveChanges();
                    return "OTP is correct. You can now change your password.";
                }
                else
                {
                    return " you are in wronge flow";
                }

            }

            catch (Exception ex)
            {
                {

                    return $"500, {ex.Message}";

                }


            }

        }
    }
}
