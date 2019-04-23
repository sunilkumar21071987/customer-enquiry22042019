using System;
using System.Collections.Generic;

namespace enquiryDemo.biz.models.enquiry
{
    public class CustomerDTO
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string ContactEmail { get; set; }
        public string MobileNo { get; set; }
        public List<TransactionDTO> transactions { get; set; }
    }
}
