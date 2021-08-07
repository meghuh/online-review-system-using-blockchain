<%@ Page Title="" Language="C#" MasterPageFile="~/Shop.Master" AutoEventWireup="true"
    CodeBehind="ShopViewCR.aspx.cs" Inherits="OnlineReview.ShopViewCR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Customer Product Review</h3>
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
                    <asp:DropDownList ID="ddlCompany" runat="server" class="form-control" autofocus AutoPostBack="True"
                        OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label>
                        Select Product</label>
                    <asp:DropDownList ID="ddlProduct" runat="server" class="form-control" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
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

                            <asp:Panel ID="Panel1" runat="server">
                        
                            <div class="form-group">
                                <label>
                                    Product Review</label>
                                <asp:TextBox ID="txtReview" class="form-control" runat="server" placeholder="Product Review"
                                    ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        
                    </asp:Panel>
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
