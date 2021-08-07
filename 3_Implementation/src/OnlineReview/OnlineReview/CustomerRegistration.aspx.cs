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
    public partial class CustomerRegistration : System.Web.UI.Page
    {
        OnlineReviewBLL objBLL = null;
        OnlineReviewDTO objDTO = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            objBLL = new OnlineReviewBLL();
            objDTO = new OnlineReviewDTO();
            Random rnd = new Random();
            objDTO.CustomerId = rnd.Next(100000, 999999).ToString();
            objDTO.CustomerName = txtName.Text;
            objDTO.EmailId = txtEmailId.Text;
            objDTO.Password = txtPassword.Text;
            objDTO.MobileNo = txtMobileNo.Text;
            objDTO.Address = txtAddress.Text;
            string result = objBLL.CustomerRegister(objDTO);
            if (result == "1")
            {

                string message = "Your Login Credentials  <br> Customer Id:" + objDTO.CustomerId + " & Password:" + objDTO.Password;
                string sub = "Login Credentials";
                SendEmail.Send(txtEmailId.Text, message, sub);
                txtName.Text = "";
                txtPassword.Text = "";
                txtMobileNo.Text = "";
                txtAddress.Text = "";
                txtEmailId.Text = "";
                lblMsg.Text = "Customer Registration Successfully & Login Credentials Mailed";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                txtName.Text = "";
                txtPassword.Text = "";
                txtMobileNo.Text = "";
                txtAddress.Text = "";
                txtEmailId.Text = "";
                lblMsg.Text = "Customer Registration Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}