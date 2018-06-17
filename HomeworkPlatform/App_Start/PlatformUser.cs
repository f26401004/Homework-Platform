using Microsoft.AspNet.Identity;

namespace HomeworkPlatform.App_Start
{
    public class PlatformUser : IUser<string>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string StudentID { get; set; }

        public string Department { get; set; }
    }
}