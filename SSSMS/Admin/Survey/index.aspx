<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SSSMS.Survey.index" MasterPageFile="/Menu.Master"  %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div algin="center">
        <h3 align="center">待审核</h3>
        <asp:GridView ID="gv1" runat="server" CssClass="gv_table" CellPadding="4" ForeColor="Black" GridLines="Vertical"
            OnRowDeleting="GridView1_RowDeleting"
            OnRowEditing="GridView1_RowEditing"
            AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="暂无数据" Font-Size="Medium" TabIndex="1" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" HorizontalAlign="Center" PageSize="20">
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
                    <HeaderTemplate>预览</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btpreview" runat="server" OnClick="Preview_Click" CssClass="my_button" Text="预览" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle Width="8%" />
                    <HeaderTemplate>审核</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btaudit" runat="server" OnClick="Audit_Click" CssClass="my_button" Text="通过" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="操作" ControlStyle-CssClass="b_icon"
                    ShowEditButton="True"
                    ShowDeleteButton="True">
                    <ControlStyle CssClass="b_icon"></ControlStyle>
                </asp:CommandField>
            </Columns>
            <RowStyle HorizontalAlign="Center" Height="26px" BackColor="white" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="white" ForeColor="Black" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#3a3f51" Font-Bold="True" ForeColor="White" CssClass="shadow_text" HorizontalAlign="Center" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>

        <h3 align="center" style="margin-top:20px">已通过</h3>
        <asp:GridView ID="gv2" runat="server" CssClass="gv_table" CellPadding="4" ForeColor="Black" GridLines="Vertical"
            OnRowDeleting="GridView2_RowDeleting"
            OnRowEditing="GridView2_RowEditing"
            AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="暂无数据" Font-Size="Medium" TabIndex="1" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" HorizontalAlign="Center" PageSize="20">
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
                    <HeaderTemplate>预览</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btpreview" runat="server" OnClick="Preview_Click" CssClass="my_button" Text="预览" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle Width="8%" />
                    <HeaderTemplate>审核</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btban" runat="server" OnClick="Ban_Click" CssClass="my_button" Text="停止" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="操作" ControlStyle-CssClass="b_icon"
                    ShowEditButton="True"
                    ShowDeleteButton="True">
                    <ControlStyle CssClass="b_icon"></ControlStyle>
                </asp:CommandField>
            </Columns>
            <RowStyle HorizontalAlign="Center" Height="26px" BackColor="white" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="white" ForeColor="Black" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#3a3f51" Font-Bold="True" ForeColor="White" CssClass="shadow_text" HorizontalAlign="Center" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>



        <h3 align="center" style="margin-top:20px">已停止</h3>
        <asp:GridView ID="gv3" runat="server" CssClass="gv_table" CellPadding="4" ForeColor="Black" GridLines="Vertical"
            OnRowDeleting="GridView3_RowDeleting"
            OnRowEditing="GridView3_RowEditing"
            AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="暂无数据" Font-Size="Medium" TabIndex="1" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" HorizontalAlign="Center" PageSize="20">
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
                    <HeaderTemplate>预览</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btpreview" runat="server" OnClick="Preview_Click" CssClass="my_button" Text="预览" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle Width="8%" />
                    <HeaderTemplate>审核</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btunban" runat="server" OnClick="UnBan_Click" CssClass="my_button" Text="审核" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="操作" ControlStyle-CssClass="b_icon"
                    ShowEditButton="True"
                    ShowDeleteButton="True">
                    <ControlStyle CssClass="b_icon"></ControlStyle>
                </asp:CommandField>
            </Columns>
            <RowStyle HorizontalAlign="Center" Height="26px" BackColor="white" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="white" ForeColor="Black" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#3a3f51" Font-Bold="True" ForeColor="White" CssClass="shadow_text" HorizontalAlign="Center" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>

    </div>
</asp:Content>
