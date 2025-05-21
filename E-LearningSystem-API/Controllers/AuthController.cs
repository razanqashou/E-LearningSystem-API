using E_LearningSystem_API.DTOs.Request.Verfication;
using E_LearningSystem_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_LearningSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthIterface _appService;

        public AuthController(IAuthIterface appService)
        {
            _appService = appService;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Verification(VerificationInputDTO input)
        {
            try
            {
                var response = await _appService.Verification(input);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> ResetPersonPassword(ResetPersonPasswordInputDTO input)
        {
            try
            {
                var response = await _appService.ResetPersonPassword(input);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
    }
}
