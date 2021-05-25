<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="answer.aspx.cs" Inherits="SSSMS.User.answer.answer1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="zh-CN">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>填写问卷</title>
    <style>
        .preview_table{
            width:100%;
            margin:auto;
            margin-left:10px;
        }
        .my_button {
            background-color:#3a3f51;
            border-radius:8px;
            color:whitesmoke;
            width:48px;
            height:30px;
        }
    </style>
</head>
<body style=";background-color:#f4f4f8;font-family: YouYuan">
    <form id="form1" runat="server">
        <div style="text-align: left">
            <div  style="margin-top:30px">
                <div style="width: 800px; margin: auto;;background-color:white;overflow:hidden;border-radius:10px">
                    <div style="text-align: center;margin-top:30px">
                        <asp:Label ID="lbtitle" runat="server" Text="题目" Font-Size="XX-Large" style="color:#3A3F51"></asp:Label>
                    </div>
                    <div style="margin-left: 20px">
                        <p style="font-size: large">描述：</p>
                        <asp:Label ID="lbdescription" runat="server" Text="描述内容" Style="margin-left: 10px"></asp:Label>
                        <asp:Label ID="lbcreator" runat="server" Text="发布者：未知" Style="float: right; margin-right: 30px;"></asp:Label>
                    </div>
                    &nbsp
                    <div style="margin-bottom:30px;margin-left:20px">
                        <p style="font-size:large">题目：</p>
                        <asp:Table ID="tbanswer" runat="server" align="Justify" CssClass="preview_table"></asp:Table> 
                        <div  align="center">
                            <asp:Button ID="btanswer" runat="server" Text="提交" OnClick="btanswer_Click" Style="margin-left: 20px" CssClass="my_button" />
                        </div>
                        
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>

</html>
