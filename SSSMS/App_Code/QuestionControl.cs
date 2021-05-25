using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SSSMS.App_Code
{
    public class QuestionControl
    {
        private int id;
        private int survey_id;
        private int question_type;
        private string question_name;
        private int quesiton_sort;
        public QuestionControl()
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

        public int GetQuestion_type()
        {
            return question_type;
        }

        public void SetQuestion_type(int value)
        {
            question_type = value;
        }

        public string GetQuestion_name()
        {
            return question_name;
        }

        public void SetQuestion_name(string value)
        {
            question_name = value;
        }

        public int GetQuesiton_sort()
        {
            return quesiton_sort;
        }

        public void SetQuesiton_sort(int value)
        {
            quesiton_sort = value;
        }

        public bool Insert2DataTable(DataTable dt)
        {
            try
            {
                DataRow dr = dt.NewRow();
                dr["survey_id"] = survey_id;
                dr["question_type"] = question_type;
                dr["question_name"] = question_name;
                dr["quesiton_sort"] = quesiton_sort;
                dt.Rows.Add(dr);
            }
            catch (Exception ee)
            {
                return false;
            }
            return true;
        }
        public static DataTable CreateDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("survey_id", typeof(int)));
            dt.Columns.Add(new DataColumn("question_type", typeof(int)));
            dt.Columns.Add(new DataColumn("question_name", typeof(string)));
            dt.Columns.Add(new DataColumn("quesiton_sort", typeof(int)));
            return dt;
        }
        public static DataTable GetDataTable(string tablename="Question",string limit=null)
        {
            string sql = "select * from [dbo].[" + tablename + "]";
            if (limit != null)
                sql = sql + limit;
            return DB.getData(sql);
        }
        public static bool SaveDataTable(DataTable dt,int sid)
        {
            int count = dt.Rows.Count;
            for(int i=0;i<count;i++)
            {
                string sql = "insert into [dbo].[Question]  (survey_id,question_type,question_name,question_sort) values ('"
               + sid + "','"
               + dt.Rows[i]["question_type"] + "','"
               + dt.Rows[i]["question_name"] + "','"
               + dt.Rows[i]["question_sort"] + "')";
                
                if(!DB.Insert(sql))
                {
                    return false;
                }

            }
            return true;

        }
        public static  bool Insert(QuestionControl q,string dataname="Question")
        {
            string sql = "insert into [dbo].["+dataname+"]  (survey_id,question_type,question_name,question_sort) values ('"
                + q.survey_id + "','"
                + q.question_type + "','"
                + q.question_name + "','"
                + q.quesiton_sort + "')";

            return DB.Insert(sql);
        }
        public static bool Delete(int survey_id)
        {
            string sql = "delete from [dbo].[Question] where survey_id='" + survey_id + "'";
            return DB.Delete(sql)&&OptionControl.Delete(survey_id);
        }
    }
}