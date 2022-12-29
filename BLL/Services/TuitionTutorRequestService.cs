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
    public class TuitionTutorRequestService
    {
        public static TuitionTutorRequestDTO Add(TuitionTutorRequestDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<TuitionTutorRequestDTO, TuitionTutorRequest>();
                c.CreateMap<TuitionTutorRequest, TuitionTutorRequestDTO>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<TuitionTutorRequest>(data);
            var ret = DataAccessFactory.TuitionTutorRequestDataAccess().Add(dbobj);
            return mapper.Map<TuitionTutorRequestDTO>(ret);
        }

        public static List<TuitionTutorRequestDTO> Get()
        {
            var data = DataAccessFactory.TuitionTutorRequestDataAccess().Get();
            var config = new MapperConfiguration(c => {
                c.CreateMap<TuitionTutorRequest, TuitionTutorRequestDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<TuitionTutorRequestDTO>>(data);
        }

        public static TuitionTutorRequestDTO Get(int id)
        {
            var data = DataAccessFactory.TuitionTutorRequestDataAccess().Get(id);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TuitionTutorRequest, TuitionTutorRequestDTO>();
            });
            var mapper = new Mapper(config);
            var TuitionTutorRequest = mapper.Map<TuitionTutorRequestDTO>(data);
            return TuitionTutorRequest;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.TuitionTutorRequestDataAccess().Delete(id);
        }

        public static TuitionTutorRequestDTO Update(TuitionTutorRequestDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TuitionTutorRequest, TuitionTutorRequestDTO>();
                c.CreateMap<TuitionTutorRequestDTO, TuitionTutorRequest>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<TuitionTutorRequest>(obj);
            var data = DataAccessFactory.TuitionTutorRequestDataAccess().Update(newobj);
            return mapper.Map<TuitionTutorRequestDTO>(data);
        }

        public static List<TuitionTutorRequestDTO> TuitionTutorRequestsByTuition(int id)
        {
            var data = DataAccessFactory.TuitionTutorRequestSpecialDataAccess().GetTuitionRequestsByTuition(id);
            var config = new MapperConfiguration(c => {
                c.CreateMap<TuitionTutorRequest, TuitionTutorRequestDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<TuitionTutorRequestDTO>>(data);
        }

        public static bool AccpetTuition(int id)
        {
            return DataAccessFactory.TuitionTutorRequestSpecialDataAccess().Accept(id);
        }

        public static int GetTuitionId(int id)
        {
            return DataAccessFactory.TuitionTutorRequestSpecialDataAccess().GetTuitionId(id);
        }

        public static List<TuitionTutorRequestDTO> TutorRequestedTuitions(int id)
        {
            var data = DataAccessFactory.TuitionTutorRequestSpecialDataAccess().GetTutorsAppliedTuitions(id);
            var config = new MapperConfiguration(c => {
                c.CreateMap<TuitionTutorRequest, TuitionTutorRequestDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<TuitionTutorRequestDTO>>(data);
        }
    }
}
