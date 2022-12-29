using BLL.DTOs;
using BLL.Services;
using StudyBuddy.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using System.Web.Http.Cors;

namespace StudyBuddy.Controllers
{
    [EnableCors("*","*","*")]
    public class UserController : ApiController
    {
        [Route("api/user/registration")]
        [HttpPost]
        public HttpResponseMessage Registration(UserRegistrationDTO user)
        {
            if (UserService.ValidEmail(user.Email))
            {
                Random rand = new Random();
                int randNum = rand.Next(1000, 9999);
                string otp = randNum.ToString();

                UserDTO user1 = new UserDTO();
                user1.Name = user.Name;
                user1.Email = user.Email;
                user1.Password = user.Password;
                user1.IsBlocked = false;
                user1.IsVerified = false;
                user1.OTP = otp;
                user1.Created = DateTime.Now;
                var data = UserService.Add(user1);
                //sendmail
                SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
                client.Credentials = new NetworkCredential("19-41346-3@student.aiub.edu", "Obantor123");
                client.EnableSsl = true;
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("19-41346-3@student.aiub.edu");
                mailMessage.To.Add(user.Email);
                mailMessage.Subject = "Studdy Buddy Registration";
                mailMessage.Body = "Your Registration Confirmation Code is" + otp;
                client.Send(mailMessage);

                return Request.CreateResponse(HttpStatusCode.OK, data.Email);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Email Already Exist");
            }
        }

        [Route("api/user/registration/otp")]
        [HttpPost]
        public HttpResponseMessage SubmitOTP(UserRegistrationOTPSubmitDTO dto)
        {
           try
           {
                var data = UserService.ValidateOTP(dto.Email, dto.OTP);
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
           }
           catch(Exception ex)
           {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
           }
        }

        [Route("api/user/login")]
        [HttpPost]
        public HttpResponseMessage Login(LoginDTO login)
        {
            try
            {
                var data = UserAuthService.Authenticate(login.UniqueIdentity, login.Password);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data.TKey);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid Email or Password");
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/user/dashboard")]
        [HttpPost]
        [UserLogged]
        public HttpResponseMessage Dashboard()
        {
            try
            {
                var user = UserAuthService.GetUserId(Request.Headers.Authorization.ToString());
                var data = UserService.Get(user);
                return Request.CreateResponse(HttpStatusCode.OK, data.Name);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/user/signout")]
        [HttpPost]
        [UserLogged]
        public HttpResponseMessage SignOut() 
        {
            try
            {
                var data = UserAuthService.ExpireToken(Request.Headers.Authorization.ToString());
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

        [Route("api/user/profile/data")]
        [HttpPost]
        [UserLogged]
        public HttpResponseMessage UserProfileData()
        {
            try
            {
                var user = UserAuthService.GetUserId(Request.Headers.Authorization.ToString());
                var data = UserService.Get(user);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/user/profile/edit")]
        [HttpPost]
        [UserLogged]
        public HttpResponseMessage UserProfileUpdate(UserProfileEditDTO dto)
        {
            try
            {
                var userId = UserAuthService.GetUserId(Request.Headers.Authorization.ToString());
                var data = UserService.EditProfile(userId, dto.Name, dto.Password);
                if(data)
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


        [Route("api/user/users")]
        [HttpGet]
        [AdminLogged]
        public HttpResponseMessage Get()
        {
            var data = UserService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
