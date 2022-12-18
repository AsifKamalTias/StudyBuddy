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
        public class TutorService
        {
            public static TutorDTO Add(TutorDTO data)
            {
                var config = new MapperConfiguration(c => {
                    c.CreateMap<TutorDTO, Tutor>();
                    c.CreateMap<Tutor, TutorDTO>();
                });
                var mapper = new Mapper(config);
                var dbobj = mapper.Map<Tutor>(data);
                var ret = DataAccessFactory.TutorDataAccess().Add(dbobj);
                return mapper.Map<TutorDTO>(ret);
            }

            public static List<TutorDTO> Get()
            {
                var data = DataAccessFactory.TutorDataAccess().Get();
                var config = new MapperConfiguration(c => {
                    c.CreateMap<Tutor, TutorDTO>();
                });
                var mapper = new Mapper(config);
                return mapper.Map<List<TutorDTO>>(data);
            }

            public static TutorDTO Get(int id)
            {
                var data = DataAccessFactory.TutorDataAccess().Get(id);
                var config = new MapperConfiguration(c =>
                {
                    c.CreateMap<Tutor, TutorDTO>();
                });
                var mapper = new Mapper(config);
                var Tutor = mapper.Map<TutorDTO>(data);
                return Tutor;
            }

            public static bool Delete(int id)
            {
                return DataAccessFactory.TutorDataAccess().Delete(id);
            }

            public static TutorDTO Update(TutorDTO obj)
            {
                var config = new MapperConfiguration(c =>
                {
                    c.CreateMap<Tutor, TutorDTO>();
                    c.CreateMap<TutorDTO, Tutor>();
                });
                var mapper = new Mapper(config);
                var newobj = mapper.Map<Tutor>(obj);
                var data = DataAccessFactory.TutorDataAccess().Update(newobj);
                return mapper.Map<TutorDTO>(data);
            }
        }
}
