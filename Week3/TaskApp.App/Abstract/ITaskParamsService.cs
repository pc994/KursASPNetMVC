using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.App.Abstract
{
    public interface ITaskParamsService<T>  
    {
        List<T> Parameters { get; set; }
        void AddParameter(T param);
        List<T> GetParametersByTypeName(string paramId);
    }
}
