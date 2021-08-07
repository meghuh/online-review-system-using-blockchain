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
    public partial class CustomerProductPurchase : System.Web.UI.Page
    {
        OnlineReviewBLL objBLL = null;
        OnlineReviewDTO objDTO = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objBLL = new OnlineReviewBLL();
                objDTO = new OnlineReviewDTO();
                DataTable tab = new DataTable();
                tab = objBLL.GetProductCategory();
                ddlCategory.DataSource = tab;
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryId";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, "--Select--");

                Panel1.Visible = false;
            }
            LoadData();
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objBLL = new OnlineReviewBLL();
                objDTO = new OnlineReviewDTO();
                objDTO.CategoryId = int.Parse(ddlCategory.SelectedItem.Value);
                DataTable tabcomp = new DataTable();
                tabcomp = objBLL.GetShop_CId(objDTO);
                ddlShop.DataSource = tabcomp;
                ddlShop.DataTextField = "ShopName";
                ddlShop.DataValueField = "ShopId";
                ddlShop.DataBind();
                ddlShop.Items.Insert(0, "--Select--");
            }
            catch
            {
 
            }
        }

        protected void ddlShop_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objBLL = new OnlineReviewBLL();
                objDTO = new OnlineReviewDTO();
                objDTO.ShopId = int.Parse(ddlShop.SelectedItem.Value);
                DataTable tabcomp = new DataTable();
                tabcomp = objBLL.GetCompanyDetails(objDTO);

                ddlCompany.DataSource = tabcomp;
                ddlCompany.DataTextField = "CompanyName";
                ddlCompany.DataValueField = "CompanyId";
                ddlCompany.DataBind();
                ddlCompany.Items.Insert(0, "--Select--");
            }
            catch
            { 
            }
        }

        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objBLL = new OnlineReviewBLL();
                objDTO = new OnlineReviewDTO();
                objDTO.CompanyId = int.Parse(ddlCompany.SelectedItem.Value);
                DataTable tab = new DataTable();
                tab = objBLL.GetProductDetails_CompanyId(objDTO);
                ddlProduct.DataSource = tab;
                ddlProduct.DataTextField = "ProductName";
                ddlProduct.DataValueField = "ProductId";
                ddlProduct.DataBind();
                ddlProduct.Items.Insert(0, "--Select--");
            }
            catch
            {

            }
        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objBLL = new OnlineReviewBLL();
                objDTO = new OnlineReviewDTO();
                DataTable tab = new DataTable();
                objDTO.ProductId = int.Parse(ddlProduct.SelectedItem.Value);

                tab = objBLL.GetProductGallery_PId(objDTO);
                if (tab.Rows.Count > 0)
                {
                    lblMsg.Text = "";
                    Repeater1.DataSource = tab;
                    Repeater1.DataBind();
                    Panel1.Visible = true;
                }
                else
                {
                    lblMsg.Text = "No Record Found";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                DataTable tabp = new DataTable();

                tabp = objBLL.GetProductDetails_ProductId(objDTO);
                txtDescription.Text = tabp.Rows[0]["Description"].ToString();
                txtPrice.Text = tabp.Rows[0]["Price"].ToString();
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
                DataTable tab = new DataTable();
                objDTO.TableName = ddlProduct.SelectedItem.Value.ToString() + "_" + ddlProduct.SelectedItem.Value.ToString();
                tab = objBLL.GetPORDetails_BC(objDTO);
                Table1.Controls.Clear();
                if (tab.Rows.Count > 0)
                {
                    TableRow hr = new TableRow();
                    TableHeaderCell hc1 = new TableHeaderCell();
                    TableHeaderCell hc2 = new TableHeaderCell();
                    TableHeaderCell hc3 = new TableHeaderCell();
                    TableHeaderCell hc4 = new TableHeaderCell();
                    TableHeaderCell hc5 = new TableHeaderCell();
                    TableHeaderCell hc6 = new TableHeaderCell();
                    TableHeaderCell hc7 = new TableHeaderCell();

                    hc1.Text = "Sl No";
                    hr.Cells.Add(hc1);
                    hc2.Text = "Customer Name";
                    hr.Cells.Add(hc2);
                    hc3.Text = "Qty";
                    hr.Cells.Add(hc3);
                    hc4.Text = "Order Date";
                    hr.Cells.Add(hc4);
                    hc5.Text = "Status";
                    hr.Cells.Add(hc5);
                    hc6.Text = "";
                    hr.Cells.Add(hc6);
                    hc7.Text = "";
                    hr.Cells.Add(hc7);
                   


                    Table1.Rows.Add(hr);
                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();

                        Label lblSlNo = new Label();
                        lblSlNo.Text = (i + 1).ToString();
                        TableCell SlNo = new TableCell();
                        SlNo.Controls.Add(lblSlNo);

                        Label lblName = new Label();
                        lblName.Text = tab.Rows[i]["Name"].ToString();
                        TableCell Name = new TableCell();
                        Name.Controls.Add(lblName);

                        Label lblQty = new Label();
                        lblQty.Text = tab.Rows[i]["Qty"].ToString();
                        TableCell Qty = new TableCell();
                        Qty.Controls.Add(lblQty);

                        Label lbllogDate = new Label();
                        lbllogDate.Text = tab.Rows[i]["OrderDate"].ToString();
                        TableCell logDate = new TableCell();
                        logDate.Controls.Add(lbllogDate);

                        LinkButton View = new LinkButton();
                        View.Text = "Review View";
                        View.ID = "lnkView" + i.ToString();
                        View.CommandArgument = tab.Rows[i]["SlNo"].ToString();
                        View.Click += new EventHandler(View_Click);

                        TableCell ViewCell = new TableCell();
                        ViewCell.Controls.Add(View);



                        LinkButton Recover = new LinkButton();
                        Recover.Text = "Recover";
                        Recover.ID = "lnkRecover" + i.ToString();
                        Recover.CommandArgument = tab.Rows[i]["SlNo"].ToString();
                        Recover.Click += new EventHandler(Recover_Click);

                        TableCell RecoverCell = new TableCell();
                        RecoverCell.Controls.Add(Recover);

                        objDTO.SlNo = int.Parse(tab.Rows[i]["SlNo"].ToString());
                        string res = objBLL.ChkPRTamper(objDTO);
                        string imgpath = "";

                        if (res == "1")
                        {
                            imgpath = "~/images/Correct.jpg";
                            Recover.Enabled = false;
                        }
                        else
                        {
                            lbllogDate.ForeColor = System.Drawing.Color.Red;
                            imgpath = "~/images/Tamper.jpg";
                            View.Enabled = false;
                        }
                        Image img = new Image();
                        img.ImageUrl = imgpath;
                        TableCell imgcell = new TableCell();
                        imgcell.Controls.Add(img);


                        row.Controls.Add(SlNo);
                        row.Controls.Add(Name);
                        row.Controls.Add(Qty);
                        row.Controls.Add(logDate);
                        row.Controls.Add(imgcell);
                        row.Controls.Add(ViewCell);
                        row.Controls.Add(RecoverCell);
                        Table1.Controls.Add(row);

                    }
                }
                else
                {
                    //lblMsg.Text = "No Record Found";
                }
            }
            catch
            {

            }
        }

        void View_Click(object sender, EventArgs e)
        {
            objBLL = new OnlineReviewBLL();
            objDTO = new OnlineReviewDTO();
            objDTO.TableName = ddlProduct.SelectedItem.Value.ToString() + "_" + ddlProduct.SelectedItem.Value.ToString();
            LinkButton lnk = (LinkButton)sender;
            objDTO.SlNo = int.Parse(lnk.CommandArgument);
            string result = objBLL.GetPostReviewBC(objDTO);
            if (result.Split('$')[0] == "1")
            {
                lblMsg.Text = "";
                txtReview.Text = result.Split('$')[1];
            }
            else if (result.Split('$')[0] == "0")
            {
                lblMsg.Text = "Invalid Crime Details";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        void Recover_Click(object sender, EventArgs e)
        {
            objBLL = new OnlineReviewBLL();
            objDTO = new OnlineReviewDTO();
            DataTable tab = new DataTable();
            objDTO.TableName = ddlProduct.SelectedItem.Value.ToString() + "_" + ddlProduct.SelectedItem.Value.ToString();
            LinkButton lnk = (LinkButton)sender;
            objDTO.SlNo = int.Parse(lnk.CommandArgument);


            string result = objBLL.PRRecover(objDTO);
            if (result == "1")
            {
                LoadData();
                lblMsg.Text = "Recover Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            objBLL = new OnlineReviewBLL();
            objDTO = new OnlineReviewDTO();
            objDTO.ProductId = int.Parse(ddlProduct.SelectedItem.Value);
            objDTO.CustomerId = Session["UserId"].ToString();
            objDTO.Qty = int.Parse(txtQty.Text);
            string res = objBLL.CustomerProductOrder(objDTO);
            if (res == "1")
            {
                ddlProduct.SelectedIndex = 0;
                ddlCompany.SelectedIndex = 0;
                txtQty.Text = "";
                lblMsg.Text = "Product Order Place Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                ddlProduct.SelectedIndex = 0;
                ddlCompany.SelectedIndex = 0;
                txtQty.Text = "";
                lblMsg.Text = "Product Order Place Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}