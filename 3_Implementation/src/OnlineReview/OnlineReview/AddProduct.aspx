<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="OnlineReview.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Add Products</h3>
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
                                        Select Category</label>
                                    <asp:DropDownList ID="ddlCategory" runat="server" class="form-control" autofocus>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlCategory"
                                     ForeColor="#FF3300" ValidationGroup="B" InitialValue="--Select--" runat="server" ErrorMessage="Select Product Category"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Select Company</label>
                                    <asp:DropDownList ID="ddlCompany" runat="server" class="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlCompany"
                                        ForeColor="#FF3300" ValidationGroup="B" InitialValue="--Select--" runat="server" ErrorMessage="Select Company"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Enter Product Name</label>
                                    <asp:TextBox ID="txtProductName" class="form-control" runat="server" placeholder="Product Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Product Name"
                                        ControlToValidate="txtProductName" ForeColor="#FF3300" ValidationGroup="B"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Enter Description</label>
                                    <asp:TextBox ID="txtDescription" class="form-control" runat="server" placeholder="Enter Description"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Description"
                                        ControlToValidate="txtDescription" ForeColor="#FF3300" ValidationGroup="B"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Enter Product Price</label>
                                    <asp:TextBox ID="txtPrice" class="form-control" runat="server" placeholder="Product Price"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Product Price"
                                        ControlToValidate="txtPrice" ForeColor="#FF3300" ValidationGroup="B"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Enter Company Product Price</label>
                                    <asp:TextBox ID="txtCPrice" class="form-control" runat="server" placeholder="Company Product Price"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter Company Product Price"
                                        ControlToValidate="txtCPrice" ForeColor="#FF3300" ValidationGroup="B"></asp:RequiredFieldValidator>
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
