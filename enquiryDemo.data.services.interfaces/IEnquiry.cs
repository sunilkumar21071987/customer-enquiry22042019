using System;
using System.Collections.Generic;

namespace enquiryDemo.data.interfaces
{
    public interface IEnquiry<T> : IDataService, IDisposable where T : class
    {
        List<T> GetCustomerDetail(biz.models.enquiry.InquiryCriteriaDTO inquiryCriteriaDTO);
    }
}







