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
    public partial class ViewProductDetails : System.Web.UI.Page
    {
        OnlineReviewBLL objBLL = null;
        OnlineReviewDTO objDTO = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objBLL = new OnlineReviewBLL();
                objDTO = new OnlineReviewDTO();
                objDTO.ShopId = int.Parse(Session["UserId"].ToString());
                DataTable tab = new DataTable();
                tab = objBLL.GetCompanyDetails(objDTO);
                ddlCompany.DataSource = tab;
                ddlCompany.DataTextField = "CompanyName";
                ddlCompany.DataValueField = "CompanyId";
                ddlCompany.DataBind();
                ddlCompany.Items.Insert(0, "--Select--");
            }
            LoadData();
        }

        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch
            {
 
            }
        }
        private void LoadData()
        {
            try
            {
                objBLL = new OnlineReviewBLL();
                objDTO = new OnlineReviewDTO();
                objDTO.CompanyId = int.Parse(ddlCompany.SelectedItem.Value);
                DataTable tab = new DataTable();
                tab = objBLL.GetProductDetails_CompanyId(objDTO);
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
                    hc2.Text = "Description";
                    hr.Cells.Add(hc2);
                    hc3.Text = "Price";
                    hr.Cells.Add(hc3);
                    hc4.Text = "Company Price";
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


                        Label lblDescription = new Label();
                        lblDescription.Text = tab.Rows[i]["Description"].ToString();
                        TableCell Description = new TableCell();
                        Description.Controls.Add(lblDescription);

                        Label lblPrice = new Label();
                        lblPrice.Text = tab.Rows[i]["Price"].ToString();
                        TableCell Price = new TableCell();
                        Price.Controls.Add(lblPrice);

                        Label lblCPrice = new Label();
                        lblCPrice.Text = tab.Rows[i]["CPrice"].ToString();
                        TableCell CPrice = new TableCell();
                        CPrice.Controls.Add(lblCPrice);

                        LinkButton Edit = new LinkButton();
                        Edit.ID = "lnkEdit" + i.ToString();
                        Edit.Text = "Edit";
                        Edit.CommandArgument = tab.Rows[i]["ProductId"].ToString();
                        Edit.Click += new EventHandler(Edit_Click);
                        TableCell Editcell = new TableCell();
                        Editcell.Controls.Add(Edit);

                        row.Controls.Add(ProductName);
                        row.Controls.Add(Description);
                        row.Controls.Add(Price);
                        row.Controls.Add(CPrice);
                        row.Controls.Add(Editcell);

                        Table1.Controls.Add(row);

                    }
                }
                else
                {
                    lblMsg.Text = "No Record Found";
                }
            }
            catch
            {
 
            }
        }



        void Edit_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            Response.Redirect("AddProduct.aspx?ProductId=" + lnk.CommandArgument.ToString());
        }
    }
}