using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace resourceServer
{
    [Route("test")]
    public class TestController : ApiController
    {
        public IHttpActionResult Get()
        {
            var caller = User as ClaimsPrincipal;
            var subjectClaim = caller.FindFirst("sub");

            if (subjectClaim == null)
            {
                return new HttpActionResult(HttpStatusCode.InternalServerError, "error message");
            }

            return Json(new
            {
                message = "OK computer",
                client = caller.FindFirst("client_id").Value,
                subject = subjectClaim.Value
            });
        }
    }
}