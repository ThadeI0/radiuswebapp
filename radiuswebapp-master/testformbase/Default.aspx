<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="testformbase.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <asp:Label ID="lbIIp" runat="server" Text="ip:" AssociatedControlID="TextBox1"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        &nbsp;<asp:DropDownList ID="ddlVendor" runat="server">
            <asp:ListItem>dlink</asp:ListItem>
            <asp:ListItem>eltex</asp:ListItem>
        </asp:DropDownList>
        &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Send" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Server: "></asp:Label>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
