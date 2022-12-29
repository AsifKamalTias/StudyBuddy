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

        [Route("api/admin/edit")]
        [HttpPost]
        [AdminLogged]
        public HttpResponseMessage Update(AdminDTO admin)
        {
            try
            {
                var data = AdminService.Update(admin);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        //Work

        [Route("api/admin/login")]
        [HttpPost]
        public HttpResponseMessage Login(LoginDTO login)
        {
            try
            {
                var data = AdminAuthService.Authenticate(login.UniqueIdentity, login.Password);
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

        [Route("api/admin/logout")]
        [HttpPost]
        [AdminLogged]
        public HttpResponseMessage Logout()
        {
            try
            {
                var data = AdminAuthService.ExpireToken(Request.Headers.Authorization.ToString());
                if(data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Logout Successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Something went wrong");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        [Route("api/admin/dashboard")]
        [HttpPost]
        [AdminLogged]
        public HttpResponseMessage Dashboard()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        [Route("api/admin/profile")]
        [HttpPost]
        [AdminLogged]
        public HttpResponseMessage Profile()
        {
            try
            {
                var admin = AdminAuthService.GetAdminId(Request.Headers.Authorization.ToString());
                var data = AdminService.Get(admin);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/admin/profile/password")]
        [HttpPost]
        [AdminLogged]
        public HttpResponseMessage UpdatePassword(AdminUpdatePasswordDTO dto)
        {
            try
            {
                var admin = AdminAuthService.GetAdminId(Request.Headers.Authorization.ToString());
                var data = AdminService.UpdatePassword(admin, dto.Password);
                if(data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Password Changed");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Something went wrong");
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

    }
}
