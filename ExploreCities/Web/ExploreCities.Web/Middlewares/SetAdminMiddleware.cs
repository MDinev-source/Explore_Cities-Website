namespace ExploreCities.Web.Middlewares
{
    using System.Threading.Tasks;
    using ExploreCities.Common;
    using ExploreCities.Data.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;

    public class SetAdminMiddleware
    {
        private readonly RequestDelegate next;

        public SetAdminMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(
            HttpContext context,
            UserManager<ApplicationUser> userManager)
        {
            SeedUserInRoles(userManager);
            await this.next(context);
        }

        private static async Task SeedUserInRoles(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByEmailAsync(GlobalConstants.AdministratorEmail).Result == null)
            {
                var user = new ApplicationUser
                {
                    UserName = GlobalConstants.AdministratorUsername,
                    Email = GlobalConstants.AdministratorEmail,
                };

                var result = userManager.CreateAsync(user, GlobalConstants.AdministratorPassword).Result;

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);
                }
            }
        }
    }
}
