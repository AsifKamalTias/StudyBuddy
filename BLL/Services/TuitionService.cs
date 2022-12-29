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
    public class TuitionService
    {
        public static TuitionDTO Add(TuitionDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<TuitionDTO, Tuition>();
                c.CreateMap<Tuition, TuitionDTO>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<Tuition>(data);
            var ret = DataAccessFactory.TuitionDataAccess().Add(dbobj);
            return mapper.Map<TuitionDTO>(ret);
        }

        public static List<TuitionDTO> Get()
        {
            var data = DataAccessFactory.TuitionDataAccess().Get();
            var config = new MapperConfiguration(c => {
                c.CreateMap<Tuition, TuitionDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<TuitionDTO>>(data);
        }

        public static TuitionDTO Get(int id)
        {
            var data = DataAccessFactory.TuitionDataAccess().Get(id);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Tuition, TuitionDTO>();
            });
            var mapper = new Mapper(config);
            var Tuition = mapper.Map<TuitionDTO>(data);
            return Tuition;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.TuitionDataAccess().Delete(id);
        }

        public static TuitionDTO Update(TuitionDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Tuition, TuitionDTO>();
                c.CreateMap<TuitionDTO, Tuition>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<Tuition>(obj);
            var data = DataAccessFactory.TuitionDataAccess().Update(newobj);
            return mapper.Map<TuitionDTO>(data);
        }

        public static List<TuitionDTO> VerifiedTuitions()
        {
            var data =  DataAccessFactory.TuitionSpeacialDataAccess().GetVerified();
            var config = new MapperConfiguration(c => {
                c.CreateMap<Tuition, TuitionDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<TuitionDTO>>(data);
        }

        public static List<TuitionDTO> PendingTuitions()
        {
            var data = DataAccessFactory.TuitionSpeacialDataAccess().GetPending();
            var config = new MapperConfiguration(c => {
                c.CreateMap<Tuition, TuitionDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<TuitionDTO>>(data);
        }

        public static bool UnverifyTuition(int id)
        {
            return DataAccessFactory.TuitionSpeacialDataAccess().Unverify(id);
        }

        public static bool VerifyTuition(int id)
        {
            return DataAccessFactory.TuitionSpeacialDataAccess().Verify(id);
        }

        public static bool AcceptTuition(int id)
        {
            return DataAccessFactory.TuitionSpeacialDataAccess().Accept(id);
        }

        public static List<TuitionDTO> GetUserTuitions(int id)
        {
            var data = DataAccessFactory.TuitionSpeacialDataAccess().GetUserTuition(id);
            var config = new MapperConfiguration(c => {
                c.CreateMap<Tuition, TuitionDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<TuitionDTO>>(data);
        }
    }
}
