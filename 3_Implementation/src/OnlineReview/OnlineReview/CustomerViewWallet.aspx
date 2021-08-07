<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="CustomerViewWallet.aspx.cs" Inherits="OnlineReview.CustomerViewWallet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h3 class="title text-capitalize font-weight-light text-dark text-center mb-5">
        <span class="font-weight-bold">Wallet Details</span>
    </h3>
    <div class="contact-grids1 w3agile-6">
        <div class="row">
            <div class="col-md-12 col-sm-12 contact-form1 form-group">
                <asp:Table class="table table-striped table-bordered table-hover" ID="Table1" runat="server">
                </asp:Table>
            </div>
        </div>
        
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
