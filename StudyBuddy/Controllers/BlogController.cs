using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace StudyBuddy.Controllers
{
    [EnableCors("*", "*", "*")]
    public class BlogController : ApiController
    {
        [Route("api/blogs/all")]
        [HttpGet]
        public HttpResponseMessage ViewBlogs()
        {
            var data = BlogService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/blogs/create")]
        [HttpPost]
        public HttpResponseMessage AddBlog(CreateBlogDTO dto)
        {
            BlogDTO b1 = new BlogDTO();
            b1.Title = dto.Title;
            b1.Description = dto.Description;
            b1.Created = (DateTime.Now).ToString();
            var data = BlogService.Add(b1);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
