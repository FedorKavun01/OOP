using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    [Serializable]
    class Group
    {
        public string name;
        public List<Student> students; 

        public Group(string name)
        {
            this.name = name;
        }
    }
}
