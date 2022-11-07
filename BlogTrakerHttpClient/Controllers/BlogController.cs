using BlogTrakerHttpClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Mvc;

namespace BlogTrakerHttpClient.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            List<Blogee> emplist = new List<Blogee>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44363//GetallBlog");

                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readData = result.Content.ReadAsAsync<Blogee[]>();
                    readData.Wait();
                    var empdata = readData.Result;
                    foreach (var item in empdata)
                    {
                        emplist.Add(new Blogee { BlogId = item.BlogId, Title = item.Title, Subject = item.Subject, DateOfCreation = item.DateOfCreation, BlogUrl = item.BlogUrl, EmpEmailId = item.EmpEmailId });

                    }
                }

            }
            return View(emplist);
        }

        public ActionResult AddNewEmployee()
        {

            return View();
        }
        [HttpPost]

        public ActionResult AddNewEmployee(Blogee empmodel)
        {

            //if (ModelState.IsValid)
            //{
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44363//AddBlog");

                var emp = new Blogee { BlogId = empmodel.BlogId, Title = empmodel.Title, Subject = empmodel.Subject, DateOfCreation = empmodel.DateOfCreation, BlogUrl = empmodel.BlogUrl, EmpEmailId = empmodel.EmpEmailId };

                var postTask = client.PostAsJsonAsync<Blogee>(client.BaseAddress, emp);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtaskResult = result.Content.ReadAsAsync<Blogee>();

                    readtaskResult.Wait();
                    var dataInserted = readtaskResult.Result;
                }


            }

            return RedirectToAction("Index");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection c)
        {
            string k = c["Email"].ToString();
            string p = c["passcode"].ToString();
            if (k == "nandhu@gmail.com" && p == "1035")
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