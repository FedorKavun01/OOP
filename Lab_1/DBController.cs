using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab_1
{
    class DBController
    {   
        public static List<Student> students;
        public static List<Group> groups = new List<Group>() { new Group("ІТ-82"), new Group("ІТ-84") };
        static string path_to_db_file = "db.bin";
        static BinaryFormatter bf = new BinaryFormatter();

        // --- Serialization and deserialization --- //
        public static void loadStudents()
        {
            if (File.Exists(path_to_db_file))
            {
                using (FileStream fileStream = new FileStream(path_to_db_file, FileMode.Open))
                {
                    students = (List<Student>)bf.Deserialize(fileStream);
                }
            }
            else
            {
                students = new List<Student>();
            }
        }

        static void saveStudents()
        {
            using (FileStream fileStream = new FileStream(path_to_db_file, FileMode.Create))
            {
                bf.Serialize(fileStream, students);
            }
        }
        // ---------------- //

        public static void createStudent(string firstName, string lastName, int groupIndex, int[] marks)
        {            
            students.Add(new Student(firstName, lastName, groups[groupIndex], marks));
            saveStudents();
        }

        public static void removeStudent(int index)
        {
            students.RemoveAt(index);
            saveStudents();
        }

        public static void editStudent(int index, string firstName, string lastName, int groupIndex, int[] marks)
        {
            students[index].firstName = firstName;
            students[index].lastName = lastName;
            students[index].fullName = firstName + " " + lastName;
            students[index].group = groups[groupIndex];
            students[index].marks = marks;
            saveStudents();
        }      
    }
}
