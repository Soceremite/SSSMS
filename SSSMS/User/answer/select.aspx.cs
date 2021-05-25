using SSSMS.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSSMS.User.answer
{
    public partial class select : System.Web.UI.Page
    {
        protected void bind()
        {
            DataTable dt1 = SurveyControl.GetDataTable(limit: "where status='1'");
            GridView1.DataSource = dt1;
            GridView1.DataKeyNames = new string[] { "id" };
            GridView1.DataBind();
            //修改button text
            int count = dt1.Rows.Count;
            string user_id = Session["currentid"].ToString();
            for (int i = 0; i < count; i++)
            {
                Button bt = GridView1.Rows[i].FindControl("btanswer") as Button;
                string survey_id =((Label) GridView1.Rows[i].FindControl("lbid")).Text;
                string sql = "select * from [dbo].[Answer] where survey_id='" + survey_id + "' and user_id='" + user_id + "'";
                SqlDataReader search = DB.Search(sql);
                if(search.HasRows)
                {
                    bt.Text = "修改";
                }
            }


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
                Session["survey_id"] = null;
            }
        }
        protected void Answer_Click(object sender, EventArgs e)
        {
            string id = ((Label)((GridViewRow)((Button)sender).NamingContainer).FindControl("lbid")).Text.ToString();
            Session["survey_id"] = id;
            string user_id = Session["currentid"].ToString();
            string sql = "select * from [dbo].[Answer] where survey_id='" + id + "' and user_id='" + user_id + "'";
            SqlDataReader search = DB.Search(sql);
            if (search.HasRows)
            {
                Session["writed"] = 1;
                Response.Write("<script>window.open('/User/answer/answer.aspx','_blank')</script>");
            }
            else
            {
                Session["writed"] = 0;
                Response.Write("<script>window.open('/User/answer/answer.aspx','_blank')</script>");
            }

        }
    }
}