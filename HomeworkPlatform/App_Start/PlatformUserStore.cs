using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace HomeworkPlatform.App_Start
{
    class PlatformUserStore
    {
        private IMongoDatabase database;

        public PlatformUserStore()
        {
        }

        public void Dispose()
        {
        }

        public Task CreateAsync(PlatformUser user)
        {
            // TODO
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PlatformUser user)
        {
            // TODO
            throw new NotImplementedException();
        }

        public Task DeleteAsync(PlatformUser user)
        {
            // TODO
            throw new NotImplementedException();
        }

    }

}