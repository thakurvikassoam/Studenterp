using Microsoft.AspNetCore.Identity;
using SVSU.Student.ERP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVSU.Student.ERP.library
{
    public class CustomUsernameEmailPolicy: UserValidator<Users>
    {

        public override async Task<IdentityResult> ValidateAsync(UserManager<Users> manager, Users user)
        {
            IdentityResult result = await base.ValidateAsync(manager, user);
            List<IdentityError> errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();

            if (user.UserName == "google")
            {
                errors.Add(new IdentityError
                {
                    Description = "Google cannot be used as a user name"
                });
            }

            return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }


    }
}
