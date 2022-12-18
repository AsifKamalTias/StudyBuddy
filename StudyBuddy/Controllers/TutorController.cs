using BLL.DTOs;
using BLL.Services;
using StudyBuddy.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace StudyBuddy.Controllers
{
    [EnableCors("*", "*", "*")]
    public class TutorController : ApiController
    {
        [Route("api/tutor/tutors")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = TutorService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/tutor/add")]
        [HttpPost]
        public HttpResponseMessage Add(TutorDTO tutor)
        {
            try
            {
                var data = TutorService.Add(tutor);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/tutor/login")]
        [HttpPost]
        public HttpResponseMessage Login(LoginDTO login)
        {
            try
            {
                var data = TutorAuthService.Authenticate(login.UniqueIdentity, login.Password);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data.TKey);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid Username or Password");
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/tutor/dashboard")]
        [HttpPost]
        [AdminLogged]
        public HttpResponseMessage Dashboard()
        {
            //var token = actionContext.Request.Headers.Authorization;
            //var adminId = AdminAuthService.GetAdminId(token.ToString());
            //var admin = AdminService.Get(adminId);

            return Request.CreateResponse(HttpStatusCode.OK, "Wow");
        }
    }
}
