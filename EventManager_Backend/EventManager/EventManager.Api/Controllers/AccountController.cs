using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EventManager.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EventManager.Api.Controllers
{
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            SignInManager<ApplicationUser> signInManager
        )
        {
            _signInManager = signInManager;
        }

        // This method is only to check that Authorize attribute is working.
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult("Authorized");
        }

        // This method redirect to google and then redirect back to our API
        [HttpGet]
        [Route("External")]
        public IActionResult External(string provider)
        {
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, "/api/Account/test");
            return new ChallengeResult(provider, properties);
        }

        // To this method redirect google authorization
        // When we get claims from google we can generate token
        [HttpGet]
        [Route("Test")]
        public async Task<IActionResult> Test(string returnUrl = null, string remoteError = null)
        {
            if (remoteError != null)
            {
                return new BadRequestResult();
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return new BadRequestResult();
            }

            // This code below is only to generate sample token - you do not need it
            var email = string.Empty;
            if (info.Principal.HasClaim(c => c.Type == ClaimTypes.Email))
            {
                email = info.Principal.FindFirstValue(ClaimTypes.Email);
            }

            var googleUserId = string.Empty;
            if (info.Principal.HasClaim(c => c.Type == ClaimTypes.NameIdentifier))
            {
                googleUserId = info.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(googleUserId))
            {
                var token = GenerateJwtToken(email, googleUserId);
                return new OkObjectResult(token);
            }

            return new BadRequestResult();
        }

        private object GenerateJwtToken(string email, string userId)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, userId)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JwtKey1JwtKey2JwtKey3JwtKey"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(1);

            var token = new JwtSecurityToken(
                "https://localhost:44362",
                "https://localhost:44362",
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}