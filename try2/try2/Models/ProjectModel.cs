


using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using System.IO;

namespace try2.Models
{
    public class Project
    {
        public int id { get; set; }

        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Topic { get; set; }
        public DateTime Date { get; set; }
        public string TextBlock { get; set; }
    }
    public class ProjectModel
    {
        public List<Project> Projects { get; set; }

        public ProjectModel()
        {
            int count = 0;
            Projects = new List<Project>();
            bool test = Fill(Path());
             
            foreach (Project proj in Projects)
            {
                proj.id = count++;
              
            }
        }



        public string Path()
        {
            return HttpContext.Current.Server.MapPath("~\\App_Data\\XmlProjectModel.xml"); //+ id.ToString()+ ".xml");
        }


        public void Add(Project proj)
        {
            Projects.Add(proj);
            Save(Path());
        }



        public bool Remove(Project gone)
        {
            int count = 0;
            foreach (Project proj in this.Projects)
            {
                if (gone.id == proj.id)
                {
                    this.Projects.RemoveAt(count);
                    break;
                }
                ++count;
            }
            if (count < Projects.Count + 1)
            {
                this.Save(this.Path());
                return true;
            }
            return false;
        }



        public bool Edit(Project project)
        {
            foreach (Project proj in this.Projects)
            {
                if (project.id == proj.id)
                {
                    proj.CustomerName = project.CustomerName;
                    proj.Address = project.Address;
                    proj.Topic = project.Topic;
                    proj.Date = project.Date;
                    proj.TextBlock = project.TextBlock;
                    this.Save(this.Path());
                    return true;
                }
            }
            return false;
        }
        public Project FindProjectById(int id)
        {
            foreach (Project proj in this.Projects)
                if (proj.id == id)
                    return proj;
            Project rtn = new Project();
            rtn.id = -1;
            rtn.CustomerName = "NA";
            rtn.Address = "NA";
            rtn.Topic = "NA";
            rtn.Date = DateTime.MaxValue;
            rtn.TextBlock = "NA";
            return rtn;
        }


        public bool Fill(string path)
        {
            try
            {
                XDocument doc = XDocument.Load(path);
                var seq = from proj in doc.Elements("projects").Elements("project") select proj;
                foreach (var elem in seq)
                {
                    Project proj = new Project();

                    proj.CustomerName = elem.Element("customername").Value;
                    proj.Address = elem.Element("address").Value;
                    proj.Topic = elem.Element("topic").Value;

                    string datestring = elem.Element("date").Value;
                    DateTime dt = Convert.ToDateTime(datestring);
                    proj.Date = dt;

                    proj.TextBlock = elem.Element("textblock").Value;
                    Projects.Add(proj);
                }
            }
            catch { return false; }
            return true;
        }

        public bool ReqModel(string path)
        {
            try
            {
                XDocument doc = new XDocument();
                XElement elm = new XElement("projects");
                foreach (Project proj in this.Projects)
                {
                    XElement project = new XElement("project");
                    XElement customername = new XElement("customername");
                    customername.Value = proj.CustomerName;
                    project.Add(customername);
                    XElement address = new XElement("address");
                    address.Value = proj.Address;
                    project.Add(address);
                    XElement topic = new XElement("topic");
                    topic.Value = proj.Topic;
                    project.Add(topic);
                    XElement date = new XElement("date");
                    string datestring = proj.Date.ToLongDateString();
                    date.Value = datestring;
                    project.Add(date);
                    
                    XElement textblock = new XElement("textblock");
                    textblock.Value = proj.TextBlock;
                    project.Add(textblock);

                    elm.Add(project);
                }
                doc.Add(elm);
                doc.Save(path);
            }
            catch { return false; }
            return true;
        }







        public bool Save(string path)
        {
            try
            {
                XDocument doc = new XDocument();
                XElement elm = new XElement("projects");
                foreach (Project proj in this.Projects)
                {
                    XElement project = new XElement("project");
                    XElement customername = new XElement("customername");
                    customername.Value = proj.CustomerName;
                    project.Add(customername);
                    XElement address = new XElement("address");
                    address.Value = proj.Address;
                    project.Add(address);
                    XElement topic = new XElement("topic");
                    topic.Value = proj.Topic;
                    project.Add(topic);
                    XElement date = new XElement("date");
                    string datestring = proj.Date.ToLongDateString();
                    date.Value = datestring;
                    project.Add(date);
                    
                    XElement textblock = new XElement("textblock");
                    textblock.Value = proj.TextBlock;
                    project.Add(textblock);

                    elm.Add(project);
                }
                doc.Add(elm);
                doc.Save(path);
            }
            catch { return false; }
            return true;
        }

      
    }
}