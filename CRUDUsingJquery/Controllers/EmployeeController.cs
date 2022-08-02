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
    public class EmployeeController : Controller
    {
        // GET: Product
        EmployeeEntities _context = new EmployeeEntities();

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(tblEmployee emp)
        {
            if(emp.EmployeeID==0)
            {
                _context.tblEmployees.Add(emp);
                
            }
            else
            {
                _context.Entry(emp).State = EntityState.Modified;
            }
            _context.SaveChanges();
            return View();
        }


        //public ActionResult Get()
        //{
        //    //var p = _context.tblEmployees.Include(x => x.tblDepartment).ToList();
        //    //return Json(p, JsonRequestBehavior.AllowGet);


        //    var t = (from a in _context.tblEmployees  //Linq
        //             join b in _context.tblDepartments
        //                on a.DepartmentID equals b.DepartmentID

        //             select new { a.EmployeeID, a.Name, a.Age, b.DepartmentName }).ToList();
        //    return Json(t, JsonRequestBehavior.AllowGet);
        //}


        public ActionResult GetEmployees(int pageNumber, int pageSize)
        {
            var t = _context.USP_Get1AllEmployees(pageNumber, pageSize);
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDepartment()
        {
            var p = (from a in _context.tblDepartments select new { a.DepartmentID,a.DepartmentName}).ToList();
            return Json(p, JsonRequestBehavior.AllowGet);
        }

        public void Delete(tblEmployee k)
        {
            var p = _context.tblEmployees.Find(k.EmployeeID);
            _context.tblEmployees.Remove(p);
            _context.SaveChanges();
        }

        public ActionResult Edit(tblEmployee k)
        {
            var t = (from a in _context.tblEmployees  //Linq
                     join b in _context.tblDepartments
                        on a.DepartmentID equals b.DepartmentID
                        where a.EmployeeID==k.EmployeeID
                     select new { a.EmployeeID, a.Name, a.Age, b.DepartmentID, b.DepartmentName }).ToList();
            return Json(t, JsonRequestBehavior.AllowGet);           
        }

        public ActionResult GetEmployee(tblEmployee m,tblDepartment n)
        {
            var t = (from a in _context.tblEmployees
                     join b in _context.tblDepartments
                        on a.DepartmentID equals b.DepartmentID
                     where a.Name ==m.Name || b.DepartmentName == n.DepartmentName
                     select new { a.EmployeeID, a.Name, a.Age, b.DepartmentName }).ToList();
            return Json(t, JsonRequestBehavior.AllowGet);
            //if (t.Count > 0)
            //{
            //    return Json(t, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    return View();
            //}
        }
    }
}