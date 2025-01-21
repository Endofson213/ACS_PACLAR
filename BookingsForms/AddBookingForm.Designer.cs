namespace ACS_PACLAR.BookingsForms
{
    partial class AddBookingForm
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
            addBtn = new Button();
            dateAvailability = new Label();
            label6 = new Label();
            clientBox = new ComboBox();
            datePicker = new DateTimePicker();
            totalAmountBox = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label5 = new Label();
            serviceGridView = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)serviceGridView).BeginInit();
            SuspendLayout();
            // 
            // addBtn
            // 
            addBtn.Location = new Point(291, 363);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(90, 23);
            addBtn.TabIndex = 58;
            addBtn.Text = "Add Booking";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // dateAvailability
            // 
            dateAvailability.AutoSize = true;
            dateAvailability.Location = new Point(281, 137);
            dateAvailability.Name = "dateAvailability";
            dateAvailability.Size = new Size(72, 15);
            dateAvailability.TabIndex = 57;
            dateAvailability.Text = "Date Validity";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(180, 137);
            label6.Name = "label6";
            label6.Size = new Size(95, 15);
            label6.TabIndex = 56;
            label6.Text = "Booking Validity:";
            // 
            // clientBox
            // 
            clientBox.DropDownStyle = ComboBoxStyle.DropDownList;
            clientBox.FormattingEnabled = true;
            clientBox.Location = new Point(281, 64);
            clientBox.Name = "clientBox";
            clientBox.Size = new Size(121, 23);
            clientBox.TabIndex = 55;
            // 
            // datePicker
            // 
            datePicker.Location = new Point(281, 93);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(188, 23);
            datePicker.TabIndex = 54;
            // 
            // totalAmountBox
            // 
            totalAmountBox.Enabled = false;
            totalAmountBox.Location = new Point(307, 320);
            totalAmountBox.Name = "totalAmountBox";
            totalAmountBox.ReadOnly = true;
            totalAmountBox.Size = new Size(126, 23);
            totalAmountBox.TabIndex = 53;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(183, 101);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 52;
            label3.Text = "Booking Date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(209, 328);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 51;
            label2.Text = "Total Amount:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(183, 72);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 50;
            label1.Text = "Client Name:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(272, 9);
            label5.Name = "label5";
            label5.Size = new Size(109, 21);
            label5.TabIndex = 60;
            label5.Text = "Add Booking";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // serviceGridView
            // 
            serviceGridView.AllowDrop = true;
            serviceGridView.AllowUserToOrderColumns = true;
            serviceGridView.AllowUserToResizeColumns = false;
            serviceGridView.AllowUserToResizeRows = false;
            serviceGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            serviceGridView.Location = new Point(12, 168);
            serviceGridView.Name = "serviceGridView";
            serviceGridView.RowHeadersVisible = false;
            serviceGridView.ShowCellErrors = false;
            serviceGridView.ShowCellToolTips = false;
            serviceGridView.ShowEditingIcon = false;
            serviceGridView.ShowRowErrors = false;
            serviceGridView.Size = new Size(620, 133);
            serviceGridView.TabIndex = 61;
            // 
            // button1
            // 
            button1.Location = new Point(360, 130);
            button1.Name = "button1";
            button1.Size = new Size(86, 23);
            button1.TabIndex = 62;
            button1.Text = "Validate Date";
            button1.UseVisualStyleBackColor = true;
            button1.Click += validateBtn_Click;
            // 
            // AddBookingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 405);
            Controls.Add(button1);
            Controls.Add(serviceGridView);
            Controls.Add(label5);
            Controls.Add(addBtn);
            Controls.Add(dateAvailability);
            Controls.Add(label6);
            Controls.Add(clientBox);
            Controls.Add(datePicker);
            Controls.Add(totalAmountBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddBookingForm";
            Text = "AddBookingForm";
            ((System.ComponentModel.ISupportInitialize)serviceGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button addBtn;
        private Label dateAvailability;
        private Label label6;
        private ComboBox clientBox;
        private DateTimePicker datePicker;
        private TextBox totalAmountBox;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label5;
        private DataGridView serviceGridView;
        private Button button1;
    }
}