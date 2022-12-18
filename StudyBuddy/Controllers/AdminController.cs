using BLL.DTOs;
using BLL.Services;
using StudyBuddy.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Cors;

namespace StudyBuddy.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AdminController : ApiController
    {

        [Route("api/admin/admins")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = AdminService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/admin/add")]
        [HttpPost]
        public HttpResponseMessage Add(AdminDTO admin)
        {
            try
            {
                var data = AdminService.Add(admin);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/admin/login")]
        [HttpPost]
        public HttpResponseMessage Login(LoginDTO login)
        {
            try
            {
                var data = AdminAuthService.Authenticate(login.UniqueIdentity, login.Password);
                if(data != null)
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

        [Route("api/admin/logout")]
        [HttpPost]
        [AdminLogged]
        public HttpResponseMessage Logout()
        {
            //need to get auth token
            return Request.CreateResponse(HttpStatusCode.OK, "Admin Logout");
        }

        [Route("api/admin/dashboard")]
        [HttpPost]
        [AdminLogged]
        public HttpResponseMessage Dashboard()
        {
            //need to get auth token
            
            return Request.CreateResponse(HttpStatusCode.OK, "Admin Dashboard");
        }
    }
}
