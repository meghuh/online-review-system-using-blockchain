using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using System.Collections.ObjectModel;
using Sha2;
using System.Security.Cryptography;
using System.Text;

namespace TamperApplication
{
    public class MyConnection
    {
        MySqlConnection con = null;
        MySqlCommand cmd = null;
        MySqlConnection contemp = null;
        MySqlDataAdapter adp = null;
        public MyConnection()
        {
            con = new MySqlConnection("server=localhost;user id=root;database=onlinereview;password=7777;port=3306;");
            con.Open();
        }
        public DataTable GetProductCategory()
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("Select * from productcategory");
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public DataTable GetShop_CId(int CategoryId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("Select DISTINCT shopmaster.ShopName,shopmaster.ShopId from shopmaster inner join companymaster on companymaster.ShopId=shopmaster.ShopId inner join productmaster on companymaster.CompanyId=productmaster.CompanyId where productmaster.CategoryId={0}", CategoryId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public DataTable GetCompanyDetails(int ShopId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("Select * from companymaster where Status='ACTIVE' and ShopId={0}", ShopId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public DataTable GetProductDetails_CompanyId(int CompanyId)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("SELECT * from productmaster where CompanyId={0}", CompanyId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public DataTable GetPOR_Log(string TableName)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select customermaster.Name,{0}.SlNo,{0}.LogDate,{0}.CId,{0}.Qty from {0} inner join customermaster on customermaster.CId={0}.CId where {0}.LogDate<>'NA' order by {0}.SlNo desc", TableName);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public string TamperData(int SlNo,string TableName)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sqlcd = string.Format("Select * from {0} where SlNo={1}",TableName, SlNo);
            cmd.CommandText = sqlcd;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            string logdate = DateTime.Now.ToString();
            Random rnd = new Random();
            int qty = rnd.Next(1, 9);
            string hashvalue = ShaKeyGeneration(tab.Rows[0]["PId"].ToString().ToString(), tab.Rows[0]["CId"].ToString(), tab.Rows[0]["OrderDate"].ToString(), qty.ToString(), logdate);
            string sqluqty = string.Format("update {0} set Qty={1} where SlNo={2}", TableName, qty, SlNo);
            cmd.CommandText = sqluqty;
            result = cmd.ExecuteNonQuery().ToString();
            string sqlulog = string.Format("update {0} set PHV='{1}' where SlNo={2}", TableName, hashvalue, SlNo - 1);
            cmd.CommandText = sqlulog;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }
        public string ShaKeyGeneration(string PId, string CId, string PODate, string Qty, string LogDate)
        {
            try
            {
                string data = PId + "," + CId + "," + PODate + "," + Qty + "," + LogDate;
                string strFilePath = HttpContext.Current.Server.MapPath("data.txt");
                if (File.Exists(strFilePath))
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    File.Delete(strFilePath);
                }
                FileStream fp = new FileStream(strFilePath, FileMode.Create);
                StreamWriter wr = new StreamWriter(fp);
                wr.WriteLine(data);
                wr.Close();
                fp.Close();

                ReadOnlyCollection<byte> hash = Sha384mManaged.HashFile(File.OpenRead(strFilePath));

                return Util.ArrayToString(hash);
            }
            catch
            {
                return null;
            }
        }
    }
}