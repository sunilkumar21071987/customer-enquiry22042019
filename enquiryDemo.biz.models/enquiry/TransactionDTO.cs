using System;
using System.Collections.Generic;

namespace enquiryDemo.biz.models.enquiry
{
    
    public class TransactionDTO
    {
        public int TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public Status Status { get; set; }
    }
    public enum Status
    {
        Success = 0,
        Failed = 1,
        Canceled = 2
    }
}