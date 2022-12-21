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
    public class TutorRatingFeedbackService
    {
        public static TutorRatingFeedbackDTO Add(TutorRatingFeedbackDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<TutorRatingFeedbackDTO, TutorRatingFeedback>();
                c.CreateMap<TutorRatingFeedback, TutorRatingFeedbackDTO>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<TutorRatingFeedback>(data);
            var ret = DataAccessFactory.TutorRatingFeedbackDataAccess().Add(dbobj);
            return mapper.Map<TutorRatingFeedbackDTO>(ret);
        }

        public static List<TutorRatingFeedbackDTO> Get()
        {
            var data = DataAccessFactory.TutorRatingFeedbackDataAccess().Get();
            var config = new MapperConfiguration(c => {
                c.CreateMap<TutorRatingFeedback, TutorRatingFeedbackDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<TutorRatingFeedbackDTO>>(data);
        }

        public static TutorRatingFeedbackDTO Get(int id)
        {
            var data = DataAccessFactory.TutorRatingFeedbackDataAccess().Get(id);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TutorRatingFeedback, TutorRatingFeedbackDTO>();
            });
            var mapper = new Mapper(config);
            var TutorRatingFeedback = mapper.Map<TutorRatingFeedbackDTO>(data);
            return TutorRatingFeedback;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.TutorRatingFeedbackDataAccess().Delete(id);
        }

        public static TutorRatingFeedbackDTO Update(TutorRatingFeedbackDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<TutorRatingFeedback, TutorRatingFeedbackDTO>();
                c.CreateMap<TutorRatingFeedbackDTO, TutorRatingFeedback>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<TutorRatingFeedback>(obj);
            var data = DataAccessFactory.TutorRatingFeedbackDataAccess().Update(newobj);
            return mapper.Map<TutorRatingFeedbackDTO>(data);
        }
    }
}
