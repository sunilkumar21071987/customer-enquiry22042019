using System.Web.Mvc;

namespace enquiryDemo.api.areas.bookings
{
    public class enquiryAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "bookings";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "enquiry_default",
                "enquiry/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}