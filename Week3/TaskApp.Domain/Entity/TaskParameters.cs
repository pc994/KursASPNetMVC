using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Domain.Entity
{
    public class TaskParameters
    {
        public int Id { get; set; }
        public int IdentityParamId { get; set; }
        public string Name { get; set; }
        public string TypeName { get; set; }

        public TaskParameters(int id, int identityParamId, string name, string typeName)
        {
            Id = id;
            IdentityParamId = identityParamId;
            Name = name;
            TypeName = typeName;
        }
    }
}
