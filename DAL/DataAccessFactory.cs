using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static ITuitionTutorRequestSpecial TuitionTutorRequestSpecialDataAccess()
        {
            return new TuitionTutorRequestRepo();
        }

        public static IPaymentSpecial PaymentSpecialDataAccess()
        {
            return new PaymentRepo();
        }
        public static IAdminSpecial AdminSpecialDataAccess()
        {
            return new AdminRepo();
        }

        public static IRepo<Admin, int, Admin> AdminDataAccess()
        {
            return new AdminRepo();
        }

        public static IAuth<Admin, string, string> AdminAuthDataAccess()
        {
            return new AdminRepo();
        }

        public static IRepo<AdminAuthToken, string, AdminAuthToken> AdminAuthTokenDataAccess()
        {
            return new AdminAuthTokenRepo();
        }

        public static IAuthToken AdminAuthTokenSpecialDataAccess()
        {
            return new AdminAuthTokenRepo();
        }

<<<<<<< HEAD
        public static IRepo<Tuition, int, Tuition> TuitionDataAccess()
        {
            return new TuitionRepo();
        }

        public static ITuitionSpecial TuitionSpeacialDataAccess()
        {
            return new TuitionRepo();
        }

        public static IRepo<TuitionTutorRequest, int, TuitionTutorRequest> TuitionTutorRequestDataAccess()
        {
            return new TuitionTutorRequestRepo();
        }

        public static IRepo<TuitionReport, int, TuitionReport> TuitionReportDataAccess()
        {
            return new TuitionReportRepo();
        }

=======
>>>>>>> 2ccc8a2b5bc256b80f5cd5cd850b1c3469c244f5
        public static IRepo<User, int, User> UserDataAccess()
        {
            return new UserRepo();
        }

        public static IAuth<User, string, string> UserAuthDataAccess()
        {
            return new UserRepo();
        }

        public static IRepo<UserAuthToken, string, UserAuthToken> UserAuthTokenDataAccess()
        {
            return new UserAuthTokenRepo();
        }

        public static IRepo<UserReport, int, UserReport> UserReportDataAccess()
        {
            return new UserReportRepo();
        }

        public static IAuthToken UserAuthTokenSpecialDataAccess()
        {
            return new UserAuthTokenRepo();
        }

<<<<<<< HEAD
        public static IUserSpecial UserSpecialDataAccess()
        {
            return new UserRepo();
        }
=======
>>>>>>> 2ccc8a2b5bc256b80f5cd5cd850b1c3469c244f5

        public static IRepo<Tutor, int, Tutor> TutorDataAccess()
        {
            return new TutorRepo();
        }

        public static IAuth<Tutor, string, string> TutorAuthDataAccess()
        {
            return new TutorRepo();
        }

        public static IRepo<TutorAuthToken, string, TutorAuthToken> TutorAuthTokenDataAccess()
        {
            return new TutorAuthTokenRepo();
        }

        public static IRepo<TutorRatingFeedback, int, TutorRatingFeedback> TutorRatingFeedbackDataAccess()
        {
            return new TutorRatingFeedbackRepo();
        }

        public static IAuthToken TutorAuthTokenSpecialDataAccess()
        {
            return new TutorAuthTokenRepo();
        }

<<<<<<< HEAD
        public static IRepo<Payment, int, Payment> PaymentDataAccess()
        {
            return new PaymentRepo();
        }

        public static ITutorSpecial TutorSpecialDataAccess()
        {
            return new TutorRepo();
        }

        public static IRepo<Blog, int, Blog> BlogDataAccess()
        {
            return new BlogRepo();
        }

=======
>>>>>>> 2ccc8a2b5bc256b80f5cd5cd850b1c3469c244f5
    }
}
