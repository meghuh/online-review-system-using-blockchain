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
    public partial class ShopWallet : System.Web.UI.Page
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
            objDTO.ShopId = int.Parse(Session["UserId"].ToString());
            objDTO.Amount =int.Parse(txtAmount.Text);
            string result = objBLL.AddShopWallet(objDTO);
            if (result == "1")
            {
                txtAmount.Text = "";
                lblMsg.Text = "Amount Deposit Wallet Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            
            else
            {
                txtAmount.Text = "";
                lblMsg.Text = "Amount Deposit Wallet Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}