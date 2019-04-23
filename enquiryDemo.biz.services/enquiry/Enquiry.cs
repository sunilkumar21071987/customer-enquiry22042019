using System;
using System.Collections.Generic;

using enquiryDemo.data.interfaces;

using DataService = enquiryDemo.data.services;
using BizModel = enquiryDemo.biz.models.enquiry;
using DataModel = enquiryDemo.data.models.enquiry;

namespace enquiryDemo.biz.service.enquiry
{
    public class Enquiry
    {
        private IEnquiry<DataModel.Customer> customerDS;

        public Enquiry()
        {
            this.customerDS = new DataService.enquiry.Enquiry();
        }

        public List<BizModel.CustomerDTO> GetCustomerDetail(BizModel.InquiryCriteriaDTO inquiryCriteriaDTO, out biz.models.TransactionalInformation transaction)
        {
            transaction = new models.TransactionalInformation();
            var dmCustomers = new List<DataModel.Customer>();
            var bmCustomers = new List<BizModel.CustomerDTO>();
            try
            {
                if (!string.IsNullOrEmpty(inquiryCriteriaDTO.CustomerID) && !string.IsNullOrEmpty(inquiryCriteriaDTO.Email))
                {
                    customerDS.CreateSession(); customerDS.BeginTransaction();
                    dmCustomers = customerDS.GetCustomerDetail(inquiryCriteriaDTO);
                    foreach (var item in dmCustomers)
                    {
                        bmCustomers.Add(new BizModel.CustomerDTO() { });
                    }
                    customerDS.CommitTransaction(true);
                    transaction.ReturnStatus = true;
                    transaction.ReturnMessage.Add("True"); 
                }
                else
                {
                    throw new Exception("No inquiry criteria");
                }
            }
            catch (Exception ex)
            {
                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
            }
            finally
            {
                customerDS.CloseSession();
            }
            return bmCustomers;
        }        
    }
}