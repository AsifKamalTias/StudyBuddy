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
    }
}
