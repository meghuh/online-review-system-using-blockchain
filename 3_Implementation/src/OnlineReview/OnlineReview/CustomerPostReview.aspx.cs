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
    public partial class CustomerPostReview : System.Web.UI.Page
    {
        OnlineReviewBLL objBLL = null;
        OnlineReviewDTO objDTO = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Panel1.Visible = false;
            }
            LoadData();
        }
        private void LoadData()
        {
            objBLL = new OnlineReviewBLL();
            objDTO = new OnlineReviewDTO();
            objDTO.CustomerId = Session["UserId"].ToString();
            DataTable tab = new DataTable();
            tab = objBLL.GetCPO_CId(objDTO);
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
               

                hc1.Text = "Product Name";
                hr.Cells.Add(hc1);
                hc2.Text = "Company Name";
                hr.Cells.Add(hc2);
                hc3.Text = "Order Date";
                hr.Cells.Add(hc3);
                hc4.Text = "Qty";
                hr.Cells.Add(hc4);
                hc5.Text = "";
                hr.Cells.Add(hc5);
               
                Table1.Rows.Add(hr);
                for (int i = 0; i < tab.Rows.Count; i++)
                {

                    TableRow row = new TableRow();

                    Label lblProductName = new Label();
                    lblProductName.Text = tab.Rows[i]["ProductName"].ToString();
                    TableCell ProductName = new TableCell();
                    ProductName.Controls.Add(lblProductName);

                    Label lblCompanyName = new Label();
                    lblCompanyName.Text = tab.Rows[i]["CompanyName"].ToString();
                    TableCell CompanyName = new TableCell();
                    CompanyName.Controls.Add(lblCompanyName);

                    Label lblPODate = new Label();
                    lblPODate.Text = tab.Rows[i]["PODate"].ToString();
                    TableCell PODate = new TableCell();
                    PODate.Controls.Add(lblPODate);
                    

                    Label lblQty = new Label();
                    lblQty.Text = tab.Rows[i]["Qty"].ToString();
                    TableCell Qty = new TableCell();
                    Qty.Controls.Add(lblQty);


                    LinkButton PostReview = new LinkButton();
                    PostReview.ID = "lnkPostReview" + i.ToString();
                    PostReview.Text = "Post Review";
                    PostReview.CommandArgument = tab.Rows[i]["CPOId"].ToString();
                    PostReview.Click += new EventHandler(PostReview_Click);
                    TableCell PostReviewcell = new TableCell();
                    PostReviewcell.Controls.Add(PostReview);

                    row.Controls.Add(ProductName);
                    row.Controls.Add(CompanyName);
                    row.Controls.Add(PODate);
                    row.Controls.Add(Qty);
                    row.Controls.Add(PostReviewcell);

                    Table1.Controls.Add(row);

                }
            }
            else
            {
                lblMsg.Text = "No Record Found";
            }
        }
        static int CPOId = 0;
        void PostReview_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            CPOId = int.Parse(lnk.CommandArgument);
            Panel1.Visible = true;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            objBLL = new OnlineReviewBLL();
            objDTO = new OnlineReviewDTO();
            objDTO.CPOId = CPOId;
            objDTO.Description = txtReview.Text;
            string result = objBLL.CreateTable_CPR(objDTO);
            if (result == "1")
            {
                txtReview.Text = "";
                Response.Redirect("CustomerPostReview.aspx");
                Panel1.Visible = false;
                lblMsg.Text = "Product Review Posted Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                txtReview.Text = "";
                lblMsg.Text = "Product Review Post Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}