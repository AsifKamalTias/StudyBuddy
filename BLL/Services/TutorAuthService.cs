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
    public class TutorAuthService
    {
        public static TutorAuthTokenDTO Authenticate(string email, string password)
        {
            var Tutor = DataAccessFactory.TutorAuthDataAccess().Authenticate(email, password);
            if (Tutor != null)
            {
                TutorAuthToken t = new TutorAuthToken();
                t.CreationTime = DateTime.Now;
                t.TutorId = Tutor.Id;
                t.ExpirationTime = null;
                t.TKey = Guid.NewGuid().ToString();
                var rt = DataAccessFactory.TutorAuthTokenDataAccess().Add(t);
                if (rt != null)
                {
                    var config = new MapperConfiguration(cfg => {
                        cfg.CreateMap<TutorAuthToken, TutorAuthTokenDTO>();
                    });
                    var mapper = new Mapper(config);
                    var data = mapper.Map<TutorAuthTokenDTO>(rt);
                    return data;
                }
            }
            return null;
        }
        public static bool TokenValidity(string tkey)
        {

            var token = DataAccessFactory.TutorAuthTokenDataAccess().Get(tkey);
            if (token != null && token.ExpirationTime == null)
            {
                return true;
            }
            return false;
        }

        public static bool ExpireToken(string tkey)
        {
            return DataAccessFactory.TutorAuthExpireDataAccess().ExpireToken(tkey);
        }
    }
}
