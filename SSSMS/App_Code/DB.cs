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
    public class DB
    {
        public DB()
        {
        }

        private static string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DataBase"].ToString();
        }
        //打开数据库连接
        public static SqlConnection Open()
        {
            try
            {
                SqlConnection cnt = new SqlConnection(getConnectionString());
                cnt.Open();
                return cnt;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
        //关闭数据库
        public static void Close(SqlConnection cnt)
        {
            if (cnt != null)
            {
                try
                {
                    cnt.Close();
                    cnt.Dispose();
                }
                catch (Exception ee)
                {
                    throw new Exception(ee.Message);
                }
            }
        }
        // 搜索数据库
        public static SqlDataReader Search(string sql)
        {
            SqlConnection cnt = Open();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cnt);
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
        //检查数据
        public static bool IsExist(string tablename, string key, string keyvalue)
        {
            SqlConnection cnt = Open();
            string sql = "select * from [dbo].[" + tablename + "] where " + key + "='" + keyvalue + " ' ";
            SqlCommand cmd = new SqlCommand(sql, cnt);
            SqlDataReader reader = cmd.ExecuteReader();
            bool res = reader.Read();
            reader.Close();
            if (res)
                return true;
            else
                return false;
        }
        //插入数据
        public static bool Insert(string sql)
        {
            SqlConnection cnt = Open();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cnt);
                if (cmd.ExecuteNonQuery() == 0)
                    return false;
                else
                    return true;

            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
            finally
            {
                Close(cnt);
            }
        }
        //从数据库中获得数据
        public static DataTable getData(string sql)
        {
            SqlConnection cnt = Open();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cnt);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
            finally
            {
                Close(cnt);
            }
        }
        //从DataTable内容筛数据
        public static DataTable getData(DataTable dt,string exp)
        {
            DataRow[] dataRows;
            DataTable subdt = dt.Clone();
            try
            {
               dataRows=dt.Select(exp);
                int len = dataRows.Length;
                for(int i=0;i<len;i++)
                {
                    subdt.ImportRow(dataRows[i]);
                }
            }
            catch(Exception ee)
            {
                throw new Exception(ee.Message);
            }
            return subdt;
        }
        //动态生成DropDownList
        public static void SetDropDownList(DropDownList ddl,
            string tablename,
            string value,
            string text,
            int index = -1,
            string indexText = null,
            string prompt = null,
            string limit = null)
        {
            if (ddl.Items.Count > 0)
                ddl.Items.Clear();
            string sql = "select * from [dbo].[" + tablename + "] ";
            if (limit != null)
            {
                sql = sql + limit;
            }
            DataTable itemlist = DB.getData(sql);
            int len = itemlist.Rows.Count;
            if (len > 0)
            {
                ddl.DataSource = itemlist;//绑定数据源
                ddl.DataValueField = itemlist.Columns[value].ToString();//绑定数据项Value
                ddl.DataTextField = itemlist.Columns[text].ToString();//绑定数据项Text
                ddl.DataBind();//绑定
            }
            ddl.Items.Add(new ListItem("--请选择" + prompt + "--", ""));//填充请【选择项】
            if (index == -1)
                ddl.SelectedIndex = ddl.Items.Count - 1;//选中【请选择】项
            else
                ddl.SelectedValue = index.ToString();
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].Text.Equals(indexText))
                {
                    ddl.SelectedIndex = i;
                }
            }
        }

        //删除
        public static bool Delete(string sql)
        {
            SqlConnection cnt = Open();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cnt);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            finally
            {
                Close(cnt);
            }

        }
        //清空表
        public static bool Truncate(string tablename)
        {
            string sql = "truncate  table [dbo].[" + tablename + "]";
            int count = 0;
            DataTable dt = new DataTable();
            SqlConnection cnt = Open();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cnt);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                count = adapter.Fill(dt);
                if (count == 0)
                    return true;
                else
                    return false;
            }
            finally
            {
                Close(cnt);
            }
        }
        //更新
        public static bool Update(string sql)
        {
            SqlConnection cnt = Open();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cnt);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            finally
            {
                Close(cnt);
            }

        }
        
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}