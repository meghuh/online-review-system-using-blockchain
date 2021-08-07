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
    public partial class CompanyViewCR : System.Web.UI.Page
    {
        OnlineReviewBLL objBLL = null;
        OnlineReviewDTO objDTO = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objBLL = new OnlineReviewBLL();
                objDTO = new OnlineReviewDTO();
                objDTO.CompanyId = int.Parse(Session["UserId"].ToString());
                DataTable tab = new DataTable();
                tab = objBLL.GetProductDetails_CompanyId(objDTO);
                ddlProduct.DataSource = tab;
                ddlProduct.DataTextField = "ProductName";
                ddlProduct.DataValueField = "ProductId";
                ddlProduct.DataBind();
                ddlProduct.Items.Insert(0, "--Select--");
                Panel1.Visible = false;
            }
            LoadData();

        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
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
                Panel1.Visible = true;
                lblMsg.Text = "";
                txtReview.Text = result.Split('$')[1];
            }
            else if (result.Split('$')[0] == "0")
            {
                lblMsg.Text = "Invalid Crime Details";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}