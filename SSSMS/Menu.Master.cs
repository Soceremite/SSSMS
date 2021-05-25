using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserControl = SSSMS.App_Code.UserControl;

namespace SSSMS
{
    public partial class Menu : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserControl user= new UserControl();
            if (Session["currentuser"]==null)
            {
                lbusername.Text = user.getusername();
                lbusername2.Text = user.getusername();
                lbtype.Text = user.getidentity();
                imguser.ImageUrl = user.getimg();
                imguser2.ImageUrl = user.getimg();
            }
            else
            {

                lbusername.Text = Session["currentuser"].ToString();
                lbusername2.Text = Session["currentuser"].ToString();
                user.settype(int.Parse(Session["type"].ToString()));
                lbtype.Text = user.getidentity();
                imguser.ImageUrl = Session["img"].ToString();
                imguser2.ImageUrl = Session["img"].ToString();
            }
        }
    }
}