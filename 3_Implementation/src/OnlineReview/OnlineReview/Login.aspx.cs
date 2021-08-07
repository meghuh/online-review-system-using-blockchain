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
    public partial class Login : System.Web.UI.Page
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
            objDTO.UserId = txtUserId.Text;
            objDTO.Password = txtPassword.Text;
            objDTO.UserType = ddlUserType.SelectedItem.Text;
            int result = objBLL.LoginVerify(objDTO);
            if (result == 1)
            {
                Session["UserId"] = txtUserId.Text;
                Session["Password"] = txtPassword.Text;
                Session["UserType"] = ddlUserType.SelectedItem.Text;
                switch (ddlUserType.SelectedItem.Text)
                {

                    case "ShopOwner": Response.Redirect("ShopHome.aspx");
                        break;
                    case "Customer": Response.Redirect("CustomerHome.aspx");
                        break;
                    case "Company": Response.Redirect("CompanyHome.aspx");
                        break;
                }

            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Invalid UserId/Password";
            }
        }
    }
}