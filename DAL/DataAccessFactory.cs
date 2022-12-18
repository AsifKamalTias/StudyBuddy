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

    }
}
