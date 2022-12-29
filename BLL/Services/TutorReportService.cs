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
    public class TutorReportService
    {
        public static TuitionReportDTO Add(TuitionReportDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<TuitionReportDTO, TuitionReport>();
                c.CreateMap<TuitionReport, TuitionReportDTO>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<TuitionReport>(data);
            var ret = DataAccessFactory.TuitionReportDataAccess().Add(dbobj);
            return mapper.Map<TuitionReportDTO>(ret);
        }

        public static List<TuitionReportDTO> Get()
        {
            var data = DataAccessFactory.TuitionReportDataAccess().Get();
            var config = new MapperConfiguration(c => {
                c.CreateMap<TuitionReport, TuitionReportDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<TuitionReportDTO>>(data);
        }

        public static TuitionReportDTO Get(int id)
        {
            var data = DataAccessFactory.TuitionReportDataAccess().Get(id);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TuitionReport, TuitionReportDTO>();
            });
            var mapper = new Mapper(config);
            var TuitionReport = mapper.Map<TuitionReportDTO>(data);
            return TuitionReport;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.TuitionReportDataAccess().Delete(id);
        }

        public static TuitionReportDTO Update(TuitionReportDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TuitionReport, TuitionReportDTO>();
                c.CreateMap<TuitionReportDTO, TuitionReport>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<TuitionReport>(obj);
            var data = DataAccessFactory.TuitionReportDataAccess().Update(newobj);
            return mapper.Map<TuitionReportDTO>(data);
        }
    }
}
