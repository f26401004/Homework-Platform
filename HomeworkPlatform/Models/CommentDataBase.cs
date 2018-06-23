using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HomeworkPlatform.Models
{
    public class CommentDataBase
    {
        private int id { get; set; }
        private int hId { get; set; }
        private string account { get; set; }
        private string comment { get; set; }

        private IMongoDatabase dataBase = null;
        private MongoClient dbClient;
        private string user;
        private string pass;
        private string connect;
        private string db;
        private string collection = "comment";

        public CommentDataBase()
        {
            System.IO.StreamReader file = new System.IO.StreamReader("../../DataBaseInfo.txt");
            user = file.ReadLine();
            pass = file.ReadLine();
            connect = file.ReadLine();
            db = file.ReadLine();
            file.Close();
        }

        public Boolean insertComment()
        {
            Boolean value;
            if (!accessCommentDataBase()) return false;
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

        public Boolean getAllComment()
        {
            if (!accessCommentDataBase()) return false;
            try
            {
                var collectionAccount = dataBase.GetCollection<BsonDocument>("hid");
                var result = collectionAccount.Find(_ => true).ToListAsync();
                return true;
            }catch(Exception err)
            {
                return false;
            }
        }

        public Boolean accessCommentDataBase()
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