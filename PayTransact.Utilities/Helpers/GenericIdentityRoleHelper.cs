using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace PayTransact.Utilities.Helpers
{
    public abstract class GenericIdentityRoleHelper
    {
        public abstract Task CreateNewRoleAsync([Required] string roleName);
    }

    public class IdentityRoleHelper : GenericIdentityRoleHelper
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public IdentityRoleHelper(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public override async Task CreateNewRoleAsync([Required] string roleName)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
                await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }
}
