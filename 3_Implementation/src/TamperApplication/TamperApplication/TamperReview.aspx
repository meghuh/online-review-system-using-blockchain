<%@ Page Title="" Language="C#" MasterPageFile="~/Tamper.Master" AutoEventWireup="true"
    CodeBehind="TamperReview.aspx.cs" Inherits="TamperApplication.TamperReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Customer Review Details</h3>
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
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="col-form-label">
                                        Select Category</label>
                                    <asp:DropDownList ID="ddlCategory" runat="server" class="form-control" autofocus
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="col-form-label">
                                        Select Shop</label>
                                    <asp:DropDownList ID="ddlShop" runat="server" class="form-control" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlShop_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="col-form-label">
                                        Select Company</label>
                                    <asp:DropDownList ID="ddlCompany" runat="server" class="form-control" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <label class="col-form-label">
                                    Select Product</label>
                                <asp:DropDownList ID="ddlProduct" runat="server" class="form-control" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <br />
                            <asp:Table class="table table-striped table-bordered table-hover" ID="Table1" runat="server">
                            </asp:Table>
                            <br />
                            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
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
</asp:Content>
