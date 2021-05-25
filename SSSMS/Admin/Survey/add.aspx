<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="SSSMS.Survey.add" MasterPageFile="/Menu.Master" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
    </style>
    <asp:Panel ID="pnfirst" runat="server">
        <div>
            <h3 align="center">创建调查问卷</h3>
            <div style="text-align: center">

                <asp:Table ID="tb1" runat="server" CssClass="my_table" GridLines="Vertical" Style="width: 70%; border-radius: 20px">
                    <asp:TableRow CssClass="survey_row">
                        <asp:TableCell>
                            <asp:TextBox ID="tbtitle" runat="server" placeholder="主题" CssClass="mytitle"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="survey_row">
                        <asp:TableCell>
                            <asp:TextBox ID="tbdescription" runat="server" placeholder="描述" CssClass="mydescription" TextMode="MultiLine"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="survey_row">
                        <asp:TableCell>
                        <div class="demo">
                            <p>开始时间</p>
		                    <p>日期：<input type="text" name="startdate" class="my_input" id="pickdate1" value="" /></p>
		                    <p>时间：<input type="text" name="starttime" placeholder="" class="my_input" id="picktime1" /></p>
	                    </div>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="survey_row">
                        <asp:TableCell>
                        <div class="demo">
                            <p>截止时间</p>
		                    <p>日期：<input type="text" name="enddate" class="my_input" id="pickdate2" /></p>
		                    <p>时间：<input type="text" name="endtime" placeholder="" class="my_input" id="picktime2" /></p>
	                    </div>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow Height="20px">
                        <asp:TableCell>
                            <asp:Button ID="btadd" runat="server" Text="下一步" OnClick="bt_add_Click" CssClass="my_button" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnsecond" runat="server" >
        <div>
            <h3 align="center">创建问卷题目</h3>
            <div>
                <asp:Button ID="btback" runat="server" Text="上一步" OnClick="bt_back_Click" CssClass="my_button" />
            </div>
            <div class="left_add">
                <asp:Panel ID="pnselect" runat="server">
                    <div  style="margin:20px">
                        <asp:DropDownList ID="ddlselect" runat="server" CssClass="my_ddl"></asp:DropDownList>
                        <asp:Button ID="btinsert" runat="server" Text="添加"  OnClick="bt_insert_Click" CssClass="my_button"  style="vertical-align:top;width:50px"/>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pn_scq" runat="server">
                    <div style="margin: 20px">
                        <h4>单选题</h4>
                        <asp:TextBox ID="tbscqtitle" runat="server" TextMode="MultiLine" style="width:200px;border-radius:5px;margin-bottom:10px" placeholder="题目"></asp:TextBox>
                        <asp:Table ID="tbscq" runat="server" align="center">
                        </asp:Table>
                        <asp:Button ID="btaddscqrow" runat="server" Text="添加选项"  OnClick="bt_add_scq_row_Click"  CssClass="my_button" style="margin-top:20px"/>
                        <asp:Button ID="btscqconfirm" runat="server" Text="保存"  OnClick="bt_scq_confirm_Click" CssClass="my_button" style="margin-top:20px"/>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pn_mcq" runat="server">
                    <div style="margin:20px">
                        <p>多选题</p>
                        <asp:TextBox ID="tbmcqtitle" runat="server" TextMode="MultiLine" style="width:200px;border-radius:5px;margin-bottom:10px" placeholder="题目"></asp:TextBox>
                        <asp:Table ID="tbmcq" runat="server" align="center">
                        </asp:Table>
                        <asp:Button ID="btaddmcqrow" runat="server" Text="添加选项"  OnClick="bt_add_mcq_row_Click" CssClass="my_button" style="margin-top:20px"/>
                        <asp:Button ID="btmcqconfirm" runat="server" Text="保存"  OnClick="bt_mcq_confirm_Click" CssClass="my_button" style="margin-top:20px"/>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pn_saq" runat="server">
                    <div style="margin:20px">
                        <p>简答题</p>
                        <asp:TextBox ID="tbsaqtitle" runat="server" TextMode="MultiLine" placeholder="标题" CssClass="my_saq"></asp:TextBox>
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="保存"  OnClick="bt_saq_confirm_Click" CssClass="my_button" style="margin-top:20px"/>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pn_continue" runat="server">
                    <div style="margin:20px">
                        <asp:Button ID="btcontinue" runat="server" Text="下一题"  OnClientClick="Check()" OnClick="bt_continue_Click" CssClass="my_button" style="width:70px;float:left;margin-left:10%;margin-bottom:20px" />
                        <asp:Button ID="btsubmit" runat="server" Text="提交问卷" OnClick="bt_submit_Click" CssClass="my_button" style="width:90px; float:right;margin-right:10%;margin-bottom:20px" />
                    </div> 
                </asp:Panel>
            </div>
            <div class="right_list" style="margin-left:5%;margin-top:20px;border-radius:8px;overflow:hidden;">
                <h3 align="center">预览</h3>
                <div style="margin-left:10px">
                    <asp:Table ID="tbpreview" runat="server" CssClass="temp_table">
                    </asp:Table>
                </div>
                
            </div>
        </div>
    </asp:Panel> 
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
