using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Domain.Entity
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public int PriorityId { get; set; }
        public string PriorityName { get; set; }

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
