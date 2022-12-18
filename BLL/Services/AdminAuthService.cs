using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AdminAuthService
    {
        public static AdminAuthTokenDTO Authenticate(string username, string password)
        {
            var admin = DataAccessFactory.AdminAuthDataAccess().Authenticate(username, password);
            if (admin != null)
            {
                AdminAuthToken t = new AdminAuthToken();
                t.CreationTime = DateTime.Now;
                t.AdminId = admin.Id;
                t.ExpirationTime = null;
                t.TKey = Guid.NewGuid().ToString();
                var rt = DataAccessFactory.AdminAuthTokenDataAccess().Add(t);
                if (rt != null)
                {
                    var config = new MapperConfiguration(cfg => {
                        cfg.CreateMap<AdminAuthToken, AdminAuthTokenDTO>();
                    });
                    var mapper = new Mapper(config);
                    var data = mapper.Map<AdminAuthTokenDTO>(rt);
                    return data;
                }
            }
            return null;
        }
        public static bool TokenValidity(string tkey)
        {

            var token = DataAccessFactory.AdminAuthTokenDataAccess().Get(tkey);
            if (token != null && token.ExpirationTime == null)
            {
                return true;
            }
            return false;
        }

        public static bool ExpireToken(string tkey)
        {
            return DataAccessFactory.AdminAuthTokenSpecialDataAccess().ExpireToken(tkey);
        }

        public static int GetAdminId(string tkey)
        {
            return DataAccessFactory.AdminAuthTokenSpecialDataAccess().GetRolePlayer(tkey);
        }
    }
}
