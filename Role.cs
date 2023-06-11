using Microsoft.AspNetCore.Identity;

namespace Projekt
{
    public class Role
    {
        public async Task CreateRole(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] role_names = { "Driver", "User", "Passenger" };
            IdentityResult identityResult;
            foreach(var role_name in role_names)
            {
                var Exist = await RoleManager.RoleExistsAsync(role_name);
                if(!Exist)
                {
                    identityResult = await RoleManager.CreateAsync(new IdentityRole(role_name));
                }
            }
        }
    }
}
