using AspNet.Identity.MongoDB;
using HomeworkPlatform.App_Start;

namespace HomeworkPlatform.App_Start
{
    	

	public class EnsureAuthIndexes
    {
        public static void Exist()
        {
            var context = PlatformIdentityContext.Create();
            IndexChecks.EnsureUniqueIndexOnUserName(context.Users);
            IndexChecks.EnsureUniqueIndexOnRoleName(context.Roles);
        }
    }
}