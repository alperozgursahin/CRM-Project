namespace crm
{
    partial class LoginPage
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
            labelUsername = new Label();
            textUsername = new TextBox();
            labelPassword = new Label();
            textPassword = new TextBox();
            labelUserType = new Label();
            cmbUserType = new ComboBox();
            buttonLogin = new Button();
            labelWelcome = new Label();
            SuspendLayout();
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelUsername.Location = new Point(120, 184);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(102, 25);
            labelUsername.TabIndex = 0;
            labelUsername.Text = "Username:";
            // 
            // textUsername
            // 
            textUsername.Location = new Point(120, 212);
            textUsername.Name = "textUsername";
            textUsername.Size = new Size(245, 27);
            textUsername.TabIndex = 1;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelPassword.Location = new Point(120, 255);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(97, 25);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Password:";
            // 
            // textPassword
            // 
            textPassword.Location = new Point(120, 283);
            textPassword.Name = "textPassword";
            textPassword.PasswordChar = '*';
            textPassword.Size = new Size(245, 27);
            textPassword.TabIndex = 3;
            // 
            // labelUserType
            // 
            labelUserType.AutoSize = true;
            labelUserType.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelUserType.Location = new Point(120, 122);
            labelUserType.Name = "labelUserType";
            labelUserType.Size = new Size(96, 25);
            labelUserType.TabIndex = 4;
            labelUserType.Text = "User Type";
            // 
            // cmbUserType
            // 
            cmbUserType.FormattingEnabled = true;
            cmbUserType.Items.AddRange(new object[] { "Admin", "Customer" });
            cmbUserType.Location = new Point(222, 123);
            cmbUserType.Name = "cmbUserType";
            cmbUserType.Size = new Size(143, 28);
            cmbUserType.TabIndex = 5;
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = Color.LightSkyBlue;
            buttonLogin.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            buttonLogin.ForeColor = SystemColors.ControlText;
            buttonLogin.Location = new Point(120, 344);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(245, 50);
            buttonLogin.TabIndex = 6;
            buttonLogin.Text = "Log In";
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // labelWelcome
            // 
            labelWelcome.AutoSize = true;
            labelWelcome.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelWelcome.Location = new Point(120, 39);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(217, 38);
            labelWelcome.TabIndex = 7;
            labelWelcome.Text = "Welcome Back!";
            // 
            // LoginPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(800, 450);
            Controls.Add(labelWelcome);
            Controls.Add(buttonLogin);
            Controls.Add(cmbUserType);
            Controls.Add(labelUserType);
            Controls.Add(textPassword);
            Controls.Add(labelPassword);
            Controls.Add(textUsername);
            Controls.Add(labelUsername);
            Name = "LoginPage";
            Text = "LoginPage";
            Load += LoginPage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelUsername;
        private TextBox textUsername;
        private Label labelPassword;
        private TextBox textPassword;
        private Label labelUserType;
        private ComboBox cmbUserType;
        private Button buttonLogin;
        private Label labelWelcome;
    }
}