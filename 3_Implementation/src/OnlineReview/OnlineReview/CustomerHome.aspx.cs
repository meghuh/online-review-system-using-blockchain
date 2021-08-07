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
    public partial class CustomerHome : System.Web.UI.Page
    {
        OnlineReviewBLL objBLL = null;
        OnlineReviewDTO objDTO = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        protected void btnSave_Click(object sender, EventArgs e)
        {
            objBLL = new OnlineReviewBLL();
            objDTO = new OnlineReviewDTO();
            if (txtOldPassword.Text == Session["Password"].ToString())
            {

                objDTO.CustomerId = Session["UserId"].ToString();
                objDTO.Password = txtNewPassword.Text;
                objDTO.UserType = Session["UserType"].ToString();
                string Result = objBLL.ChangePassword(objDTO);
                if (Result != "0")
                {
                    Session["Password"] = txtNewPassword.Text;
                    txtNewPassword.Text = txtConfirmPassword.Text = txtOldPassword.Text = "";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Password Reset Successfully";
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "Password Reset Error";
                }
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Invalid Old Password";
            }
        }
    }
}