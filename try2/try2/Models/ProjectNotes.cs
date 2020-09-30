using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using System.IO;

namespace try2.Models
{
    public class Note
    {
        public int id { get; set; }
        public string NotesName { get; set; }
        public string NotesDetail { get; set; }
    }
    public class ProjectNotes
    {
        public List<Note> Notes { get; set; }

        public ProjectNotes()
        {
            int count = 0;
            Notes = new List<Note>();
            bool test = Fill(Path());
            foreach (Note c in Notes)
            {
                c.id = count++;
            }
        }
        public string Path()
        {
            return HttpContext.Current.Server.MapPath("~\\App_Data\\ProjectNotes.xml");
        }
        public void Add(Note c)
        {
            Notes.Add(c);
            Save(Path());
        }
        public bool Remove(Note gone)
        {
            int count = 0;
            foreach (Note c in this.Notes)
            {
                if (gone.id == c.id)
                {
                    this.Notes.RemoveAt(count);
                    break;
                }
                ++count;
            }
            if (count < Notes.Count + 1)
            {
                this.Save(this.Path());
                return true;
            }
            return false;
        }
        public bool Edit(Note note)
        {
            foreach (Note c in this.Notes)
            {
                if (note.id == c.id)
                {
                    c.NotesName = note.NotesName;
                    c.NotesDetail = note.NotesDetail;
                    this.Save(this.Path());
                    return true;
                }
            }
            return false;
        }
        public Note FindNoteById(int id)
        {
            //use { and } improving code readabilty
            foreach (Note c in this.Notes)
            {
                if (c.id == id)
                {
                    return c;
                }
            }
            Note rtn = new Note();
            rtn.id = -1;
            rtn.NotesName = "Error";
            rtn.NotesDetail = "";
            return rtn;
        }
        public bool Fill(string path)
        {
            try
            {
                XDocument doc = XDocument.Load(path);
                var q = from chr in doc.Elements("notes").Elements("note") select chr;
                foreach (var elem in q)
                {
                    Note c = new Note();
                    c.NotesName = elem.Element("NotesName").Value;
                    c.NotesDetail = elem.Element("NotesDetail").Value;
                    Notes.Add(c);
                }
            }
            catch { return false; }
            return true;
        }
        public bool Save(string path)
        {
            try
            {
                XDocument doc = new XDocument();
                XElement elm = new XElement("notes");
                foreach (Note c in this.Notes)
                {
                    XElement note = new XElement("note");
                    XElement NotesName = new XElement("NotesName");
                    NotesName.Value = c.NotesName;
                    XElement NotesDetail = new XElement("NotesDetail");
                    NotesDetail.Value = c.NotesDetail;
                    note.Add(NotesName);

                    note.Add(NotesDetail);
                    elm.Add(note);
                }
                doc.Add(elm);
                doc.Save(path);
            }
            catch { return false; }
            return true;
        }
    }
}
