namespace crm
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
            updateNoteButton = new Button();
            noteTextBox = new TextBox();
            labelNotes = new Label();
            labelElapsedTimeText = new Label();
            labelElapsedTime = new Label();
            labelDateText = new Label();
            labelDate = new Label();
            labelStatusText = new Label();
            labelStatus = new Label();
            labelCustomerIDText = new Label();
            labelCustomerID = new Label();
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
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(updateNoteButton);
            panel1.Controls.Add(noteTextBox);
            panel1.Controls.Add(labelNotes);
            panel1.Controls.Add(labelElapsedTimeText);
            panel1.Controls.Add(labelElapsedTime);
            panel1.Controls.Add(labelDateText);
            panel1.Controls.Add(labelDate);
            panel1.Controls.Add(labelStatusText);
            panel1.Controls.Add(labelStatus);
            panel1.Controls.Add(labelCustomerIDText);
            panel1.Controls.Add(labelCustomerID);
            panel1.Controls.Add(labelDescription);
            panel1.Controls.Add(labelSubject);
            panel1.Controls.Add(labelDescriptionText);
            panel1.Controls.Add(labelSubjectText);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(382, 753);
            panel1.TabIndex = 1;
            // 
            // updateNoteButton
            // 
            updateNoteButton.Location = new Point(134, 578);
            updateNoteButton.Name = "updateNoteButton";
            updateNoteButton.Size = new Size(107, 29);
            updateNoteButton.TabIndex = 17;
            updateNoteButton.Text = "Update Note";
            updateNoteButton.UseVisualStyleBackColor = true;
            updateNoteButton.Click += updateNoteButton_Click;
            // 
            // noteTextBox
            // 
            noteTextBox.Location = new Point(12, 545);
            noteTextBox.Name = "noteTextBox";
            noteTextBox.Size = new Size(358, 27);
            noteTextBox.TabIndex = 16;
            // 
            // labelNotes
            // 
            labelNotes.AutoSize = true;
            labelNotes.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelNotes.Location = new Point(152, 500);
            labelNotes.Name = "labelNotes";
            labelNotes.Size = new Size(67, 31);
            labelNotes.TabIndex = 15;
            labelNotes.Text = "Note";
            // 
            // labelElapsedTimeText
            // 
            labelElapsedTimeText.AutoSize = true;
            labelElapsedTimeText.Location = new Point(150, 303);
            labelElapsedTimeText.Name = "labelElapsedTimeText";
            labelElapsedTimeText.Size = new Size(68, 20);
            labelElapsedTimeText.TabIndex = 13;
            labelElapsedTimeText.Text = "0h 0m 0s";
            // 
            // labelElapsedTime
            // 
            labelElapsedTime.AutoSize = true;
            labelElapsedTime.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelElapsedTime.Location = new Point(3, 300);
            labelElapsedTime.Name = "labelElapsedTime";
            labelElapsedTime.Size = new Size(129, 25);
            labelElapsedTime.TabIndex = 12;
            labelElapsedTime.Text = "Elapsed Time:";
            // 
            // labelDateText
            // 
            labelDateText.AutoSize = true;
            labelDateText.Location = new Point(150, 253);
            labelDateText.Name = "labelDateText";
            labelDateText.Size = new Size(72, 20);
            labelDateText.TabIndex = 11;
            labelDateText.Text = "Date Text";
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelDate.Location = new Point(3, 250);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(128, 25);
            labelDate.TabIndex = 10;
            labelDate.Text = "Created Date:";
            // 
            // labelStatusText
            // 
            labelStatusText.AutoSize = true;
            labelStatusText.Location = new Point(150, 203);
            labelStatusText.Name = "labelStatusText";
            labelStatusText.Size = new Size(80, 20);
            labelStatusText.TabIndex = 9;
            labelStatusText.Text = "Status Text";
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelStatus.Location = new Point(3, 200);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(70, 25);
            labelStatus.TabIndex = 8;
            labelStatus.Text = "Status:";
            // 
            // labelCustomerIDText
            // 
            labelCustomerIDText.AutoSize = true;
            labelCustomerIDText.Location = new Point(150, 103);
            labelCustomerIDText.Name = "labelCustomerIDText";
            labelCustomerIDText.Size = new Size(128, 20);
            labelCustomerIDText.TabIndex = 7;
            labelCustomerIDText.Text = "Customer ID TEXT";
            // 
            // labelCustomerID
            // 
            labelCustomerID.AutoSize = true;
            labelCustomerID.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelCustomerID.Location = new Point(3, 100);
            labelCustomerID.Name = "labelCustomerID";
            labelCustomerID.Size = new Size(122, 25);
            labelCustomerID.TabIndex = 6;
            labelCustomerID.Text = "Customer ID:";
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelDescription.Location = new Point(3, 350);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(121, 28);
            labelDescription.TabIndex = 5;
            labelDescription.Text = "Description";
            // 
            // labelSubject
            // 
            labelSubject.AutoSize = true;
            labelSubject.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelSubject.Location = new Point(3, 150);
            labelSubject.Name = "labelSubject";
            labelSubject.Size = new Size(80, 25);
            labelSubject.TabIndex = 4;
            labelSubject.Text = "Subject:";
            // 
            // labelDescriptionText
            // 
            labelDescriptionText.AutoSize = true;
            labelDescriptionText.Location = new Point(12, 388);
            labelDescriptionText.MaximumSize = new Size(350, 300);
            labelDescriptionText.Name = "labelDescriptionText";
            labelDescriptionText.Size = new Size(116, 20);
            labelDescriptionText.TabIndex = 3;
            labelDescriptionText.Text = "Description Text";
            // 
            // labelSubjectText
            // 
            labelSubjectText.AutoSize = true;
            labelSubjectText.Location = new Point(150, 153);
            labelSubjectText.Name = "labelSubjectText";
            labelSubjectText.Size = new Size(89, 20);
            labelSubjectText.TabIndex = 2;
            labelSubjectText.Text = "Subject Text";
            // 
            // RequestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 753);
            Controls.Add(button1);
            Controls.Add(panel1);
            Name = "RequestForm";
            Text = "RequestForm";
            Load += RequestForm_Load;
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
        private Label labelCustomerIDText;
        private Label labelCustomerID;
        private Label labelStatusText;
        private Label labelStatus;
        private Label labelDateText;
        private Label labelDate;
        private Label labelElapsedTime;
        private Label labelElapsedTimeText;
        private Label labelNotes;
        private TextBox noteTextBox;
        private Button updateNoteButton;
    }
}