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
    public partial class ProductPurchase : System.Web.UI.Page
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            objBLL = new OnlineReviewBLL();
            objDTO = new OnlineReviewDTO();
            objDTO.ProductId = int.Parse(ddlProduct.SelectedItem.Value);
            objDTO.CompanyId = int.Parse(ddlCompany.SelectedItem.Value);
            objDTO.Qty = int.Parse(txtQty.Text);
            string res = objBLL.ProductPurchase(objDTO);
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