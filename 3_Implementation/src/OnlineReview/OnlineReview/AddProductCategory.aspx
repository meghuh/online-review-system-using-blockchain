<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="AddProductCategory.aspx.cs" Inherits="OnlineReview.AddProductCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                  Product Category Details</h3>
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
                                        Category Name</label>
                                    <asp:TextBox ID="txtCategoryName" class="form-control" runat="server" placeholder="Category Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Category Name"
                                        ControlToValidate="txtCategoryName" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>
                                
                               
                                <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label>
                                <div class="pull-right">
                                    <asp:Button ID="btnSubmit" class="btn btn-default" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                                        ValidationGroup="A" />
                                    
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
