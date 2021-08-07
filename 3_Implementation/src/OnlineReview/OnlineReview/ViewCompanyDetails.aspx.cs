using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using OnlineReview.BLL;
using OnlineReview.DTO;

namespace OnlineReview
{
    public partial class ViewCompanyDetails : System.Web.UI.Page
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
            tab = objBLL.GetCompanyDetails(objDTO);
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

                hc1.Text = "Company Name";
                hr.Cells.Add(hc1);
                hc2.Text = "Contact Person";
                hr.Cells.Add(hc2);
                hc3.Text = "MobileNo";
                hr.Cells.Add(hc3);
                Table1.Rows.Add(hr);
                for (int i = 0; i < tab.Rows.Count; i++)
                {

                    TableRow row = new TableRow();

                    Label lblCompanyName = new Label();
                    lblCompanyName.Text = tab.Rows[i]["CompanyName"].ToString();
                    TableCell CompanyName = new TableCell();
                    CompanyName.Controls.Add(lblCompanyName);


                    Label lblContactName = new Label();
                    lblContactName.Text = tab.Rows[i]["ContactName"].ToString();
                    TableCell ContactName = new TableCell();
                    ContactName.Controls.Add(lblContactName);

                    Label lblMobileNo = new Label();
                    lblMobileNo.Text = tab.Rows[i]["MobileNo"].ToString();
                    TableCell MobileNo = new TableCell();
                    MobileNo.Controls.Add(lblMobileNo);

                    row.Controls.Add(CompanyName);
                    row.Controls.Add(ContactName);
                    row.Controls.Add(MobileNo);

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