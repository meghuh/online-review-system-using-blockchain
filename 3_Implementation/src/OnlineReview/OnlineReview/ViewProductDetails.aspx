<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true" CodeBehind="ViewProductDetails.aspx.cs" Inherits="OnlineReview.ViewProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    View Product Details</h3>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
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
                                   
                                </div>
                                <br />
                <div class="panel panel-default">
                    <div class="panel-heading">
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="dataTable_wrapper">
                            
                                    <asp:Table class="table table-striped table-bordered table-hover" ID="Table1" runat="server">
                                            </asp:Table>
                                            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                                    
                               
                        </div>
                        <!-- /.table-responsive -->
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
                </form>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
    </div>
</asp:Content>
