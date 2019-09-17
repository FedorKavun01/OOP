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
        int[] marks = new int[3];

        public AdminForm()
        {
            InitializeComponent();
            Init();            
        }

        void Init()
        {
            DBController.loadStudents();
            listBoxStudents.DisplayMember = "fullName";
            updateAll();
            comboBoxSearch.SelectedIndex = 0;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                marks[0] = Convert.ToInt32(textBoxOOP.Text);
                marks[1] = Convert.ToInt32(textBoxTA.Text);
                marks[2] = Convert.ToInt32(textBoxDS.Text);

                if (textBoxName.Text != "" && textBoxLastName.Text != "" && comboBoxGroup.SelectedIndex > 0 && markCheck(marks[0]) && markCheck(marks[1]) && markCheck(marks[2]))
                {
                    DBController.editStudent(listBoxStudents.SelectedIndex, textBoxName.Text, textBoxLastName.Text, comboBoxGroup.SelectedIndex, marks);
                }
                else
                {
                    throw new Exception();
                }
            } catch(Exception)
            {
                MessageBox.Show("Некоректні дані", "Помилка :(");
            }
            updateAll();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            DBController.removeStudent(listBoxStudents.SelectedIndex);
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
            listBoxStudents.DataSource = null;
            listBoxStudents.DataSource = DBController.students;
            listBoxStudents.DisplayMember = "fullName";
            textBoxName.Clear();
            textBoxLastName.Clear();
            comboBoxGroup.SelectedIndex = 0;
            textBoxOOP.Clear();
            textBoxTA.Clear();
            textBoxDS.Clear();
            buttonRemove.Enabled = false;
        }

        private void listBoxStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (listBoxStudents.SelectedIndex >= 0)
            {
                Student student = (Student)listBoxStudents.SelectedValue;
                textBoxName.Text = student.firstName;
                textBoxLastName.Text = student.lastName;
                comboBoxGroup.SelectedIndex = DBController.groups.IndexOf(student.group);
                textBoxOOP.Text = student.marks[0].ToString();
                textBoxTA.Text = student.marks[1].ToString();
                textBoxDS.Text = student.marks[2].ToString();

                buttonRemove.Enabled = true;
            }
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

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            marks[0] = Convert.ToInt32(textBoxOOP.Text);
            marks[1] = Convert.ToInt32(textBoxTA.Text);
            marks[2] = Convert.ToInt32(textBoxDS.Text);
            DBController.createStudent(textBoxName.Text, textBoxLastName.Text, comboBoxGroup.SelectedIndex, marks);
            updateAll();
        }
    }
}
