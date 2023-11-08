using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TaskApp.Domain.Entity
{
    public class MenuAction
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("MenuName")]
        public string MenuName { get; set; }

        public MenuAction()
        {
                
        }
        public MenuAction(int id, string name, string menuName)
        {
            Id = id;
            Name = name;
            MenuName = menuName;
        }
    }
}
