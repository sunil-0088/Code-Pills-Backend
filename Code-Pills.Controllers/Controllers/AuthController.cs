using Code_Pills.Services.DTOs;
using Code_Pills.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Code_Pills.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IJwtToken tokenService;

        public AuthController( UserManager<IdentityUser> userManager, IJwtToken tokenService)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            // Create Identity user
            var user = new IdentityUser
            {
                UserName = request.Email?.Trim(),
                Email = request.Email?.Trim(),
            };
            var identityResult = await userManager.CreateAsync(user, request.Password);
            if(identityResult.Succeeded)
            {
                identityResult = await userManager.AddToRoleAsync(user, "User");
                if(identityResult.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    if(identityResult.Errors.Any())
                    {
                        foreach(var error in identityResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
            }
            else
            {
                if (identityResult.Errors.Any())
                {
                    foreach(var error in identityResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return ValidationProblem(ModelState);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            // checking email
            var identityUser = await userManager.FindByEmailAsync(request.Email);

            if(identityUser != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(identityUser,request.Password);
                if(checkPasswordResult)
                {
                    var roles = await userManager.GetRolesAsync(identityUser);

                    // Create a Token and response
                    var token = tokenService.CreateToken(identityUser, roles.ToList());
                    var response = new LoginResponseDto()
                    {
                        Email = request.Email,
                        Roles = roles.ToList(),
                        Token = token

                    };
                    return Ok(response);
                }
            }
            ModelState.AddModelError("", "Email or password is incorrect");
            return Ok();
        }

        // Handling Google signing

        [HttpPost("google")]
        public async Task<IActionResult> GoogleSignin([FromBody] GoogleRequestDto request)
        {
            // checking email
            var identityUser = await userManager.FindByEmailAsync(request.Email);
            //Sign in
            if (identityUser != null)
            {
                var roles = await userManager.GetRolesAsync(identityUser);

                // Create a Token and response
                var token = tokenService.CreateToken(identityUser, roles.ToList());
                var response = new LoginResponseDto()
                {
                    Email = request.Email,
                    Roles = roles.ToList(),
                    Token = token

                };
                return Ok(response);
            }
            // SignUp
            else
            {
                var user = new IdentityUser
                {
                    UserName = request.Email?.Trim(),
                    Email = request.Email?.Trim(),
                };
                var identityResult = await userManager.CreateAsync(user);
                if (identityResult.Succeeded)
                {
                    identityResult = await userManager.AddToRoleAsync(user, "User");
                    if (identityResult.Succeeded)
                    {
                        return Ok();
                    }
                    else
                    {
                        if (identityResult.Errors.Any())
                        {
                            foreach (var error in identityResult.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }
                else
                {
                    if (identityResult.Errors.Any())
                    {
                        foreach (var error in identityResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                return ValidationProblem(ModelState);
            }
        }
    }
}
