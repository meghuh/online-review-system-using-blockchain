<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="AddCustomerWallet.aspx.cs" Inherits="OnlineReview.AddCustomerWallet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <h3 class="title text-capitalize font-weight-light text-dark text-center mb-5">
				<span class="font-weight-bold">Add Amount To Wallet</span>
			</h3>
    <div class="contact-grids1 w3agile-6">
        <div class="row">
            <div class="col-md-12 col-sm-12 contact-form1 form-group">
               
                 <label class="col-form-label">
                                        Enter Amount</label>
                                    <asp:TextBox ID="txtAmount" class="form-control" runat="server" 
                                        placeholder="Enter Amount" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Amount"
                                        ControlToValidate="txtAmount" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
            </div>
            
        </div>
        <div class="contact-form">
            <asp:Button ID="btnSave" runat="server" Text="Save"  class="btn btn-primary" ValidationGroup="A"
                onclick="btnSave_Click" />
        </div>
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
