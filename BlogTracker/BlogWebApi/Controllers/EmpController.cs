using BlogWebApi.Models;
using DAl;

using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogWebApi.Controllers
{
    public class EmpController : ApiController
    {
        DAL be = null;
        public EmpController()
        {
            be = new DAL();
        }

       

        [Route("AddEmps")]
        
        public HttpResponseMessage Post([FromBody] Emp emp)
        {
            EmpInfo hy = new EmpInfo();
           hy.EmailId = emp.EmailId;
            hy.Name = emp.Name;
            hy.DateOfJoining = emp.DateOfJoining;
            hy.PassCode = emp.PassCode;
            bool ans = be.InsertEmployee(hy);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }



        }
        [Route("DeleteEmps/value/{value}")]
       
        public HttpResponseMessage Delete(string value)
        {
            bool ans = be.DeleteEmp(value);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }

        [Route("UpdateEmps/value/{value}")]
        
        public HttpResponseMessage Put(string value, [FromBody] Emp p1)
        {
            EmpInfo hy1 = new EmpInfo();

            hy1.EmailId = p1.EmailId;
            hy1.Name = p1.Name;
            hy1.DateOfJoining = p1.DateOfJoining;
            hy1.PassCode = p1.PassCode;
            
            bool ans = be.UpdateEmployee(value, hy1);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }
        [Route("Getallemp")]
        public List<Emp> Get()
        {
            List<Emp> profiles = new List<Emp>();
            List<EmpInfo> empbal = new List<EmpInfo>();
            empbal = be.EmployeeList();
            foreach (var item in empbal)
            {
                //Employees emp = new Employees();
                profiles.Add(new Emp { EmailId = item.EmailId, Name = item.Name, DateOfJoining = item.DateOfJoining, PassCode = item.PassCode });
            }

            return profiles;
        }

    }
}