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
    public class UserReportService
    {
        public static UserReportDTO Add(UserReportDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<UserReportDTO, UserReport>();
                c.CreateMap<UserReport, UserReportDTO>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<UserReport>(data);
            var ret = DataAccessFactory.UserReportDataAccess().Add(dbobj);
            return mapper.Map<UserReportDTO>(ret);
        }

        public static List<UserReportDTO> Get()
        {
            var data = DataAccessFactory.UserReportDataAccess().Get();
            var config = new MapperConfiguration(c => {
                c.CreateMap<UserReport, UserReportDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<UserReportDTO>>(data);
        }

        public static UserReportDTO Get(int id)
        {
            var data = DataAccessFactory.UserReportDataAccess().Get(id);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<UserReport, UserReportDTO>();
            });
            var mapper = new Mapper(config);
            var UserReport = mapper.Map<UserReportDTO>(data);
            return UserReport;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.UserReportDataAccess().Delete(id);
        }

        public static UserReportDTO Update(UserReportDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<UserReport, UserReportDTO>();
                c.CreateMap<UserReportDTO, UserReport>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<UserReport>(obj);
            var data = DataAccessFactory.UserReportDataAccess().Update(newobj);
            return mapper.Map<UserReportDTO>(data);
        }
    }
}
