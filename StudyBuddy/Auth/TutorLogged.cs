using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace StudyBuddy.Auth
{
    public class TutorLogged : AuthorizationFilterAttribute
    {
<<<<<<< HEAD
=======
    {
>>>>>>> 2ccc8a2b5bc256b80f5cd5cd850b1c3469c244f5
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.Authorization;
            if (token == null)
            {
                actionContext.Response =
                    actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "No token supplied");
            }
            else if (!TutorAuthService.TokenValidity(token.ToString()))
            {
                actionContext.Response =
                    actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "Supplied Token is invalid or expired");
            }
            base.OnAuthorization(actionContext);
        }
    }
}