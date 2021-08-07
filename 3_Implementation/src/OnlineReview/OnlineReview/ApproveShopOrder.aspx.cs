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
    public partial class ApproveShopOrder : System.Web.UI.Page
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
            objDTO.CompanyId = int.Parse(Session["UserId"].ToString());
            DataTable tab = new DataTable();
            tab = objBLL.GetProductOrder_CompanyId(objDTO);
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

                hc1.Text = "Shop Name";
                hr.Cells.Add(hc1);
                hc2.Text = "Mobile No";
                hr.Cells.Add(hc2);
                hc3.Text = "Order Date";
                hr.Cells.Add(hc3);
                hc4.Text = "Product Name";
                hr.Cells.Add(hc4);
                hc5.Text = "Qty";
                hr.Cells.Add(hc5);
                hc6.Text = "";
                hr.Cells.Add(hc6);
                Table1.Rows.Add(hr);
                for (int i = 0; i < tab.Rows.Count; i++)
                {

                    TableRow row = new TableRow();

                    Label lblShopName = new Label();
                    lblShopName.Text = tab.Rows[i]["ShopName"].ToString();
                    TableCell ShopName = new TableCell();
                    ShopName.Controls.Add(lblShopName);

                    Label lblMobileNo = new Label();
                    lblMobileNo.Text = tab.Rows[i]["MobileNo"].ToString();
                    TableCell MobileNo = new TableCell();
                    MobileNo.Controls.Add(lblMobileNo);

                    Label lblPurchaseDate = new Label();
                    lblPurchaseDate.Text = tab.Rows[i]["PurchaseDate"].ToString();
                    TableCell PurchaseDate = new TableCell();
                    PurchaseDate.Controls.Add(lblPurchaseDate);

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
                    Approve.CommandArgument = tab.Rows[i]["PurchaseId"].ToString();
                    Approve.Click += new EventHandler(Approve_Click);
                    TableCell Approvecell = new TableCell();
                    Approvecell.Controls.Add(Approve);

                    row.Controls.Add(ShopName);
                    row.Controls.Add(MobileNo);
                    row.Controls.Add(PurchaseDate);
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
            objDTO.PurchaseId = int.Parse(lnk.CommandArgument);
            string res = objBLL.ApproveProduct(objDTO);
            if (res == "1")
            {
                Response.Redirect("ApproveShopOrder.aspx");
            }
        }
    }
}