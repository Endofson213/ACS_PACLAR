namespace ACS_PACLAR
{
    partial class BookingsForm
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
            deleteBtn = new Button();
            detailsBtn = new Button();
            addressBox = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            bookingsData = new DataGridView();
            dateTime = new DateTimePicker();
            label4 = new Label();
            bookingsID = new TextBox();
            label5 = new Label();
            clientBox = new ComboBox();
            button1 = new Button();
            label6 = new Label();
            dateAvailability = new Label();
            button3 = new Button();
            addBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)bookingsData).BeginInit();
            SuspendLayout();
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(264, 230);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(54, 23);
            deleteBtn.TabIndex = 35;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = true;
            // 
            // detailsBtn
            // 
            detailsBtn.Location = new Point(179, 230);
            detailsBtn.Name = "detailsBtn";
            detailsBtn.Size = new Size(79, 23);
            detailsBtn.TabIndex = 34;
            detailsBtn.Text = "View Details";
            detailsBtn.UseVisualStyleBackColor = true;
            detailsBtn.Click += viewDetailsBtn;
            // 
            // addressBox
            // 
            addressBox.Enabled = false;
            addressBox.Location = new Point(119, 191);
            addressBox.Name = "addressBox";
            addressBox.ReadOnly = true;
            addressBox.Size = new Size(126, 23);
            addressBox.TabIndex = 31;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 139);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 27;
            label3.Text = "Booking Date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 199);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 26;
            label2.Text = "Total Amount:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 110);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 25;
            label1.Text = "Client:";
            // 
            // bookingsData
            // 
            bookingsData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            bookingsData.Location = new Point(355, 74);
            bookingsData.Name = "bookingsData";
            bookingsData.Size = new Size(593, 450);
            bookingsData.TabIndex = 24;
            // 
            // dateTime
            // 
            dateTime.Location = new Point(119, 131);
            dateTime.Name = "dateTime";
            dateTime.Size = new Size(188, 23);
            dateTime.TabIndex = 38;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(424, 23);
            label4.Name = "label4";
            label4.Size = new Size(170, 21);
            label4.TabIndex = 39;
            label4.Text = "Booking Information";
            // 
            // bookingsID
            // 
            bookingsID.Enabled = false;
            bookingsID.Location = new Point(119, 74);
            bookingsID.Name = "bookingsID";
            bookingsID.ReadOnly = true;
            bookingsID.Size = new Size(34, 23);
            bookingsID.TabIndex = 37;
            bookingsID.TextChanged += clientBox_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 82);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 36;
            label5.Text = "Bookings ID:";
            // 
            // clientBox
            // 
            clientBox.FormattingEnabled = true;
            clientBox.Location = new Point(119, 102);
            clientBox.Name = "clientBox";
            clientBox.Size = new Size(121, 23);
            clientBox.TabIndex = 40;
            // 
            // button1
            // 
            button1.Location = new Point(246, 101);
            button1.Name = "button1";
            button1.Size = new Size(72, 23);
            button1.TabIndex = 43;
            button1.Text = "Add Client";
            button1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 168);
            label6.Name = "label6";
            label6.Size = new Size(95, 15);
            label6.TabIndex = 45;
            label6.Text = "Booking Validity:";
            // 
            // dateAvailability
            // 
            dateAvailability.AutoSize = true;
            dateAvailability.Location = new Point(122, 168);
            dateAvailability.Name = "dateAvailability";
            dateAvailability.Size = new Size(31, 15);
            dateAvailability.TabIndex = 47;
            dateAvailability.Text = "Date";
            // 
            // button3
            // 
            button3.Location = new Point(12, 12);
            button3.Name = "button3";
            button3.Size = new Size(63, 23);
            button3.TabIndex = 48;
            button3.Text = "Go Back";
            button3.UseVisualStyleBackColor = true;
            button3.Click += backBtn;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(21, 230);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(54, 23);
            addBtn.TabIndex = 49;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // BookingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 536);
            Controls.Add(addBtn);
            Controls.Add(button3);
            Controls.Add(dateAvailability);
            Controls.Add(label6);
            Controls.Add(button1);
            Controls.Add(clientBox);
            Controls.Add(label4);
            Controls.Add(dateTime);
            Controls.Add(bookingsID);
            Controls.Add(label5);
            Controls.Add(deleteBtn);
            Controls.Add(detailsBtn);
            Controls.Add(addressBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(bookingsData);
            Name = "BookingsForm";
            Text = "BookingsForm";
            ((System.ComponentModel.ISupportInitialize)bookingsData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button deleteBtn;
        private Button detailsBtn;
        private TextBox addressBox;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView bookingsData;
        private DateTimePicker dateTime;
        private Label label4;
        private TextBox bookingsID;
        private Label label5;
        private ComboBox clientBox;
        private Button button1;
        private Label label6;
        private Label dateAvailability;
        private Button button3;
        private Button addBtn;
    }
}