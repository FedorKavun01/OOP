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
        public int groupIndex;
        public int mark0, mark1, mark2;

        public Student(string firstName,string lastName, int groupIndex, int[] marks)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.fullName = firstName + " " + lastName;
            this.groupIndex = groupIndex;
            //this.groupIndex = groupIndex;
           // group.students.Add(this);
            mark0 = marks[0];
            mark1 = marks[1];
            mark2 = marks[2];
        }
    }
}
