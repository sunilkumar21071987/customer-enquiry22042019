using System.Collections.Generic;
using BizModel = enquiryDemo.biz.models;

namespace enquiryDemo.api.areas.enquiry.Models
{
    public class EnquiryApiModel : biz.models.TransactionalInformation
    {
        public List<BizModel.enquiry.CustomerDTO> items;
        public EnquiryApiModel()
        {
            items = new List<BizModel.enquiry.CustomerDTO>();
        }
    }
}