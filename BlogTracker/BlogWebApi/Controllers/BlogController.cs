using BlogWebApi.Models;
using DAl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogWebApi.Controllers
{
    public class BlogController : ApiController
    {
        DAL be = null;
        public BlogController()
        {
            be = new DAL();
        }
        [Route("AddBlog")]

        public HttpResponseMessage Post([FromBody] Blog blog)
        {
            BlogInfo hy1 = new BlogInfo();
            hy1.BlogId = blog.BlogId;
            hy1.Title = blog.Title;
            hy1.Subject = blog.Subject;
            hy1.DateOfCreation = blog.DateOfCreation;
            hy1.BlogUrl = blog.BlogUrl;
            hy1.EmpEmailId = blog.EmpEmailId;
            bool ans = be.InsertBlog(hy1);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }



        }
        [Route("Updateblog/{id}")]
        public HttpResponseMessage Put(int id, [FromBody]Blog blog)
        {
            BlogInfo hy1 = new BlogInfo();
            hy1.BlogId = Convert.ToInt32(blog.BlogId);
            hy1.Title = blog.Title;
            hy1.Subject = blog.Subject;
            hy1.DateOfCreation = blog.DateOfCreation;
            hy1.BlogUrl = blog.BlogUrl;
            hy1.EmpEmailId = blog.EmpEmailId;


            bool ans = be.UpdateBlog(id, hy1);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }

        [Route("DeleteBlog/{id}")]

        public HttpResponseMessage Delete(int id)
        {
            bool ans = be.DeleteBlog(id);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }
        [Route("GetallBlog")]
        public List<Blog> Get()
        {
            List<Blog> profiles = new List<Blog>();
            List<BlogInfo> empbal = new List<BlogInfo>();
            empbal = be.BlogList();
            foreach (var item in empbal)
            {
                //Employees emp = new Employees();
                profiles.Add(new Blog { BlogId = item.BlogId, Title = item.Title, Subject = item.Subject, DateOfCreation = item.DateOfCreation, BlogUrl = item.BlogUrl, EmpEmailId = item.EmpEmailId } );
            }

            return profiles;
        }
    }
}
