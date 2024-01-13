using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using WebApplication2.Models.Repository;
using WebApplication2.Models;


namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        DAL dal = new DAL();
        // GET: User
        public ActionResult Index()
        {
            ModelState.Clear();

            return View(dal.GetDetails());
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View(dal.GetDetails().Find(ur => ur.id == id));
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(StudentRegistratonModel sr)
        {
            try
            {
                // TODO: Add insert logic here
                if (dal.Insertdetails(sr))
                { ViewBag.Message = "Data Saved"; }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View(dal.GetDetails().Find(ur=>ur.id==id));
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentRegistratonModel sr)
        {
            try
            {
                // TODO: Add update logic here
                if(dal.updatedetails(sr))
                {
                    ViewBag.Message = "Edit completed";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View(dal.GetDetails().Find(ur => ur.id == id));
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, StudentRegistratonModel sr)
        {
            try
            {
                // TODO: Add delete logic here
                if (dal.deletedetails(sr))
                {
                    ViewBag.Message = "Record deleted";
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
    }
}
