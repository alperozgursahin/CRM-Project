namespace crm.Customer
{
    partial class CustomerCreateRequest
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
            labelSubject = new Label();
            labelDescription = new Label();
            textSubject = new TextBox();
            textDescription = new TextBox();
            buttonSubmitRequest = new Button();
            SuspendLayout();
            // 
            // labelSubject
            // 
            labelSubject.AutoSize = true;
            labelSubject.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelSubject.Location = new Point(96, 63);
            labelSubject.Name = "labelSubject";
            labelSubject.Size = new Size(122, 38);
            labelSubject.TabIndex = 0;
            labelSubject.Text = "Subject:";
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelDescription.Location = new Point(96, 164);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(175, 38);
            labelDescription.TabIndex = 1;
            labelDescription.Text = "Description:";
            // 
            // textSubject
            // 
            textSubject.Location = new Point(311, 74);
            textSubject.Name = "textSubject";
            textSubject.Size = new Size(196, 27);
            textSubject.TabIndex = 2;
            // 
            // textDescription
            // 
            textDescription.Location = new Point(311, 175);
            textDescription.Name = "textDescription";
            textDescription.Size = new Size(196, 27);
            textDescription.TabIndex = 3;
            // 
            // buttonSubmitRequest
            // 
            buttonSubmitRequest.BackColor = Color.Wheat;
            buttonSubmitRequest.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            buttonSubmitRequest.Location = new Point(311, 266);
            buttonSubmitRequest.Name = "buttonSubmitRequest";
            buttonSubmitRequest.Size = new Size(196, 45);
            buttonSubmitRequest.TabIndex = 4;
            buttonSubmitRequest.Text = "Create Request";
            buttonSubmitRequest.UseVisualStyleBackColor = false;
            buttonSubmitRequest.Click += buttonSubmitRequest_Click;
            // 
            // CustomerCreateRequest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Tan;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonSubmitRequest);
            Controls.Add(textDescription);
            Controls.Add(textSubject);
            Controls.Add(labelDescription);
            Controls.Add(labelSubject);
            Name = "CustomerCreateRequest";
            Text = "CustomerCreateRequest";
            Load += CustomerCreateRequest_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelSubject;
        private Label labelDescription;
        private TextBox textSubject;
        private TextBox textDescription;
        private Button buttonSubmitRequest;
    }
}