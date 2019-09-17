using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    [Serializable]
    class Student
    {
        public string firstName;
        public string lastName;
        public string fullName { get; set; }
        public Group group;
        public int[] marks;

        public Student(string firstName, string lastName, Group group, int[] marks)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.fullName = firstName + " " + lastName;
            this.group = group;
            this.marks = new int[3];
            this.marks[0] = marks[0];
            this.marks[1] = marks[1];
            this.marks[2] = marks[2];
        }

        public Student()
        {
            firstName = "Новий";
            lastName = "Студент";
            group = DBController.groups[0]; 
            marks = new int[] { 0, 0, 0 };
        }
    }
}
