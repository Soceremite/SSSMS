<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="select.aspx.cs" Inherits="SSSMS.User.answer.select" MasterPageFile="/Menu.Master"%>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div algin="center">
        <h3 align="center">选择问卷</h3>
        <asp:GridView ID="GridView1" runat="server" CssClass="gv_table" CellPadding="4" ForeColor="Black" GridLines="Vertical"
           AutoGenerateColumns="False"  Font-Size="Medium" TabIndex="1" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" HorizontalAlign="Center" PageSize="20">
            <EditRowStyle Font-Size="Smaller" />
            <FooterStyle BackColor="#CCCC99" />
            <AlternatingRowStyle HorizontalAlign="Center" BackColor="White" />
            <Columns>
                <asp:TemplateField>
                    <HeaderStyle Width="5%" />
                    <HeaderTemplate>id</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbid" runat="server" Text='<%#Eval("id") %>'></asp:Label></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="=tb_class">
                    <HeaderStyle Width="15%" />
                    <HeaderTemplate>主题</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbtitle" runat="server" Text='<%#Eval("title") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="=tb_class"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-CssClass="=tb_class">
                    <HeaderStyle Width="10%" />
                    <HeaderTemplate>描述</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbdescription" runat="server" Text='<%#Eval("description") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="=tb_class"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle Width="8%" />
                    <HeaderTemplate>发起者</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbauthor_id" runat="server" Text='<%#Eval("author_id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle Width="11%" />
                    <HeaderTemplate>发起日期</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbcreatedate" runat="server" Text='<%#Eval("create_date") %>'/></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle Width="11%" />
                    <HeaderTemplate>开始日期</HeaderTemplate>
                    <ItemTemplate><%#Eval("start_date") %></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle Width="11%" />
                    <HeaderTemplate>截止日期</HeaderTemplate>
                    <ItemTemplate><%#Eval("end_date") %></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle Width="8%" />
                    <HeaderTemplate>选择</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btanswer" runat="server" OnClick="Answer_Click" CssClass="my_button" Text="填写" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
        </asp:GridView>
        </div>
  </asp:Content>
