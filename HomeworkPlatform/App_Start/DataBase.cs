using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.driver;
using MongoDB.Bson;

namespace HomeworkPlatform.App_Start
{
    public class DataBase
    {
        private String dbrootuser { get; set; }
        private String dbrootpassword { get; set; }
        private String mlbConnect { get; set; }
        private MongoClient dbClient { get; set; }
        private IMongoDatabase db { get; set; }
        private String database { get; set; }
        private String column { get; set; }

        public Boolean getConnectToDataBase()
        {
            try
            {
                dbClient = new MongoClient(mlbConnect);
                db = dbClient.GetDatabase(database);
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        public BsonDocument getData()
        {

        }
    }
}
