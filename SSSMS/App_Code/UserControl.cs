using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SSSMS.App_Code
{
    public class UserControl
    {
        private int id;
        private string username;
        private string passwd;
        private int type;
        private string stuid;
        private string img;
        
        public UserControl()
        {
            id = 0;
            username = "Customer";
            type = 2;
            img = "/Source/img/头像.png";
        }

        public UserControl(string name,string password)
        {
            username = name;
            passwd = password;
            string sql = "select * from [dbo].[User] where username='" + name + "'and passwd='" + password + "'";
            DataTable dt = DB.getData(sql);
            if(dt.Rows.Count>0)
            {
                id = int.Parse(dt.Rows[0]["id"].ToString());
                type = int.Parse(dt.Rows[0]["type"].ToString());
                stuid = dt.Rows[0]["stuid"].ToString();
                img = dt.Rows[0]["img"].ToString();
                if(img.Equals(""))
                {
                    img = "/Source/img/头像.png";
                }
            }
        }
        public void setid(int value)
        {
            id = value;
        }
        public int getid()
        {
            return id;
        }
        public void setusername(string name)
        {
            username = name;
        }
        public string getusername()
        {
            return username;
        }
        public void setpasswd(string password)
        {
            passwd = password;
        }
        public string getpasswd()
        {
            return passwd;
        }
        public void settype(int t)
        {
            type =t;
        }
        public int gettype()
        {
            return type;
        }
        public void setstuid(string id)
        {
            stuid = id;
        }
        public string getstuid()
        {
            return stuid;
        }
        public void setimg(string url)
        {
            img = url;
        }
        public string getimg()
        {
            return img;
        }
        public string getidentity()
        {
            string identity="Customer";
            switch(type)
            {
                case 0: identity = "Adminstrator";break;
                case 1: identity = "User";break;
                default:identity = "Customer";break;
            }
            return identity;
            
        }
        public static  bool Search(string name, string password)
        {
            string  sql="select * from [dbo].[User] where username='" + name+ "'and passwd='" + password + "'";
            SqlDataReader reader = DB.Search(sql);
            if (reader.Read())
                return true;
            else
                return false;
        }
        public static string GetUserName(string id)
        {
            string sql = "select * from [dbo].[User] where id='" + id + "'";
            DataTable dt = DB.getData(sql);
            return dt.Rows[0]["username"].ToString();
        }
    }
}