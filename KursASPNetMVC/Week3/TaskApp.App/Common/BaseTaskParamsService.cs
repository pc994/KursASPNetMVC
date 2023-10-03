using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.App.Abstract;
using TaskApp.Domain.Entity;

namespace TaskApp.App.Common
{
    public class BaseTaskParamsService<T> : ITaskParamsService<T> where T : TaskParameters
    {
        public List<T> Parameters { get; set ; }

        public void AddParameter(T param)
        {
            Parameters.Add(param);
        }

        public List<T> GetParametersByTypeName(string typeName)
        {
            var param = Parameters.Where(p=>p.TypeName == typeName).ToList();
            return param;
        }

    }
}
