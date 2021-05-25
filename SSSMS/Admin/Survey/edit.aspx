<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="SSSMS.Admin.Survey.edit" MasterPageFile="/Menu.Master"  %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .mytextbox{
            width:200px;
            border-radius:8px;
        }
        .mylabel{
            width:200px;
        }
    </style>
    <h3 align="center">修改调查问卷</h3>
    <div style="text-align: center">

        <asp:Table ID="tb1" runat="server" CssClass="my_table" GridLines="Vertical" Style="width: 70%; border-radius: 20px">
            <asp:TableRow CssClass="survey_row">
                <asp:TableCell>
                    <asp:Label ID="lbauthor" runat="server" Text="发起者"></asp:Label>
                    <br />
                    <asp:TextBox ID="tbauthor" runat="server" ReadOnly="true" CssClass="mytextbox" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow CssClass="survey_row">
                <asp:TableCell>
                    <asp:Label ID="lbtitle" runat="server" Text="主题"></asp:Label>
                    <br />
                    <asp:TextBox ID="tbtitle" runat="server" placeholder="主题" CssClass="mytitle"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow CssClass="survey_row">
                <asp:TableCell>
                    <asp:Label ID="lbdescription" runat="server" Text="描述"></asp:Label>
                    <br />
                    <asp:TextBox ID="tbdescription" runat="server" placeholder="描述" CssClass="mydescription" TextMode="MultiLine"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow CssClass="survey_row">
                <asp:TableCell>
                        <div class="demo">
                            <p>开始时间</p>
		                    <p>日期：<input type="text" name="startdate" class="my_input" id="pickdate1"  value='<%=Session["start_date"]%>'/></p>
		                    <p>时间：<input type="text" name="starttime" placeholder="" class="my_input" id="picktime1" value='<%=Session["start_time"]%>' /></p>
	                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow CssClass="survey_row">
                <asp:TableCell>
                        <div class="demo">
                            <p>截止时间</p>
		                    <p>日期：<input type="text" name="enddate" class="my_input" id="pickdate2"  value='<%=Session["end_date"]%>'/></p>
		                    <p>时间：<input type="text" name="endtime" placeholder="" class="my_input" id="picktime2" value='<%=Session["end_time"]%>' /></p>
	                    </div>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow Height="20px">
                <asp:TableCell>
                    <asp:Button ID="btedit" runat="server" Text="提交" OnClick="bt_edit_Click" CssClass="my_button" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    <script type="text/javascript" src="/Scripts/liu/calendar/jquery-1.12.3.min.js"></script>
    <script src="/Scripts/liu/calendar/datedropper.min.js"></script>
    <script src="/Scripts/liu/calendar/timedropper.min.js"></script>
    <script>
        $("#pickdate1").dateDropper({
            animate: false,
            format: 'Y/m/d',
            maxYear: '2050'
        });
        $("#pickdate2").dateDropper({
            animate: false,
            format: 'Y/m/d',
            maxYear: '2050'
        });
        $("#picktime1").timeDropper({
            meridians: false,
            format: 'HH:mm',
        });
        $("#picktime2").timeDropper({
            meridians: false,
            format: 'HH:mm',
        });
    </script>
</asp:Content>
