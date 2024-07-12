namespace crm
{
    partial class CustomerRequest
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
            panelData = new Panel();
            label1 = new Label();
            labelDate = new Label();
            labelStatus = new Label();
            labelDescription = new Label();
            labelSubject = new Label();
            labelCustomerID = new Label();
            labelID = new Label();
            panelData.SuspendLayout();
            SuspendLayout();
            // 
            // panelData
            // 
            panelData.BackColor = SystemColors.ControlLight;
            panelData.Controls.Add(label1);
            panelData.Controls.Add(labelDate);
            panelData.Controls.Add(labelStatus);
            panelData.Controls.Add(labelDescription);
            panelData.Controls.Add(labelSubject);
            panelData.Controls.Add(labelCustomerID);
            panelData.Controls.Add(labelID);
            panelData.Dock = DockStyle.Fill;
            panelData.Location = new Point(0, 0);
            panelData.Name = "panelData";
            panelData.Size = new Size(1262, 673);
            panelData.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(427, 29);
            label1.Name = "label1";
            label1.Size = new Size(339, 46);
            label1.TabIndex = 6;
            label1.Text = "Customer Requests";
            // 
            // labelDate
            // 
            labelDate.Anchor = AnchorStyles.Top;
            labelDate.AutoSize = true;
            labelDate.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelDate.Location = new Point(853, 100);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(57, 28);
            labelDate.TabIndex = 5;
            labelDate.Text = "Date";
            // 
            // labelStatus
            // 
            labelStatus.Anchor = AnchorStyles.Top;
            labelStatus.AutoSize = true;
            labelStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelStatus.Location = new Point(747, 100);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(71, 28);
            labelStatus.TabIndex = 4;
            labelStatus.Text = "Status";
            // 
            // labelDescription
            // 
            labelDescription.Anchor = AnchorStyles.Top;
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelDescription.Location = new Point(519, 100);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(121, 28);
            labelDescription.TabIndex = 3;
            labelDescription.Text = "Description";
            // 
            // labelSubject
            // 
            labelSubject.Anchor = AnchorStyles.Top;
            labelSubject.AutoSize = true;
            labelSubject.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelSubject.Location = new Point(376, 100);
            labelSubject.Name = "labelSubject";
            labelSubject.Size = new Size(82, 28);
            labelSubject.TabIndex = 2;
            labelSubject.Text = "Subject";
            // 
            // labelCustomerID
            // 
            labelCustomerID.Anchor = AnchorStyles.Top;
            labelCustomerID.AutoSize = true;
            labelCustomerID.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelCustomerID.Location = new Point(228, 100);
            labelCustomerID.Name = "labelCustomerID";
            labelCustomerID.Size = new Size(129, 28);
            labelCustomerID.TabIndex = 1;
            labelCustomerID.Text = "Customer ID";
            // 
            // labelID
            // 
            labelID.Anchor = AnchorStyles.Top;
            labelID.AutoSize = true;
            labelID.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelID.Location = new Point(180, 100);
            labelID.Name = "labelID";
            labelID.Size = new Size(33, 28);
            labelID.TabIndex = 0;
            labelID.Text = "ID";
            // 
            // CustomerRequest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 673);
            Controls.Add(panelData);
            Name = "CustomerRequest";
            Text = "CustomerRequests";
            Load += CustomerRequest_Load;
            panelData.ResumeLayout(false);
            panelData.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelData;
        private Label labelID;
        private Label labelSubject;
        private Label labelCustomerID;
        private Label labelStatus;
        private Label labelDescription;
        private Label labelDate;
        private Label label1;
    }
}