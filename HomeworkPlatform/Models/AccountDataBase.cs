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
        private int id;
        private string email;
        private string password;
        private string departmentAge;
        private string studentNumber;
        private string name;

        private string command = null;
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
        /*
        public Boolean insertAccount()
        {
            Boolean value;
            if (!accessDataBase()) return false;
            try {
                if (!checkAccount()) value = false;
                else
                {
                    var collectionAccount = dataBase.GetCollection<BsonDocument>(collection);
                    //collectionAccount.InsertOne(new BsonDocument { { "account", txtboxaccount.Text }, { "departmentage", txtboxdepartmentage.Text }, { "email", txtboxemail.Text }, { "name", txtboxname.Text }, { "password", txtboxpassword.Text }, { "studentnumber", txtboxstudentnumber.Text } });
                    value = true;
                }
            } catch (Exception err)
            {
                value = false;
            }
            return value;
        }
        */
        public ApplicationUser find(string userName)
        {
            if (!accessDataBase())
                return null;
            var collectionAccount = dataBase.GetCollection<ApplicationUser>("account");
            var result = collectionAccount.Find(Builders<ApplicationUser>.Filter.Eq(x => x.UserName, userName)).ToList().ElementAt(0);
            
            return result;
        }
        public Boolean checkAccount(string userName)
        {
            if (!accessDataBase()) return false;
            var collectionAccount = dataBase.GetCollection<ApplicationUser>("account");
            var result = collectionAccount.Find(Builders<ApplicationUser>.Filter.Eq(x => x.UserName, userName)).ToList();
            return (result.Count >= 1);
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
        public string getEmail()
        {
            return email;
        }
        public void setEmail(string Email)
        {
            email = Email;
        }
        public string getName()
        {
            return name;
        }
        public void setName(string Name)
        {
            name = Name;
        }
        public string getPassword()
        {
            return password;
        }
        public void setPassword(string Pass)
        {
            password = Pass;
        }
        public string getDepartmentAge()
        {
            return departmentAge;
        }
        public void setDepartmentAge(string Department)
        {
            departmentAge = Department;
        }
        public string getStudentNumber()
        {
            return studentNumber;
        }
        public void setStudentNumber(string Student)
        {
            studentNumber = Student;
        }
    }
}