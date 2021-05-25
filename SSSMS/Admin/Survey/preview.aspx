<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="preview.aspx.cs" Inherits="SSSMS.Admin.Survey.preview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>预览</title>
    <style>
        .preview_table{
            width:100%;
            margin:auto;
            margin-left:10px;
        }
    </style>
</head>
<body style=";background-color:#f4f4f8;font-family: YouYuan">
    <form id="form1" runat="server">
        <div  style="margin-top:30px">
            <div style="width: 800px; margin: auto;;background-color:white;overflow:hidden;border-radius:10px">
                <div style="text-align: center;margin-top:30px">
                    <asp:Label ID="lbtitle" runat="server" Text="题目" Font-Size="XX-Large" style="color:#3A3F51"></asp:Label>
                </div>
                <div style="margin-left:20px">
                    <p style="font-size:large">描述：</p>
                    <asp:Label ID="lbdescription" runat="server" Text="描述内容" style="margin-left:10px"></asp:Label>
                </div>
                
                <asp:Label ID="lbcreator" runat="server" Text="发布者：未知" style="float:right;margin-right:20px;"></asp:Label>
                <div style="margin-bottom:30px;margin-left:20px">
                    <p style="font-size:large">题目：</p>
                    <asp:Table ID="tbsurvey" runat="server" align="center" CssClass="preview_table">
                    </asp:Table>
                </div>
                
            </div>
            
        </div>
    </form>
</body>
</html>
