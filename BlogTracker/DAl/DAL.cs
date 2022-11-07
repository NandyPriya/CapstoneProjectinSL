using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAl
{
    public class DAL
    {

        MyContext c1 = null;
        public DAL()
        {
            c1 = new MyContext();
        }
        public bool InsertEmployee(EmpInfo b1)
        {
            try
            {
                c1.EmpInfoTable.Add(b1);
                c1.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }

        }
        public bool DeleteEmp(string b1)
        {
            try
            {

                EmpInfo k = c1.EmpInfoTable.Find(b1);
                c1.EmpInfoTable.Remove(k);
                c1.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public bool UpdateEmployee(string id, EmpInfo b1)
        {
            try
            {
                EmpInfo k = c1.EmpInfoTable.Find(id);
                k.EmailId = b1.EmailId;
                k.Name = b1.Name;
                k.DateOfJoining = b1.DateOfJoining;
                k.PassCode = b1.PassCode;

                c1.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public List<EmpInfo> EmployeeList()
        {

            return c1.EmpInfoTable.ToList();
        }

        public EmpInfo FindEmployee(string id)
        {
            EmpInfo k = c1.EmpInfoTable.Find(id);
            return k;
        }
        public bool InsertBlog(BlogInfo b11)
        {
            try
            {
                c1.BlogInfoTable.Add(b11);
                c1.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }

        }
        public bool UpdateBlog(int id, BlogInfo b11)
        {
            try
            {
                BlogInfo k1 = c1.BlogInfoTable.Find(id);
                //var d = c1.BlogInfoTable.ToList();
                //BlogInfo k1 = d.Find(x => x.BlogId == id);
                
                                k1.BlogId = Convert.ToInt32(b11.BlogId);
                k1.Title = b11.Title;
                k1.Subject = b11.Subject;
                k1.DateOfCreation = b11.DateOfCreation;
                k1.BlogUrl = b11.BlogUrl;
                k1.EmpEmailId = b11.EmpEmailId;

                c1.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }
        public bool DeleteBlog(int b11)
        {
            try
            {

                BlogInfo k1 = c1.BlogInfoTable.Find(b11);
                c1.BlogInfoTable.Remove(k1);
                c1.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }


        }
        public List<BlogInfo> BlogList()
        {

            return c1.BlogInfoTable.ToList();
        }
    }
}
