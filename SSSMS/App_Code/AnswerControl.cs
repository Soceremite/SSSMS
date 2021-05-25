using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI.WebControls;

namespace SSSMS.App_Code
{
    public class AnswerControl
    {
        private int id;
        private int answer_id;
        private int question_id;
        private string content;
        public AnswerControl()
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

        public int GetAnswer_id()
        {
            return answer_id;
        }

        public void SetAnswer_id(int value)
        {
            answer_id = value;
        }

        public int GetQuestion_id()
        {
            return question_id;
        }

        public void SetQuestion_id(int value)
        {
            question_id = value;
        }

        public string GetContent()
        {
            return content;
        }
        public void SetContent(string value)
        {
            content = value;
        }

        public static DataTable GetDataTable(string tablename = "Answer", string limit = null)
        {
            string sql = "select * from [dbo].[" + tablename + "]";
            if (limit != null)
                sql = sql + limit;
            return DB.getData(sql);
        }
        public static bool SaveDataTable(DataTable dt, int sid)
        {
            int count = dt.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                string sql = "insert into [dbo].[Question]  (answer_id,question_id,[content]) values ('"
               + sid + "','"
               + dt.Rows[i]["answer_id"] + "','"
               + dt.Rows[i]["question_id"] + "','"
               + dt.Rows[i]["[content]"] + "')";

                if (!DB.Insert(sql))
                {
                    return false;
                }

            }
            return true;

        }
        public static bool Insert(AnswerControl a, string dataname = "Answer")
        {
            string sql = "insert into [dbo].[" + dataname + "]  (answer_id,question_id,[content]) values ('"
                + a.answer_id + "','"
                + a.question_id + "','"
                + a.content + "')";

            return DB.Insert(sql);
        }

        public static bool Delete(int answer_id)
        {
            string sql = "delete from [dbo].[Answer] where answer_id='" + answer_id + "'";
            return DB.Delete(sql);
        }

        public static string NumberOption(int count, string Survey_id)
        {
            SqlConnection cnt = DB.Open();
            string sql = "select count(*) from [Question] inner join[Option] on Question.question_sort =[Option].question_id and Question.survey_id =[Option].survey_id where[Option].question_id = '" + count + "' and[Option].survey_id = '" + Survey_id + "'";
            SqlCommand cmd = new SqlCommand(sql, cnt);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            String number = dt.Rows[0][0].ToString();
            return number;
        }
        public static String GetQuestionType(int count, String Survey_id)
        {
            SqlConnection cnt = DB.Open();
            string sql = "select Question.question_type from [Question] where Question.question_sort = '" + count + "' and Question.survey_id = '" + Survey_id + "'";
            SqlCommand cmd = new SqlCommand(sql, cnt);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            String number = dt.Rows[0][0].ToString();
            return number;
        }

        public static String GetContent(String Survey_id, String user_id, String question_id)
        {
            SqlConnection cnt = DB.Open();
            String sql = "select [content] from Answer  inner join  Sub_Answer on Answer.Id=Sub_Answer.answer_id  where survey_id='" + Survey_id + "' and user_id='" + user_id + "' and question_id='" + question_id + "'";
            SqlCommand cmd = new SqlCommand(sql, cnt);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            String content = dt.Rows[0][0].ToString();
            return content;
        }



        public static bool insert(String Survey_id, String question_id, String Option, String user_id)
        {
            SqlConnection cnt = DB.Open();
            String str = "select Id from Answer where survey_id='" + Survey_id + "' and user_id='" + user_id + "'";
            SqlCommand cmd = new SqlCommand(str, cnt);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            String id = dt.Rows[0][0].ToString();
            cnt.Close();

            String sql = "insert into Sub_Answer  (answer_id,question_id,[content]) values ('"
                + id + "','"
                + question_id + "','"
                + Option + "') ";
            return DB.Insert(sql);
        }


        public static bool insertdate(String Survey_id, String user_id, DateTime date)
        {
            String sql = "insert into Answer (survey_id,user_id,create_date) values ('"
                + Survey_id + "','"
                + user_id + "','"
                + date + "') ";
            return DB.Insert(sql);
        }
        public static bool updatedate(String Survey_id, String user_id, DateTime date)
        {
            String sql = "update  Answer set create_date='" + date + "' where survey_id='" + Survey_id + "' and user_id='" + user_id + "'";
            return DB.Update(sql);
        }

        public static bool update(String Survey_id, String question_id, String Option, String user_id)
        {
            SqlConnection cnt = DB.Open();
            String str = "select Id from Answer where survey_id='" + Survey_id + "' and user_id='" + user_id + "'";
            SqlCommand cmd = new SqlCommand(str, cnt);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            String id = dt.Rows[0][0].ToString();
            cnt.Close();

            String sql = "update Sub_Answer set [content]='" + Option + "' where answer_id='" + id + "' and question_id='" + question_id + "'";
            return DB.Update(sql);
        }
    }
}