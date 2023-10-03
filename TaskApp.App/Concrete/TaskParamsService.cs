using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.App.Abstract;
using TaskApp.App.Common;
using TaskApp.Domain.Entity;

namespace TaskApp.App.Concrete
{
    public class TaskParamsService : BaseTaskParamsService<TaskParameters>
    {
        public List<TaskParameters> Parameters { get ; set;}

        public TaskParamsService()
        {
            Parameters = new List<TaskParameters>();
            AddParameters();
        }
        public void AddParameter(TaskParameters param)
        {
            Parameters.Add(param);
        }
        public void AddParameters()
        {
            AddParameter(new TaskParameters(1, 1, "Software problem", "Category"));
            AddParameter(new TaskParameters(2, 1, "Hardware problem", "Category"));
            AddParameter(new TaskParameters(3, 1, "Other problem", "Category"));

            AddParameter(new TaskParameters(1, 2, "New", "Status"));
            AddParameter(new TaskParameters(2, 2, "In progress", "Status"));
            AddParameter(new TaskParameters(3, 2, "Finished", "Status"));
            AddParameter(new TaskParameters(4, 2, "Suspensed", "Status"));

            AddParameter(new TaskParameters(1, 3, "Low", "Priority"));
            AddParameter(new TaskParameters(2, 3, "Normal", "Priority"));
            AddParameter(new TaskParameters(3, 3, "High", "Priority"));
            AddParameter(new TaskParameters(4, 3, "Immediate", "Priority"));
        }

        public List<TaskParameters> GetParametersByTypeName(string paramId)
        {
            var parameters = Parameters.Where(p=>p.TypeName  == paramId);
            return parameters.ToList();
        }
    }
}
