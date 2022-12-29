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
<<<<<<< HEAD
    [EnableCors("*","*","*")]
=======
    [EnableCors("*", "*", "*")]
>>>>>>> 2ccc8a2b5bc256b80f5cd5cd850b1c3469c244f5
    public class TutorController : ApiController
    {
        [Route("api/tutor/tutors")]
        [HttpGet]
<<<<<<< HEAD
        [AdminLogged]
=======
>>>>>>> 2ccc8a2b5bc256b80f5cd5cd850b1c3469c244f5
        public HttpResponseMessage Get()
        {
            var data = TutorService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

<<<<<<< HEAD


        [Route("api/tutor/registration")]
        [HttpPost]
        public HttpResponseMessage Registration(TutorRegistrationDTO tutor)
        {

            if (TutorService.ValidEmail(tutor.Email))
            {
                TutorDTO tutor1 = new TutorDTO();
                tutor1.Name = tutor.Name;
                tutor1.Email = tutor.Email;
                tutor1.Password = tutor.Password;
                tutor1.Photo = "";
                tutor1.PhoneNumber = tutor.PhoneNumber;
                tutor1.Description = tutor.Description;
                tutor1.Address = tutor.Address;
                tutor1.NID = tutor.NID;
                tutor1.EducationLabel = tutor.EducationLabel;
                tutor1.CurrentJob = tutor.CurrentJob;
                tutor1.IsAccepted = false;
                tutor1.IsBlocked = false;
                tutor1.Created = DateTime.Now;
                var data = TutorService.Add(tutor1);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Email Already Exist");
            }

        }



=======
>>>>>>> 2ccc8a2b5bc256b80f5cd5cd850b1c3469c244f5
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

<<<<<<< HEAD


=======
>>>>>>> 2ccc8a2b5bc256b80f5cd5cd850b1c3469c244f5
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

<<<<<<< HEAD


=======
>>>>>>> 2ccc8a2b5bc256b80f5cd5cd850b1c3469c244f5
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

<<<<<<< HEAD


        [Route("api/tutor/signout")]
        [HttpPost]
        [TutorLogged]
        public HttpResponseMessage SignOut()
        {
            try
            {
                var data = TutorAuthService.ExpireToken(Request.Headers.Authorization.ToString());
                if (data)
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



        [Route("api/tutor/dashboard")]
        [HttpPost]
        [TutorLogged]
        public HttpResponseMessage Dashboard()
        {
            try
            {
                var tutor = TutorAuthService.GetTutorId(Request.Headers.Authorization.ToString());
                var data = TutorService.Get(tutor);
                return Request.CreateResponse(HttpStatusCode.OK, data.Name);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        //change



        [Route("api/tutor/profile/data")]
        [HttpPost]
        [TutorLogged]
        public HttpResponseMessage TutorProfileData()
        {
            try
            {
                var tutor = TutorAuthService.GetTutorId(Request.Headers.Authorization.ToString());
                var data = TutorService.Get(tutor);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        [Route("api/tutor/profile/edit")]
        [HttpPost]
        [TutorLogged]
        public HttpResponseMessage TutorProfileUpdate(TutorEditDTO dto)
        {
            try
            {
                var tutorId = TutorAuthService.GetTutorId(Request.Headers.Authorization.ToString());
                var data = TutorService.EditProfile(tutorId, dto.Name, dto.Password, dto.PhoneNumber, dto.Description, dto.Address, dto.EducationLabel, dto.CurrentJob);
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Profile Updated");
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

        [Route("api/tutor/info/{id}")]
        [HttpGet]
        public HttpResponseMessage GetTutor(int id)
        {
            var data = TutorService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/tutor/accept/{id}")]
        [HttpPost]
        [AdminLogged]
        public HttpResponseMessage Accept(int id)
        {
            var data = TutorService.AcceptTutor(id);
            if(data)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Accepted");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Someting went wrong");
            }
        }

=======
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
>>>>>>> 2ccc8a2b5bc256b80f5cd5cd850b1c3469c244f5
    }
}
