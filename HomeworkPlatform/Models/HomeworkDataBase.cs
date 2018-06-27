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
            dataBase = dbClient.GetDatabase(db);
            file.Close();
        }

        public Boolean insertHomwork()
        {
            Boolean value;
            if (!accessHomeworkDataBase()) return false;
            try
            {
                    var collectionAccount = dataBase.GetCollection<BsonDocument>(collection);
                    //collectionAccount.InsertOne(new BsonDocument { { "account", txtboxaccount.Text }, { "departmentage", txtboxdepartmentage.Text }, { "email", txtboxemail.Text }, { "name", txtboxname.Text }, { "password", txtboxpassword.Text }, { "studentnumber", txtboxstudentnumber.Text } });
                    value = true;
            }
            catch (Exception err)
            {
                value = false;
            }
            return value;
        }

        public Boolean pageDefault()
        {
            IMongoCollection<BsonDocument> collectionHome;
            try
            {
                collectionHome = dataBase.GetCollection<BsonDocument>("homwork");

                int j = 0;
                homeworktype = new List<string>();

                var result = collectionHome.Find(_ => true).ToList();

                for (int i = 0; i < result.Count; ++i)
                {
                    string homty = result[i].ToString();
                    String[] cut = homty.Split(new char[5] { ',', ':', '"', ' ', '\n' });
                    for (int l = 0; l < cut.Length; ++l)
                    {
                        if (cut[l] == "homeworktype")
                        {
                            l = l + 1;
                            while (cut[l] == "")
                            {
                                l = l + 1;
                            }
                            homty = cut[l];
                            break;
                        }
                    }
                    int k;
                    for (k = 0; k < i; ++k)
                    {
                        if (homty == homeworktype[k])
                        {
                            break;
                        }
                    }
                    if (k == i)
                    {
                        homeworktype.Add(homty);
                    }
                }

            }
            catch (Exception err)
            {







            }
            return true;
        }

        public Boolean getHomework()
        {
            Boolean value;
            if (!accessHomeworkDataBase()) return false;
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

        public Boolean accessHomeworkDataBase()
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