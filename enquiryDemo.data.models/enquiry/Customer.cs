using System;
using System.Collections.Generic;

namespace enquiryDemo.data.models.enquiry
{
    public class Customer
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string ContactEmail { get; set; }
        public string MobileNo { get; set; }
        public List<Transaction> transactions { get; set; }
    }
}
