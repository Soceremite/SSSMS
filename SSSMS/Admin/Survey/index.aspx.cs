using SSSMS.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSSMS.Survey
{
    public partial class index : System.Web.UI.Page
    {
        protected void bind()
        {
            DataTable dt1 = SurveyControl.GetDataTable(limit:"where status='0'"); 
            gv1.DataSource = dt1;
            gv1.DataKeyNames = new string[] { "id" };
            gv1.DataBind();
            DataTable dt2 = SurveyControl.GetDataTable(limit: "where status='1'");
            gv2.DataSource = dt2;
            gv2.DataKeyNames = new string[] { "id" };
            gv2.DataBind();
            DataTable dt3 = SurveyControl.GetDataTable(limit: "where status='-1'");
            gv3.DataSource = dt3;
            gv3.DataKeyNames = new string[] { "id" };
            gv3.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bind();
                Session["edit_survey_id"] = null;
                Session["preview_survey_id"] = null;
            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SurveyControl survey = new SurveyControl();
            
            int id=int.Parse(gv1.DataKeys[e.RowIndex].Value.ToString());

            if (SurveyControl.Delete(id))
            {
                Response.Write(@"<script>alert('删除成功');</script> <script>window.location ='/Admin/Survey/index.aspx'</script>");
            }
            else
            {
                Response.Write(@"<script>alert('删除失败');</script>");
                return;
            }
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Session["edit_survey_id"] = gv1.DataKeys[e.NewEditIndex].Value.ToString();
            Session["edit_author_id"] = ((Label)gv1.Rows[e.NewEditIndex].FindControl("lbauthor_id")).Text;
            Response.Write("<script>window.open('/Admin/Survey/edit.aspx','_blank')</script>");
        }
        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SurveyControl survey = new SurveyControl();

            int id = int.Parse(gv2.DataKeys[e.RowIndex].Value.ToString());

            if (SurveyControl.Delete(id))
            {
                Response.Write(@"<script>alert('删除成功');</script> <script>window.location ='/Admin/Survey/index.aspx'");
            }
            else
            {
                Response.Write(@"<script>alert('删除失败');</script>");
                return;
            }
        }
        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Session["edit_survey_id"] = gv2.DataKeys[e.NewEditIndex].Value.ToString();
            Session["edit_author_id"] = ((Label)gv2.Rows[e.NewEditIndex].FindControl("lbauthor_id")).Text;
            Response.Write("<script>window.open('/Admin/Survey/edit.aspx','_blank')</script>");
        }
        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SurveyControl survey = new SurveyControl();

            int id = int.Parse(gv3.DataKeys[e.RowIndex].Value.ToString());

            if (SurveyControl.Delete(id))
            {
                Response.Write(@"<script>alert('删除成功');</script> <script>window.location ='/Admin/Survey/index.aspx'</script>");
            }
            else
            {
                Response.Write(@"<script>alert('删除失败');</script>");
                return;
            }
        }
        protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Session["edit_survey_id"] = gv3.DataKeys[e.NewEditIndex].Value.ToString();
            Session["edit_author_id"] = ((Label)gv3.Rows[e.NewEditIndex].FindControl("lbauthor_id")).Text;
            Response.Write("<script>window.open('/Admin/Survey/edit.aspx','_blank')</script>");
        }
        protected void Audit_Click(object sender, EventArgs e)
        {
            int row = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
            string id = ((Label)gv1.Rows[row].FindControl("lbid")).Text;
            if(SurveyControl.UpdateStatus(id, "1"))
                Response.Write(@"<script>alert('审核通过');</script><script>window.location ='/Admin/Survey/index.aspx'</script>");
            else
            {
                Response.Write(@"<script>alert('审核无法通过');</script>");
                return;
            }
        }
        protected void Preview_Click(object sender, EventArgs e)
        {
            string id=((Label)((GridViewRow)((Button)sender).NamingContainer).FindControl("lbid")).Text.ToString();
            Session["preview_survey_id"] = id;
            Response.Write("<script>window.open('/Admin/Survey/preview.aspx','_blank')</script>");
        }
        protected void Ban_Click(object sender, EventArgs e)
        {
            int row = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
            string id = ((Label)gv2.Rows[row].FindControl("lbid")).Text;
            if (SurveyControl.UpdateStatus(id, "-1"))
                Response.Write(@"<script>alert('停止成功');</script><script>window.location ='/Admin/Survey/index.aspx'</script>");
            else
            {
                Response.Write(@"<script>alert('停止失败');</script>");
                return;
            }
        }
        protected void UnBan_Click(object sender, EventArgs e)
        {
            int row = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
            string id = ((Label)gv3.Rows[row].FindControl("lbid")).Text;
            if (SurveyControl.UpdateStatus(id, "0"))
                Response.Write(@"<script>alert('停止成功');</script><script>window.location ='/Admin/Survey/index.aspx'</script>");
            else
            {
                Response.Write(@"<script>alert('停止失败');</script>");
                return;
            }
        }
    }
}