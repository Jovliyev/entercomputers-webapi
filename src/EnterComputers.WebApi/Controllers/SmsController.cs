﻿using EnterComputers.Service.Dtos.Notification;
using EnterComputers.Service.Interfaces.Notification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnterComputers.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly ISmsSender _smsSender;
        public SmsController(ISmsSender smsSender)
        {
            this._smsSender = smsSender;
        }

        [HttpPost]
        public async Task<IActionResult> SendAsync([FromBody] SmsMessage smsMessage)
        {
            return Ok(await _smsSender.SendAsync(smsMessage));
        }
    }
}
