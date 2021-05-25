<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SSSMS.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="zh-CN">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no"/>
    <link rel='stylesheet' href="Content/liu/bootstrap.min.css"/>
    <link rel='stylesheet' href="Content/liu/perfect-scrollbar.min.css"/>
    <link rel="stylesheet" href="Content/liu/dmaku.css"/>
    <title>登录</title>
</head>
<body>
    <div class="container-fluid">
        <div class="row no-gutters">
            <div class="col-12 col-sm-12 col-md-12 col-lg-5 text-center left__section">
                <div class="dowebok">
                    <div style="margin-top: 5%">
                        <img src="/Source/img/nuaa.jpg" style="width: 100px; height: 100px;" />
                    </div>
                    <h2 class="heading my-5">学生满意度调查管理系统</h2>
                    <form id="form1" runat="server" class="mt-4">
                        <div class="input-group my-4">
                            <div class="input-group-prepend">
                                <asp:Label  runat="server" for="formGroupExampleInput" class="d-block mx-auto">
                                    <img src="/Source/img/8dq.svg"
                                        width="18" height="18" class="mt-2" />
                                </asp:Label>
                            </div>
                            <asp:TextBox ID="tbusername"  runat="server"  class="form-control" placeholder="账号" aria-label="" aria-describedby="basic-addon1" />
                        </div>
                        <div class="input-group my-4">
                            <div class="input-group-prepend">
                                <asp:Label  runat="server" for="formGroupExampleInput" class="d-block mx-auto" >
                                    <img src="/Source/img/8dT.svg"
                                        width="18" height="18" class="mt-2" />
                                </asp:Label>
                            </div>
                            <asp:TextBox  ID="tbpasswd" runat="server"  TextMode="Password"  class="form-control" placeholder="密码"  aria-label="" aria-describedby="basic-addon1" />
                        </div>

                        <div class="form-check float-left my-3">
                            <input class="form-check-input" type="checkbox" value="" id="defaultCheck1" />
                            <label class="form-check-label" for="defaultCheck1">记住我</label>
                        </div>
                        <br />
                        <br />
                        <div class="d-flex justify-content-between align-items-center" >
                            <asp:Button  id="btlogin" runat="server" type="button" class="btn btn-primary" Text="登陆" style="width:80px;border-radius:10px" OnClick="btlogin_click"></asp:Button>
                        </div>
                    </form>
                </div>
            </div>

            <div class="col-12 col-sm-12 col-md-12 col-lg-7">
                <div class="bg"></div>
            </div>
        </div>
    </div>
    <script src="js/jquery.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/perfect-scrollbar.min.js"></script>
    <script src="js/dmaku.js"></script>
</body>
</html>
