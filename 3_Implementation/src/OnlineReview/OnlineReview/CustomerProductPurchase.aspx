<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true"
    CodeBehind="CustomerProductPurchase.aspx.cs" Inherits="OnlineReview.CustomerProductPurchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="title text-capitalize font-weight-light text-dark text-center mb-5">
        <span class="font-weight-bold">Purchase Product</span>
    </h3>
    <div class="contact-grids1 w3agile-6">
        <div class="row">
            <div class="col-md-6 col-sm-6 contact-form1 form-group">
                <label class="col-form-label">
                    Select Category</label>
                <asp:DropDownList ID="ddlCategory" runat="server" class="form-control" autofocus
                    AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Select Category"
                    InitialValue="--Select--" ControlToValidate="ddlCategory" ForeColor="#FF3300"
                    ValidationGroup="A"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-6 col-sm-6 contact-form1 form-group">
                <label class="col-form-label">
                    Select Shop</label>
                <asp:DropDownList ID="ddlShop" runat="server" class="form-control" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlShop_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlShop"
                    ForeColor="#FF3300" ValidationGroup="A" InitialValue="--Select--" runat="server"
                    ErrorMessage="Select Shop"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-6 col-sm-6 contact-form1 form-group">
                <label class="col-form-label">
                    Select Company</label>
                <asp:DropDownList ID="ddlCompany" runat="server" class="form-control" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlCompany"
                    ForeColor="#FF3300" ValidationGroup="A" InitialValue="--Select--" runat="server"
                    ErrorMessage="Select Company"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-6 col-sm-6 contact-form1 form-group">
                <label class="col-form-label">
                    Select Product</label>
                <asp:DropDownList ID="ddlProduct" runat="server" class="form-control" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlProduct"
                    ForeColor="#FF3300" ValidationGroup="A" InitialValue="--Select--" runat="server"
                    ErrorMessage="Select Product"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-6 col-sm-6 contact-form1 form-group">
                <label class="col-form-label">
                    Product Description</label>
                <asp:TextBox ID="txtDescription" class="form-control" runat="server" placeholder="Description"
                    ReadOnly="true"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Description"
                    ControlToValidate="txtDescription" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-6 col-sm-6 contact-form1 form-group">
                <label class="col-form-label">
                    Product Price</label>
                <asp:TextBox ID="txtPrice" class="form-control" runat="server" placeholder="Product Price"
                    ReadOnly="true"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Product Price"
                    ControlToValidate="txtPrice" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-12 col-sm-12 contact-form1 form-group">
                <label class="col-form-label">
                    Enter Qty</label>
                <asp:TextBox ID="txtQty" class="form-control" runat="server" placeholder="Enter Product Qty"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter Product Qty"
                    ControlToValidate="txtQty" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="contact-form">
            <asp:Button ID="btnSubmit" class="btn btn-default" runat="server" Text="Order Product"
                OnClick="btnSubmit_Click" ValidationGroup="A" />
        </div>
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        <asp:Panel ID="Panel1" runat="server">
            <h3 class="title text-capitalize font-weight-light text-dark text-center mb-5">
                <span class="font-weight-bold">Product Gallery</span>
            </h3>
            <div class="row">
                <div class="inner-sec pt-md-4">
                    <div class="row proj_gallery_grid">
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <div class="col-sm-4 section_1_gallery_grid">
                                    <a href="#" class="thumbnail img-responsive">
                                        <div class="section_1_gallery_grid1">
                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("FilePath") %>' />
                                        </div>
                                    </a>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server">
            <h3 class="title text-capitalize font-weight-light text-dark text-center mb-5">
                <span class="font-weight-bold">Product Review Details</span>
            </h3>
            <div class="row">
                <div class="col-md-12 col-sm-12 contact-form1 form-group">
                    <asp:Table class="table table-striped table-bordered table-hover" ID="Table1" runat="server">
                    </asp:Table>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server">
            <div class="row">
                <div class="col-md-12 col-sm-12 contact-form1 form-group">
                    <label class="col-form-label">
                        Product Review</label>
                    <asp:TextBox ID="txtReview" class="form-control" runat="server" placeholder="Product Review" ReadOnly="true"
                        TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
        </asp:Panel>
    </div>
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <div id="myCarousel" class="carousel slide">
                        <div class="carousel-inner">
                            <div class="item">
                                <img id="imgurl" src="" style="height: 400px; width: 100%" name="1" class="img-responsive" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <link rel="stylesheet" href="css/bootstrap_css.css">
    <script src="js/jquery-2.2.3.min.js"></script>
    <!-- Default-JavaScript-File -->
    <script src="js/bootstrap.js"></script>
    <script type="text/javascript">
    $(document).ready(function () {
    $('.thumbnail').click(function () {
        var name = $(this).find('img').attr('src');
        $('#imgurl').attr('src',name);
        var mname = $('.carousel-inner').find("img[src='" + $(this).find('img').attr('src') + "']");
        $('.carousel-inner div').removeClass("active");
        $(mname).parent().addClass("active");
        $('#myModal').modal({
            backdrop: 'static',
        }, 'show');
    });
 
 
    $(function () {
        $("#myCarousel").carousel({
            interval: 5000
        });
    });
});
    </script>
</asp:Content>
