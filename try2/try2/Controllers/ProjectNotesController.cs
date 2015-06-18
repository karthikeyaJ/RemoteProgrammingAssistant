using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using try2.Models;

namespace try2.Controllers
{
    public class ProjectNotesController : Controller
    {
        [Authorize]
        public ActionResult Index(ProjectNotes ProjectNote)
        {
            return View(ProjectNote.Notes);
        }

        [Authorize]
        public ActionResult Form()
        {
            return View();
        }

        [Authorize]
        public ActionResult Grid(ProjectNotes model)
        {
            return View(model.Notes);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Note note)
        {
            ProjectNotes cm = new ProjectNotes();
            cm.Add(note);
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            ProjectNotes cm = new ProjectNotes();
            Note temp = cm.FindNoteById(id);
            return View(temp);
        }



        [Authorize]
        public ActionResult Details(int id)
        {
            try
            {
                Models.ProjectNotes courses = new Models.ProjectNotes();
                foreach (Models.Note course in courses.Notes)
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
        [HttpPost]
        public ActionResult Delete(Note note)
        {
            ProjectNotes cm = new ProjectNotes();
            cm.Remove(note);
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            ProjectNotes cm = new ProjectNotes();
            Note temp = cm.FindNoteById(id);
            return View(temp);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Note note)
        {
            ProjectNotes cm = new ProjectNotes();
            cm.Edit(note);
            return RedirectToAction("Index");
        }
      
    }
}