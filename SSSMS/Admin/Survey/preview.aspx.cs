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
    public partial class preview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                show();
            }
        }
        protected void show()
        {
            if (Session["preview_survey_id"] == null)
                return;
            string survey_id= Session["preview_survey_id"].ToString();
            SurveyControl survey = new SurveyControl();
            survey.SetId(int.Parse(survey_id));
            survey.GetSurveyByIdFromDataBase();
            lbtitle.Text = survey.GetTitle();
            lbdescription.Text = survey.GetDescription();
            lbcreator.Text ="发布者： "+ UserControl.GetUserName(survey.GetAuthor_id().ToString());
            Preview.LoadTable(tbsurvey, survey_id);
        }
        
    }
}