using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SSSMS.App_Code
{
    public class TableControl
    {
        public static bool CheckOption(Table tb, string tablename, TextBox tbtitle)
        {
            if (tbtitle.Text.Trim().Equals(""))
            {
                return false;
            }
            int count = tb.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                string opt = "tb" + tablename + ((char)(i + (int)'A')).ToString();
                TextBox tb1 = tb.Rows[i].FindControl(opt) as TextBox;
                if (tb1.Text.Trim().Equals(""))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool InsertOption(Table tb, string tablename,int question_count)
        {
            OptionControl oc = new OptionControl();
            int count = tb.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                try
                {
                    string opt = "tb" + tablename + ((char)(i + (int)'A')).ToString();
                    TextBox tb1 = tb.Rows[i].FindControl(opt) as TextBox;
                    oc.SetOption_name(tb1.Text);
                    oc.SetOption_sort(i + 1);
                    oc.SetQuestion_id(question_count);
                    OptionControl.Insert(oc, dataname: "Temp_Option");
                }
                catch (Exception ee)
                {
                    return false;
                }
            }
            return true;
        }
        public static void AddRows(Table table, String tablename, int num)
        {
            TableRow tr = new TableRow();

            TableCell tc = new TableCell();
            Label lb = new Label();

            lb.Text = ((char)(num + (int)'A')).ToString();
            lb.Width = Unit.Parse("10px");
            tc.Controls.Add(lb);
            tc.Width = Unit.Parse("10px");

            TableCell tc1 = new TableCell();
            TextBox tb = new TextBox();
            tb.ID = "tb" + tablename + lb.Text.ToString();
            tb.Width = Unit.Parse("150px");
            tb.Style.Add("border-radius", "5px");
            tc1.Controls.Add(tb);

            tr.Cells.Add(tc);
            tr.Cells.Add(tc1);

            table.Rows.Add(tr);

        }
        protected static void DelRow(Table table, int index)
        {
            table.Rows.RemoveAt(index);
        }
    }
}