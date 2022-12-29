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
    public class AdminService
    {
        public static AdminDTO Add(AdminDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<AdminDTO, Admin>();
                c.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<Admin>(data);
            var ret = DataAccessFactory.AdminDataAccess().Add(dbobj);
            return mapper.Map<AdminDTO>(ret);
        }

        public static List<AdminDTO> Get()
        {
            var data = DataAccessFactory.AdminDataAccess().Get();
            var config = new MapperConfiguration(c => {
                c.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<AdminDTO>>(data);
        }

        public static AdminDTO Get(int id)
        {
            var data = DataAccessFactory.AdminDataAccess().Get(id);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(config);
            var Admin = mapper.Map<AdminDTO>(data);
            return Admin;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.AdminDataAccess().Delete(id);
        }

        public static AdminDTO Update(AdminDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Admin, AdminDTO>();
                c.CreateMap<AdminDTO, Admin>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<Admin>(obj);
            var data = DataAccessFactory.AdminDataAccess().Update(newobj);
            return mapper.Map<AdminDTO>(data);
        }

        public static bool UpdatePassword(int id, string password)
        {
            return DataAccessFactory.AdminSpecialDataAccess().UpdatePassword(id, password);
        }
    }
}
