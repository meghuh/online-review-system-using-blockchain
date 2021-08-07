using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TamperApplication
{
    public partial class TamperReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MyConnection obj = new MyConnection();
                DataTable tab = new DataTable();
                tab = obj.GetProductCategory();
                ddlCategory.DataSource = tab;
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryId";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, "--Select--");
            }
            LoadData();
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MyConnection obj = new MyConnection();
                DataTable tabcomp = new DataTable();
                tabcomp = obj.GetShop_CId(int.Parse(ddlCategory.SelectedItem.Value));
                ddlShop.DataSource = tabcomp;
                ddlShop.DataTextField = "ShopName";
                ddlShop.DataValueField = "ShopId";
                ddlShop.DataBind();
                ddlShop.Items.Insert(0, "--Select--");
            }
            catch
            {

            }
        }

        protected void ddlShop_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MyConnection obj = new MyConnection();
                DataTable tabcomp = new DataTable();
                tabcomp = obj.GetCompanyDetails(int.Parse(ddlShop.SelectedItem.Value));

                ddlCompany.DataSource = tabcomp;
                ddlCompany.DataTextField = "CompanyName";
                ddlCompany.DataValueField = "CompanyId";
                ddlCompany.DataBind();
                ddlCompany.Items.Insert(0, "--Select--");
            }
            catch
            {
            }
        }

        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MyConnection obj = new MyConnection();
                DataTable tab = new DataTable();
                tab = obj.GetProductDetails_CompanyId(int.Parse(ddlCompany.SelectedItem.Value));
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
                MyConnection obj = new MyConnection();
                DataTable tab = new DataTable();

                string TableName = ddlProduct.SelectedItem.Value + "_" + ddlProduct.SelectedItem.Value;
                tab = obj.GetPOR_Log(TableName);
                Table1.Controls.Clear();
                if (tab.Rows.Count > 0)
                {
                    TableRow hr = new TableRow();
                    TableHeaderCell hc1 = new TableHeaderCell();
                    TableHeaderCell hc2 = new TableHeaderCell();
                    TableHeaderCell hc3 = new TableHeaderCell();
                    TableHeaderCell hc4 = new TableHeaderCell();
                    TableHeaderCell hc5 = new TableHeaderCell();

                    hc1.Text = "Sl No";
                    hr.Cells.Add(hc1);
                    hc2.Text = "Customer Name";
                    hr.Cells.Add(hc2);
                    hc3.Text = "Qty";
                    hr.Cells.Add(hc3);
                    hc4.Text = "Log Date";
                    hr.Cells.Add(hc4);
                    hc5.Text = "";
                    hr.Cells.Add(hc5);

                    Table1.Rows.Add(hr);
                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        Table1.BorderWidth = 2;
                        Table1.GridLines = GridLines.Both;
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
                        lbllogDate.Text = tab.Rows[i]["LogDate"].ToString();
                        TableCell logDate = new TableCell();
                        logDate.Controls.Add(lbllogDate);

                        LinkButton Edit = new LinkButton();
                        Edit.Text = "Edit";
                        Edit.ID = "lnkEdit" + i.ToString();
                        Edit.CommandArgument = tab.Rows[i]["SlNo"].ToString();
                        Edit.Click += new EventHandler(Edit_Click);

                        TableCell ViewCell = new TableCell();
                        ViewCell.Controls.Add(Edit);


                        row.Controls.Add(SlNo);
                        row.Controls.Add(Name);
                        row.Controls.Add(Qty);
                        row.Controls.Add(logDate);
                        row.Controls.Add(ViewCell);
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

        void Edit_Click(object sender, EventArgs e)
        {
            MyConnection obj = new MyConnection();
            LinkButton lnk = (LinkButton)sender;
            int SlNo = int.Parse(lnk.CommandArgument);
            string TableName = ddlProduct.SelectedItem.Value + "_" + ddlProduct.SelectedItem.Value;
            string res = obj.TamperData(SlNo, TableName);
            if (res == "1")
            {
                Response.Redirect("TamperReview.aspx");
            }
        }
    }
}