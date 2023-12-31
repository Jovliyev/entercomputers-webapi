﻿using EnterComputers.Service.Dtos.Auth;
using EnterComputers.Service.Interfaces.Auth;
using EnterComputers.Service.Validators;
using EnterComputers.Service.Validators.Dtos.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnterComputers.WebApi.Controllers;

[Route("api/Auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        this._authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromForm] RegisterDto registerDto)
    {
        var validator = new RegisterValidator();
        var result = validator.Validate(registerDto);
        if (result.IsValid)
        {
            var serviceResult = await _authService.RegisterAsync(registerDto);
            return Ok(new { serviceResult.Result, serviceResult.CachedMinutes });
        }
        else return BadRequest(result.Errors);
    }

    [HttpPost("register/send-code")]
    [AllowAnonymous]
    public async Task<IActionResult> SendCodeRegisterAsync(string phone)
    {
        var result = PhoneNumberValidator.IsValed(phone);
        if (result == false) return BadRequest("Phone number is invalid!");

        //   var serviceResult = await _authService.SendCodeForRegisterAsync(phone);
        var serviceResult = await _authService.SendCodeForRegisterAsync(phone.ToString());
        return Ok(new { serviceResult.Result, serviceResult.CachedVerificationMinutes });
    }

    [HttpPost("register/verify")]
    [AllowAnonymous]
    public async Task<IActionResult> VerifyRegisterAsync([FromBody] VerifyRegisterDto verifyRegisterDto)
    {
        var serviceResult = await _authService.VerifyRegisterAsync(verifyRegisterDto.PhoneNumber, verifyRegisterDto.Code);
        return Ok(new { serviceResult.Result, serviceResult.Token });
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync([FromBody] LoginDto loginDto)
    {
        var validator = new LoginValidator();
        var valResult = validator.Validate(loginDto);
        if (valResult.IsValid == false) return BadRequest(valResult.Errors);

        var serviceResult = await _authService.LoginAsync(loginDto);
        return Ok(new { serviceResult.Result, serviceResult.Token });
    }
}
