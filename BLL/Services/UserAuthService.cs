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
    public class UserAuthService
    {
        public static UserAuthTokenDTO Authenticate(string email, string password)
        {
            var User = DataAccessFactory.UserAuthDataAccess().Authenticate(email, password);
            if (User != null)
            {
                UserAuthToken t = new UserAuthToken();
                t.CreationTime = DateTime.Now;
                t.UserId = User.Id;
                t.ExpirationTime = null;
                t.TKey = Guid.NewGuid().ToString();
                var rt = DataAccessFactory.UserAuthTokenDataAccess().Add(t);
                if (rt != null)
                {
                    var config = new MapperConfiguration(cfg => {
                        cfg.CreateMap<UserAuthToken, UserAuthTokenDTO>();
                    });
                    var mapper = new Mapper(config);
                    var data = mapper.Map<UserAuthTokenDTO>(rt);
                    return data;
                }
            }
            return null;
        }
        public static bool TokenValidity(string tkey)
        {

            var token = DataAccessFactory.UserAuthTokenDataAccess().Get(tkey);
            if (token != null && token.ExpirationTime == null)
            {
                return true;
            }
            return false;
        }

        public static bool ExpireToken(string tkey)
        {
            return DataAccessFactory.UserAuthTokenSpecialDataAccess().ExpireToken(tkey);
        }

        public static int GetUserId(string tkey)
        {
            return DataAccessFactory.UserAuthTokenSpecialDataAccess().GetRolePlayer(tkey);
        }
    }
}
