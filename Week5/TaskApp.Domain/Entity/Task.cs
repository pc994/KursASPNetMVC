using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TaskApp.Domain.Entity
{
    public class Task
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Description")]
        public string Description { get; set; }
        [XmlElement("CategoryId")]
        public int CategoryId { get; set; }
        [XmlElement("CategoryName")]
        public string CategoryName { get; set; }
        [XmlElement("StatusId")]
        public int StatusId { get; set; }
        [XmlElement("StatusName")]
        public string StatusName { get; set; }
        [XmlElement("PriorityId")]
        public int PriorityId { get; set; }
        [XmlElement("PriorityName")]
        public string PriorityName { get; set; }
        public Task()
        {
            
        }
        public Task(int id, string name, string description, int categoryId, string categoryName, int statusId, string statusName, int priorityId, string priorityName)
        {
            Id = id;
            Name = name;
            Description = description;
            CategoryId = categoryId;
            CategoryName = categoryName;
            StatusId = 1;
            StatusName = "New";
            PriorityId = priorityId;
            PriorityName = priorityName;
        }
    }
}
