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
    public class UserService
    {
        public static UserDTO Add(UserDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<UserDTO, User>();
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<User>(data);
            var ret = DataAccessFactory.UserDataAccess().Add(dbobj);
            return mapper.Map<UserDTO>(ret);
        }

        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserDataAccess().Get();
            var config = new MapperConfiguration(c => {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<UserDTO>>(data);
        }

        public static UserDTO Get(int id)
        {
            var data = DataAccessFactory.UserDataAccess().Get(id);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
            });
            var mapper = new Mapper(config);
            var User = mapper.Map<UserDTO>(data);
            return User;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.UserDataAccess().Delete(id);
        }

        public static UserDTO Update(UserDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
                c.CreateMap<UserDTO, User>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<User>(obj);
            var data = DataAccessFactory.UserDataAccess().Update(newobj);
            return mapper.Map<UserDTO>(data);
        }

        public static bool ValidateOTP(string email, string otp)
        {
            return DataAccessFactory.UserSpecialDataAccess().CheckOTP(email, otp);
        }

        public static bool EditProfile(int id, string name, string email)
        {
            return DataAccessFactory.UserSpecialDataAccess().EditProfile(id, name, email);
        }

        public static bool ValidEmail(string email)
        {
            if(DataAccessFactory.UserSpecialDataAccess().FindUserByEmail(email))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
