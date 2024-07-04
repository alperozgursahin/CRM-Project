﻿namespace crm
{
    partial class RequestForm
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
            button1 = new Button();
            panel1 = new Panel();
            labelDescription = new Label();
            labelSubject = new Label();
            labelDescriptionText = new Label();
            labelSubjectText = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.GreenYellow;
            button1.Dock = DockStyle.Top;
            button1.Font = new Font("Arial Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(382, 89);
            button1.TabIndex = 0;
            button1.Text = "Start Time";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.Controls.Add(labelDescription);
            panel1.Controls.Add(labelSubject);
            panel1.Controls.Add(labelDescriptionText);
            panel1.Controls.Add(labelSubjectText);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(382, 753);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelDescription.Location = new Point(10, 300);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(138, 31);
            labelDescription.TabIndex = 5;
            labelDescription.Text = "Description";
            // 
            // labelSubject
            // 
            labelSubject.AutoSize = true;
            labelSubject.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelSubject.Location = new Point(10, 120);
            labelSubject.Name = "labelSubject";
            labelSubject.Size = new Size(94, 31);
            labelSubject.TabIndex = 4;
            labelSubject.Text = "Subject";
            // 
            // labelDescriptionText
            // 
            labelDescriptionText.AutoSize = true;
            labelDescriptionText.Location = new Point(10, 350);
            labelDescriptionText.MaximumSize = new Size(350, 300);
            labelDescriptionText.Name = "labelDescriptionText";
            labelDescriptionText.Size = new Size(116, 20);
            labelDescriptionText.TabIndex = 3;
            labelDescriptionText.Text = "Description Text";
            labelDescriptionText.Click += label1_Click_1;
            // 
            // labelSubjectText
            // 
            labelSubjectText.AutoSize = true;
            labelSubjectText.Location = new Point(10, 170);
            labelSubjectText.Name = "labelSubjectText";
            labelSubjectText.Size = new Size(89, 20);
            labelSubjectText.TabIndex = 2;
            labelSubjectText.Text = "Subject Text";
            labelSubjectText.Click += Detay_Click;
            // 
            // RequestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 753);
            Controls.Add(button1);
            Controls.Add(panel1);
            Name = "RequestForm";
            Text = "GorevForm";
            Load += GorevForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Panel panel1;
        private Label labelSubjectText;
        private Label labelDescriptionText;
        private Label labelSubject;
        private Label labelDescription;
    }
}