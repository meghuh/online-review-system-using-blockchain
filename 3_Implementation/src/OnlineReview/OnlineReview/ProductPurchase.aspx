<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="ProductPurchase.aspx.cs" Inherits="OnlineReview.ProductPurchase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Product Purchase Details</h3>
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
                                        Select Company</label>
                                    <asp:DropDownList ID="ddlCompany" runat="server" class="form-control" autofocus 
                                        AutoPostBack="True" 
                                        onselectedindexchanged="ddlCompany_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlCompany"
                                     ForeColor="#FF3300" ValidationGroup="B" InitialValue="--Select--" runat="server" ErrorMessage="Select Company"></asp:RequiredFieldValidator>
                                </div>
                                
                                 <div class="form-group">
                                    <label>
                                        Select Product</label>
                                    <asp:DropDownList ID="ddlProduct" runat="server" class="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlProduct"
                                     ForeColor="#FF3300" ValidationGroup="B" InitialValue="--Select--" runat="server" ErrorMessage="Select Product"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Product Qty</label>
                                    <asp:TextBox ID="txtQty" class="form-control" runat="server" 
                                        placeholder="Product Qty" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtQty"
                                     ForeColor="#FF3300" ValidationGroup="B"  runat="server" ErrorMessage="Enter Product Qty"></asp:RequiredFieldValidator>
                                </div>
                                
                                <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label>
                                <div class="pull-right">
                                    <asp:Button ID="btnSubmit" class="btn btn-default" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                                        ValidationGroup="B" />
                                   
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
