using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace kursovaya
{
    public partial class ViewDataBase : Form
    {
        private DataTable dataTable; // Данные таблицы
        private string currentTableName; // Имя текущей таблицы
        private int currentUserId; // ID текущего пользователя
        private List<string> tableNames; // Список имен таблиц

        public ViewDataBase(int userId)
        {
            InitializeComponent();
            this.currentUserId = userId;
            dataGridView1.Hide();
            back.Hide();
            remove.Hide();
            add.Hide();
            edit.Hide();
            filter.Hide(); // Скрываем ComboBox фильтра
            this.Load += MainForm_Load;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ForeColor = Color.Black;

            // Подписка на событие изменения выбранного элемента в ComboBox
            filter.SelectedIndexChanged += filter_SelectedIndexChanged;
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

        private void LoadTableData()
        {
            string userRole = GetUserRole(currentUserId);
            tableNames = GetTablesForUser(userRole);
            DisplayTablesInListBox(tableNames);
        }

        private List<string> GetTablesForUser(string userRole)
        {
            List<string> tableNames = new List<string>();
            DataBase db = new DataBase();

            using (MySqlCommand command = new MySqlCommand("SHOW FULL TABLES;", db.getConnection()))
            {
                try
                {
                    db.openConnection();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tableName = reader[0].ToString();
                            string tableType = reader[1].ToString();
                            if (tableType == "BASE TABLE")
                            {
                                if (tableName == "Пользователи" && userRole != "Администратор")
                                {
                                    continue;
                                }
                                tableNames.Add(tableName);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
                finally
                {
                    db.closeConnection();
                }
            }

            return tableNames;
        }

        private void DisplayTablesInListBox(List<string> tables)
        {
            tablesListBox.Items.Clear();
            foreach (var table in tables)
            {
                tablesListBox.Items.Add(table);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadTableData();
        }

        private void tablesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataBase db = new DataBase();

            using (MySqlCommand command = new MySqlCommand("SELECT Роль FROM Пользователи WHERE id = @id;", db.getConnection()))
            {
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = currentUserId;
                db.openConnection();
                var role = command.ExecuteScalar();
                db.closeConnection();

                if (tablesListBox.SelectedItem != null)
                {
                    string selectedTable = tablesListBox.SelectedItem.ToString();
                    currentTableName = selectedTable;

                    labelInfo.Text = $"Таблица: {currentTableName}";
                    labelInfo.Show();
                    tablesListBox.Hide();
                    dataGridView1.Show();
                    back.Show();
                    filter.Show();

                    UpdateButtonVisibility(role);
                    DisplayTableContents(selectedTable);
                }
            }
        }

        private void UpdateButtonVisibility(object role)
        {
            if (role != null && role.ToString() == "Администратор")
            {
                edit.Show();
                remove.Show();
                add.Show();
            }
            else
            {
                edit.Hide();
                remove.Hide();
                add.Hide();
            }
        }

        private void backLabel_Click(object sender, EventArgs e)
        {
            // Скрытие всех элементов управления
            dataGridView1.Hide();
            back.Hide();
            edit.Hide();
            remove.Hide();
            add.Hide();
            filter.Hide(); // Скрываем ComboBox
            tablesListBox.Show();
            labelInfo.Hide();

            // Очищаем ComboBox фильтров
            filter.Items.Clear();
            filter.SelectedIndex = -1; // Сбрасываем выбор в ComboBox

            // Вывод информации и возврат к содержимому таблицы
            DisplayTableContents(currentTableName);
        }



        private void redactionButton_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();

            foreach (DataRow row in dataTable.Rows)
            {
                if (row.RowState == DataRowState.Modified)
                {
                    string updateQuery = CreateUpdateQuery(row);
                    if (!string.IsNullOrEmpty(updateQuery))
                    {
                        using (MySqlCommand command = new MySqlCommand(updateQuery, db.getConnection()))
                        {
                            try
                            {
                                db.openConnection();
                                command.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Ошибка: {ex.Message}");
                            }
                            finally
                            {
                                db.closeConnection();
                            }
                        }
                    }
                }
            }
            MessageBox.Show("Изменения успешно сохранены.");
        }

        private string CreateUpdateQuery(DataRow row)
        {
            List<string> updates = new List<string>();
            foreach (DataColumn column in dataTable.Columns)
            {
                if (column.ColumnName.ToLower().Contains("id"))
                {
                    continue;
                }

                var currentValue = row[column, DataRowVersion.Current];
                var originalValue = row[column, DataRowVersion.Original];

                if (currentValue == DBNull.Value && column.AllowDBNull == false)
                {
                    MessageBox.Show($"Поле {column.ColumnName} не может быть пустым.");
                    return string.Empty;
                }

                if (!currentValue.Equals(originalValue))
                {
                    string formattedValue = ConvertValue(column, currentValue);
                    updates.Add($"{column.ColumnName} = '{formattedValue}'");
                }
            }

            if (updates.Count > 0)
            {
                string primaryKeyColumn = GetPrimaryKeyColumnName();
                return $"UPDATE {currentTableName} SET {string.Join(", ", updates)} WHERE {primaryKeyColumn} = '{row[primaryKeyColumn]}';";
            }

            return string.Empty;
        }

        private string GetPrimaryKeyColumnName()
        {
            foreach (DataColumn column in dataTable.Columns)
            {
                if (column.ColumnName.ToLower().Contains("id"))
                {
                    return column.ColumnName;
                }
            }
            throw new Exception("Первичный ключ не найден в таблице.");
        }

        private string ConvertValue(DataColumn column, object value)
        {
            string formattedValue = value.ToString();
            if (column.DataType == typeof(double) || column.DataType == typeof(decimal))
            {
                return Convert.ToDouble(value).ToString(CultureInfo.InvariantCulture);
            }
            else if (column.DataType == typeof(DateTime))
            {
                return Convert.ToDateTime(value).ToString("yyyy-MM-dd");
            }
            return formattedValue;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string primaryKeyColumn = GetPrimaryKeyColumnName();

                string primaryKeyValue = selectedRow.Cells[primaryKeyColumn].Value.ToString();
                string deleteQuery = $"DELETE FROM {currentTableName} WHERE {primaryKeyColumn} = {primaryKeyValue};";

                DataBase db = new DataBase();

                using (MySqlCommand command = new MySqlCommand(deleteQuery, db.getConnection()))
                {
                    try
                    {
                        db.openConnection();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Запись успешно удалена.");
                        DisplayTableContents(currentTableName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}");
                    }
                    finally
                    {
                        db.closeConnection();
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку для удаления.");
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            DataRow newRow = dataTable.NewRow();

            foreach (DataColumn column in dataTable.Columns)
            {
                if (column.ColumnName.ToLower() == "id")
                {
                    continue;
                }
                newRow[column.ColumnName] = PromptForValue(column.ColumnName, column.DataType);
            }

            int newPrimaryKey = GeneratePrimaryKey(db);
            newRow["id"] = newPrimaryKey;
            dataTable.Rows.Add(newRow);

            string insertQuery = CreateInsertQuery(newRow);

            using (MySqlCommand command = new MySqlCommand(insertQuery, db.getConnection()))
            {
                try
                {
                    db.openConnection();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно добавлена.");
                    DisplayTableContents(currentTableName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
                finally
                {
                    db.closeConnection();
                }
            }
        }

        private string CreateInsertQuery(DataRow newRow)
        {
            string insertQuery = $"INSERT INTO {currentTableName} (";

            foreach (DataColumn column in dataTable.Columns)
            {
                insertQuery += $"{column.ColumnName}, ";
            }

            insertQuery = insertQuery.TrimEnd(',', ' ');
            insertQuery += ") VALUES (";

            foreach (DataColumn column in dataTable.Columns)
            {
                string value = newRow[column.ColumnName].ToString().Replace("'", "''");
                if (column.DataType == typeof(decimal) || column.DataType == typeof(double) || column.DataType == typeof(float))
                {
                    value = Convert.ToDecimal(newRow[column.ColumnName]).ToString(CultureInfo.InvariantCulture);
                }
                else if (column.DataType == typeof(DateTime))
                {
                    value = Convert.ToDateTime(newRow[column.ColumnName]).ToString("yyyy-MM-dd");
                }
                insertQuery += $"'{value}', ";
            }
            insertQuery = insertQuery.TrimEnd(',', ' ');
            insertQuery += ");";

            return insertQuery;
        }

        private int GeneratePrimaryKey(DataBase db)
        {
            int newPrimaryKey;

            using (MySqlCommand command = new MySqlCommand($"SELECT MAX(id) FROM {currentTableName}", db.getConnection()))
            {
                db.openConnection();
                object result = command.ExecuteScalar();
                db.closeConnection();

                newPrimaryKey = result != DBNull.Value ? Convert.ToInt32(result) + 1 : 1;
            }

            return newPrimaryKey;
        }

        private object PromptForValue(string columnName, Type columnType)
        {
            while (true)
            {
                string promptValue = Prompt.ShowDialog($"Введите значение для столбца '{columnName}':", "Введите значение");

                try
                {
                    if (columnType == typeof(int))
                    {
                        return int.Parse(promptValue);
                    }
                    else if (columnType == typeof(decimal) || columnType == typeof(double) || columnType == typeof(float))
                    {
                        return decimal.Parse(promptValue, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
                    }
                    else if (columnType == typeof(DateTime))
                    {
                        return DateTime.Parse(promptValue);
                    }
                    else
                    {
                        return promptValue;
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show($"Значение для столбца '{columnName}' имеет неверный формат. Попробуйте снова.");
                }
            }
        }

        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 400, // Измененный размер
                    Height = 170, // Измененный размер
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen,
                    BackColor = Color.LightBlue // Цвет фона формы
                };

                Label textLabel = new Label()
                {
                    Left = 20,
                    Top = 20,
                    Width = 360,
                    Text = text,
                    ForeColor = Color.DarkBlue // Цвет текста метки
                };
                TextBox inputBox = new TextBox()
                {
                    Left = 20,
                    Top = 50,
                    Width = 360,
                    BackColor = Color.White, // Цвет фона текстового поля
                    ForeColor = Color.Black // Цвет текста текстового поля
                };
                Button confirmation = new Button()
                {
                    Text = "ОК",
                    Left = 300,
                    Width = 80,
                    Top = 90,
                    DialogResult = DialogResult.OK,
                    BackColor = Color.LightGreen, // Цвет фона кнопки
                    ForeColor = Color.Black // Цвет текста кнопки
                };

                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(inputBox);
                prompt.Controls.Add(confirmation);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : string.Empty;
            }
        }


        private void DisplayTableContents(string tableName)
        {
            DataBase db = new DataBase();
            string query = $"SELECT * FROM {tableName}";

            using (MySqlCommand command = new MySqlCommand(query, db.getConnection()))
            {
                try
                {
                    db.openConnection();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;

                    // Заполняем ComboBox названиями столбцов
                    filter.Items.Clear();
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        filter.Items.Add(column.ColumnName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
                finally
                {
                    db.closeConnection();
                }
            }
        }

        private void filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter.SelectedItem != null)
            {
                string selectedColumn = filter.SelectedItem.ToString();
                DataView dv = new DataView(dataTable);
                dv.Sort = selectedColumn; // Сортировка по выбранному полю
                dataGridView1.DataSource = dv; // Устанавливаем отсортированные данные в grid
            }
        }

        private string GetUserRole(int userId)
        {
            string role = null;
            DataBase db = new DataBase();

            using (MySqlCommand command = new MySqlCommand("SELECT Роль FROM Пользователи WHERE id = @id;", db.getConnection()))
            {
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = userId;

                db.openConnection();
                role = command.ExecuteScalar()?.ToString();
                db.closeConnection();
            }

            return role;
        }
    }
}
