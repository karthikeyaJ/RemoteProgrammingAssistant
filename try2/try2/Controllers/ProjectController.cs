
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using try2.Models;

namespace try2.Controllers
{
    public class ProjectController : Controller
    {
        //
        // GET: /Project/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }


        [Authorize]
        public ActionResult ListView(ProjectModel model)
        {

            return View(model.Projects);
        }


        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Project project)
        {
            ProjectModel pm = new ProjectModel();
            pm.Add(project);
            return RedirectToAction("ListView");
        }

        [Authorize]
        public ActionResult AddReq()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddReq(Project project)
        {
            ProjectModel pm = new ProjectModel();
            //pm.ReqModel(project);
            return RedirectToAction("ListView");
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            try
            {
                Models.ProjectModel courses = new Models.ProjectModel();
                foreach (Models.Project course in courses.Projects)
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

        [Authorize]
        public ActionResult Delete(int id)
        {

            ProjectModel pm = new ProjectModel();
            Project temp = pm.FindProjectById(id);
            return View(temp);

        }
        [Authorize]
        [HttpPost]
        public ActionResult Delete(Project project)
        {
            ProjectModel pm = new ProjectModel();
            pm.Remove(project);
            return RedirectToAction("ListView");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            ProjectModel pm = new ProjectModel();
            Project temp = pm.FindProjectById(id);
            return View(temp);
        }


        [Authorize]
        [HttpPost]
        public ActionResult Edit(Project project)
        {
            ProjectModel pm = new ProjectModel();
            pm.Edit(project);
            return RedirectToAction("ListView");
        }
    }
}
