using FitnessApp.Models;
using FitnessClassRegistration.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace FitnessApp.Data
{
    public class UserAndRoleSeedData
    {
        private RoleManager<IdentityRole> _roleMgr;
        private UserManager<ApplicationUser> _userMgr;
        private readonly string defaultAdminUser = "shimojax@gmail.com";
        private readonly string defaultUser = "shimojax+123@gmail.com";
        private readonly string adminRoleName = "FitnessAppAdmin";
        private readonly string userRoleName = "UserRole";

        public UserAndRoleSeedData(
            UserManager<ApplicationUser> userMgr,
            RoleManager<IdentityRole> roleMgr
        )
        {
            _roleMgr = roleMgr;
            _userMgr = userMgr;
        }

        public async Task Seed()
        {
            var adminUser = await _userMgr.FindByNameAsync(defaultAdminUser);

            if (adminUser == null)
            {
                if (!(await _roleMgr.RoleExistsAsync(adminRoleName)))
                {
                    var adminRole = new IdentityRole(adminRoleName);
                    await _roleMgr.CreateAsync(adminRole);
                }

                adminUser = new ApplicationUser()
                {
                    Email = defaultAdminUser,
                    UserName = defaultAdminUser
                };

                var adminUserResult = await _userMgr.CreateAsync(adminUser, "Test1234!");
                var adminRoleResult = await _userMgr.AddToRoleAsync(adminUser, adminRoleName);

                if (!adminUserResult.Succeeded || !adminRoleResult.Succeeded)
                {
                    throw new InvalidOperationException("Failed to build admin user and role");
                }
            }

            var user = await _userMgr.FindByNameAsync(defaultUser);

            if (user == null)
            {
                if (!(await _roleMgr.RoleExistsAsync(userRoleName)))
                {
                    var userRole = new IdentityRole(userRoleName);
                    await _roleMgr.CreateAsync(userRole);
                }

                user = new ApplicationUser()
                {
                    Email = defaultUser,
                    UserName = defaultUser
                };

                var userResult = await _userMgr.CreateAsync(user, "Test1234!");
                var roleResult = await _userMgr.AddToRoleAsync(user, userRoleName);

                if (!userResult.Succeeded || !roleResult.Succeeded)
                {
                    throw new InvalidOperationException("Failed to build user and role");
                }
            }
        }
    }
}
