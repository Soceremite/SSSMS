using SSSMS.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserControl = SSSMS.App_Code.UserControl;

namespace SSSMS
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btlogin_click(object sender, EventArgs e)
        {

            if (UserControl.Search(tbusername.Text, tbpasswd.Text))
            {
                UserControl user = new UserControl(tbusername.Text, tbpasswd.Text);
                Session["currentid"] = user.getid();
                Session["currentuser"] = user.getusername();
                Session["type"] = user.gettype();
                Session["img"] = user.getimg();
                Response.Write(@"<script>alert('登录成功！');</script><script>window.location ='/home.aspx'</script>");
            }
            else
            {
                Response.Write(@"<script>alert('登录失败！账号或密码错误！');</script>");

            }
        }
    }
}