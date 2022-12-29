using BLL.DTOs;
using BLL.Services;
using StudyBuddy.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using System.Web.Http.Cors;

namespace StudyBuddy.Controllers
{
    [EnableCors("*", "*", "*")]
    public class TuitionController : ApiController
    {
        [Route("api/tuition/tuitions")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = TuitionService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/tuition/verified")]
        [HttpGet]
        public HttpResponseMessage GetVerifiedTuitions()
        {
            var data = TuitionService.VerifiedTuitions();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/tuition/pending")]
        [HttpGet]
        public HttpResponseMessage GetPendingTuitions()
        {
            var data = TuitionService.PendingTuitions();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/tuition/add")]
        [HttpPost]
        [UserLogged]
        public HttpResponseMessage AddTuition(CreatePostDTO dto)
        {
            TuitionDTO t1 = new TuitionDTO();
            t1.Title = dto.Title;
            t1.Description = dto.Description;
            t1.MonthlyFees= dto.MonthlyFees;
            t1.Address= dto.Address;
            t1.Course = dto.Course;
            t1.Status = "pending";
            t1.Created = DateTime.Now;
            t1.UserId = UserAuthService.GetUserId(Request.Headers.Authorization.ToString());
            var data = TuitionService.Add(t1);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/tuition/unverify/{id}")]
        [HttpPost]
        [AdminLogged]
        public HttpResponseMessage Unverify(int id)
        {
            try
            {
                var data = TuitionService.UnverifyTuition(id);
                if(data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Unverified");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Something went wrong.");
                }
                
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, exc);
            }
        }

        [Route("api/tuition/verify/{id}")]
        [HttpPost]
        [AdminLogged]
        public HttpResponseMessage Verify(int id)
        {
            try
            {
                var data = TuitionService.VerifyTuition(id);
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Verified");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Something went wrong.");
                }

            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, exc);
            }
        }

        //payments
        [Route("api/payment/payments")]
        [HttpPost]
        [AdminLogged]
        public HttpResponseMessage Payments()
        {
            try
            {
                var data = PaymentService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, exc);
            }
        }

        [Route("api/payment/pending")]
        [HttpPost]
        [AdminLogged]
        public HttpResponseMessage PendingPayments()
        {
            try
            {
                var data = PaymentService.GetPendingPayments();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, exc);
            }
        }

        [Route("api/payment/verify/{id}")]
        [HttpPost]
        [AdminLogged]
        public HttpResponseMessage VerifyPaymentWithTuition(int id)
        {
            try
            {
                var verifyPayment = PaymentService.VerifyPayment(id);
                var paidTuitionId = PaymentService.GetPaidTuition(id);
                var verifyTuition = TuitionService.VerifyTuition(paidTuitionId);
                return Request.CreateResponse(HttpStatusCode.OK, "Verified");
            }
            catch(Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, exc);
            }
        }

        [Route("api/payment/tuition/{id}")]
        [HttpPost]
        [UserLogged]
        public HttpResponseMessage TuitionPaymentInfo(int id)
        {
            try
            {
                var userId = UserAuthService.GetUserId(Request.Headers.Authorization.ToString());
                var data = TuitionService.Get(id);
                if(userId == data.UserId)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, "Something Went Wrong");
                }
                
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, exc);
            }
        }

        [Route("api/payment/submit/{id}")]
        [HttpPost]
        [UserLogged]
        public HttpResponseMessage SubmitPayment(int id, PaymentCreateDTO dto)
        {
            try
            {
                var userId = UserAuthService.GetUserId(Request.Headers.Authorization.ToString());
                PaymentDTO p1 = new PaymentDTO();
                p1.TransactionKey = dto.TransactionKey;
                p1.IsVerified = false;  
                p1.Created = DateTime.Now;
                p1.TuitionId = id;
                p1.UserId = userId;
                var data = PaymentService.Add(p1);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch(Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, exc);
            }
        }

        [Route("api/tuition/user")]
        [HttpPost]
        [UserLogged]
        public HttpResponseMessage MyTuitionPosts()
        {
            try
            {
                var userId = UserAuthService.GetUserId(Request.Headers.Authorization.ToString());
                var data = TuitionService.GetUserTuitions(userId);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, exc);
            }
        }

        [Route("api/tuition/requests/{id}")]
        [HttpPost]
        [UserLogged]
        public HttpResponseMessage TuitionRequestsByTuition(int id)
        {
            try
            {
                var data = TuitionTutorRequestService.TuitionTutorRequestsByTuition(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, exc);
            }

        }

        [Route("api/tuition/request/accept/{id}")]
        [HttpPost]
        [UserLogged]
        public HttpResponseMessage TuitionAccept(int id)
        {
            var data = TuitionTutorRequestService.AccpetTuition(id);
            var tuitionId = TuitionTutorRequestService.GetTuitionId(id);
            var dataTuitionUpdate = TuitionService.AcceptTuition(tuitionId);
            return Request.CreateResponse(HttpStatusCode.OK, "Accepted");
        }

        [Route("api/tuitions/tutor-feed")]
        [HttpPost]
        [TutorLogged]
        public HttpResponseMessage VerifiedTuitionList()
        {
            var data = TuitionService.VerifiedTuitions();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/tuition/apply/{id}")]
        [HttpPost]
        [TutorLogged]
        public HttpResponseMessage AddRequest(int id, AddRequestDTO dto)
        {
            var tuitorId = TutorAuthService.GetTutorId(Request.Headers.Authorization.ToString());
            TuitionTutorRequestDTO x1 = new TuitionTutorRequestDTO();
            x1.Message = dto.Message;
            x1.IsAccepted = false;
            x1.Created = DateTime.Now;
            x1.TuitionId= id;
            x1.TutorId = tuitorId;
            var data = TuitionTutorRequestService.Add(x1);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/tuition/applied")]
        [HttpPost]
        [TutorLogged]
        public HttpResponseMessage AppliedTuitions()
        {
            var tutorId = TutorAuthService.GetTutorId(Request.Headers.Authorization.ToString());
            var data = TuitionTutorRequestService.TutorRequestedTuitions(tutorId);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/tuition/info/{id}")]
        [HttpGet]
        public HttpResponseMessage GetTuitionInfo(int id)
        {
            var data = TuitionService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
