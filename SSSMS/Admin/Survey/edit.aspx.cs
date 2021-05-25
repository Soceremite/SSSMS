using SSSMS.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserControl = SSSMS.App_Code.UserControl;

namespace SSSMS.Admin.Survey
{
    public partial class edit : System.Web.UI.Page
    {
        SurveyControl survey = new SurveyControl();
        protected void GetEditSurvey()
        {
            
            string limit = " where id='" + Session["edit_survey_id"].ToString()+"'";
            DataTable dt = SurveyControl.GetDataTable(limit: limit);
            tbtitle.Text = dt.Rows[0]["title"].ToString();
            tbdescription.Text = dt.Rows[0]["description"].ToString();
            string[] start_date=dt.Rows[0]["start_date"].ToString().Split(' ');
            Session["start_date"] = start_date[0];
            Session["start_time"] = start_date[1];
            string[] end_date = dt.Rows[0]["end_date"].ToString().Split(' ');
            Session["end_date"] = end_date[0];
            Session["end_time"] = end_date[1];
            tbauthor.Text = UserControl.GetUserName(Session["edit_author_id"].ToString());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetEditSurvey();
            }
        }
        protected void bt_edit_Click(object sender, EventArgs e)
        {
            if (!tbtitle.Text.ToString().Trim().Equals(""))
                survey.SetTitle(tbtitle.Text.ToString());
            else
            {
                Response.Write("<script>alert('主题为空')</script>");
                return;
            }
            survey.SetDescription(tbdescription.Text.ToString());
            string startdate = Request.Form.Get("startdate").ToString();
            if (startdate.Equals(""))
            {
                Response.Write("<script>alert('请选择开始日期')</script>");
                return;
            }
            string starttime = Request.Form.Get("starttime").ToString();
            string enddate = Request.Form.Get("enddate").ToString();
            if (enddate.Equals(""))
            {
                Response.Write("<script>alert('请选择截止日期')</script>");
                return;
            }
            string endtime = Request.Form.Get("endtime").ToString();
            DateTime start_date = DateTime.Parse(startdate + " " + starttime);
            DateTime end_date = DateTime.Parse(enddate + " " + endtime);
            if (DateTime.Compare(start_date, end_date) >= 0)
            {
                Response.Write("<script>alert('开始日期晚于或等于截止日期')</script>");
                return;
            }
            survey.SetId(int.Parse(Session["edit_survey_id"].ToString()));
            survey.SetStart_date(start_date.ToString());
            survey.SetEnd_date(end_date.ToString());
            if(survey.SaveEditSurvey())
            {
                Session["edit_survey_id"] = null;
                Session["edit_author_id"] = null;
                Session["start_date"] = null;
                Session["start_time"] = null;
                Session["end_date"] = null;
                Session["end_time"] = null;
                Response.Write("<script>alert('修改成功')</script> <script>window.close()</script>");
                
            }
            else
            {
                Response.Write("<script>alert('修改失败')</script>");
            }
        }
    }
}