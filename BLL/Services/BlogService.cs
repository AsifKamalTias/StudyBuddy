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
    public class BlogService
    {
        public static BlogDTO Add(BlogDTO data)
        {
            var config = new MapperConfiguration(c => {
                c.CreateMap<BlogDTO, Blog>();
                c.CreateMap<Blog, BlogDTO>();
            });
            var mapper = new Mapper(config);
            var dbobj = mapper.Map<Blog>(data);
            var ret = DataAccessFactory.BlogDataAccess().Add(dbobj);
            return mapper.Map<BlogDTO>(ret);
        }

        public static List<BlogDTO> Get()
        {
            var data = DataAccessFactory.BlogDataAccess().Get();
            var config = new MapperConfiguration(c => {
                c.CreateMap<Blog, BlogDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<BlogDTO>>(data);
        }

        public static BlogDTO Get(int id)
        {
            var data = DataAccessFactory.BlogDataAccess().Get(id);
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Blog, BlogDTO>();
            });
            var mapper = new Mapper(config);
            var Blog = mapper.Map<BlogDTO>(data);
            return Blog;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.BlogDataAccess().Delete(id);
        }

        public static BlogDTO Update(BlogDTO obj)
        {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Blog, BlogDTO>();
                c.CreateMap<BlogDTO, Blog>();
            });
            var mapper = new Mapper(config);
            var newobj = mapper.Map<Blog>(obj);
            var data = DataAccessFactory.BlogDataAccess().Update(newobj);
            return mapper.Map<BlogDTO>(data);
        }
    }
}
