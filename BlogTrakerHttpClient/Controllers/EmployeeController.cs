using BlogTrakerHttpClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BlogTrakerHttpClient.Controllers
{
    public class EmployeeController : Controller
    {
      
        public ActionResult Index()
        {
            List<Emp1> emplist = new List<Emp1>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44363//Getallemp");

                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readData = result.Content.ReadAsAsync<Emp1[]>();
                    readData.Wait();
                    var empdata = readData.Result;
                    foreach (var item in empdata)
                    {
                        emplist.Add(new Emp1 { EmailId = item.EmailId, Name = item.Name, DateOfJoining = item.DateOfJoining, PassCode = item.PassCode });

                    }
                }

            }

            return View(emplist);
        }
        public ActionResult AddNewEmployeee()
        {

            return View();
        }
        [HttpPost]

        public ActionResult AddNewEmployeee(Emp1 empmodel)
        {

            //if (ModelState.IsValid)
            //{
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44363//AddEmps");

                var emp = new Emp1 { EmailId = empmodel.EmailId,Name = empmodel.Name, DateOfJoining = empmodel.DateOfJoining, PassCode = empmodel.PassCode  };

                var postTask = client.PostAsJsonAsync<Emp1>(client.BaseAddress, emp);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtaskResult = result.Content.ReadAsAsync<Emp1>();

                    readtaskResult.Wait();
                    var dataInserted = readtaskResult.Result;
                }


            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection c)
        {
            string k = c["Email"].ToString();
            string p = c["password"].ToString();
            if (k == "admin@gmail.com" && p == "N@ndhu")
            {
                // return RedirectToRoute(new { action = "Index", controller = "Home", area = "" });
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message1 = "Invalid username/password";
                return View();
            }
        }
    }
}