using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace HomeworkPlatform.Models
{
    public class HomeworkDataBase
    {
        private int id;
        private string author;
        private string title;
        private string content;
        private int like;
        private int people;
        private int score ;
        //time homework homeworktype

        private string command = null;
        private IMongoDatabase dataBase = null;
        private MongoClient dbClient;
        private string user;
        private string pass;
        private string connect;
        private string db;
        private string collection = "homework";
        private List<string> homeworktype;

        public HomeworkDataBase()
        {
            System.IO.StreamReader file = new System.IO.StreamReader("../DataBaseInfo.txt");
            user = file.ReadLine();
            pass = file.ReadLine();
            connect = file.ReadLine();
            db = file.ReadLine();
            file.Close();
        }

        public Boolean insertHomwork(HomeworkModel model, string Author, string TopicId, string FileName)
        {
            Boolean value = false;
            if (!accessDataBase()) return false;
            try
            {
                var collectionAccount = dataBase.GetCollection<BsonDocument>(collection);
                
                collectionAccount.InsertOne(new BsonDocument { { "TopicId", TopicId} ,{"Title", model.Title}, { "Content", model.Content },
                    { "Author", Author }, { "ServerFilePath", FileName }, { "Score", model.Score }, { "Time", DateTime.Now.ToString()}
                , { "Visits", 0 }, {"Like", 0 } });
                value = true;
            }
            catch (Exception err)
            {
                value = false;
            }
            return value;
        }

        

        public List<HomeworkModel> getHomeworkByTopicId(string id)
        {
            if (!accessDataBase())
                return null;
            var collectionHomework = dataBase.GetCollection<HomeworkModel>(collection);
            try
            {
                var result = collectionHomework.Find(Builders<HomeworkModel>.Filter.Eq(x => x.TopicId, id)).ToList();
                return result;
            }
            catch (Exception e) {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return null;
            
        }
        public HomeworkModel getHomeworkById(string id)
        {
            if (!accessDataBase())
                return null;
            var collectionHomework = dataBase.GetCollection<HomeworkModel>(collection);
            try
            {
                var result = collectionHomework.Find(Builders<HomeworkModel>.Filter.Eq(x => x.HomeworkId, ObjectId.Parse(id))).ToList();
                return result.ElementAt(0);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return null;

        }

        public Boolean accessDataBase()
        {
            try
            {
                dbClient = new MongoClient(connect);
                dataBase = dbClient.GetDatabase(db);
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }
        public int getId()
        {
            return id;
        }
        public void setId(int Id)
        {
            id = Id;
        }
        public string getTitle()
        {
            return title;
        }
        public void setTitle(string Title)
        {
            title = Title;
        }
        public string getContent()
        {
            return content;
        }
        public void setContent(string Content)
        {
            content = Content;
        }
        public string getAuthor()
        {
            return author;
        }
        public void setAuthor(string Author)
        {
            author = Author;
        }
        public int getLike()
        {
            return like;
        }
        public void setLike(int Like)
        {
            like = Like;
        }
        public int getPeople()
        {
            return people;
        }
        public void setPeople(int People)
        {
            people = People;
        }
        public int getScore()
        {
            return score;
        }
        public void setScore(int Score)
        {
            score = Score;
        }
    }
}