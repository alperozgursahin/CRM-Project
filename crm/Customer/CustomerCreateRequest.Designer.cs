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
            labelSubject.Location = new Point(119, 85);
            labelSubject.Name = "labelSubject";
            labelSubject.Size = new Size(58, 20);
            labelSubject.TabIndex = 0;
            labelSubject.Text = "Subject";
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(269, 85);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(85, 20);
            labelDescription.TabIndex = 1;
            labelDescription.Text = "Description";
            // 
            // textSubject
            // 
            textSubject.Location = new Point(96, 134);
            textSubject.Name = "textSubject";
            textSubject.Size = new Size(125, 27);
            textSubject.TabIndex = 2;
            // 
            // textDescription
            // 
            textDescription.Location = new Point(255, 134);
            textDescription.Name = "textDescription";
            textDescription.Size = new Size(125, 27);
            textDescription.TabIndex = 3;
            // 
            // buttonSubmitRequest
            // 
            buttonSubmitRequest.Location = new Point(469, 134);
            buttonSubmitRequest.Name = "buttonSubmitRequest";
            buttonSubmitRequest.Size = new Size(94, 29);
            buttonSubmitRequest.TabIndex = 4;
            buttonSubmitRequest.Text = "Submit";
            buttonSubmitRequest.UseVisualStyleBackColor = true;
            buttonSubmitRequest.Click += buttonSubmitRequest_Click;
            // 
            // CustomerCreateRequest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
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