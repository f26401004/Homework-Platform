using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HomeworkPlatform.Models
{
    public class HomeworkDataBase
    {
        private int id { get; set; }
        private string author { get; set; }
        private string title { get; set; }
        private string content { get; set; }
        private int like { get; set; }
        private int people { get; set; }
        private int score { get; set; }
        //time homework homeworktype

        private string command = null;
        private IMongoDatabase dataBase = null;
        private MongoClient dbClient;
        private string user;
        private string pass;
        private string connect;
        private string db;
        private string collection = "homework";

        public HomeworkDataBase()
        {
            System.IO.StreamReader file = new System.IO.StreamReader("../../DataBaseInfo.txt");
            user = file.ReadLine();
            pass = file.ReadLine();
            connect = file.ReadLine();
            db = file.ReadLine();
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
            if (dataBase == null) return false;
            if (!accessHomeworkDataBase()) return false;
            var collectionAccount = dataBase.GetCollection<BsonDocument>("hit");
            var result = collectionAccount.Find(_ => true).ToListAsync();
            return true;
        }

        public Boolean getHomework()
        {
            Boolean value;
            if (!accessHomeworkDataBase()) return false;
            var collectionAccount = dataBase.GetCollection<BsonDocument>("id");
            var search = new BsonDocument("id", /*accountinput*/);
            var result = collectionAccount.Find(search).ToList();
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
    }
}