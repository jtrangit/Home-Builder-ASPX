<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeBuilder.aspx.cs" Inherits="DreamHomeBuilder.HomeBuilder" MaintainScrollPositionOnPostback="true" %>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-aFq/bzH65dt+w6FI2ooMVUpc+21e0SRygnTpmBvdBgSdnuTN7QbdgL+OapgHtvPp" crossorigin="anonymous">
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha2/dist/js/bootstrap.bundle.min.js" integrity="sha384-qKXV1j0HvMUeCBQ+QVp7JcfGl760yU08IQ+GpUo5hlbpg51QRiuqHAJz8+BrxE/N" crossorigin="anonymous"></script>
<link href="HomeBuilder.css" type="text/css" rel="stylesheet"/>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="buyerInfo">
            <h2>Enter your information below</h2> 
            <h3>Name:  <asp:TextBox ID="txtBuyerName" runat="server"></asp:TextBox> <br /> </h3>
            <h3>Email:  <asp:TextBox ID="txtBuyerEmail" runat="server"></asp:TextBox> <br /> </h3>
            <h3>Address:  <asp:TextBox ID="txtBuyerAddress" runat="server"></asp:TextBox> <br /> </h3>
            <h3>Phone Number:  <asp:TextBox ID="txtBuyerPhoneNumber" runat="server"></asp:TextBox> <br /> </h3>
            <h3>Employment:  <asp:TextBox ID="txtBuyerEmployment" runat="server"></asp:TextBox> <br /> </h3>
            <h3>Annual Income: $ <asp:TextBox ID="txtBuyerIncome" runat="server"></asp:TextBox> <br /> </h3>
            <h3>Date of move-in: <asp:TextBox ID="txtBuyerMoveDate" runat="server" TextMode="Date"></asp:TextBox></h3>
            <br /> <br />
        </div>

        <asp:RequiredFieldValidator ID="valBuyerName" runat="server" ControlToValidate="txtBuyerName" CssClass="field-validation-error" ErrorMessage="** Name Required **" Font-Bold="true" ForeColor="#CC0000"
        style="z-index: 1; left: 400px; top: 50px; position: absolute; height: 15px"></asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator ID="valEmail" runat="server" ControlToValidate="txtBuyerEmail" ErrorMessage="** Email Required **" Font-Bold="true" ForeColor="#CC0000"
        style="z-index: 1; left: 395px; top: 100px; position: absolute; height: 15px"></asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator ID="valAddress" runat="server" ControlToValidate="txtBuyerAddress" ErrorMessage="** Address Required **" Font-Bold="true" ForeColor="#CC0000"
        style="z-index: 1; left: 425px; top: 150px; position: absolute; height: 15px"></asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator ID="valPhoneNum" runat="server" ControlToValidate="txtBuyerPhoneNumber" ErrorMessage="** Phone Number Required **" Font-Bold="true" ForeColor="#CC0000"
        style="z-index: 1; left: 525px; top: 195px; position: absolute; height: 15px"></asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator ID="valEmployment" runat="server" ControlToValidate="txtBuyerEmployment" ErrorMessage="** Employment Required **" Font-Bold="true" ForeColor="#CC0000"
        style="z-index: 1; left: 500px; top: 245px; position: absolute; height: 15px"></asp:RequiredFieldValidator>

        <asp:CompareValidator ID="valIncome" runat="server" ControlToValidate="txtBuyerIncome" Operator="GreaterThanEqual" Type="Currency" ValueToCompare="350000"
        ErrorMessage="Enter Income Greater or Equal to $350,000" style="z-index: 1; left: 550px; top: 295px; position: absolute; height: 15px" Font-Bold="true" ForeColor="#CC0000"></asp:CompareValidator>

        <asp:RequiredFieldValidator ID="valMoveInDate" runat="server" ControlToValidate="txtBuyerMoveDate" ErrorMessage="** Move-in Date Required **" Font-Bold="true" ForeColor="#CC0000"
        style="z-index: 1; left: 495px; top: 340px; position: absolute; height: 15px"></asp:RequiredFieldValidator>

        <div class="homeplanInfo">
        <asp:GridView ID="gvHomes" runat="server" AutoGenerateColumns="false" OnRowCommand="gvHomes_RowCommand" DataKeyNames="ImageURL" OnRowDataBound="gvHomes_RowDataBound" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px">
        
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Home Plan" />

                <asp:BoundField DataField="Description" HeaderText="Home Description" />

                <asp:BoundField DataField="Bedrooms" HeaderText="Number of Bedrooms" />

                <asp:BoundField DataField="Bathrooms" HeaderText="Number of Bathrooms" />

                <asp:BoundField DataField="Size" HeaderText="Size in square feet" />

                <asp:BoundField DataField="ImageURL" HeaderText="House Image" ReadOnly="true" Visible="false"/>

                <asp:BoundField DataField="Price" HeaderText="Home Price (USD)" DataFormatString="{0:C}"/>

                <asp:ButtonField ButtonType="Button" HeaderText="" Text="Select" CommandName="selectHomePlan"  />
                                
            </Columns>

        </asp:GridView>

           <h2>Current Selected Home Plan: <asp:Label ID="lblSelectedHomePlan" runat="server" Font-Bold="true" ForeColor="#00ccff">No Homeplan Selected</asp:Label></h2>
            
            <div class="homeImg">
            <asp:Image ID="homeImage" runat="server" width="500px" />
            </div>
            <br /><br />
        </div>

        <div class="roofingInfo">
        <h3>Roofing Material</h3>
        <asp:GridView ID="gvRoofing" runat="server" AutoGenerateColumns="false" OnRowCommand="gvRoofing_RowCommand">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Material" />

                <asp:BoundField DataField="Life Span" HeaderText="Life Span" />

                <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />

                <asp:ButtonField ButtonType="Button" HeaderText="" Text="Select" CommandName="selectRoofing" />

            </Columns>
        </asp:GridView>
        <h2>Current Selected Roofing: <asp:Label ID="lblSelectedRoofing" runat="server" Font-Bold="true" ForeColor="#00ccff">No Roofing Selected</asp:Label></h2>
        <br /><br />
        </div>

        <div class="countertopInfo">
        <h3>Countertop Material</h3>
        <asp:GridView ID="gvCountertop" runat="server" AutoGenerateColumns="false" OnRowCommand="gvCountertop_RowCommand">
            <Columns>
                <asp:BoundField DataField="Material" HeaderText="Material"/>

                <asp:BoundField DataField="Maintenance" HeaderText="Maintenance"/>

                <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}"/>

                <asp:ButtonField ButtonType="Button" HeaderText="" Text="Select" CommandName="selectCountertop" />

            </Columns>
        </asp:GridView>
        <h2>Current Selected Countertop: <asp:Label ID="lblSelectedCountertop" runat="server" Font-Bold="true" ForeColor="#00ccff">No Countertop Selected</asp:Label></h2>
        <br /><br />
        </div>

        <div class="homeAdditionInfo">
        <h3>Home Additions</h3>
        <asp:GridView ID="gvHomeAdditions" runat="server" AutoGenerateColumns="false">
            
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkAdditionSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="Name" HeaderText="Additions"/>
                <asp:BoundField DataField="Description" HeaderText="Description"/>
                <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}"/>
                
            </Columns>
        </asp:GridView>
        <br />
        <br />
        </div>

        <div class="submit">
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click1" />
        </div>
    </form>
</body>
</html>

