using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using Microsoft.AspNet.Identity;

namespace HomeworkPlatform.App_Start
{
    public class PlatformUserManager : UserManager<PlatformUser>
    {
        public PlatformUserManager(IUserStore<PlatformUser> store)
            : base(store)
        {
        }
    }
}