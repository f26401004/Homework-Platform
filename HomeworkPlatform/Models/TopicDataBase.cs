using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeworkPlatform.Models
{
    public class TopicDataBase
    {
        private IMongoDatabase database = null;
        private MongoClient dbClient;
        private string user;
        private string pass;
        private string connect;
        private string db;
        private string collection = "topic";

        public TopicDataBase()
        {
            System.IO.StreamReader file = new System.IO.StreamReader("../DataBaseInfo.txt");
            user = file.ReadLine();
            pass = file.ReadLine();
            connect = file.ReadLine();
            db = file.ReadLine();
            file.Close();
        }
        public List<TopicDocument> getAllTopics()
        {
            var collectionTopic = database.GetCollection<TopicDocument>(collection);
            var document = collectionTopic.Find(Builders<TopicDocument>.Filter.Empty).ToList();
            document.Sort((x, y) => DateTime.Compare(y.Date, x.Date));
            return document;
        }
        public Boolean accessDataBase()
        {
            try
            {
                dbClient = new MongoClient(connect);
                database = dbClient.GetDatabase(db);
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }
    }
}