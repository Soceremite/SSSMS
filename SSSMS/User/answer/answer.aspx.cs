using SSSMS.App_Code;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserControl = SSSMS.App_Code.UserControl;

namespace SSSMS.User.answer
{
    public partial class answer1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            show();
        }
        protected void show()
        {

            if (Session["survey_id"] == null)
                return;
            String writed = Session["writed"].ToString();
            if (writed == "0")
            {
                string Survey_id = Session["survey_id"].ToString();
                SurveyControl survey = new SurveyControl();
                survey.SetId(int.Parse(Survey_id));
                survey.GetSurveyByIdFromDataBase();
                lbtitle.Text = survey.GetTitle();
                lbdescription.Text = survey.GetDescription();
                lbcreator.Text = "发布者： " + UserControl.GetUserName(survey.GetAuthor_id().ToString());
                SurveyAnswer.LoadTable(tbanswer, Survey_id);
            }
            else
            if (writed == "1")
            {
                string Survey_id = Session["survey_id"].ToString();
                string user_id = Session["currentid"].ToString();
                SurveyControl survey = new SurveyControl();
                survey.SetId(int.Parse(Survey_id));
                survey.GetSurveyByIdFromDataBase();
                lbtitle.Text = survey.GetTitle();
                lbdescription.Text = survey.GetDescription();
                lbcreator.Text = "发布者： " + UserControl.GetUserName(survey.GetAuthor_id().ToString());
                SurveyAnswer.LoadTable(tbanswer, Survey_id);

                int count = SurveyAnswer.QuestionNumber;
                for (int i = 0; i < count; i++)
                {
                    string qType = AnswerControl.GetQuestionType(i + 1, Survey_id);
                    if (qType == "3")
                    {
                        String TextboxID = "tbl" + (i + 1).ToString().Trim();
                        TextBox tbl = (TextBox)this.Page.FindControl(TextboxID);
                        tbl.Text = AnswerControl.GetContent(Survey_id, user_id, (i + 1).ToString());
                    }
                    else
                    if (qType == "1")
                    {
                        String radioblid = "rbl" + (i + 1).ToString().Trim();
                        RadioButtonList rbl = (RadioButtonList)this.Page.FindControl(radioblid);
                        rbl.SelectedValue = AnswerControl.GetContent(Survey_id, user_id, (i + 1).ToString());
                    }
                    else
                    if (qType == "2")
                    {
                        String checkedld = "cbl" + (i + 1).ToString().Trim();
                        CheckBoxList cbl = (CheckBoxList)this.Page.FindControl(checkedld);
                        String str = AnswerControl.GetContent(Survey_id, user_id, (i + 1).ToString());
                        String[] str2 = str.Split(',');
                        foreach (string c in str2)
                        {
                            int j = int.Parse(c);
                            cbl.Items[j - 1].Selected = true;
                        }
                    }
                }
            }
            else
            {
                return;
            }
        }

        protected void btanswer_Click(object sender, EventArgs e)
        {
            int count = SurveyAnswer.QuestionNumber;
            if (Session["survey_id"] == null)
                return;
            String writed = Session["writed"].ToString();
            string Survey_id = Session["survey_id"].ToString();
            string user_id = Session["currentid"].ToString();
            if (kong(count, Survey_id))
            {
                Response.Write("<script>alert('填写失败，请检查是否有遗漏的问题')</script>");
                return;
            }

            if (writed == "0")
            {
                DateTime creatdate = DateTime.Now;
                AnswerControl.insertdate(Survey_id, user_id, creatdate);
                for (int i = 0; i < count; i++)
                {
                    string qType = AnswerControl.GetQuestionType(i + 1, Survey_id);
                    if (qType == "3")
                    {
                        String TextboxID = "tbl" + (i + 1).ToString().Trim();
                        String str = Request.Form[TextboxID].ToString();
                        AnswerControl.insert(Survey_id, (i + 1).ToString(), str, user_id);
                    }
                    else
                    if (qType == "1")
                    {
                        String radioblid = "rbl" + (i + 1).ToString().Trim();
                        String str = Request.Form[radioblid].ToString();
                        AnswerControl.insert(Survey_id, (i + 1).ToString(), str, user_id);
                    }
                    else
                    if (qType == "2")
                    {
                        String str = String.Empty;
                        String checkedld = "cbl" + (i + 1).ToString().Trim();
                        CheckBoxList cbl = (CheckBoxList)this.Page.FindControl(checkedld);
                        for (int j = 0; j < cbl.Items.Count; j++)
                        {
                            if (cbl.Items[j].Selected)
                            {
                                if (str == String.Empty)
                                {
                                    str = str + cbl.Items[j].Value;
                                }
                                else
                                {
                                    str = str + ',' + cbl.Items[j].Value;
                                }
                            }
                        }
                        AnswerControl.insert(Survey_id, (i + 1).ToString(), str, user_id);
                    }
                }
                Response.Write("<script language='javascript'>alert('填写成功');</script>");
                Response.Write("<script language='javascript'>window.location='select.aspx';</script>");
            }
            else
            if (writed == "1")
            {
                DateTime creatdate = DateTime.Now;
                AnswerControl.updatedate(Survey_id, user_id, creatdate);
                for (int i = 0; i < count; i++)
                {
                    string qType = AnswerControl.GetQuestionType(i + 1, Survey_id);
                    if (qType == "3")
                    {
                        String TextboxID = "tbl" + (i + 1).ToString().Trim();
                        String str = Request.Form[TextboxID].ToString();
                        AnswerControl.update(Survey_id, (i + 1).ToString(), str, user_id);
                    }
                    else
                    if (qType == "1")
                    {
                        String radioblid = "rbl" + (i + 1).ToString().Trim();
                        String str = Request.Form[radioblid].ToString();
                        AnswerControl.update(Survey_id, (i + 1).ToString(), str, user_id);
                    }
                    else
                    if (qType == "2")
                    {
                        String str = String.Empty;
                        String checkedld = "cbl" + (i + 1).ToString().Trim();
                        CheckBoxList cbl = (CheckBoxList)this.Page.FindControl(checkedld);
                        for (int j = 0; j < cbl.Items.Count; j++)
                        {
                            if (cbl.Items[j].Selected)
                            {
                                if (str == String.Empty)
                                {
                                    str = str + cbl.Items[j].Value;
                                }
                                else
                                {
                                    str = str + ',' + cbl.Items[j].Value;
                                }
                            }
                        }
                        AnswerControl.update(Survey_id, (i + 1).ToString(), str, user_id);
                    }
                }
                Response.Write("<script language='javascript'>alert('修改成功');</script>");
                Response.Write("<script language='javascript'>window.location='select.aspx';</script>");
            }
        }
        protected bool kong(int count, String Survey_id)
        {
            for (int i = 0; i < count; i++)
            {
                string qType = AnswerControl.GetQuestionType(i + 1, Survey_id);
                if (qType == "3")
                {
                    String TextboxID = "tbl" + (i + 1).ToString().Trim();
                    String str = Request.Form[TextboxID].ToString();
                    if (str == String.Empty)
                    {
                        return true;
                    }
                }
                else
                if (qType == "1")
                {
                    String radioblid = "rbl" + (i + 1).ToString().Trim();
                    String str = Request.Form[radioblid].ToString();
                    if (str == String.Empty)
                    {
                        return true;
                    }
                }
                else
                if (qType == "2")
                {
                    String str = String.Empty;
                    String checkedld = "cbl" + (i + 1).ToString().Trim();
                    CheckBoxList cbl = (CheckBoxList)this.Page.FindControl(checkedld);
                    for (int j = 0; j < cbl.Items.Count; j++)
                    {
                        if (cbl.Items[j].Selected)
                        {
                            if (str == String.Empty)
                            {
                                str = str + cbl.Items[j].Value;
                            }
                            else
                            {
                                str = str + ',' + cbl.Items[j].Value;
                            }
                        }
                    }
                    if (str == String.Empty)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}