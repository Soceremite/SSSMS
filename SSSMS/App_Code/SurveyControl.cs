using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SSSMS.App_Code
{
    public class SurveyControl
    {
        private int id;
        private string title;
        private string description;
        private int author_id;
        private string create_date;
        private string start_date;
        private string end_date;
        private int status;

        public int GetId()
        {
            return id;
        }

        public void SetId(int value)
        {
            id = value;
        }

        public SurveyControl()
        {

        }
        public string GetCreate_date()
        {
            return create_date;
        }

        public void SetCreate_date(string value)
        {
            create_date = value;
        }

        public string GetStart_date()
        {
            return start_date;
        }

        public void SetStart_date(string value)
        {
            start_date = value;
        }

        public string GetEnd_date()
        {
            return end_date;
        }

        public void SetEnd_date(string value)
        {
            end_date = value;
        }

        public int GetStatus()
        {
            return status;
        }

        public void SetStatus(int value)
        {
            status = value;
        }

        public string GetTitle()
        {
            return title;
        }

        public void SetTitle(string value)
        {
            title = value;
        }

        public string GetDescription()
        {
            return description;
        }

        public void SetDescription(string value)
        {
            description = value;
        }

        public int GetAuthor_id()
        {
            return author_id;
        }

        public void SetAuthor_id(int value)
        {
            author_id = value;
        }
        public bool GetSurveyByIdFromDataBase()
        {
            string sql = "select * from [dbo].[Survey] where id= '"
                + id + "'";
            DataTable dt = DB.getData(sql);
            if (dt.Rows.Count != 1)
                return false;
            title=dt.Rows[0]["title"].ToString();
            description = dt.Rows[0]["description"].ToString();
            author_id = int.Parse(dt.Rows[0]["author_id"].ToString());
            create_date = dt.Rows[0]["create_date"].ToString();
            start_date = dt.Rows[0]["start_date"].ToString();
            end_date = dt.Rows[0]["end_date"].ToString();
            status = int.Parse(dt.Rows[0]["status"].ToString());
            return true;
    }
        public  int GetIdFromDataBase()
        {
            string sql = "select * from [dbo].[Survey] where title= '"
                + title + "' and start_date='"
                + start_date + "'";
            DataTable dt=DB.getData(sql);
            return int.Parse(dt.Rows[0]["id"].ToString());
        }
        public static bool Insert(SurveyControl s)
        {
            string sql = "insert into [dbo].[Survey]  (title,description,author_id,create_date,start_date,end_date) values ('"
                + s.title + "','"
                + s.description + "','"
                + s.author_id + "','"
                + s.create_date + "','"
                + s.start_date + "','"
                + s.end_date + "')";
            return DB.Insert(sql);
        }
        public static bool Delete(int id)
        {
            string sql = "delete from [dbo].[Survey] where id='" + id + "'";
            return DB.Delete(sql) && QuestionControl.Delete(id);
        }
        public  bool Update()
        {
            string sql = "update  [dbo].[Survey] set title='"
                + title + "' , description='"
                + description + "' , start_date='"
                + start_date + "' , end_date='"
                + end_date + "' where id='"
                + id + "'";
            return DB.Update(sql);
        }
        public static DataTable GetDataTable(string tablename="Survey",string limit=null)
        {
            string sql = "select * from [dbo].[" + tablename + "] ";
            if (limit != null)
                sql = sql + limit;
            return DB.getData(sql);
        }
        public static bool UpdateStatus(string id,string status)
        {
            string sql = "update [dbo].[Survey]  set status = '" + status + "' where id = '" + id + "'";
             return DB.Update(sql);
        }
        public  bool SaveEditSurvey()
        {
            string sql = "update  [dbo].[Survey] set title='"
                + title + "' , description='"
                + description + "' , start_date='"
                + start_date + "' , end_date='"
                + end_date + "' where id='"
                + id+"'";
            return DB.Update(sql);
        }
    }
}