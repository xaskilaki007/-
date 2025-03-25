using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursovaya
{
    public partial class LoginInDataBase : Form
    {
        private int currentUserId; // Идентификатор текущего пользователя

        public LoginInDataBase()
        {
            InitializeComponent();

            this.passField.AutoSize = false;
            this.passField.Size = new Size(this.passField.Size.Width, this.LoginField.Size.Height);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Point lastPoint;
        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void MainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void TopMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void TopMain_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            String loginUser = LoginField.Text;
            String passUser = passField.Text;

            DataBase db = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `Пользователи` WHERE `Логин` = @uL AND `Пароль` = @uP", db.getConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                // Получаем идентификатор пользователя
                currentUserId = Convert.ToInt32(table.Rows[0]["id"]);
                Console.WriteLine($"Current User ID: {currentUserId}"); // Вывод в консоль

                this.Hide();
                ViewDataBase mainForm = new ViewDataBase(currentUserId);
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Авторизация не пройдена");
            }
        }


        private void LoginField_TextChanged(object sender, EventArgs e)
        {

        }

        private void passField_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterInDataBase registerForm = new RegisterInDataBase();
            registerForm.Show();
        }
    }
}
