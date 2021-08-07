using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineReview.BLL;
using OnlineReview.DTO;

namespace OnlineReview
{
    public partial class AddProductCategory : System.Web.UI.Page
    {
        OnlineReviewBLL objBLL = null;
        OnlineReviewDTO objDTO = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            objBLL = new OnlineReviewBLL();
            objDTO = new OnlineReviewDTO();
            objDTO.CategoryName = txtCategoryName.Text;
            string result = objBLL.CreateCategory(objDTO);
            if (result == "1")
            {
                txtCategoryName.Text = "";
                lblMsg.Text = "Product Category Created Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else if (result == "2")
            {
                txtCategoryName.Text = "";
                lblMsg.Text = "Product Category Created Already";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                txtCategoryName.Text = "";
                lblMsg.Text = "Product Category Creation Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}