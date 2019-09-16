using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class Student
    {
        public string firstName;
        public string lastName;
        public string fullName;
        public Group group;
        private uint[] marks = new uint[3];

        public Student(string firstName,string lastName, Group group, uint[] marks)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.fullName = firstName + " " + lastName;
            this.group = group;
            group.students.Add(this);
            this.marks = marks;
        }
    }
}
