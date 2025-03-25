namespace kursovaya
{
    partial class RegisterInDataBase
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
            this.registerLabel = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.PassField = new System.Windows.Forms.TextBox();
            this.LoginField = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TopMain = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.Blue;
            this.MainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MainPanel.Controls.Add(this.label2);
            this.MainPanel.Controls.Add(this.label1);
            this.MainPanel.Controls.Add(this.registerLabel);
            this.MainPanel.Controls.Add(this.buttonLogin);
            this.MainPanel.Controls.Add(this.PassField);
            this.MainPanel.Controls.Add(this.LoginField);
            this.MainPanel.Controls.Add(this.panel2);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(926, 556);
            this.MainPanel.TabIndex = 1;
            this.MainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopMain_MouseDown);
            this.MainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPanel_MouseMove);
            // 
            // registerLabel
            // 
            this.registerLabel.AutoSize = true;
            this.registerLabel.BackColor = System.Drawing.Color.Blue;
            this.registerLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registerLabel.ForeColor = System.Drawing.Color.White;
            this.registerLabel.Location = new System.Drawing.Point(664, 461);
            this.registerLabel.Name = "registerLabel";
            this.registerLabel.Size = new System.Drawing.Size(152, 16);
            this.registerLabel.TabIndex = 8;
            this.registerLabel.Text = "Уже зарегистрирован";
            this.registerLabel.Click += new System.EventHandler(this.registerLabel_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonLogin.FlatAppearance.BorderSize = 0;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Location = new System.Drawing.Point(322, 439);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(320, 70);
            this.buttonLogin.TabIndex = 5;
            this.buttonLogin.Text = "Зарегистрироваться";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // PassField
            // 
            this.PassField.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PassField.Location = new System.Drawing.Point(583, 331);
            this.PassField.Name = "PassField";
            this.PassField.Size = new System.Drawing.Size(279, 34);
            this.PassField.TabIndex = 4;
            this.PassField.Enter += new System.EventHandler(this.userPassField_Enter);
            this.PassField.Leave += new System.EventHandler(this.userPassField_Leave);
            // 
            // LoginField
            // 
            this.LoginField.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginField.Location = new System.Drawing.Point(115, 331);
            this.LoginField.Multiline = true;
            this.LoginField.Name = "LoginField";
            this.LoginField.Size = new System.Drawing.Size(279, 64);
            this.LoginField.TabIndex = 2;
            this.LoginField.Enter += new System.EventHandler(this.userLoginField_Enter);
            this.LoginField.Leave += new System.EventHandler(this.userLoginField_Leave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(163)))), ((int)(((byte)(194)))));
            this.panel2.Controls.Add(this.TopMain);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(926, 145);
            this.panel2.TabIndex = 0;
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
            this.TopMain.Size = new System.Drawing.Size(926, 145);
            this.TopMain.TabIndex = 0;
            this.TopMain.Text = "Регистрация";
            this.TopMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TopMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopMain_MouseDown);
            this.TopMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopMain_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(203, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 32);
            this.label1.TabIndex = 9;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(670, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 32);
            this.label2.TabIndex = 10;
            this.label2.Text = "Пароль";
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 556);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox LoginField;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label TopMain;
        public System.Windows.Forms.TextBox PassField;
        private System.Windows.Forms.Label registerLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}