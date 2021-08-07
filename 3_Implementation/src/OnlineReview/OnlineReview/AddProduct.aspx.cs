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
    public partial class AddProduct : System.Web.UI.Page
    {
        OnlineReviewBLL objBLL = null;
        OnlineReviewDTO objDTO = null;
        public static int ProductId = 0;
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

                objDTO.ShopId = int.Parse(Session["UserId"].ToString());
                DataTable tabcomp = new DataTable();
                tabcomp = objBLL.GetCompanyDetails(objDTO);

                ddlCompany.DataSource = tabcomp;
                ddlCompany.DataTextField = "CompanyName";
                ddlCompany.DataValueField = "CompanyId";
                ddlCompany.DataBind();
                ddlCompany.Items.Insert(0, "--Select--");

                if (Request.QueryString["ProductId"] != null)
                {
                    ProductId = int.Parse(Request.QueryString["ProductId"].ToString());
                    LoadData();
                }
            }
        }
        public void LoadData()
        {
            objBLL = new OnlineReviewBLL();
            objDTO = new OnlineReviewDTO();
            objDTO.ProductId = ProductId;
            DataTable tab = new DataTable();
            tab = objBLL.GetProductDetails_ProductId(objDTO);
            ddlCategory.Items.FindByValue(tab.Rows[0]["CategoryId"].ToString()).Selected = true;
            ddlCompany.Items.FindByValue(tab.Rows[0]["CompanyId"].ToString()).Selected = true;
            txtProductName.Text = tab.Rows[0]["ProductName"].ToString();
            txtDescription.Text = tab.Rows[0]["Description"].ToString();
            txtPrice.Text = tab.Rows[0]["Price"].ToString();
            txtCPrice.Text = tab.Rows[0]["CPrice"].ToString();
            btnSubmit.Text = "Update";
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            objBLL = new OnlineReviewBLL();
            objDTO = new OnlineReviewDTO();
            objDTO.CategoryId = int.Parse(ddlCategory.SelectedItem.Value);
            objDTO.CompanyId = int.Parse(ddlCompany.SelectedItem.Value);
            objDTO.ProductName = txtProductName.Text;
            objDTO.Description = txtDescription.Text;
            objDTO.Price = int.Parse(txtPrice.Text);
            objDTO.CPrice = int.Parse(txtCPrice.Text);
            if (btnSubmit.Text == "Update")
            {
                objDTO.ProductId = ProductId;
                string result = objBLL.UpdateProduct(objDTO);
                if (result == "1")
                {
                    txtProductName.Text = "";
                    txtDescription.Text = "";
                    txtPrice.Text = "";
                    txtCPrice.Text = "";
                    ddlCategory.SelectedIndex = 0;
                    ddlCompany.SelectedIndex = 0;
                    btnSubmit.Text = "Submit";
                    lblMsg.Text = "Product Details Updated Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
            }
            else
            {
                string result = objBLL.AddProduct(objDTO);
                if (result == "1")
                {
                    txtProductName.Text = "";
                    txtDescription.Text = "";
                    txtPrice.Text = "";
                    txtCPrice.Text = "";
                    ddlCategory.SelectedIndex = 0;
                    ddlCompany.SelectedIndex = 0;
                    lblMsg.Text = "Product Added Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    txtProductName.Text = "";
                    txtDescription.Text = "";
                    txtPrice.Text = "";
                    txtCPrice.Text = "";
                    ddlCategory.SelectedIndex = 0;
                    ddlCompany.SelectedIndex = 0;
                    lblMsg.Text = "Product Add Error";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}