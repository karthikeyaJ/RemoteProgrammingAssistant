using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.IO;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace try2.Models
{

        public class BugTracker
        {
            public int id { get; set; }
            [DisplayName("BugID")]
            [Required(ErrorMessage = "Integer")]
            [Range(0,1000,ErrorMessage="Must be between 0 and 1000")]
            public string BugID { get; set; }


            public string Reporter { get; set; }
            public string Customer { get; set; }
            public string BugResolution { get; set; }
            public string Component { get; set; }
            public string Priority { get; set; }
            public string Description { get; set; }
            public string Status { get; set; }
        }

        public class BugTrackerModel
        {
            public List<BugTracker> BugTrackers { get; set; }

            public BugTrackerModel()
            {
                int count = 0;
                BugTrackers = new List<BugTracker>();
                bool test = Fill(Path());
                foreach (BugTracker bug in BugTrackers)
                {
                    bug.id = count++;
                }
            }
            public string Path()
            {
                return HttpContext.Current.Server.MapPath("~\\App_Data\\BugTracker.xml");
            }
            public void Add(BugTracker bug)
            {
                BugTrackers.Add(bug);
                Save(Path());
            }
            public bool Remove(BugTracker gone)
            {
                int count = 0;
                foreach (BugTracker bug in this.BugTrackers)
                {
                    if (gone.id == bug.id)
                    {
                        this.BugTrackers.RemoveAt(count);
                        break;
                    }
                    ++count;
                }
                if (count < BugTrackers.Count + 1)
                {
                    this.Save(this.Path());
                    return true;
                }
                return false;
            }
            public bool Edit(BugTracker bugvalue)
            {
                foreach (BugTracker bug in this.BugTrackers)
                {
                    if (bugvalue.id == bug.id)
                    {

                        bug.BugID = bugvalue.BugID;
                        bug.Reporter = bugvalue.Reporter;
                        bug.Customer = bugvalue.Customer;
                        bug.BugResolution = bugvalue.BugResolution;
                        bug.Component = bugvalue.Component;
                        bug.Priority = bugvalue.Priority;
                        bug.Description = bugvalue.Description;
                        bug.Status = bugvalue.Status;
                        this.Save(this.Path());
                        return true;
                    }
                }
                return false;
            }
            public BugTracker FindBugById(int id)
            {
                foreach (BugTracker bug in this.BugTrackers)
                    if (bug.id == id)
                        return bug;
                BugTracker rtn = new BugTracker();
                rtn.id = -1;
                rtn.BugID = "Error";
                rtn.Reporter = "";
                rtn.Customer = "";
                rtn.BugResolution = "";
                rtn.Component = "";
                rtn.Priority = "";
                rtn.Description = "NA";
                rtn.Status = "";
                return rtn;
            }
            public bool Fill(string path)
            {
                try
                {
                    XDocument doc = XDocument.Load(path);
                    var q = from bugtrack in doc.Elements("bugtrackers").Elements("bugtracker") select bugtrack;
                    foreach (var elem in q)
                    {
                        BugTracker bug = new BugTracker();
                        bug.BugID = elem.Element("bugID").Value;
                        int bugint = Convert.ToInt32(bug.BugID);
                        bug.Reporter = elem.Element("reporter").Value;
                        bug.Customer = elem.Element("customer").Value;
                        bug.BugResolution = elem.Element("bugresolution").Value;
                        bug.Component = elem.Element("component").Value;
                        bug.Priority = elem.Element("priority").Value;
                        bug.Description = elem.Element("description").Value;
                        bug.Status = elem.Element("status").Value;
                        BugTrackers.Add(bug);
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
                    XElement elm = new XElement("bugtrackers");
                    foreach (BugTracker bug in this.BugTrackers)
                    {
                        XElement bugtracker = new XElement("bugtracker");
                        XElement bugID = new XElement("bugID");
                        bugID.Value = bug.BugID;

                        XElement reporter = new XElement("reporter");
                        reporter.Value = bug.Reporter;
                        XElement customer = new XElement("customer");
                        customer.Value = bug.Customer;
                        XElement bugresolution = new XElement("bugresolution");
                        bugresolution.Value = bug.BugResolution;
                        XElement component = new XElement("component");
                        component.Value = bug.Component;
                        XElement priority = new XElement("priority");
                        priority.Value = bug.Priority;
                        XElement description = new XElement("description");
                        XElement status = new XElement("status");
                        status.Value = bug.Status;
                        description.Value = bug.Description;
                        bugtracker.Add(bugID);
                        bugtracker.Add(reporter);
                        bugtracker.Add(customer);
                        bugtracker.Add(bugresolution);
                        bugtracker.Add(component);
                        bugtracker.Add(priority);
                        bugtracker.Add(description);
                        bugtracker.Add(status);

                        elm.Add(bugtracker);
                    }
                    doc.Add(elm);
                    doc.Save(path);
                }
                catch { return false; }
                return true;
            }
        }
    }
