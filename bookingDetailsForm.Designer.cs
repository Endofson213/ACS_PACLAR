namespace ACS_PACLAR
{
    partial class BookingDetailsForm
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
            dateTime = new DateTimePicker();
            bookingsID = new TextBox();
            label5 = new Label();
            label3 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            label4 = new Label();
            label7 = new Label();
            comboBox1 = new ComboBox();
            label6 = new Label();
            textBox2 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            bookingDetailsData = new DataGridView();
            saveBtn = new Button();
            label8 = new Label();
            totalAmountLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)bookingDetailsData).BeginInit();
            SuspendLayout();
            // 
            // dateTime
            // 
            dateTime.Location = new Point(127, 135);
            dateTime.Name = "dateTime";
            dateTime.Size = new Size(188, 23);
            dateTime.TabIndex = 43;
            // 
            // bookingsID
            // 
            bookingsID.Enabled = false;
            bookingsID.Location = new Point(127, 78);
            bookingsID.Name = "bookingsID";
            bookingsID.ReadOnly = true;
            bookingsID.Size = new Size(34, 23);
            bookingsID.TabIndex = 42;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 86);
            label5.Name = "label5";
            label5.Size = new Size(68, 15);
            label5.TabIndex = 41;
            label5.Text = "Booking ID:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 143);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 40;
            label3.Text = "Booking Date:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 114);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 39;
            label1.Text = "Client Name:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(127, 106);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(188, 23);
            textBox1.TabIndex = 44;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(29, 45);
            label2.Name = "label2";
            label2.Size = new Size(170, 21);
            label2.TabIndex = 45;
            label2.Text = "Booking Information";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(29, 175);
            label4.Name = "label4";
            label4.Size = new Size(108, 21);
            label4.TabIndex = 46;
            label4.Text = "Add Services";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(34, 224);
            label7.Name = "label7";
            label7.Size = new Size(52, 15);
            label7.TabIndex = 47;
            label7.Text = "Services:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(127, 216);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 48;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(36, 252);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 49;
            label6.Text = "Hours:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(127, 244);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(34, 23);
            textBox2.TabIndex = 50;
            // 
            // button1
            // 
            button1.Location = new Point(184, 276);
            button1.Name = "button1";
            button1.Size = new Size(57, 23);
            button1.TabIndex = 51;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(247, 276);
            button2.Name = "button2";
            button2.Size = new Size(68, 23);
            button2.TabIndex = 52;
            button2.Text = "Remove";
            button2.UseVisualStyleBackColor = true;
            // 
            // bookingDetailsData
            // 
            bookingDetailsData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            bookingDetailsData.Location = new Point(339, 12);
            bookingDetailsData.Name = "bookingDetailsData";
            bookingDetailsData.Size = new Size(459, 287);
            bookingDetailsData.TabIndex = 53;
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(379, 320);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(56, 23);
            saveBtn.TabIndex = 54;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(36, 320);
            label8.Name = "label8";
            label8.Size = new Size(82, 15);
            label8.TabIndex = 55;
            label8.Text = "Total Amount:";
            // 
            // totalAmountLabel
            // 
            totalAmountLabel.AutoSize = true;
            totalAmountLabel.Location = new Point(127, 320);
            totalAmountLabel.Name = "totalAmountLabel";
            totalAmountLabel.Size = new Size(32, 15);
            totalAmountLabel.TabIndex = 56;
            totalAmountLabel.Text = "Total";
            totalAmountLabel.Click += totalAmountLabel_Click;
            // 
            // BookingDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(810, 360);
            Controls.Add(totalAmountLabel);
            Controls.Add(label8);
            Controls.Add(saveBtn);
            Controls.Add(bookingDetailsData);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(label6);
            Controls.Add(comboBox1);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(dateTime);
            Controls.Add(bookingsID);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "BookingDetailsForm";
            Text = "bookingDetailsForm";
            ((System.ComponentModel.ISupportInitialize)bookingDetailsData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTime;
        private TextBox bookingsID;
        private Label label5;
        private Label label3;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Label label4;
        private Label label7;
        private ComboBox comboBox1;
        private Label label6;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private DataGridView bookingDetailsData;
        private Button saveBtn;
        private Label label8;
        private Label totalAmountLabel;
    }
}