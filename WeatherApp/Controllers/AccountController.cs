﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
                                SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IEnumerable<IdentityError>> Register([FromForm] User model)
        {
            var user = new IdentityUser
            {
                UserName = model.Username,
                Email = model.Email,
                PasswordHash = model.Password,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }

            return result.Errors;
        }
    }
}
