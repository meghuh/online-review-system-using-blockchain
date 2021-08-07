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
    public partial class ViewShopWallet : System.Web.UI.Page
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
            tab = objBLL.GetShopWallet(objDTO);
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

                hc1.Text = "Deposit Date";
                hr.Cells.Add(hc1);
                hc2.Text = "Amount";
                hr.Cells.Add(hc2);
                hc3.Text = "Deposit Type";
                hr.Cells.Add(hc3);
                Table1.Rows.Add(hr);
                for (int i = 0; i < tab.Rows.Count; i++)
                {

                    TableRow row = new TableRow();

                    Label lblDDate = new Label();
                    lblDDate.Text = tab.Rows[i]["DDate"].ToString();
                    TableCell DDate = new TableCell();
                    DDate.Controls.Add(lblDDate);


                    Label lblAmount = new Label();
                    lblAmount.Text = tab.Rows[i]["Amount"].ToString();
                    TableCell Amount = new TableCell();
                    Amount.Controls.Add(lblAmount);

                    Label lblDepositType = new Label();
                    lblDepositType.Text = tab.Rows[i]["DepositType"].ToString();
                    TableCell DepositType = new TableCell();
                    DepositType.Controls.Add(lblDepositType);

                    row.Controls.Add(DDate);
                    row.Controls.Add(Amount);
                    row.Controls.Add(DepositType);

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