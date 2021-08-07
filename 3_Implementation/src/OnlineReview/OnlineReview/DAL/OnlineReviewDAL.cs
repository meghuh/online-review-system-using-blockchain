using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using OnlineReview.DTO;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;
using Sha2;

namespace OnlineReview.DAL
{
    public class OnlineReviewDAL
    {
        MySqlConnection con = null;
        MySqlCommand cmd = null;
        MySqlDataAdapter adp = null;
        MySqlConnection contemp = null;

        string con_temp = "server=localhost;database=onlinereviewtemp;user id=root;password=7777;port=3306;";

        string databasename = "onlinereview";
        string databasenametemp = "onlinereviewtemp";

        public OnlineReviewDAL()
        {
            con = new MySqlConnection("server=localhost;database=onlinereview;user id=root;password=7777;port=3306;");
            con.Open();
        }
        public int LoginVerify(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = "";
            if (objDTO.UserType == "ShopOwner")
            {
                sql = string.Format("Select count(*) from shopmaster where ShopId={0} and Password='{1}'", objDTO.UserId, objDTO.Password);
            }
            else if (objDTO.UserType == "Customer")
            {
                sql = string.Format("Select count(*) from customermaster where CId={0} and Password='{1}'", objDTO.UserId, objDTO.Password);
            }
            else if (objDTO.UserType == "Company")
            {
                sql = string.Format("Select count(*) from companymaster where CompanyId={0} and Password='{1}'", objDTO.UserId, objDTO.Password);
            }
            cmd.CommandText = sql;
            int result = int.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            return result;
        }
        public string RegisterShop(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("insert into shopmaster(ShopId,ShopName,Password,ContactName,EmailId,MobileNo,Address,Status)values({0},'{1}','{2}','{3}','{4}','{5}','{6}','Approve')",objDTO.ShopId, objDTO.ShopName, objDTO.Password, objDTO.ContactName, objDTO.EmailId, objDTO.MobileNo, objDTO.Address);
            cmd.CommandText = sql;
            string result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }
        public string ChangePassword(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = "";
            if (objDTO.UserType == "ShopOwner")
            {
                sql = string.Format("Update shopmaster set Password='{0}' where ShopId={1}", objDTO.Password, objDTO.ShopId);
            }
            else if (objDTO.UserType == "Customer")
            {
                sql = string.Format("Update customermaster set Password='{0}' where CId='{1}'", objDTO.Password, objDTO.CustomerId);
            }
            else if (objDTO.UserType == "Company")
            {
                sql = string.Format("Update companymaster set Password='{0}' where CompanyId={1}", objDTO.Password, objDTO.CompanyId);
            }
            cmd.CommandText = sql;
            string result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }
        public string AddShopWallet(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = string.Format("insert into shopwallet(ShopId,DDate,Amount,DepositeType)values({0},'{1}',{2},'Normal')", objDTO.ShopId,DateTime.Now.ToString(),objDTO.Amount);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            string sqlub = string.Format("update shopmaster set Balance=Balance+{0} where ShopId={1}",objDTO.Amount,objDTO.ShopId);
            cmd.CommandText = sqlub;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }
        public DataTable GetShopWallet(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("Select shopmaster.Balance,shopwallet.DDate,shopwallet.Amount,shopwallet.DepositType from shopwallet inner join shopmaster on shopmaster.ShopId=shopwallet.ShopId where shopmaster.ShopId={0}", objDTO.ShopId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public string CreateCategory(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sqlcnt = string.Format("Select count(*) from productcategory where CategoryName='{0}'", objDTO.CategoryName);
            cmd.CommandText = sqlcnt;
            int res = int.Parse(cmd.ExecuteScalar().ToString());
            string result = "";
            if (res == 0)
            {
                string sql = string.Format("insert into productcategory(CategoryName)values('{0}')", objDTO.CategoryName);
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery().ToString();
            }
            else
            {
                result = "2";
            }
            con.Close();
            return result;
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
        public string AddCompany(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sqlcnt = string.Format("Select count(*) from companymaster where CompanyName='{0}'", objDTO.CompanyName);
            cmd.CommandText = sqlcnt;
            int res = int.Parse(cmd.ExecuteScalar().ToString());
            string result = "";
            if (res == 0)
            {
                string sql = string.Format("insert into companymaster(CompanyId,ShopId,CompanyName,Password,ContactName,EmailId,MobileNo,Address,Status)values({0},{1},'{2}','{3}','{4}','{5}','{6}','{7}','ACTIVE')", objDTO.CompanyId, objDTO.ShopId, objDTO.CompanyName, objDTO.Password, objDTO.ContactName, objDTO.EmailId, objDTO.MobileNo, objDTO.Address);
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery().ToString();
            }
            else
            {
                result = "2";
            }
            con.Close();
            return result;
        }
        public DataTable GetCompanyDetails(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("Select * from companymaster where Status='ACTIVE' and ShopId={0}", objDTO.ShopId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public string AddProduct(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("insert into productmaster(CategoryId,CompanyId,ProductName,Description,Price,CPrice)values({0},{1},'{2}','{3}',{4},{5})", objDTO.CategoryId, objDTO.CompanyId, objDTO.ProductName, objDTO.Description, objDTO.Price,objDTO.CPrice);
            cmd.CommandText = sql;
            string result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }
        public string UpdateProduct(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("Update productmaster set CategoryId={0},CompanyId={1},ProductName='{2}',Description='{3}',Price={4},CPrice={5} where ProductId={6}", objDTO.CategoryId, objDTO.CompanyId, objDTO.ProductName, objDTO.Description, objDTO.Price,objDTO.CPrice, objDTO.ProductId);
            cmd.CommandText = sql;
            string result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }
        public string UploadProductImage(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = string.Format("insert into productgallery(ProductId,FilePath)values({0},'{1}')", objDTO.ProductId, objDTO.FilePath);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
           
            con.Close();
            return result;
        }
        public DataTable GetProductDetails_ProductId(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("SELECT * from productmaster where ProductId={0}", objDTO.ProductId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public DataTable GetProductDetails_CompanyId(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("SELECT * from productmaster where CompanyId={0}", objDTO.CompanyId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public string ProductPurchase(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            int res = 0;
            string sql = string.Format("insert into purchasemaster(CompanyId,ProductId,PurchaseDate,Qty,Status)values({0},{1},'{2}',{3},'Pending')", objDTO.CompanyId, objDTO.ProductId, DateTime.Now.ToString("dd/MM/yyyy"), objDTO.Qty);
            cmd.CommandText = sql;
            res = cmd.ExecuteNonQuery();
            
            con.Close();
            return res.ToString();
        }
        public DataTable GetProductOrder_CompanyId(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format(@"SELECT shopmaster.ShopName,shopmaster.MobileNo,productmaster.ProductName,purchasemaster.Qty,purchasemaster.PurchaseId,purchasemaster.PurchaseDate 
            from purchasemaster inner join productmaster on productmaster.ProductId=purchasemaster.ProductId inner join 
            companymaster on purchasemaster.CompanyId=companymaster.CompanyId inner join shopmaster on shopmaster.ShopId=companymaster.ShopId where purchasemaster.CompanyId={0} and purchasemaster.Status='Pending'", objDTO.CompanyId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public string ApproveProduct(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            int res = 0;
            string sql = string.Format("Update purchasemaster set Status='Approve' where PurchaseId={0}",objDTO.PurchaseId);
            cmd.CommandText = sql;
            res = cmd.ExecuteNonQuery();
            string sqlpp = string.Format("SELECT * from purchasemaster where PurchaseId={0}", objDTO.PurchaseId);
            cmd.CommandText = sqlpp;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            string chksql = string.Format("select count(*) from productstock where CompanyId={0} and ProductId={1}", int.Parse(tab.Rows[0]["CompanyId"].ToString()), int.Parse(tab.Rows[0]["ProductId"].ToString()));
            cmd.CommandText = chksql;
            int cnt = int.Parse(cmd.ExecuteScalar().ToString());
            string stocksql = "";
            if (cnt == 0)
            {
                stocksql = string.Format("insert into productstock(ProductId,CompanyId,Qty)values({0},{1},{2})", int.Parse(tab.Rows[0]["ProductId"].ToString()), int.Parse(tab.Rows[0]["CompanyId"].ToString()), int.Parse(tab.Rows[0]["Qty"].ToString()));
            }
            else
            {
                stocksql = string.Format("Update productstock set Qty=Qty+{0} where ProductId={1} and CompanyId={2}", int.Parse(tab.Rows[0]["Qty"].ToString()), int.Parse(tab.Rows[0]["ProductId"].ToString()), int.Parse(tab.Rows[0]["CompanyId"].ToString()));
            }
            cmd.CommandText = stocksql;
            res = cmd.ExecuteNonQuery();

            string sqlcp = string.Format("SELECT * from productmaster where ProductId={0} and CompanyId={1}", int.Parse(tab.Rows[0]["ProductId"].ToString()), int.Parse(tab.Rows[0]["CompanyId"].ToString()));
            cmd.CommandText = sqlcp;
            adp = new MySqlDataAdapter(cmd);
            DataTable tabcp = new DataTable();
            adp.Fill(tabcp);

            string sqlshp = string.Format("SELECT * from companymaster where CompanyId={0}",  int.Parse(tab.Rows[0]["CompanyId"].ToString()));
            cmd.CommandText = sqlshp;
            adp = new MySqlDataAdapter(cmd);
            DataTable tabshp = new DataTable();
            adp.Fill(tabshp);

            string sqlsw = string.Format("Update shopmaster set Balance=Balance-{0} where ShopId={1}", int.Parse(tab.Rows[0]["Qty"].ToString()) * int.Parse(tabcp.Rows[0]["CPrice"].ToString()), int.Parse(tabshp.Rows[0]["ShopId"].ToString()));
            cmd.CommandText = sqlsw;
            res = cmd.ExecuteNonQuery();

            string sqlcpw = string.Format("Update companymaster set Balance=Balance+{0} where CompanyId={1}", int.Parse(tab.Rows[0]["Qty"].ToString()) * int.Parse(tabcp.Rows[0]["CPrice"].ToString()), int.Parse(tab.Rows[0]["CompanyId"].ToString()));
            cmd.CommandText = sqlcpw;
            res = cmd.ExecuteNonQuery();

            string sqlcpwallet = string.Format("insert into cpwallet(CPId,PurchaseId,DDate,Amount)values({0},{1},'{2}',{3})", int.Parse(tab.Rows[0]["CompanyId"].ToString()), objDTO.PurchaseId, DateTime.Now.ToString(), int.Parse(tab.Rows[0]["Qty"].ToString()) * int.Parse(tabcp.Rows[0]["CPrice"].ToString()));
            cmd.CommandText = sqlcpwallet;
            res = cmd.ExecuteNonQuery();

            con.Close();
            return res.ToString();
        }
        public string CustomerRegister(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("insert into customermaster(CId,Name,Password,EmailId,MobileNo,Address,Balance)values({0},'{1}','{2}','{3}','{4}','{5}',0)", objDTO.CustomerId, objDTO.CustomerName, objDTO.Password, objDTO.EmailId, objDTO.MobileNo, objDTO.Address);
            cmd.CommandText = sql;
            string result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }

        public DataTable GetShop_CId(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("Select DISTINCT shopmaster.ShopName,shopmaster.ShopId from shopmaster inner join companymaster on companymaster.ShopId=shopmaster.ShopId inner join productmaster on companymaster.CompanyId=productmaster.CompanyId where productmaster.CategoryId={0}", objDTO.CategoryId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }

        public DataTable GetProductGallery_PId(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("Select * from productgallery where ProductId={0}",objDTO.ProductId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public string AddCustomerWallet(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sql = string.Format("insert into cwallet(CId,DDate,Amount)values('{0}','{1}',{2})", objDTO.CustomerId, DateTime.Now.ToString(), objDTO.Amount);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            string sqlub = string.Format("update customermaster set Balance=Balance+{0} where CId={1}", objDTO.Amount, objDTO.CustomerId);
            cmd.CommandText = sqlub;
            result = cmd.ExecuteNonQuery().ToString();
            con.Close();
            return result;
        }
        public string CustomerProductOrder(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            int res = 0;
            string sql = string.Format("insert into customerorder(ProductId,CId,PODate,Qty,Status,RStatus)values({0},{1},'{2}',{3},'Pending',0)", objDTO.ProductId, objDTO.CustomerId, DateTime.Now.ToString("dd/MM/yyyy"), objDTO.Qty);
            cmd.CommandText = sql;
            res = cmd.ExecuteNonQuery();
            con.Close();
            return res.ToString();
        }
        public DataTable GetCPO_SHId(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format(@"Select productmaster.ProductName,companymaster.CompanyName,
            customermaster.Name,customermaster.MobileNo,customermaster.Address,customerorder.PODate,customerorder.Qty,customerorder.CPOId from productmaster inner join companymaster on productmaster.CompanyId=companymaster.CompanyId 
            inner join customerorder on customerorder.ProductId=productmaster.ProductId inner join customermaster on customermaster.CId=customerorder.CId where companymaster.ShopId={0} and customerorder.Status='Pending'", objDTO.ShopId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }

        public string ApproveCustomerPO(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            int res = 0;
            string sql = string.Format("Update customerorder set Status='Approve' where CPOId={0}", objDTO.CPOId);
            cmd.CommandText = sql;
            res = cmd.ExecuteNonQuery();
            string sqlpp = string.Format("SELECT * from customerorder where CPOId={0}", objDTO.CPOId);
            cmd.CommandText = sqlpp;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            string chksql = string.Format("select Qty from productstock where ProductId={0}",  int.Parse(tab.Rows[0]["ProductId"].ToString()));
            cmd.CommandText = chksql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tabchk = new DataTable();
            adp.Fill(tabchk);
            string stocksql = "";
            if (int.Parse(tabchk.Rows[0]["Qty"].ToString()) >= int.Parse(tab.Rows[0]["Qty"].ToString()))
            {
                stocksql = string.Format("Update productstock set Qty=Qty-{0} where ProductId={1} ", int.Parse(tab.Rows[0]["Qty"].ToString()), int.Parse(tab.Rows[0]["ProductId"].ToString()));

                cmd.CommandText = stocksql;
                res = cmd.ExecuteNonQuery();

                string sqlcp = string.Format("SELECT * from productmaster where ProductId={0}", int.Parse(tab.Rows[0]["ProductId"].ToString()));
                cmd.CommandText = sqlcp;
                adp = new MySqlDataAdapter(cmd);
                DataTable tabcp = new DataTable();
                adp.Fill(tabcp);

                string sqlsw = string.Format("Update customermaster set Balance=Balance-{0} where CId={1}", int.Parse(tab.Rows[0]["Qty"].ToString()) * int.Parse(tabcp.Rows[0]["Price"].ToString()), int.Parse(tab.Rows[0]["CId"].ToString()));
                cmd.CommandText = sqlsw;
                res = cmd.ExecuteNonQuery();

                string sqlshp = string.Format("SELECT * from companymaster where CompanyId={0}", int.Parse(tabcp.Rows[0]["CompanyId"].ToString()));
                cmd.CommandText = sqlshp;
                adp = new MySqlDataAdapter(cmd);
                DataTable tabshp = new DataTable();
                adp.Fill(tabshp);

                string sqlcpw = string.Format("Update shopmaster set Balance=Balance+{0} where ShopId={1}", int.Parse(tab.Rows[0]["Qty"].ToString()) * int.Parse(tabcp.Rows[0]["Price"].ToString()), int.Parse(tabshp.Rows[0]["ShopId"].ToString()));
                cmd.CommandText = sqlcpw;
                res = cmd.ExecuteNonQuery();

                string sqlcpwallet = string.Format("insert into shopwallet(ShopId,DDate,Amount,DepositType)values({0},'{1}',{2},'Sales')", int.Parse(tabshp.Rows[0]["ShopId"].ToString()), DateTime.Now.ToString(), int.Parse(tab.Rows[0]["Qty"].ToString()) * int.Parse(tabcp.Rows[0]["Price"].ToString()));
                cmd.CommandText = sqlcpwallet;
                res = cmd.ExecuteNonQuery();
            }
            else
            {
                res = 2;
            }
            

            con.Close();
            return res.ToString();
        }
        public DataTable GetCPO_CId(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format(@"Select productmaster.ProductName,companymaster.CompanyName,
            customerorder.PODate,customerorder.Qty,customerorder.ProductId,customerorder.CPOId from productmaster inner join companymaster on productmaster.CompanyId=companymaster.CompanyId 
            inner join customerorder on customerorder.ProductId=productmaster.ProductId inner join customermaster on customermaster.CId=customerorder.CId where customerorder.CId='{0}' and customerorder.RStatus=0 and customerorder.Status='Approve'", objDTO.CustomerId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }

        public string CreateTable_CPR(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string result = "";
            string sqlpp = string.Format("SELECT * from customerorder where CPOId={0}", objDTO.CPOId);
            cmd.CommandText = sqlpp;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            objDTO.TableName = tab.Rows[0]["ProductId"].ToString() + "_" + tab.Rows[0]["ProductId"].ToString();
            string sqlcnt = string.Format("SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '{1}' AND table_name = '{0}'", objDTO.TableName, databasename);
            cmd.CommandText = sqlcnt;
            string cnt = cmd.ExecuteScalar().ToString();

            contemp = new MySqlConnection(con_temp);
            contemp.Open();

            if (cnt == "0") //If Table Not Found,Then Update customerorder Table Rstatus & Create Dynamic Table
            {
                
                
                    string sql = string.Format(@"CREATE TABLE `{0}` (
                                    `SlNo` int(11) NOT NULL AUTO_INCREMENT,
                                    `PId` int(11) DEFAULT NULL,
                                    `CId` varchar(10) DEFAULT NULL,
                                    `OrderDate` varchar(200) DEFAULT NULL,
                                    `Qty` int(11) DEFAULT NULL,
                                    `LogDate` varchar(200) DEFAULT NULL,
                                    `PHV` varchar(4000) DEFAULT NULL,
                                    `PRED` varchar(20000) DEFAULT NULL,
                                     PRIMARY KEY(`SlNo`)
                                    ) ENGINE = InnoDB AUTO_INCREMENT = 4 DEFAULT CHARSET = latin1; ", objDTO.TableName);
                    cmd.CommandText = sql;
                    result = cmd.ExecuteNonQuery().ToString();

                    //Temp Table Backup

                    cmd.Connection = contemp;
                    string resulttemp = "";
                    string sqlcnttemp = string.Format("SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '{1}' AND table_name = '{0}'", objDTO.TableName, databasenametemp);
                    cmd.CommandText = sqlcnttemp;
                    string cnttemp = cmd.ExecuteScalar().ToString();
                    if (cnttemp == "0") //If Table Not Found, Create Dynamic Table
                    {
                        string sqltemp = string.Format(@"CREATE TABLE `{0}` (
                                    `SlNo` int(11) NOT NULL AUTO_INCREMENT,
                                    `PId` int(11) DEFAULT NULL,
                                    `CId` varchar(10) DEFAULT NULL,
                                    `OrderDate` varchar(200) DEFAULT NULL,
                                    `Qty` int(11) DEFAULT NULL,
                                    `LogDate` varchar(200) DEFAULT NULL,
                                    `PHV` varchar(4000) DEFAULT NULL,
                                    `PRED` varchar(20000) DEFAULT NULL,
                                     PRIMARY KEY(`SlNo`)
                                    ) ENGINE = InnoDB AUTO_INCREMENT = 4 DEFAULT CHARSET = latin1; ", objDTO.TableName);
                        cmd.CommandText = sqltemp;
                        resulttemp = cmd.ExecuteNonQuery().ToString();



                        if (result == "0")
                        {
                            cmd.Connection = con;
                            string sqlclog = string.Format("insert into {0} (PId,CID,OrderDate,Qty,LogDate,PHV,PRED)values({1},'{2}','{3}',{4},'{5}','{6}','{7}')", objDTO.TableName, 0, "0", "NA", 0,"NA","NA","NA");
                            cmd.CommandText = sqlclog;
                            result = cmd.ExecuteNonQuery().ToString();


                        }
                        if (resulttemp == "0")
                        {
                            cmd.Connection = contemp;
                            string sqlclog = string.Format("insert into {0} (PId,CID,OrderDate,Qty,LogDate,PHV,PRED)values({1},'{2}','{3}',{4},'{5}','{6}','{7}')", objDTO.TableName, 0, "0", "NA", 0, "NA", "NA", "NA");
                            cmd.CommandText = sqlclog;
                            result = cmd.ExecuteNonQuery().ToString();


                        }

                    }
                //}
            }

            cmd.Connection = con;
            string sqlcu = string.Format("update customerorder set RStatus=1 where CPOId={0}", objDTO.CPOId);
            cmd.CommandText = sqlcu;
            result = cmd.ExecuteNonQuery().ToString();

            string logdate = DateTime.Now.ToString();
            string hashvalue = ShaKeyGeneration(tab.Rows[0]["ProductId"].ToString(), tab.Rows[0]["CId"].ToString(), tab.Rows[0]["PODate"].ToString(), tab.Rows[0]["Qty"].ToString(), logdate);

            byte[] passBytes = Encoding.UTF8.GetBytes(hashvalue.Substring(0, 2));

            string keyvalue = string.Join("", passBytes);

            string EncryptData = AESCryptoClass.EncryptData(objDTO.Description, keyvalue);


            cmd.Connection = con;
            string sqlclogcs = string.Format("insert into {0} (PId,CID,OrderDate,Qty,LogDate,PHV,PRED)values({1},'{2}','{3}',{4},'{5}','{6}','{7}')", objDTO.TableName, int.Parse(tab.Rows[0]["ProductId"].ToString()), tab.Rows[0]["CId"].ToString(), tab.Rows[0]["PODate"].ToString(), int.Parse(tab.Rows[0]["Qty"].ToString()), logdate, "NA", "NA");
            cmd.CommandText = sqlclogcs;
            result = cmd.ExecuteNonQuery().ToString();

            string sqlcdlp = string.Format("SELECT * FROM {0} ORDER BY SlNo DESC LIMIT 1,1", objDTO.TableName);
            cmd.CommandText = sqlcdlp;
            adp = new MySqlDataAdapter(cmd);
            DataTable tablp = new DataTable();
            adp.Fill(tablp);

            string sqlulog = string.Format("update {0} set PHV='{1}',PRED='{2}' where SlNo={3}", objDTO.TableName, hashvalue, EncryptData, tablp.Rows[0]["SlNo"].ToString());
            cmd.CommandText = sqlulog;
            result = cmd.ExecuteNonQuery().ToString();

            //Temp Table
            cmd.Connection = contemp;
            string sqlclogcstemp = string.Format("insert into {0} (PId,CID,OrderDate,Qty,LogDate,PHV,PRED)values({1},'{2}','{3}',{4},'{5}','{6}','{7}')", objDTO.TableName, int.Parse(tab.Rows[0]["ProductId"].ToString()), tab.Rows[0]["CId"].ToString(), tab.Rows[0]["PODate"].ToString(), int.Parse(tab.Rows[0]["Qty"].ToString()), logdate, "NA", "NA");
            cmd.CommandText = sqlclogcstemp;
            result = cmd.ExecuteNonQuery().ToString();

            string sqlcdlptemp = string.Format("SELECT * FROM {0} ORDER BY SlNo DESC LIMIT 1,1", objDTO.TableName);
            cmd.CommandText = sqlcdlptemp;
            adp = new MySqlDataAdapter(cmd);
            DataTable tablptemp = new DataTable();
            adp.Fill(tablptemp);

            string sqlulogtemp = string.Format("update {0} set PHV='{1}',PRED='{2}' where SlNo={3}", objDTO.TableName, hashvalue, EncryptData, tablptemp.Rows[0]["SlNo"].ToString());
            cmd.CommandText = sqlulogtemp;
            result = cmd.ExecuteNonQuery().ToString();
            contemp.Close();
            con.Close();
            return result;
        }
        public string ShaKeyGeneration(string PId,string CId,string PODate,string Qty, string LogDate)
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

        public DataTable GetPORDetails_BC(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("select customermaster.Name,{0}.SlNo,{0}.OrderDate,{0}.CId,{0}.Qty from {0} inner join customermaster on customermaster.CId={0}.CId where {0}.LogDate<>'NA' order by {0}.SlNo desc", objDTO.TableName);
            cmd.CommandText = sql;
            DataTable tab = new DataTable();
            adp = new MySqlDataAdapter(cmd);
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public string ChkPRTamper(OnlineReviewDTO objDTO)
        {
            contemp = new MySqlConnection(con_temp);
            contemp.Open();
            cmd = new MySqlCommand();
            cmd.Connection = contemp;
            string sqltb = string.Format("Select * from {0} where SlNo={1}", objDTO.TableName, objDTO.SlNo);
            cmd.CommandText = sqltb;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            string hashvalue = ShaKeyGeneration(tab.Rows[0]["PId"].ToString().ToString(), tab.Rows[0]["CId"].ToString(), tab.Rows[0]["OrderDate"].ToString(), tab.Rows[0]["Qty"].ToString(), tab.Rows[0]["LogDate"].ToString());
            cmd.Connection = con;
            string sql = string.Format("Select count(*) from {0} where PHV='{1}'", objDTO.TableName, hashvalue);
            cmd.CommandText = sql;
            string result = cmd.ExecuteScalar().ToString();
            contemp.Close();
            con.Close();
            return result;

        }
        public string PRRecover(OnlineReviewDTO objDTO)
        {
            contemp = new MySqlConnection(con_temp);
            contemp.Open();
            cmd = new MySqlCommand();
            cmd.Connection = contemp;
            string sqltb = string.Format("Select * from {0} where SlNo={1}", objDTO.TableName, objDTO.SlNo - 1);
            cmd.CommandText = sqltb;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);

            string sqltbq = string.Format("Select * from {0} where SlNo={1}", objDTO.TableName, objDTO.SlNo);
            cmd.CommandText = sqltbq;
            adp = new MySqlDataAdapter(cmd);
            DataTable tabq = new DataTable();
            adp.Fill(tabq);

            cmd.Connection = con;
            string sqluq = string.Format("update {0} set Qty={1} where SlNo={2}", objDTO.TableName, int.Parse(tabq.Rows[0]["Qty"].ToString()), objDTO.SlNo);
            cmd.CommandText = sqluq;
            string result = cmd.ExecuteNonQuery().ToString();
            string sql = string.Format("update {0} set PHV='{1}' where SlNo={2}", objDTO.TableName, tab.Rows[0]["PHV"].ToString(), objDTO.SlNo - 1);
            cmd.CommandText = sql;
            result = cmd.ExecuteNonQuery().ToString();
            contemp.Close();
            con.Close();
            return result;

        }
        public string GetPostReviewBC(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sqlfsd = string.Format("Select * from {0} where SlNo={1}", objDTO.TableName, objDTO.SlNo);
            cmd.CommandText = sqlfsd;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            string hashvalue = ShaKeyGeneration(tab.Rows[0]["PId"].ToString().ToString(), tab.Rows[0]["CId"].ToString(), tab.Rows[0]["OrderDate"].ToString(), tab.Rows[0]["Qty"].ToString(), tab.Rows[0]["LogDate"].ToString());
            string sql = string.Format("Select count(*) from {0} where PHV='{1}'", objDTO.TableName, hashvalue);
            cmd.CommandText = sql;
            string result = cmd.ExecuteScalar().ToString();
            if (result == "1")
            {
                string sqlCS = string.Format("Select * from {0} where PHV='{1}'", objDTO.TableName, hashvalue);
                cmd.CommandText = sqlCS;
                adp = new MySqlDataAdapter(cmd);
                DataTable tabfsd = new DataTable();
                adp.Fill(tabfsd);
                byte[] passBytes = Encoding.UTF8.GetBytes(hashvalue.Substring(0, 2));
                string keyvalue = string.Join("", passBytes);
                string data = AESCryptoClass.Decrypt(tabfsd.Rows[0]["PRED"].ToString(), keyvalue);
                result = result + "$" + data;
            }
            else
            {
                result = result + "$0";
            }
            con.Close();
            return result;


        }

        public DataTable CompanyWalletDetails(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format(@"select productmaster.ProductName,shopmaster.ShopName,purchasemaster.PurchaseDate,
            purchasemaster.Qty,cpwallet.Amount,companymaster.Balance from cpwallet inner join purchasemaster on cpwallet.PurchaseId=purchasemaster.PurchaseId inner join companymaster on purchasemaster.CompanyId=companymaster.CompanyId inner join shopmaster on shopmaster.ShopId=companymaster.ShopId  inner join productmaster on productmaster.ProductId=purchasemaster.ProductId where cpwallet.CPId={0}",objDTO.CompanyId);
            cmd.CommandText = sql;
            DataTable tab = new DataTable();
            adp = new MySqlDataAdapter(cmd);
            adp.Fill(tab);
            con.Close();
            return tab;
        }
        public DataTable GetCustomerWallet(OnlineReviewDTO objDTO)
        {
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("Select customermaster.Balance,cwallet.DDate,cwallet.Amount from cwallet inner join customermaster on customermaster.CId=cwallet.CId where customermaster.CId={0}", objDTO.CustomerId);
            cmd.CommandText = sql;
            adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            con.Close();
            return tab;
        }
    }
}