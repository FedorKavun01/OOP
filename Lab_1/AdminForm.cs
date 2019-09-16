using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Lab_1
{
    public partial class AdminForm : Form
    {
        Thread thread;
        List<Student> students = new List<Student>();
        int[] marks = new int[3];
        int index;
        bool edit;

        public AdminForm()
        {
            InitializeComponent();
            updateAll();
            comboBoxSearch.SelectedIndex = 0;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(edit)
                    students.RemoveAt(index);

                marks[0] = Convert.ToInt32(textBoxOOP.Text);
                marks[1] = Convert.ToInt32(textBoxTA.Text);
                marks[2] = Convert.ToInt32(textBoxDS.Text);

                if (textBoxName.Text != "" && textBoxLastName.Text != "" && comboBoxGroup.SelectedIndex > 0 && markCheck(marks[0]) && markCheck(marks[1]) && markCheck(marks[2]))
                {
                    students.Add(new Student(textBoxName.Text, textBoxLastName.Text, comboBoxGroup.SelectedIndex, marks));
                    updateAll();
                }
                else
                {
                    throw new Exception();
                }

            } catch(Exception)
            {
                MessageBox.Show("Некоректні дані", "Помилка :(");
            }
        }

        private void buttonNotEdit_Click(object sender, EventArgs e)
        {
            updateAll();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            students.RemoveAt(index);
            updateAll();
        }

        private void pictureBoxSearch_Click(object sender, EventArgs e)
        {
            //короч це ще не готово 

            switch(comboBoxSearch.SelectedIndex)
            {
                case 0:
                    //textBoxSearch.Text;
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }

        bool markCheck(int mark)
        {
            if (mark >= 0 && mark <= 100)
                return true;
            else
                return false;
        }

        void updateAll()
        {
            addToListBox();
            textBoxName.Clear();
            textBoxLastName.Clear();
            comboBoxGroup.SelectedIndex = 0;
            textBoxOOP.Clear();
            textBoxTA.Clear();
            textBoxDS.Clear();

            buttonRemove.Enabled = false;
            edit = false;
            buttonNotEdit.Enabled = false;
        }

        void addToListBox()
        {
            listBoxStudents.Items.Clear();

            foreach(Student el in students)
            {
                listBoxStudents.Items.Add(el.fullName);
            }
        }

        private void listBoxStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxStudents.SelectedIndex >= 0)
            {
                index = indexStudent(listBoxStudents.SelectedItem.ToString());

                textBoxName.Text = students[index].firstName;
                textBoxLastName.Text = students[index].lastName;
                comboBoxGroup.SelectedIndex = students[index].groupIndex;
                textBoxOOP.Text = students[index].mark0.ToString();
                textBoxTA.Text = students[index].mark1.ToString();
                textBoxDS.Text = students[index].mark2.ToString();

                buttonRemove.Enabled = true;
                edit = true;
                buttonNotEdit.Enabled = true;
            }
        }

        int indexStudent(string fullName)
        {
            foreach(Student el in students)
            {
                if (el.fullName == fullName)
                    return students.IndexOf(el);
            }
            return -1;
        }

        private void Open(object obj)
        {
            Application.Run(new FormSignIn());
        }

        private void pictureBoxBack_Click(object sender, EventArgs e)
        {
            this.Close();
            thread = new Thread(Open);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}
