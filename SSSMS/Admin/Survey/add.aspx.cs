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
    public partial class add : System.Web.UI.Page
    {
        SurveyControl survey = new SurveyControl();
        protected void Load_Table(Table table,string tablename)
        {
            string s = tablename + "_count";
            int len = Convert.ToInt16(ViewState[s]);
            for(int i=0;i<len;i++)
            {
                TableControl.AddRows(table, tablename, i);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Load_Table(tbscq, "scq");
            Load_Table(tbmcq, "mcq");
            Preview.TempLoadTable(tbpreview, "0");
            //if(Session["scq_confirm"]==null||Session["scq_confirm"].ToString().Equals("0"))
            //    btcontinue.Attributes.Add("onclick", "return confirm('是否放弃保存？'); ");
            if (!IsPostBack)
            {
                if(!(DB.Truncate("Temp_Question")&& DB.Truncate("Temp_Option")))
                {
                    Response.Write(@"<script>alert('数据库初始化失败！');</script>");
                    return;
                }
                pnfirst.Visible = true;
                pnsecond.Visible = false;
                //btcontinue.Attributes.Add("onclick", "return confirm('是否放弃保存？'); ");
                Session["question_count"] = 1;
                Session["mcq_confirm"] = 0;
                Session["scq_confirm"] = 0;
                //cdstart.Visible = false;
            }

        }
        protected void bt_add_Click(object sender, EventArgs e)
        {
            if (!tbtitle.Text.ToString().Equals(""))
                survey.SetTitle(tbtitle.Text.ToString());
            else
            {
                Response.Write("<script>alert('请输入主题')</script>");
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
            survey.SetStart_date(start_date.ToString());
            survey.SetEnd_date(end_date.ToString());
            survey.SetAuthor_id(int.Parse(Session["currentid"].ToString()));
            survey.SetCreate_date(DateTime.Now.ToString());
            Session["currentsurvey"] = survey;
            pnfirst.Visible = false;
            pnsecond.Visible = true;
            DB.SetDropDownList(ddlselect, "Question_type", "id", "name", prompt: "题型");
            pncontrol(0);
            pnselect.Visible = true;

        }
        protected void bt_back_Click(object sender, EventArgs e)
        {
            pnfirst.Visible = true;
            pnsecond.Visible = false;
        }
        protected void pncontrol(int value)
        {
            pn_mcq.Visible = false;
            pn_saq.Visible = false;
            pn_scq.Visible = false;
            pn_continue.Visible = true;
            switch (value)
            {
                case 0:
                    pn_continue.Visible = false;
                    break;
                case 1:
                    pn_scq.Visible = true;
                    tbscqtitle.Text = "";
                    break;
                case 2:
                    pn_mcq.Visible = true;
                    tbmcqtitle.Text = "";
                    break;
                case 3:
                    pn_saq.Visible = true;
                    tbsaqtitle.Text = "";
                    break;
                default:
                    break;
            }
        }
        protected void bt_insert_Click(object sender, EventArgs e)
        {
            if (ddlselect.SelectedIndex == ddlselect.Items.Count - 1)
            {
                Response.Write("<script>alert('请选择题型')</script>");
                return;
            }
            pnselect.Visible = false;
            pncontrol(int.Parse(ddlselect.SelectedValue));
        }
        protected void bt_continue_Click(object sender, EventArgs e)
        {
            if(ddlselect.SelectedValue.Equals("1"))
            {
               if(Session["scq_confirm"].ToString().Trim().Equals("0"))
                {
                    
                    Session["scq_confirm"] = 1;
                }
                ViewState["scq_count"] = 0;
            } 
            else if(ddlselect.SelectedValue.Equals("2"))
                ViewState["mcq_count"] = 0;
            pnselect.Visible = true;
            pncontrol(0);
        }
        protected void bt_submit_Click(object sender, EventArgs e)
        {
            if(Session["currentsurvey"]!=null)
            {
                survey = (SurveyControl)Session["currentsurvey"];
                if(SurveyControl.Insert(survey))
                {
                    int survey_id = survey.GetIdFromDataBase();

                    DataTable dtquestion = QuestionControl.GetDataTable("Temp_Question");
                    DataTable dtoption = OptionControl.GetDataTable("Temp_Option");
                    if(!(QuestionControl.SaveDataTable(dtquestion, survey_id)&&OptionControl.SaveDataTable(dtoption,survey_id)))
                    {
                        Response.Write("<script>alert('提交问卷失败')</script>");
                    }

                    Response.Write("<script>alert('提交问卷成功')</script><script>window.location ='/Admin/Survey/add.aspx'</script>");
                }
            }
        }
        protected void bt_add_scq_row_Click(object sender, EventArgs e)
        {
            TableControl.AddRows(tbscq,"scq",tbscq.Rows.Count);
            ViewState["scq_count"] = Convert.ToInt16(ViewState["scq_count"]) + 1;
        }

        protected void bt_add_mcq_row_Click(object sender, EventArgs e)
        {
            TableControl.AddRows(tbmcq, "mcq", tbmcq.Rows.Count);
            ViewState["mcq_count"] = Convert.ToInt16(ViewState["mcq_count"]) + 1;
        }

        protected void bt_scq_confirm_Click(object sender, EventArgs e)
        {
            QuestionControl qc = new QuestionControl();
            qc.SetQuesiton_sort(int.Parse(Session["question_count"].ToString()));
            //qc.SetQuesiton_sort(question_count);
            if(tbscq.Rows.Count<2)
            {
                Response.Write("<script>alert('至少两个选项')</script>");
                return;
            }
            if(!TableControl.CheckOption(tbscq,"scq",tbscqtitle))
            {
                Response.Write("<script>alert('题目或者选项为空')</script>");
                return;
            }
            qc.SetQuestion_name(tbscqtitle.Text);
            qc.SetQuestion_type(int.Parse(ddlselect.SelectedValue));
             if(!(QuestionControl.Insert(qc,"Temp_Question")&&TableControl.InsertOption(tbscq, "scq", int.Parse(Session["question_count"].ToString()))))
            {
                Response.Write("<script>alert('确认失败')</script>");
                return;
            }
            Session["question_count"] = int.Parse(Session["question_count"].ToString()) + 1;
            Response.Write("<script>alert('保存成功')</script>");
            //Session["scq_confirm"] = 1;
            //btcontinue.Attributes.Remove("onclick");
        }
        protected void bt_mcq_confirm_Click(object sender, EventArgs e)
        {
            QuestionControl qc = new QuestionControl();
            qc.SetQuesiton_sort(int.Parse(Session["question_count"].ToString()));
            //qc.SetQuesiton_sort(question_count);
            if (tbmcq.Rows.Count < 2)
            {
                Response.Write("<script>alert('至少两个选项')</script>");
                return;
            }
            if (!TableControl.CheckOption(tbmcq, "mcq", tbmcqtitle))
            {
                Response.Write("<script>alert('题目为空')</script>");
                return;
            }
            qc.SetQuestion_name(tbmcqtitle.Text);
            qc.SetQuestion_type(int.Parse(ddlselect.SelectedValue));
            if (!(QuestionControl.Insert(qc, "Temp_Question")&& TableControl.InsertOption(tbmcq,"mcq", int.Parse(Session["question_count"].ToString()))))
            {
                Response.Write("<script>alert('确认失败')</script>");
                return;
            }
            Session["question_count"] = int.Parse(Session["question_count"].ToString()) + 1;
            Response.Write("<script>alert('保存成功')</script>");
            //Session["mcq_confirm"] = 1;
        }
        protected void bt_saq_confirm_Click(object sender, EventArgs e)
        {
            QuestionControl qc = new QuestionControl();
            qc.SetQuesiton_sort(int.Parse(Session["question_count"].ToString()));
            //qc.SetQuesiton_sort(question_count);
            if (tbsaqtitle.Text.ToString().Trim().Equals(""))
            {
                Response.Write("<script>alert('题目为空')</script>");
                return;
            }
            qc.SetQuestion_name(tbsaqtitle.Text);
            qc.SetQuestion_type(int.Parse(ddlselect.SelectedValue));
            if (!QuestionControl.Insert(qc, "Temp_Question"))
            {
                Response.Write("<script>alert('确认失败')</script>");
                return;
            }
            Session["question_count"] = int.Parse(Session["question_count"].ToString()) + 1;
            Response.Write("<script>alert('保存成功')</script>");
            //Session["mcq_confirm"] = 1;
        }
        
    }
}