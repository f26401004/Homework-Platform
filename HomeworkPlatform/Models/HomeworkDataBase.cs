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

        public Boolean insertHomwork(HomeworkModel model)
        {
            Boolean value;
            if (!accessDataBase()) return false;
            try
            {
                var collectionAccount = dataBase.GetCollection<BsonDocument>(collection);
                collectionAccount.InsertOne(new BsonDocument { {"Title", model.Title}, { "Content", model.Content }, { "Author", model.Author.StudentID }, { "DepartmentAge", model.Author.DepartmentAge }, { "Email", model.Author.Email },
                    { "UserName", model.Author.UserName },  { "ServerFilePath", model.ServerFilePath }, { "Score", model.Score } });
                value = true;
            }
            catch (Exception err)
            {
                value = false;
            }
            return value;
        }

        

        public Boolean getHomework()
        {
            Boolean value;
            if (!accessDataBase()) return false;
            var collectionHomework = dataBase.GetCollection<BsonDocument>("id");
            var search = new BsonDocument("id", "test"/*accountinput*/);
            var result = collectionHomework.Find(search).ToList();
            if (result.Count == 1)
            {
                value = true;
            }
            value = false;
            return value;
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