using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeworkPlatform.App_Start
{
    public class PlatformSignInManager : SignInManager<PlatformUser, string>
    {
        public PlatformSignInManager(PlatformUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }
    }
}