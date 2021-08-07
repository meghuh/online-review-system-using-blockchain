using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineReview.BLL;
using OnlineReview.DTO;
using System.IO;
using System.Data;

namespace OnlineReview
{
    public partial class UploadProductImage : System.Web.UI.Page
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            objBLL = new OnlineReviewBLL();
            objDTO = new OnlineReviewDTO();
            if (ProductImg.HasFile)
            {
                string PPath = "~/ProductImg/";
                Random rnd = new Random();

                PPath += ddlProduct.SelectedItem.Text + "_" + rnd.Next(1000, 9999) + Path.GetExtension(ProductImg.FileName);
                ProductImg.SaveAs(Server.MapPath(PPath));

                objDTO.ProductId = int.Parse(ddlProduct.SelectedItem.Value);
                objDTO.FilePath = PPath;
                string res = objBLL.UploadProductImage(objDTO);
                if (res == "1")
                {
                    ddlProduct.SelectedIndex = 0;
                    ddlCompany.SelectedIndex = 0;
                    lblMsg.Text = "Product Image Uploaded Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
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
    }
}