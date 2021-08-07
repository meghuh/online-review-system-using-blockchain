<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true"
    CodeBehind="CustomerPostReview.aspx.cs" Inherits="OnlineReview.CustomerPostReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="title text-capitalize font-weight-light text-dark text-center mb-5">
        <span class="font-weight-bold">Product Details</span>
    </h3>
    <div class="contact-grids1 w3agile-6">
        <div class="row">
            <div class="col-md-12 col-sm-12 contact-form1 form-group">
                <asp:Table class="table table-striped table-bordered table-hover" ID="Table1" runat="server">
                </asp:Table>
            </div>
        </div>
        <asp:Panel ID="Panel1" runat="server">
            <div class="row">
                <div class="col-md-12 col-sm-12 contact-form1 form-group">
                    <label class="col-form-label">
                        Enter Product Review</label>
                    <asp:TextBox ID="txtReview" class="form-control" runat="server" placeholder="Enter Product Review"
                        TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Product Review"
                        ControlToValidate="txtReview" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="contact-form">
                <asp:Button ID="btnSave" runat="server" Text="Post Review" class="btn btn-primary"
                    ValidationGroup="A" OnClick="btnSave_Click" />
            </div>
        </asp:Panel>
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
