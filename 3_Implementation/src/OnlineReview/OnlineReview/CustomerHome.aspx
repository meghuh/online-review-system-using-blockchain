<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="CustomerHome.aspx.cs" Inherits="OnlineReview.CustomerHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="title text-capitalize font-weight-light text-dark text-center mb-5">
				<span class="font-weight-bold">Change Password</span>
			</h3>
    <div class="contact-grids1 w3agile-6">
        <div class="row">
            <div class="col-md-12 col-sm-12 contact-form1 form-group">
               
                 <label class="col-form-label">
                                        Old Password</label>
                                    <asp:TextBox ID="txtOldPassword" class="form-control" runat="server" 
                                        placeholder="Old Password" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Old Password"
                                        ControlToValidate="txtOldPassword" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-12 col-sm-12 contact-form1 form-group">
               
                 <label class="col-form-label">
                                        New Password</label>
                                      <asp:TextBox ID="txtNewPassword" class="form-control" runat="server" 
                                        placeholder="New Password" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter New Password"
                                        ControlToValidate="txtNewPassword" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-12 col-sm-12 contact-form1 form-group">
               
                 <label class="col-form-label">
                                        Confirm Password</label>
                                   <asp:TextBox ID="txtConfirmPassword" class="form-control" runat="server" 
                                        placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Confirm Password"
                                        ControlToValidate="txtConfirmPassword" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                        ErrorMessage="Password Not Match" ControlToCompare="txtNewPassword" 
                                        ControlToValidate="txtConfirmPassword" ForeColor="#FF3300" ValidationGroup="A"></asp:CompareValidator>
            </div>
        </div>
        <div class="contact-form">
            <asp:Button ID="btnSave" runat="server" Text="Save"  class="btn btn-primary" ValidationGroup="A"
                onclick="btnSave_Click" />
        </div>
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
