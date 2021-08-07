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
    public partial class AddCompany : System.Web.UI.Page
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
            Random rnd = new Random();
            objDTO.CompanyId = rnd.Next(100000, 999999);
            objDTO.ShopId = int.Parse(Session["UserId"].ToString());
            objDTO.Password = rnd.Next(1000, 9999).ToString();
            objDTO.CompanyName = txtCompanyName.Text;
            objDTO.ContactName = txtContactPerson.Text;
            objDTO.EmailId = txtEmailId.Text;
            objDTO.MobileNo = txtMobileNo.Text;
            objDTO.Address = txtAddress.Text;
            string result = objBLL.AddCompany(objDTO);
            if (result == "1")
            {
                string message = "Your Login Credentials  <br> Company Id:" + objDTO.CompanyId + " & Password:" + objDTO.Password;
                string sub = "Login Credentials";
                SendEmail.Send(txtEmailId.Text, message, sub);
                txtCompanyName.Text = "";
                txtContactPerson.Text = "";
                txtEmailId.Text = "";
                txtMobileNo.Text = "";
                txtAddress.Text = "";
                lblMsg.Text = "Company Added Successfully & Login Credentials Mailed";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else if (result == "2")
            {
                txtCompanyName.Text = "";
                txtContactPerson.Text = "";
                txtEmailId.Text = "";
                txtMobileNo.Text = "";
                txtAddress.Text = "";
                lblMsg.Text = "Company Add Already";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}