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
    public partial class CompanyViewWallet : System.Web.UI.Page
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
            tab = objBLL.CompanyWalletDetails(objDTO);
            Table1.Controls.Clear();
            lblMsg.Text = "";
            if (tab.Rows.Count > 0)
            {
                lblMsg.Text = "Current A/c Balance Rs." + tab.Rows[0]["Balance"].ToString() + "/-";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                TableRow hr = new TableRow();
                TableHeaderCell hc1 = new TableHeaderCell();
                TableHeaderCell hc2 = new TableHeaderCell();
                TableHeaderCell hc3 = new TableHeaderCell();
                TableHeaderCell hc4 = new TableHeaderCell();
                TableHeaderCell hc5 = new TableHeaderCell();

                hc1.Text = "Shop Name";
                hr.Cells.Add(hc1);
                hc2.Text = "Product Name";
                hr.Cells.Add(hc2);
                hc3.Text = "Order Date";
                hr.Cells.Add(hc3);
                hc4.Text = "Qty";
                hr.Cells.Add(hc4);
                hc5.Text = "Amount";
                hr.Cells.Add(hc5);
                Table1.Rows.Add(hr);
                for (int i = 0; i < tab.Rows.Count; i++)
                {

                    TableRow row = new TableRow();

                    Label lblShopName = new Label();
                    lblShopName.Text = tab.Rows[i]["ShopName"].ToString();
                    TableCell ShopName = new TableCell();
                    ShopName.Controls.Add(lblShopName);

                    Label lblProductName = new Label();
                    lblProductName.Text = tab.Rows[i]["ProductName"].ToString();
                    TableCell ProductName = new TableCell();
                    ProductName.Controls.Add(lblProductName);

                    Label lblPurchaseDate = new Label();
                    lblPurchaseDate.Text = tab.Rows[i]["PurchaseDate"].ToString();
                    TableCell PurchaseDate = new TableCell();
                    PurchaseDate.Controls.Add(lblPurchaseDate);

                    Label lblQty = new Label();
                    lblQty.Text = tab.Rows[i]["Qty"].ToString();
                    TableCell Qty = new TableCell();
                    Qty.Controls.Add(lblQty);


                    Label lblAmount = new Label();
                    lblAmount.Text = tab.Rows[i]["Amount"].ToString();
                    TableCell Amount = new TableCell();
                    Amount.Controls.Add(lblAmount);



                    row.Controls.Add(ShopName);
                    row.Controls.Add(ProductName);
                    row.Controls.Add(PurchaseDate);
                    row.Controls.Add(Qty);
                    row.Controls.Add(Amount);

                    Table1.Controls.Add(row);

                }
            }
            else
            {
                lblMsg.Text = "No Record Found";
            }
        }
    }
}