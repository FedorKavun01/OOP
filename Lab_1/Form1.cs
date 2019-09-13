using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{
    public partial class FormSignIn : Form
    {
        String loginAdmin = "admin";
        String passwordAdmin = "admin";
        String loginUser = "user";
        String passwordUser = "user";

        Thread thread;
        bool admin = false;

        public FormSignIn()
        {
            InitializeComponent();
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == loginAdmin && textBoxPassword.Text == passwordAdmin)
            {
                admin = true;                
            }
            else if (textBoxLogin.Text != loginUser && textBoxPassword.Text != passwordUser)
            {
                textBoxLogin.Clear();
                textBoxPassword.Clear();
                MessageBox.Show("Incorrect login or password :(", "Error");
                return;
            }
            Close();
            thread = new Thread(Open);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void Open()
        {
            if(admin)
                Application.Run(new AdminForm());
            else
                Application.Run(new UserForm());
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !textBoxPassword.UseSystemPasswordChar;

            if (textBoxPassword.UseSystemPasswordChar)
                pictureBox.Image = Properties.Resources.not_show;
            else
                pictureBox.Image = Properties.Resources.show1;
        }
    }
}
