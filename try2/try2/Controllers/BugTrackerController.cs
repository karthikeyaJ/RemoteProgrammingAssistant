using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using try2.Models;

namespace try2.Controllers
{
    public class BugTrackerController : Controller
    {
        //
        // GET: /BugTracker/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Create()
        {
            List<string> statuslist=new List<string>();
            statuslist.Add("Not Started");
            statuslist.Add("Pending");
            statuslist.Add("Completed");
            ViewBag.list = new SelectList(statuslist);


            return View();
        }
        // To create the BugTracker Module
        [Authorize]
        [HttpPost]
        public ActionResult Create(BugTracker bugtracker)
        {
            
            BugTrackerModel btm = new BugTrackerModel();
            btm.Add(bugtracker);
            return RedirectToAction("BugsList");
        }
        // BugTracker Module Definitions

        // To call the view to show the grid level of  BugTrackers
        [Authorize]
        public ActionResult BugsList(BugTrackerModel model)
        {
            return View(model.BugTrackers);
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            BugTrackerModel btm = new BugTrackerModel();
            BugTracker retbug = btm.FindBugById(id);
            return View(retbug);
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            try
            {
                Models.BugTrackerModel courses = new Models.BugTrackerModel();
                foreach (Models.BugTracker course in courses.BugTrackers)
                {
                    if (course.id == id)
                    {
                        return View(course);
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }


        // Delete the object for BugTracker
        [Authorize]
        [HttpPost]
        public ActionResult Delete(BugTracker bugtracker)
        {
            BugTrackerModel btm = new BugTrackerModel();
            btm.Remove(bugtracker);
            return RedirectToAction("BugsList");
        }
        // Perform the Action to Fire up Edit
                [Authorize]
        public ActionResult Edit(int id)
        {
            BugTrackerModel btm = new BugTrackerModel();
            BugTracker rettemp = btm.FindBugById(id);
            return View(rettemp);
        }
        // Perform the action to Edit the object of BugTracker
        [Authorize]
        [HttpPost]
        public ActionResult Edit(BugTracker bugtracker)
        {
            BugTrackerModel btm = new BugTrackerModel();
            btm.Edit(bugtracker);
            return RedirectToAction("BugsList");
        }



	}
}