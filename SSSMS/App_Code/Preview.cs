using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSSMS.App_Code
{
    public class Preview
    {
        //加载所有题目和选项
        public static bool LoadTable(Table table,string survey_id)
        {
            DataTable dtq = GetQuestion(survey_id);
            DataTable dto = GetOption(survey_id);
            int count = dtq.Rows.Count;
            for(int i=0;i<count;i++)
            {
                int q_type =int.Parse( dtq.Rows[i]["question_type"].ToString());
                string q_sort= dtq.Rows[i]["question_sort"].ToString();
                string q_name = dtq.Rows[i]["question_name"].ToString();
                switch (q_type)
                {
                    case 1:
                        {
                            DataTable opt = GetOption(dto, q_sort);
                            AddScq(table, q_sort,q_name, opt);
                            break;
                        }
                    case 2:
                        {
                            DataTable opt = GetOption(dto, q_sort);
                            AddMcq(table,q_sort,q_name, opt);
                            break;
                        }
                    case 3:
                        {
                            AddSaq(table,q_sort,q_name);
                            break;
                        }
                    default:break;
                }
            }
            return true;
        }

        public static bool TempLoadTable(Table table, string survey_id)
        {
            DataTable dtq = GetQuestion(survey_id, "Temp_Question");
            DataTable dto = GetOption(survey_id, "Temp_Option");
            int count = dtq.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                int q_type = int.Parse(dtq.Rows[i]["question_type"].ToString());

                string q_sort = dtq.Rows[i]["question_sort"].ToString();
                string q_name = dtq.Rows[i]["question_name"].ToString();
                switch (q_type)
                {
                    case 1:
                        {
                            DataTable opt = GetOption(dto, q_sort);
                            AddScq(table, q_sort, q_name, opt);
                            break;
                        }
                    case 2:
                        {
                            DataTable opt = GetOption(dto, q_sort);
                            AddMcq(table, q_sort, q_name, opt);
                            break;
                        }
                    case 3:
                        {
                            AddSaq(table, q_sort, q_name);
                            break;
                        }
                    default: break;
                }
            }
            return true;
        }

        //通过id获取调查问卷的题目并根据option_sort排序
        public static DataTable GetQuestion(string survey_id, string tablename = null)
        {
            string limit = " where survey_id='" + survey_id + "' order by question_sort" ;
            if (tablename==null)
                return QuestionControl.GetDataTable(limit: limit);
            else
                return QuestionControl.GetDataTable(tablename: tablename, limit: limit);
        }
        //通过id获取调查问卷的选项 
        public static DataTable GetOption(string survey_id, string tablename = null)
        {
            string limit = " where survey_id='" + survey_id + "' order by question_id";
            if (tablename == null)
                return OptionControl.GetDataTable(limit: limit);
            else
                return OptionControl.GetDataTable(tablename:tablename,limit: limit);
        }
        public static DataTable GetOption(DataTable dt,string question_id)
        {
            string exp = "question_id='" + question_id + "'";
            return DB.getData(dt, exp);
        }
        //添加单选题预览模块

       //sort序号
       //name 题目内容
       //table 选项
        public static void AddScq(Table table,string sort,string name,DataTable datatable)
        {
            TableRow tr = new TableRow();
            tr.Width=Unit.Parse("100%");
            tr.Style.Add("margin-top","20px");
            TableCell tc = new TableCell();
            tc.Width= Unit.Parse("100%");
            Label lb = new Label();
            lb.Style.Add("font-weight", "bold");
            //ID名称
            lb.Text = sort + ": (单选题)" + name;
            tc.Controls.Add(lb);

            int count = datatable.Rows.Count;
            //单选控件
            RadioButtonList rbl = new RadioButtonList();
            rbl.Style.Add("margin-top", "10px");
            rbl.ID = "rbl" + sort;
            for (int i=0;i<count;i++)
            {
                ListItem li1 = new ListItem();
                li1.Text = datatable.Rows[i]["option_name"].ToString();
                li1.Value = datatable.Rows[i]["option_sort"].ToString();
                rbl.Items.Add(li1);
            }
            tc.Controls.Add(rbl);
            tr.Cells.Add(tc);
            table.Rows.Add(tr);
        }
        //添加多选题预览模块
        public static void AddMcq(Table table, string sort,string name,DataTable datatable)
        {
            TableRow tr = new TableRow();
            tr.Width = Unit.Parse("100%");
            tr.Style.Add("margin-top", "20px");
            TableCell tc = new TableCell();
            tc.Width = Unit.Parse("100%");
            Label lb = new Label();
            lb.Style.Add("font-weight", "bold");
            lb.Text = sort + ": (多选题)" + name;
            tc.Controls.Add(lb);

            int count = datatable.Rows.Count;
            //复选控件
            CheckBoxList cbl = new CheckBoxList();
            cbl.Style.Add("margin-top", "10px");
            //ID名称
            cbl.ID = "cbl" + sort;
            for (int i = 0; i < count; i++)
            {
                ListItem li1 = new ListItem();
                li1.Text = datatable.Rows[i]["option_name"].ToString();
                li1.Value = datatable.Rows[i]["option_sort"].ToString();
                cbl.Items.Add(li1);
            }
            tc.Controls.Add(cbl);
            tr.Cells.Add(tc);
            table.Rows.Add(tr);
        }
        //添加简答题预览模块
        public static void AddSaq(Table table, string sort,string name)
        {
            TableRow tr = new TableRow();
            tr.Width = Unit.Parse("100%");
            tr.Style.Add("margin-top", "20px");
            TableCell tc = new TableCell();
            tc.Width = Unit.Parse("100%");
            Label lb = new Label();
            lb.Style.Add("font-weight", "bold");
            lb.Text = sort + ": (简答题)" + name;
            tc.Controls.Add(lb);

            //回答框模块
            TextBox tb = new TextBox();
            tb.Style.Add("margin-top", "10px");
            tb.Style.Add("margin-left", "10px");
            tb.Style.Add("width", "200px");
            tb.TextMode =TextBoxMode.MultiLine;
            tc.Controls.Add(new LiteralControl("<br/>"));
            tc.Controls.Add(tb);
            tr.Cells.Add(tc);

            table.Rows.Add(tr);
        }
    }
}