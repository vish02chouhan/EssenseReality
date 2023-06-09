﻿using EssenceRealty.Data.Identity.Contract;
using EssenceRealty.Data.Identity.Models;
using EssenceRealty.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EssenceRealty.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("authenticate")]
   
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _authenticationService.AuthenticateAsync(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationRequest request)
        {
            return Ok(await _authenticationService.RegisterAsync(request));
        }

        [HttpPost("resetpassword")]
        public async Task<ActionResult<bool>> ResetPassword(ResetPasswordRequest request)
        {
            return Ok(await _authenticationService.ResetPassword(request));
        }

        [HttpPost("forgotpassword")]
        public async Task<ActionResult<bool>> ForgotPassword(ForgotPasswordRequest request)
        {
            return Ok(await _authenticationService.ForgotPassword(request));
        }

        [HttpPost("changepassword")]
        [Authorize]
        public async Task<ActionResult<bool>> ChangePassword(ChangePasswordRequest request)
        {
            return Ok(await _authenticationService.ChangePassword(request, HttpContext.User));
        }


 
    }
}
