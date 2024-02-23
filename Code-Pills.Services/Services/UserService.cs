using Code_Pills.DataAccess.Context;
using Code_Pills.DataAccess.Models;
using Code_Pills.Services.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.Services.Services
{
    public class UserService: IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AuthDbContext dbContext;

        public UserService(UserManager<IdentityUser> userManager, AuthDbContext dbContext)
        { 
            _userManager = userManager;
            this.dbContext = dbContext;
        }
        public async Task<bool> VerifyEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                // User not found
                return false;
            }
            user.EmailConfirmed = true;
            // Verify the email using the provided token
            this.dbContext.Users.Update(user);
            
            //var result = await _userManager.ConfirmEmailAsync(user, token);
            await this.dbContext.SaveChangesAsync();
            if (this.dbContext.SaveChangesAsync() !=null)
            {
                // Email verification successful
                return true;
            }
            else
            {
                // Email verification failed
                // Handle errors or log them
                return false;
            }
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
    }
}
