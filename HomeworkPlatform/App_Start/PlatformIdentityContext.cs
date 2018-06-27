using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNet.Identity.MongoDB;
using HomeworkPlatform.Models;
using MongoDB.Driver;
using System.Web;

namespace HomeworkPlatform.App_Start
{



	public class PlatformIdentityContext : IDisposable
    {
        public static PlatformIdentityContext Create()
        {

            System.IO.StreamReader file = new System.IO.StreamReader("../DataBaseInfo.txt");
            file.ReadLine();
            file.ReadLine();
            var connect = file.ReadLine();
            var db = file.ReadLine();
            file.Close();

            var client = new MongoClient(connect);
            var database = client.GetDatabase(db);
            var users = database.GetCollection<ApplicationUser>("account");
            var roles = database.GetCollection<IdentityRole>("roles");
            return new PlatformIdentityContext(users, roles);
        }

        private PlatformIdentityContext(IMongoCollection<ApplicationUser> users, IMongoCollection<IdentityRole> roles)
        {
            Users = users;
            Roles = roles;
        }

        public IMongoCollection<IdentityRole> Roles { get; set; }

        public IMongoCollection<ApplicationUser> Users { get; set; }

        public Task<List<IdentityRole>> AllRolesAsync()
        {
            return Roles.Find(r => true).ToListAsync();
        }

        public void Dispose()
        {
        }
    }
}