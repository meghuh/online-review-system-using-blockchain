using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineReview.DTO
{
    public class OnlineReviewDTO
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CPrice { get; set; }

        public int DiscountId { get; set; }
        public int Normal { get; set; }
        public int RC { get; set; }
        public int NC { get; set; }
        public int Qty { get; set; }

        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string _ProductPurchase { get; set; }

        public int Amount    { get; set; }
        public int PurchaseId { get; set; }

        public string FilePath { get; set; }

        public int CPOId { get; set; }

        public string TableName { get; set; }

        public int SlNo { get; set; }

        
    }
}