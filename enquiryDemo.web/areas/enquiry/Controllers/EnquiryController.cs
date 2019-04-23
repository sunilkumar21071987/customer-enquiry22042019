using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BizModelMaster = enquiryDemo.biz.models;
using ApiModel = enquiryDemo.api.areas.enquiry.Models;
using BizService = enquiryDemo.biz.service.enquiry;

namespace enquiryDemo.api.areas.enquiry.Controllers
{
    [RoutePrefix("api/enquiry")]
    public class EnquiryController : ApiController
    {
        [Route("GetCustomerDetailByID")]
        [HttpGet]
        public HttpResponseMessage GetCustomerDetailByID(HttpRequestMessage request, [FromBody] BizModelMaster.enquiry.InquiryCriteriaDTO inquiryCriteriaDTO)
        {
            ApiModel.EnquiryApiModel _enquiryAPIModel = new ApiModel.EnquiryApiModel();
            BizModelMaster.TransactionalInformation transaction = new BizModelMaster.TransactionalInformation();
            BizService.Enquiry enquiryBS;


            enquiryBS = new BizService.Enquiry();
            
                var dmenquiry = enquiryBS.GetCustomerDetail(inquiryCriteriaDTO, out transaction);
                if (transaction.ReturnStatus == false)
                {
                    _enquiryAPIModel.ReturnMessage = transaction.ReturnMessage;
                    _enquiryAPIModel.ReturnStatus = transaction.ReturnStatus;
                    _enquiryAPIModel.ValidationErrors = transaction.ValidationErrors;
                    var badResponse = Request.CreateResponse<ApiModel.EnquiryApiModel>(HttpStatusCode.BadRequest, _enquiryAPIModel);
                    return badResponse;
                } 
            
            _enquiryAPIModel.ReturnStatus = transaction.ReturnStatus;
            _enquiryAPIModel.ReturnMessage = transaction.ReturnMessage;
            _enquiryAPIModel.items = dmenquiry;
            var response = Request.CreateResponse<ApiModel.EnquiryApiModel>(dmenquiry.Count > 0? HttpStatusCode.OK: HttpStatusCode.NotFound, _enquiryAPIModel);
            
            return response;
        }        
    }
}