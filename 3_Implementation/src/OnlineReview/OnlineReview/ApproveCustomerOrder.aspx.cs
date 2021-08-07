using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineReview.BLL;
using OnlineReview.DTO;
using System.Data;

namespace OnlineReview
{
    public partial class ApproveCustomerOrder : System.Web.UI.Page
    {
        OnlineReviewBLL objBLL = null;
        OnlineReviewDTO objDTO = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            objBLL = new OnlineReviewBLL();
            objDTO = new OnlineReviewDTO();
            objDTO.ShopId = int.Parse(Session["UserId"].ToString());
            DataTable tab = new DataTable();
            tab = objBLL.GetCPO_SHId(objDTO);
            Table1.Controls.Clear();
            lblMsg.Text = "";
            if (tab.Rows.Count > 0)
            {
                TableRow hr = new TableRow();
                TableHeaderCell hc1 = new TableHeaderCell();
                TableHeaderCell hc2 = new TableHeaderCell();
                TableHeaderCell hc3 = new TableHeaderCell();
                TableHeaderCell hc4 = new TableHeaderCell();
                TableHeaderCell hc5 = new TableHeaderCell();
                TableHeaderCell hc6 = new TableHeaderCell();
                TableHeaderCell hc7= new TableHeaderCell();
                TableHeaderCell hc8 = new TableHeaderCell();

                hc1.Text = "Customer Name";
                hr.Cells.Add(hc1);
                hc2.Text = "Mobile No";
                hr.Cells.Add(hc2);
                hc3.Text = "Address";
                hr.Cells.Add(hc3);
                hc4.Text = "Order Date";
                hr.Cells.Add(hc4);
                hc5.Text = "Company Name";
                hr.Cells.Add(hc5);
                hc6.Text = "Product Name";
                hr.Cells.Add(hc6);
                hc7.Text = "Qty";
                hr.Cells.Add(hc7);
                hc8.Text = "";
                hr.Cells.Add(hc8);
                Table1.Rows.Add(hr);
                for (int i = 0; i < tab.Rows.Count; i++)
                {

                    TableRow row = new TableRow();

                    Label lblCustomerName = new Label();
                    lblCustomerName.Text = tab.Rows[i]["Name"].ToString();
                    TableCell CustomerName = new TableCell();
                    CustomerName.Controls.Add(lblCustomerName);

                    Label lblMobileNo = new Label();
                    lblMobileNo.Text = tab.Rows[i]["MobileNo"].ToString();
                    TableCell MobileNo = new TableCell();
                    MobileNo.Controls.Add(lblMobileNo);

                    Label lblAddress = new Label();
                    lblAddress.Text = tab.Rows[i]["Address"].ToString();
                    TableCell Address = new TableCell();
                    Address.Controls.Add(lblAddress);

                    Label lblPODate = new Label();
                    lblPODate.Text = tab.Rows[i]["PODate"].ToString();
                    TableCell PODate = new TableCell();
                    PODate.Controls.Add(lblPODate);

                    Label lblCompanyName = new Label();
                    lblCompanyName.Text = tab.Rows[i]["CompanyName"].ToString();
                    TableCell CompanyName = new TableCell();
                    CompanyName.Controls.Add(lblCompanyName);

                    Label lblProductName = new Label();
                    lblProductName.Text = tab.Rows[i]["ProductName"].ToString();
                    TableCell ProductName = new TableCell();
                    ProductName.Controls.Add(lblProductName);

                    Label lblQty = new Label();
                    lblQty.Text = tab.Rows[i]["Qty"].ToString();
                    TableCell Qty = new TableCell();
                    Qty.Controls.Add(lblQty);

                    LinkButton Approve = new LinkButton();
                    Approve.ID = "lnkApprove" + i.ToString();
                    Approve.Text = "Approve";
                    Approve.CommandArgument = tab.Rows[i]["CPOId"].ToString();
                    Approve.Click += new EventHandler(Approve_Click);
                    TableCell Approvecell = new TableCell();
                    Approvecell.Controls.Add(Approve);

                    row.Controls.Add(CustomerName);
                    row.Controls.Add(MobileNo);
                    row.Controls.Add(Address);
                    row.Controls.Add(PODate);
                    row.Controls.Add(CompanyName);
                    row.Controls.Add(ProductName);
                    row.Controls.Add(Qty);
                    row.Controls.Add(Approvecell);

                    Table1.Controls.Add(row);

                }
            }
            else
            {
                lblMsg.Text = "No Record Found";
            }
        }

        void Approve_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            objBLL = new OnlineReviewBLL();
            objDTO = new OnlineReviewDTO();
            objDTO.CPOId = int.Parse(lnk.CommandArgument);
            string res = objBLL.ApproveCustomerPO(objDTO);
            if (res == "1")
            {
                Response.Redirect("ApproveCustomerOrder.aspx");
            }
            else if (res == "2")
            {
                lblMsg.Text = "Insufficient Product Stock";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}