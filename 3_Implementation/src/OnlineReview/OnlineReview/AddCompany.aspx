<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true"
    CodeBehind="AddCompany.aspx.cs" Inherits="OnlineReview.AddCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Company Details</h3>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <form id="Form1" role="form" runat="server">
                                <div class="form-group">
                                    <label>
                                        Company Name</label>
                                    <asp:TextBox ID="txtCompanyName" class="form-control" runat="server" placeholder="Company Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Company Name"
                                        ControlToValidate="txtCompanyName" ForeColor="#FF3300" ValidationGroup="B"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Contact Person</label>
                                    <asp:TextBox ID="txtContactPerson" class="form-control" runat="server" placeholder="Contact Person"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter Contact Person"
                                        ControlToValidate="txtContactPerson" ForeColor="#FF3300" ValidationGroup="B"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Mobile No</label>
                                    <asp:TextBox ID="txtMobileNo" class="form-control" runat="server" placeholder="Only 10 Digits"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Mobile No"
                                        ControlToValidate="txtMobileNo" ForeColor="#FF3300" ValidationGroup="B"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtMobileNo"
                                        ErrorMessage="Only 10 Digits" ForeColor="#FF3300" ValidationExpression="[0-9]{10}"
                                        ValidationGroup="B"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Email Id</label>
                                    <asp:TextBox ID="txtEmailId" class="form-control" runat="server" placeholder="Enter Email Id"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Email Id"
                                        ControlToValidate="txtEmailId" ForeColor="#FF3300" ValidationGroup="B"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Email Id"
                                        ControlToValidate="txtEmailId" ForeColor="#FF3300" ValidationGroup="B" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Address</label>
                                    <asp:TextBox ID="txtAddress" class="form-control" runat="server" placeholder="Address"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Address"
                                        ControlToValidate="txtAddress" ForeColor="#FF3300" ValidationGroup="B"></asp:RequiredFieldValidator>
                                </div>
                                <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label>
                                <div class="pull-right">
                                    <asp:Button ID="btnSubmit" class="btn btn-default" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                                        ValidationGroup="B" />
                                    <button type="reset" class="btn btn-default">
                                        Cancel</button>
                                </div>
                                </form>
                            </div>
                            <!-- /.col-lg-6 (nested) -->
                            <!-- /.col-lg-6 (nested) -->
                        </div>
                        <!-- /.row (nested) -->
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
    </div>
</asp:Content>
