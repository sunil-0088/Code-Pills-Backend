using Code_Pills.Services.DTOs;
using Code_Pills.Services.Interface;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Code_Pills.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IJwtToken tokenService;
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;

        public AuthController(UserManager<IdentityUser> userManager, IJwtToken tokenService, IEmailService emailService, IUserService userService)
        {
            this.userManager = userManager;
            this.tokenService = tokenService;
            _emailService = emailService;
            _userService = userService;
        }

        // From register button api end point

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            bool isRegister = true;
            
            // Create Identity user
            var user = new IdentityUser
            {
                UserName = request.Email?.Trim(),
                Email = request.Email?.Trim(),
            };
            var identityResult = await userManager.CreateAsync(user, request.Password);
            if (identityResult.Succeeded)
            {
                // saving Emial in personalInfo table 

                var isPersonalInfoSaved = await _userService.AddPersonalInformation(user.Id, user.Email!);
               
                identityResult = await userManager.AddToRoleAsync(user, "User");
                if (identityResult.Succeeded && isPersonalInfoSaved)
                {
                    // Generating Verificatiom token

                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var verificationLink = $"https://localhost:7010/api/Auth/verify?userId={user.Id}&token={token}";
                   
                    // Send verification email
                    await _emailService.SendEmailAsync(request.Email, "Email Verification", verificationLink, isRegister);
                    return Ok(new { message = "Registration successful. Please check your email for verification instructions." });
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            // checking email
            var identityUser = await userManager.FindByEmailAsync(request.Email);

            if (identityUser != null && identityUser.EmailConfirmed)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(identityUser, request.Password);
                if (checkPasswordResult)
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
            return ValidationProblem(ModelState);
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
                        await _userService.AddPersonalInformation(user.Id, user.Email!);
                        var roles = await userManager.GetRolesAsync(user);
                        await _userService.MarkEmailConfirm(user);

                        var token = tokenService.CreateToken(user, roles.ToList());
                        var response = new LoginResponseDto()
                        {
                            Email = user.Email,
                            Roles = roles.ToList(),
                            Token = token

                        };
                        return Ok(response);
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

        // email verification from link given in email for register

        //[HttpGet("verify")]
        //public async Task<IActionResult> VerifyEmail(string email, string otp)
        //{
        //    if (string.IsNullOrEmpty(email))
        //    {
        //        return BadRequest("Invalid verification Email.");
        //    }
        //    var isVerified = await _userService.VerifyEmailAsync(email, otp);

        //    if (isVerified!= null)
        //    {
        //        return Ok(isVerified);
        //    }
        //    else
        //    {
        //        return BadRequest("Invalid or expired verification token.");
        //    }
        //}


        // Forgot Password

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto model)
        {
            
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null || !(await userManager.IsEmailConfirmedAsync(user)))
            {
                // User not found or email not confirmed
                return BadRequest("Invalid email address.");
            }

            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            string resetUrl = $"http://localhost:4200/change-password?email={model.Email}&token={token}";

            var emailBody = $"Please click the following link to reset your password:{resetUrl}";
            // Send verification email
            await _emailService.SendEmailAsync(model.Email, "Reset Password", resetUrl, false);

            return Ok("Password reset link sent successfully.");
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
        {
            Console.WriteLine(model.Token);
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // User not found
                return BadRequest("Invalid email address.");
            }

            var result = await userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
            if (result.Succeeded)
            {
                return Ok("Password reset successfully.");
            }
            else
            {
                // Password reset failed
                return BadRequest("Unable to reset password.");
            }
        }

        [HttpPost("VerifyOtp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpDto request)
        {
            var result = await _userService.VerifyOtp(request);
            return Ok(result);
        }
    }
}
