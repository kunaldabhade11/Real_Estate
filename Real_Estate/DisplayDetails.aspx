<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayDetails.aspx.cs" Inherits="Real_Estate.DisplayDetails" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:Label ID="lvlSearch" runat="server" ></asp:Label>
        <asp:TextBox ID="txtsearch" runat="server"></asp:TextBox>
        <asp:Button ID="btnsearch" runat="server" Text="search" OnClick="btnsearch_Click1" /><br />
        <asp:Button ID="btnExcel" runat="server" Text="Download Excel sheet" OnClick="btnExcel_Click" /> <br />

        <asp:Button ID="btnRedirect" Text="Add Building" runat="server" OnClick="btnRedirect_Click" />
        <asp:GridView ID="gvBuildingDetails12" DataKeyNames="Building_ID"  OnRowEditing="gvBuildingDetails12_RowEditing" OnRowUpdating="gvBuildingDetails12_RowUpdating" OnRowDataBound="gvBuildingDetails12_RowDataBound"
            OnRowDeleting="gvBuildingDetails12_RowDeleting" AllowPaging="true" OnPageIndexChanging="gvBuildingDetails12_PageIndexChanging" PageSize="10"  OnRowCancelingEdit="gvBuildingDetails12_RowCancelingEdit" 
              AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:TemplateField HeaderText="Building ID">
                    
                    
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblBuilding_ID" Text='<%#Eval("Building_ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <%--Building name coloumn start from here--%>
                <asp:TemplateField HeaderText="Building_Name">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblBuildingName" Text='<%#Eval("BuildingName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate >
                        <asp:TextBox ID="TextBuildingName" Text='<%#Eval("BuildingName")%>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <%--price--%>
                <asp:TemplateField HeaderText="Building Price">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblBuildingPrice" Text='<%#Eval("Price") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate >
                        <asp:TextBox ID="TextPrice" Text='<%#Eval("Price")%>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <%--Country--%>
             <asp:TemplateField HeaderText="Country">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblBuildingCountry" Text='<%#Eval("Country") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate >
                        <asp:TextBox ID="TextCountry" Text='<%#Eval("Country")%>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
               
                <%--CarpetArea--%>
                 <asp:TemplateField HeaderText="CarpetArea">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblCarpetArea" Text='<%#Eval("CarpetArea") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate >
                        <asp:TextBox ID="TextCarpetArea" Text='<%#Eval("CarpetArea")%>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
             
                <%--BuildUPArea--%>
                <asp:TemplateField HeaderText="BuildUpArea">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblBuildUpArea" Text='<%#Eval("BuildingUpArea") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate >
                        <asp:TextBox ID="TextBuiltUpArea" Text='<%#Eval("BuildingUpArea")%>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <%--Address--%>
                <asp:TemplateField HeaderText="Building_Address">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblBuildingAddress" Text='<%#Eval("BuildingAddress") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate >
                        <asp:TextBox ID="TextAddress" Text='<%#Eval("BuildingAddress")%>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

             <%--Email--%>
                <asp:TemplateField HeaderText="Email_ID">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblEmailid" Text='<%#Eval("Email_ID") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate >
                        <asp:TextBox ID="TextEmailid" Text='<%#Eval("Email_ID")%>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <%--Decription--%>
                 <asp:TemplateField HeaderText="Decription">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblDecription" Text='<%#Eval("Description") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate >
                        <asp:TextBox ID="TextDecription" Text='<%#Eval("Description")%>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <%--image--%>
                <asp:TemplateField HeaderText="Building Image">
                    <ItemTemplate>
                        <asp:Image ID="imagePath" ImageUrl='<%#Eval("Image")%>' runat="server" Height="70px" Width="100px" />
                    </ItemTemplate>
                   
                </asp:TemplateField>

                <%-- for ConfigId Dropdown --%>
                
               <asp:TemplateField  HeaderText="Config_ID">
                                <ItemTemplate >
                                      <asp:Label ID="lblConfig_ID" runat="server" Text='<%#Eval("ConfigID")%>'></asp:Label> 
                                </ItemTemplate>
                   
                          <ItemTemplate> 
                              <asp:DropDownList ID="ddlConfig_ID" runat="server" AutoPostBack="true"></asp:DropDownList>
                              <asp:HiddenField ID="lblConfig_ID" runat="server" Value='<%#Eval("ConfigID")%>' />
                          </ItemTemplate>
                    </asp:TemplateField>
                <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true"  />
            </Columns>

        </asp:GridView>
        <asp:Label ID="lblCount" runat="server" Text="Total Row Are: "></asp:Label>

        
        <div>
        </div>
    </form>
</body>
</html>
