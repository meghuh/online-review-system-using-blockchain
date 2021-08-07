using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineReview.DAL;
using OnlineReview.DTO;
using System.Data;

namespace OnlineReview.BLL
{
    public class OnlineReviewBLL
    {
        OnlineReviewDAL objDAL = null;

        public int LoginVerify(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.LoginVerify(objDTO);
        }
        public string RegisterShop(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.RegisterShop(objDTO);
        }
        public string ChangePassword(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.ChangePassword(objDTO);
        }
        public string CreateCategory(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.CreateCategory(objDTO);
        }
        public string AddShopWallet(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.AddShopWallet(objDTO);
        }
        public DataTable GetShopWallet(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.GetShopWallet(objDTO);
        }
        public DataTable GetProductCategory()
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.GetProductCategory();
        }
        public string AddCompany(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.AddCompany(objDTO);
        }
        public DataTable GetCompanyDetails(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.GetCompanyDetails(objDTO);
        }
        public string AddProduct(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.AddProduct(objDTO);
        }
        public string UpdateProduct(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.UpdateProduct(objDTO);
        }
        public DataTable GetProductDetails_ProductId(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.GetProductDetails_ProductId(objDTO);
        }
        public DataTable GetProductDetails_CompanyId(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.GetProductDetails_CompanyId(objDTO);
        }
        public string ProductPurchase(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.ProductPurchase(objDTO);
        }
        public DataTable GetProductOrder_CompanyId(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.GetProductOrder_CompanyId(objDTO);
        }
        public string ApproveProduct(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.ApproveProduct(objDTO);
        }
        public string UploadProductImage(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.UploadProductImage(objDTO);
        }
        public string CustomerRegister(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.CustomerRegister(objDTO);
        }
        public DataTable GetShop_CId(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.GetShop_CId(objDTO);
        }
        public DataTable GetProductGallery_PId(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.GetProductGallery_PId(objDTO);
        }
        public string AddCustomerWallet(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.AddCustomerWallet(objDTO);
        }
        public string CustomerProductOrder(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.CustomerProductOrder(objDTO);
        }
        public DataTable GetCPO_SHId(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.GetCPO_SHId(objDTO);
        }
        public string ApproveCustomerPO(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.ApproveCustomerPO(objDTO);
        }
        public DataTable GetCPO_CId(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.GetCPO_CId(objDTO);
        }
        public string CreateTable_CPR(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.CreateTable_CPR(objDTO);
        }
        public DataTable GetPORDetails_BC(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.GetPORDetails_BC(objDTO);
        }
        public string ChkPRTamper(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.ChkPRTamper(objDTO);
        }
        public string PRRecover(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.PRRecover(objDTO);
        }
        public string GetPostReviewBC(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.GetPostReviewBC(objDTO);
        }
        public DataTable CompanyWalletDetails(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.CompanyWalletDetails(objDTO);
        }
        public DataTable GetCustomerWallet(OnlineReviewDTO objDTO)
        {
            objDAL = new DAL.OnlineReviewDAL();
            return objDAL.GetCustomerWallet(objDTO);
        }
    }
}