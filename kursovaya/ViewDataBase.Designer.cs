namespace kursovaya
{
    partial class ViewDataBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPanel = new System.Windows.Forms.Panel();
            this.filter = new System.Windows.Forms.ComboBox();
            this.remove = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.edit = new System.Windows.Forms.Button();
            this.tablesListBox = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.back = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.TopMain = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.Blue;
            this.MainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MainPanel.Controls.Add(this.filter);
            this.MainPanel.Controls.Add(this.remove);
            this.MainPanel.Controls.Add(this.add);
            this.MainPanel.Controls.Add(this.dataGridView1);
            this.MainPanel.Controls.Add(this.edit);
            this.MainPanel.Controls.Add(this.tablesListBox);
            this.MainPanel.Controls.Add(this.panel2);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.ForeColor = System.Drawing.Color.White;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1136, 651);
            this.MainPanel.TabIndex = 1;
            // 
            // filter
            // 
            this.filter.BackColor = System.Drawing.Color.DodgerBlue;
            this.filter.FormattingEnabled = true;
            this.filter.Location = new System.Drawing.Point(4, 275);
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(192, 24);
            this.filter.TabIndex = 6;
            // 
            // remove
            // 
            this.remove.BackColor = System.Drawing.Color.DodgerBlue;
            this.remove.ForeColor = System.Drawing.Color.White;
            this.remove.Location = new System.Drawing.Point(0, 233);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(201, 35);
            this.remove.TabIndex = 4;
            this.remove.Text = "Удалить";
            this.remove.UseVisualStyleBackColor = false;
            this.remove.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.Color.DodgerBlue;
            this.add.ForeColor = System.Drawing.Color.White;
            this.add.Location = new System.Drawing.Point(0, 192);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(201, 35);
            this.add.TabIndex = 5;
            this.add.Text = "Добавить";
            this.add.UseVisualStyleBackColor = false;
            this.add.Click += new System.EventHandler(this.addButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(202, 148);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(934, 500);
            this.dataGridView1.TabIndex = 2;
            // 
            // edit
            // 
            this.edit.BackColor = System.Drawing.Color.DodgerBlue;
            this.edit.ForeColor = System.Drawing.Color.White;
            this.edit.Location = new System.Drawing.Point(0, 151);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(201, 35);
            this.edit.TabIndex = 3;
            this.edit.Text = "Редактировать";
            this.edit.UseVisualStyleBackColor = false;
            this.edit.Click += new System.EventHandler(this.redactionButton_Click);
            // 
            // tablesListBox
            // 
            this.tablesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablesListBox.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablesListBox.FormattingEnabled = true;
            this.tablesListBox.ItemHeight = 38;
            this.tablesListBox.Location = new System.Drawing.Point(202, 148);
            this.tablesListBox.Name = "tablesListBox";
            this.tablesListBox.Size = new System.Drawing.Size(931, 460);
            this.tablesListBox.TabIndex = 1;
            this.tablesListBox.SelectedIndexChanged += new System.EventHandler(this.tablesListBox_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(163)))), ((int)(((byte)(194)))));
            this.panel2.Controls.Add(this.back);
            this.panel2.Controls.Add(this.labelInfo);
            this.panel2.Controls.Add(this.TopMain);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1136, 145);
            this.panel2.TabIndex = 0;
            // 
            // back
            // 
            this.back.AutoSize = true;
            this.back.BackColor = System.Drawing.Color.Blue;
            this.back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.back.Font = new System.Drawing.Font("Playbill", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.ForeColor = System.Drawing.Color.White;
            this.back.Location = new System.Drawing.Point(12, 9);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(86, 28);
            this.back.TabIndex = 2;
            this.back.Text = "Назад";
            this.back.Click += new System.EventHandler(this.backLabel_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.BackColor = System.Drawing.Color.Blue;
            this.labelInfo.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInfo.ForeColor = System.Drawing.Color.White;
            this.labelInfo.Location = new System.Drawing.Point(3, 103);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(1130, 32);
            this.labelInfo.TabIndex = 11;
            this.labelInfo.Text = "---------------------------------------------------------------------------------" +
    "-------------------------------------------";
            // 
            // TopMain
            // 
            this.TopMain.BackColor = System.Drawing.Color.Blue;
            this.TopMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.TopMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopMain.Font = new System.Drawing.Font("Playbill", 31.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopMain.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TopMain.Location = new System.Drawing.Point(0, 0);
            this.TopMain.Name = "TopMain";
            this.TopMain.Size = new System.Drawing.Size(1136, 145);
            this.TopMain.TabIndex = 0;
            this.TopMain.Text = "Пищевая промышленность";
            this.TopMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ViewDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 651);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ViewDataBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label TopMain;
        private System.Windows.Forms.ListBox tablesListBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label back;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.ComboBox filter;
    }
}