using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDUsingJquery.Models;
using System.Data.Entity;
using Newtonsoft.Json;

namespace CRUDUsingJquery.Controllers
{
    public class StudentController : Controller
    {
        PracticeEntities1 _context = new PracticeEntities1();
        // GET: Employee

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Get()
        {
            var p = _context.stu_data.ToList();
            return Json(p, JsonRequestBehavior.AllowGet);
            //return View();
        }

        [HttpPost]
        public ActionResult Insert(stu_data k)
        {
            if (k.sid == 0)
            {
                _context.stu_data.Add(k);
            }

            else
            {
                _context.Entry(k).State = EntityState.Modified;
            }
            _context.SaveChanges();
             return View();
        }

        public ActionResult Edit(stu_data k)
        {
            var t = (from a in _context.stu_data where a.sid == k.sid select a).ToList();
            //var t = _context.stu_data.SingleOrDefault(x => x.sid == k.sid);
            

            //var json = JsonConvert.SerializeObject(stu_data);
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        public void Delete(stu_data k)
        {
            var p = _context.stu_data.Find(k.sid);
            _context.stu_data.Remove(p);
            _context.SaveChanges();              
        }
    }
}