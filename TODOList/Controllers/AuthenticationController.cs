using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TODOList.Service.Interfaces;
using TODOList.ViewModels;

namespace TODOList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IUserTaskService _userTaskService;

        public AuthenticationController(ILogger<AuthenticationController> logger,
            IUserTaskService userTaskService
            )
        {
            _logger = logger;
            _userTaskService = userTaskService;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(LoginViewModel loginViewModel)
        {
            try
            {
                var user = await _userTaskService.GetUserByCredentials(loginViewModel.UserName, loginViewModel.Password);

                if (user == null)
                {
                    return BadRequest();
                }

                //  todo: maybe move this lot to a service
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(principal);

                return Ok();
            }
            catch (Exception)
            {
                //  todo: return a user-friendly error message
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return Ok();
        }

    }
}
