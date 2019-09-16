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
        string path_to_db_file = "db.bin";
        BinaryFormatter bf = new BinaryFormatter();
        static List<Student> students;

        void loadStudents()
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
                MessageBox.Show("Файл бази даних не існує за вказаним шляхом: " + path_to_db_file);
            }
        }

        void createStudent(string firstName, string lastName, int group, int[] marks)
        {
            Student student = new Student(firstName, lastName, group, marks);
            students.Add(student);
        }

        void removeStudent(Student student)
        {
            students.Remove(student);
        }

        void editStudent(string firstName, string lastName, Group group, uint[] marks)
        {

        }
    }
}
