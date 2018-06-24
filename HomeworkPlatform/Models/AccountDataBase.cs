using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HomeworkPlatform.Models
{
    public class AccountDataBase
    {
        public int id { get; set; }
        public string email { get; set; }
        private string password { get; set; }
        private string departmentAge { get; set; }
        private string studentNumber { get; set; }
        private string name { get; set; }

        private string command=null;
        private IMongoDatabase dataBase = null;
        private MongoClient dbClient;
        private string user;
        private string pass;
        private string connect;
        private string db;
        private string collection = "account";

        public AccountDataBase()
        { 
            System.IO.StreamReader file = new System.IO.StreamReader("../DataBaseInfo.txt");
            user = file.ReadLine();
            pass = file.ReadLine();
            connect = file.ReadLine();
            db = file.ReadLine();
            file.Close();
        }

        public Boolean insertAccount()
        {
            Boolean value;
            if (!accessAccountDataBase()) return false;
            try {
                if (!checkAccount()) value = false;
                else
                {
                    var collectionAccount = dataBase.GetCollection<BsonDocument>(collection);
                    //collectionAccount.InsertOne(new BsonDocument { { "account", txtboxaccount.Text }, { "departmentage", txtboxdepartmentage.Text }, { "email", txtboxemail.Text }, { "name", txtboxname.Text }, { "password", txtboxpassword.Text }, { "studentnumber", txtboxstudentnumber.Text } });
                    value = true;
                }
            } catch(Exception err)
            {
                value = false;
            }
            return value;
        }

        public Boolean checkAccount()
        {
            Boolean value;
            if (!accessAccountDataBase()) return false;
            var collectionAccount = dataBase.GetCollection<BsonDocument>("account");
            var search = new BsonDocument("account", "admin"/*accountinput*/);
            var result = collectionAccount.Find(search).ToList();
            if (result.Count==1)
            {
                value=true;
            }
            value=false;
            return value;
        }

        public Boolean accessAccountDataBase()
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