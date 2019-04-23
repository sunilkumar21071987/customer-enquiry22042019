using System.Net.Http;
using System.Web.Http;


namespace enquiryDemo.api.Controllers
{
    [RoutePrefix("enquiryDemoapi/home")]
    public class HomeController : ApiController
    {
        //test
        public HomeController()
        {            
        }

        [Route("Login")]
        [HttpGet]
        public HttpResponseMessage Login()
        {
            return null;
        }

        [Route("Logout")]
        [HttpGet]
        public HttpResponseMessage Logout()
        {
            return null;
        }
        
        [Route("ForgotPassword")]
        [HttpGet]
        public HttpResponseMessage ForgotPassword()
        {
            return null;
        }
        
        [Route("LoadApp")]
        [HttpGet]
        public HttpResponseMessage LoadApp()
        {
            return null;
        }

        [Route("GetMenus")]
        [HttpGet]
        public HttpResponseMessage GetMenus()
        {
            return null;
        }
    }
}
