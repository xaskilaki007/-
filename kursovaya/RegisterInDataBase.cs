using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
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
    public partial class RegisterInDataBase : Form
    {
        public RegisterInDataBase()
        {
            InitializeComponent();

            LoginField.Text = "Введите логин";
            LoginField.ForeColor = Color.Gray;
            PassField.Text = "Введите пароль";
            PassField.ForeColor = Color.Gray;


            this.PassField.AutoSize = false;
            this.PassField.Size = new Size(this.PassField.Size.Width, this.LoginField.Size.Height);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        Point lastPoint;
        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
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

        private void userLoginField_Enter(object sender, EventArgs e)
        {
            if (LoginField.Text == "Введите логин")
            {
                LoginField.Text = "";
                LoginField.ForeColor = Color.Black;
            }
        }

        private void userLoginField_Leave(object sender, EventArgs e)
        {
            if (LoginField.Text == "")
            {
                LoginField.Text = "Введите логин";
                LoginField.ForeColor = Color.Gray;
            }
        }

        private void userPassField_Enter(object sender, EventArgs e)
        {
            if (PassField.Text == "Введите пароль")
            {
                PassField.Text = "";
                PassField.ForeColor = Color.Black;
            }
        }

        private void userPassField_Leave(object sender, EventArgs e)
        {
            if (PassField.Text == "")
            {
                PassField.Text = "Введите пароль";
                PassField.ForeColor = Color.Gray;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (LoginField.Text == "Введите логин" || PassField.Text == "Введите пароль")
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }

            if (isUserExists())
            {
                return;
            }

            DataBase db = new DataBase();
            MySqlCommand command = new MySqlCommand("INSERT INTO `Пользователи` (`Логин`, `Пароль`, `Роль`) VALUES (@login, @pass, 'Гость');", db.getConnection());

            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = LoginField.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = PassField.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Вы зарегистрированы");
            }
            else
            {
                MessageBox.Show("Ошибка регистрации, повторите попытку ещё раз");
            }

            db.closeConnection();
        }


        public Boolean isUserExists()
        {
            DataBase db = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `Пользователи` WHERE `Логин` = @uL", db.getConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = LoginField.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой логин уже есть, введите другой");
                return true;

            }
            else
            {
                return false;
            }
        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginInDataBase loginForm = new LoginInDataBase();
            loginForm.Show();
        }

        private void userNameField_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
