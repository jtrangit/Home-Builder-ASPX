<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="DreamHomeBuilder.Results" %>
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
        <div class="receiptInfo">
            <h3>Buyer Name: <asp:Label ID="lblName" runat="server">Buyer Name Goes Here</asp:Label> <br /> </h3>
            <h3>Email: <asp:Label ID="lblEmail" runat="server">Buyer Email Goes Here</asp:Label> <br /> </h3>
            <h3>Address: <asp:Label ID="lblAddress" runat="server">Buyer Address Goes Here</asp:Label> <br /> </h3>
            <h3>Phone Number: <asp:Label ID="lblPhone" runat="server">Buyer Phone Number Goes Here</asp:Label> <br /> </h3>
            <h3>Employment: <asp:Label ID="lblEmployment" runat="server">Buyer Employment Goes Here</asp:Label> <br /> </h3>
            <h3>Annual Income: <asp:Label ID="lblIncome" runat="server">Buyer Income Goes Here</asp:Label> <br /> </h3>
            <h3>Move-in Date: <asp:Label ID="lblMoveIn" runat="server">Buyer Move-in Date Goes Here</asp:Label><br /> </h3>
        </div> 
        
        <div class="receipt">
            <asp:GridView ID="gvReceipt" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
