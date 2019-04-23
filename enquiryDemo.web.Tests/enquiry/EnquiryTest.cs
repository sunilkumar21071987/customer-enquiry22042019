using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Web.Http;
using enquiryDemo.api.areas.enquiry.Controllers;
using BizModel = enquiryDemo.biz.models.enquiry;

namespace enquiryDemo.web.Tests.enquiry
{
    [TestClass]
    public class EnquiryTest
    {
        readonly EnquiryController _controller = new EnquiryController()
        {
            Request = new HttpRequestMessage(),
            Configuration = new HttpConfiguration()
        };
        [TestMethod]
        public void GetCustomerDetailByID_BadRequest()
        {

            var response = _controller.GetCustomerDetailByID(_controller.Request,
             new BizModel.InquiryCriteriaDTO()
             {
                 CustomerID = "",
                 Email = ""
             });
            Assert.AreEqual("OK", response.StatusCode.ToString());
        }
        [TestMethod]
        public void GetCustomerDetailByID_NotFound()
        {

            var response = _controller.GetCustomerDetailByID(_controller.Request,
             new BizModel.InquiryCriteriaDTO()
             {
                 CustomerID = "6",
                 Email = ""
             });
            Assert.AreEqual("OK", response.StatusCode.ToString());
        }
        [TestMethod]
        public void GetCustomerDetailByID()
        {

            var response = _controller.GetCustomerDetailByID(_controller.Request,
             new BizModel.InquiryCriteriaDTO()
            {
                CustomerID = "1",
                Email = ""
            });
            Assert.AreEqual("OK", response.StatusCode.ToString());
        }
        [TestMethod]
        public void GetCustomerDetailByEmail()
        {
            var response = _controller.GetCustomerDetailByID(_controller.Request, new BizModel.InquiryCriteriaDTO()
            {
                CustomerID = "",
                Email = "sunil.kumar@gmail.com"
            });
            Assert.AreEqual("OK", response.StatusCode.ToString());
        }
        [TestMethod]
        public void GetCustomerDetailByEmailAndID()
        {
            var response = _controller.GetCustomerDetailByID(_controller.Request, new BizModel.InquiryCriteriaDTO()
            {
                CustomerID = "2",
                Email = "anil.kumar@gmail.com"
            });
            Assert.AreEqual("OK", response.StatusCode.ToString());
        }
    }
}