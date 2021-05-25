using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SSSMS.App_Code
{
    public class OptionControl
    {
        private int id;
        private int survey_id;
        private int question_id;
        private string option_name;
        private int option_sort;
        public OptionControl()
        {

        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int value)
        {
            id = value;
        }

        public int GetSurvey_id()
        {
            return survey_id;
        }

        public void SetSurvey_id(int value)
        {
            survey_id = value;
        }

        public int GetQuestion_id()
        {
            return question_id;
        }

        public void SetQuestion_id(int value)
        {
            question_id = value;
        }

        public string GetOption_name()
        {
            return option_name;
        }

        public void SetOption_name(string value)
        {
            option_name = value;
        }

        public int GetOption_sort()
        {
            return option_sort;
        }

        public void SetOption_sort(int value)
        {
            option_sort = value;
        }

        public static DataTable GetDataTable(string tablename = "Option",string limit=null)
        {
            string sql = "select * from [dbo].[" + tablename + "] ";
            if (limit != null)
                sql = sql + limit;
            return DB.getData(sql);
        }
        public static bool SaveDataTable(DataTable dt, int sid)
        {
            int count = dt.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                string sql = "insert into [dbo].[Option]  (survey_id,question_id,option_name,option_sort) values ('"
               + sid + "','"
               + dt.Rows[i]["question_id"] + "','"
               + dt.Rows[i]["option_name"] + "','"
               + dt.Rows[i]["option_sort"] + "')";

                if (!DB.Insert(sql))
                {
                    return false;
                }

            }
            return true;

        }

        public static bool Insert(OptionControl oc,string dataname="Option")
        { 
            string sql = "insert into [dbo].["+dataname+"]  (survey_id,question_id,option_name,option_sort) values ('"
                + oc.survey_id + "','"
                + oc.question_id + "','"
                + oc.option_name + "','"
                + oc.option_sort + "')";

            return DB.Insert(sql);
        }
        public static bool Delete(int survey_id)
        {
            string sql="delete from [dbo].[Option] where survey_id='" + survey_id+ "'";
            return DB.Delete(sql);
        }
    }
}