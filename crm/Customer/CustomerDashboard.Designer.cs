namespace crm
{
    partial class CustomerDashboard
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
            buttonCreateNewRequest = new Button();
            panelData = new Panel();
            labelDate = new Label();
            labelStatus = new Label();
            labelDescription = new Label();
            labelSubject = new Label();
            labelID = new Label();
            panelData.SuspendLayout();
            SuspendLayout();
            // 
            // buttonCreateNewRequest
            // 
            buttonCreateNewRequest.Anchor = AnchorStyles.Top;
            buttonCreateNewRequest.BackColor = Color.White;
            buttonCreateNewRequest.Font = new Font("Segoe UI Black", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 162);
            buttonCreateNewRequest.Location = new Point(17, 14);
            buttonCreateNewRequest.Margin = new Padding(50);
            buttonCreateNewRequest.Name = "buttonCreateNewRequest";
            buttonCreateNewRequest.Size = new Size(767, 84);
            buttonCreateNewRequest.TabIndex = 5;
            buttonCreateNewRequest.Text = "Create New Request";
            buttonCreateNewRequest.UseVisualStyleBackColor = false;
            buttonCreateNewRequest.Click += buttonCreateNewRequest_Click;
            // 
            // panelData
            // 
            panelData.BackColor = SystemColors.ControlLight;
            panelData.Controls.Add(buttonCreateNewRequest);
            panelData.Controls.Add(labelDate);
            panelData.Controls.Add(labelStatus);
            panelData.Controls.Add(labelDescription);
            panelData.Controls.Add(labelSubject);
            panelData.Controls.Add(labelID);
            panelData.Dock = DockStyle.Fill;
            panelData.Location = new Point(0, 0);
            panelData.Name = "panelData";
            panelData.Size = new Size(800, 450);
            panelData.TabIndex = 11;
            // 
            // labelDate
            // 
            labelDate.Anchor = AnchorStyles.Top;
            labelDate.AutoSize = true;
            labelDate.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelDate.Location = new Point(743, 125);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(57, 28);
            labelDate.TabIndex = 6;
            labelDate.Text = "Date";
            // 
            // labelStatus
            // 
            labelStatus.Anchor = AnchorStyles.Top;
            labelStatus.AutoSize = true;
            labelStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelStatus.Location = new Point(560, 125);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(71, 28);
            labelStatus.TabIndex = 5;
            labelStatus.Text = "Status";
            // 
            // labelDescription
            // 
            labelDescription.Anchor = AnchorStyles.Top;
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelDescription.Location = new Point(231, 125);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(121, 28);
            labelDescription.TabIndex = 4;
            labelDescription.Text = "Description";
            // 
            // labelSubject
            // 
            labelSubject.Anchor = AnchorStyles.Top;
            labelSubject.AutoSize = true;
            labelSubject.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelSubject.Location = new Point(87, 125);
            labelSubject.Name = "labelSubject";
            labelSubject.Size = new Size(82, 28);
            labelSubject.TabIndex = 3;
            labelSubject.Text = "Subject";
            // 
            // labelID
            // 
            labelID.Anchor = AnchorStyles.Top;
            labelID.AutoSize = true;
            labelID.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelID.Location = new Point(0, 125);
            labelID.Name = "labelID";
            labelID.Size = new Size(33, 28);
            labelID.TabIndex = 1;
            labelID.Text = "ID";
            // 
            // CustomerDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelData);
            Name = "CustomerDashboard";
            Text = "CustomerDashboard";
            Load += CustomerDashboard_Load;
            panelData.ResumeLayout(false);
            panelData.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button buttonCreateNewRequest;
        private Panel panelData;
        private Label labelID;
        private Label labelSubject;
        private Label labelDescription;
        private Label labelStatus;
        private Label labelDate;
    }
}