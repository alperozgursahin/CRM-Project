namespace crm
{
    partial class Customers
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
            customerID = new Label();
            customerName = new Label();
            customerEmail = new Label();
            customerPhone = new Label();
            customerAddress = new Label();
            panelData = new Panel();
            labelTitle = new Label();
            panelData.SuspendLayout();
            SuspendLayout();
            // 
            // customerID
            // 
            customerID.Anchor = AnchorStyles.Top;
            customerID.AutoSize = true;
            customerID.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            customerID.Location = new Point(0, 70);
            customerID.Name = "customerID";
            customerID.Size = new Size(33, 28);
            customerID.TabIndex = 0;
            customerID.Text = "ID";
            // 
            // customerName
            // 
            customerName.Anchor = AnchorStyles.Top;
            customerName.AutoSize = true;
            customerName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            customerName.Location = new Point(146, 70);
            customerName.Name = "customerName";
            customerName.Size = new Size(68, 28);
            customerName.TabIndex = 1;
            customerName.Text = "Name";
            // 
            // customerEmail
            // 
            customerEmail.Anchor = AnchorStyles.Top;
            customerEmail.AutoSize = true;
            customerEmail.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            customerEmail.Location = new Point(349, 70);
            customerEmail.Name = "customerEmail";
            customerEmail.Size = new Size(64, 28);
            customerEmail.TabIndex = 2;
            customerEmail.Text = "Email";
            // 
            // customerPhone
            // 
            customerPhone.Anchor = AnchorStyles.Top;
            customerPhone.AutoSize = true;
            customerPhone.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            customerPhone.Location = new Point(547, 70);
            customerPhone.Name = "customerPhone";
            customerPhone.Size = new Size(71, 28);
            customerPhone.TabIndex = 3;
            customerPhone.Text = "Phone";
            // 
            // customerAddress
            // 
            customerAddress.Anchor = AnchorStyles.Top;
            customerAddress.AutoSize = true;
            customerAddress.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            customerAddress.Location = new Point(747, 70);
            customerAddress.Name = "customerAddress";
            customerAddress.Size = new Size(87, 28);
            customerAddress.TabIndex = 4;
            customerAddress.Text = "Address";
            // 
            // panelData
            // 
            panelData.AutoSize = true;
            panelData.BackColor = SystemColors.ControlLight;
            panelData.Controls.Add(labelTitle);
            panelData.Controls.Add(customerAddress);
            panelData.Controls.Add(customerPhone);
            panelData.Controls.Add(customerEmail);
            panelData.Controls.Add(customerName);
            panelData.Controls.Add(customerID);
            panelData.Dock = DockStyle.Fill;
            panelData.Location = new Point(0, 0);
            panelData.Name = "panelData";
            panelData.Size = new Size(800, 450);
            panelData.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.Anchor = AnchorStyles.Top;
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelTitle.Location = new Point(287, 9);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(224, 38);
            labelTitle.TabIndex = 5;
            labelTitle.Text = "Customers List";
            labelTitle.Click += label1_Click;
            // 
            // Customers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(800, 450);
            Controls.Add(panelData);
            Name = "Customers";
            Text = "Customers";
            Load += Customers_Load;
            panelData.ResumeLayout(false);
            panelData.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label customerID;
        private Label customerName;
        private Label customerEmail;
        private Label customerPhone;
        private Label customerAddress;
        private Panel panelData;
        private Label labelTitle;
    }
}