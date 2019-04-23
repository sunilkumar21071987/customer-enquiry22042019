using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using enquiryDemo.data.interfaces;
using enquiryDemo.data.model.master;
using DataModel = enquiryDemo.data.models.enquiry;

namespace enquiryDemo.data.services.enquiry
{
    public class Enquiry : DbFactory, IEnquiry<DataModel.Customer>
    {
        public List<DataModel.Customer> GetCustomerDetail(biz.models.enquiry.InquiryCriteriaDTO inquiryCriteriaDTO)
        {
            var dynp = new DynamicParameters();
            dynp.Add("@ID", inquiryCriteriaDTO.CustomerID, DbType.String, ParameterDirection.Input);
            dynp.Add("@Email", inquiryCriteriaDTO.Email, DbType.String, ParameterDirection.Input);

            var enquiry = CompanyConnection.QueryMultiple("enq_CustomerDetail", dynp,commandType: CommandType.StoredProcedure);

            var customers = enquiry.Read<DataModel.Customer>().ToList();
            var transactions = enquiry.Read<DataModel.Transaction>().ToList();

            foreach (var customer in customers)
            {
                customer.transactions = transactions.Where(a => a.CustomerID == customer.CustomerID).ToList();
            }

            return customers;
        }
    }
}
