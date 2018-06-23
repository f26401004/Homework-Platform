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
        private int id;
        private int hId;
        private string account;
        private string comment;

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
        public int getId()
        {
            return id;
        }
        public void setId(int Id)
        {
            id = Id;
        }
        public int getHId()
        {
            return hId;
        }
        public void setHId(int HId)
        {
            hId = HId;
        }
        public string getAccount()
        {
            return account;
        }
        public void setAccount(string Account)
        {
            account = Account;
        }
        public string getComment()
        {
            return comment;
        }
        public void setComment(string Comment)
        {
            comment = Comment;
        }
    }
}