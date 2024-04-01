
using Code_Pills.DataAccess.Context;
using Code_Pills.DataAccess.Interface;
using Code_Pills.Services.DTOs;
using Code_Pills.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Code_Pills.Services.Services
{
    public class UserService: IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AuthDbContext dbContext;
        private readonly IJwtToken jwtToken;
        private readonly ApplicationDbContext appdbContext;
        private readonly IAuthRepo authRepo;

        public UserService(UserManager<IdentityUser> userManager,
            AuthDbContext dbContext,
            IJwtToken jwtToken,
            ApplicationDbContext appdbContext,
            IAuthRepo authRepo
            )
        { 
            _userManager = userManager;
            this.dbContext = dbContext;
            this.jwtToken = jwtToken;
            this.appdbContext = appdbContext;
            this.authRepo = authRepo;
        }
        public async Task<Object> VerifyEmailAsync(string email, string otp)
        {
            var userId =  dbContext.Users.FirstOrDefaultAsync(user=>user.Email == email).Id;
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                // User not found
                return false;
            }
            user.EmailConfirmed = true;
          
            // Verify the email using the provided token
            
            dbContext.Users.Update(user);
            await dbContext.SaveChangesAsync();
            var roles = await _userManager.GetRolesAsync(user);
            var token = jwtToken.CreateToken(user, roles.ToList());
            //var result = await _userManager.ConfirmEmailAsync(user, token);
            var response = new
            {
                Email = user.Email!,
                Roles = roles.ToList(),
                Token = token

            };
            return true;
        }

        public async Task<bool> MarkEmailConfirm(IdentityUser user)
        {
            if (user == null)
            {
                return false;
            }
            else
            {
                user.EmailConfirmed = true;
                this.dbContext.Users.Update(user);
                await this.dbContext.SaveChangesAsync();
                return true;
            }
        }


        public async Task<LoginResponseDto> VerifyOtp(VerifyOtpDto req)
        {
            var existingOtp = await appdbContext.UserOtp.FirstOrDefaultAsync(a => a.Email == req.Email);
            var response= new LoginResponseDto();
            if (existingOtp == null)
            {
               return null;
            }
            else
            {
                var user = dbContext.Users.FirstOrDefault(a => a.Email == req.Email);
                if (existingOtp != null) 
                {
                    if(existingOtp.Otp == req.Otp)
                    {
                        await this.MarkEmailConfirm(user);
                        var roles = await _userManager.GetRolesAsync(user);

                        // Create a Token and response
                        var token = jwtToken.CreateToken(user, roles.ToList());
                        response = new LoginResponseDto()
                        {
                            Email = req.Email,
                            Roles = roles.ToList(),
                            Token = token

                        };
                    }
                    else
                    {
                        // otp did not match
                    }
                }
            }
            await appdbContext.SaveChangesAsync();

            return response;
        }

        public async Task<bool> AddPersonalInformation(string userId, string email)
        {
            var uniqueUsername =await GenerateUniqueUserName(email);
            return await authRepo.AddPersonalInformation(userId, email,uniqueUsername);
        }


  

        // To generate unique user name using email

        public async Task<string>GenerateUniqueUserName(string email)
        {
            // Extract username from email (before @gmail.com)
            var atIndex = email.IndexOf("@");
            var username = atIndex != -1 ? email.Substring(0, atIndex) : email;

            // Check if the username is already in use
            var existingUser = await _userManager.FindByNameAsync(username);
            if (existingUser == null)
            {
                // Username is unique, return it
                return username;
            }
            else
            {
                // Append a unique suffix to the username until it becomes unique
                var suffix = 1;
                while (true)
                {
                    var uniqueUsername = $"{username}{suffix}";
                    if (await _userManager.FindByNameAsync(uniqueUsername) == null)
                    {
                        return uniqueUsername;
                    }
                    suffix++;
                }
            }
        }

    }
}
