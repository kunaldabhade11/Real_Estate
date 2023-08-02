<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainForm.aspx.cs" Inherits="Real_Estate.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .Msg{
            font-size: large;
            font-weight: 600;
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <b>BuildingName </b>:
            <asp:TextBox ID="txtBuildingName" runat="server" AutoPostBack="true" OnTextChanged="txtBuildingName_TextChanged"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtBuildingName2" ControlToValidate="txtBuildingName" ValidationGroup="LoginFrame"
                runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
              <asp:Label ID="Label1" runat="server" ForeColor="#CC3300" Visible="true"></asp:Label>
            <br />
            <b>Price </b>:
            <asp:TextBox ID="TxtPrice" runat="server"></asp:TextBox><br />
            <b>Country </b>:
            <asp:TextBox ID="TxtCountry" runat="server"></asp:TextBox><br />
            <b>CarpetArea </b>:
            <asp:TextBox ID="TxtCarpetArea" runat="server"></asp:TextBox><br />
            <b>BuildingUpArea </b>:
            <asp:TextBox ID="TxtBuildingUpArea" runat="server"></asp:TextBox><br />
            <b>BuildingAddress</b> :
            <asp:TextBox ID="TxtBuildingAddress" runat="server"></asp:TextBox><br />
            <b>Email ID</b> :
            <asp:TextBox ID="TextEmailid" runat="server"></asp:TextBox><br />

            <b>Confic_ID</b>
            <asp:DropDownList ID="ddlConfiguration" runat="server"></asp:DropDownList>
            <br />
            <b>Decription</b> :
            <asp:TextBox ID="txtDecription" runat="server"></asp:TextBox><br />
            <b>ImagePath</b><asp:Image ID="imagePath" runat="server" /> <br />
            <asp:FileUpload ID="FileUpload" runat="server" /> <br />
            
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="LoginFrame" BackColor="#00CC00" />

            <asp:Button ID="Goto_GridView" Class="grid" runat="server" Text="Go to GridView" OnClick="Goto_GridView_Click" BackColor="#9966FF" BorderColor="Black" />
            <br />
            <asp:Label ID="lbltxt" Class="Msg" runat="server" Visible="true"></asp:Label>



        </div>



    </form>
</body>
</html>

