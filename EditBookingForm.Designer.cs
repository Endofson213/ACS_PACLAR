namespace ACS_PACLAR.BookingsForms
{
    partial class EditBookingForm
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
            saveBookingBtn = new Button();
            datePicker = new DateTimePicker();
            label3 = new Label();
            totalAmountLabel = new Label();
            label5 = new Label();
            labelclient = new Label();
            serviceBox = new ComboBox();
            label7 = new Label();
            hoursRenderedInput = new NumericUpDown();
            label8 = new Label();
            bookingSummaryGrid = new DataGridView();
            addServiceBtn = new Button();
            hourlyRateLabel = new Label();
            clientNameBox = new TextBox();
            totalAmountBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)hoursRenderedInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bookingSummaryGrid).BeginInit();
            SuspendLayout();
            // 
            // saveBookingBtn
            // 
            saveBookingBtn.Location = new Point(210, 485);
            saveBookingBtn.Name = "saveBookingBtn";
            saveBookingBtn.Size = new Size(90, 23);
            saveBookingBtn.TabIndex = 58;
            saveBookingBtn.Text = "Save Booking";
            saveBookingBtn.UseVisualStyleBackColor = true;
            saveBookingBtn.Click += saveBookingBtn_Click;
            // 
            // datePicker
            // 
            datePicker.Location = new Point(226, 410);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(188, 23);
            datePicker.TabIndex = 54;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(126, 418);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 52;
            label3.Text = "Booking Date:";
            // 
            // totalAmountLabel
            // 
            totalAmountLabel.AutoSize = true;
            totalAmountLabel.Location = new Point(128, 454);
            totalAmountLabel.Name = "totalAmountLabel";
            totalAmountLabel.Size = new Size(82, 15);
            totalAmountLabel.TabIndex = 51;
            totalAmountLabel.Text = "Total Amount:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(201, 9);
            label5.Name = "label5";
            label5.Size = new Size(108, 21);
            label5.TabIndex = 60;
            label5.Text = "Edit Booking";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelclient
            // 
            labelclient.AutoSize = true;
            labelclient.Location = new Point(128, 52);
            labelclient.Name = "labelclient";
            labelclient.Size = new Size(76, 15);
            labelclient.TabIndex = 64;
            labelclient.Text = "Client Name:";
            // 
            // serviceBox
            // 
            serviceBox.DropDownStyle = ComboBoxStyle.DropDownList;
            serviceBox.FormattingEnabled = true;
            serviceBox.Location = new Point(226, 78);
            serviceBox.Name = "serviceBox";
            serviceBox.Size = new Size(121, 23);
            serviceBox.TabIndex = 65;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(126, 86);
            label7.Name = "label7";
            label7.Size = new Size(72, 15);
            label7.TabIndex = 66;
            label7.Text = "Add Service:";
            // 
            // hoursRenderedInput
            // 
            hoursRenderedInput.Location = new Point(226, 125);
            hoursRenderedInput.Name = "hoursRenderedInput";
            hoursRenderedInput.Size = new Size(120, 23);
            hoursRenderedInput.TabIndex = 67;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(125, 133);
            label8.Name = "label8";
            label8.Size = new Size(95, 15);
            label8.TabIndex = 68;
            label8.Text = "Hours Rendered:";
            // 
            // bookingSummaryGrid
            // 
            bookingSummaryGrid.AllowUserToAddRows = false;
            bookingSummaryGrid.AllowUserToDeleteRows = false;
            bookingSummaryGrid.AllowUserToResizeColumns = false;
            bookingSummaryGrid.AllowUserToResizeRows = false;
            bookingSummaryGrid.BackgroundColor = SystemColors.GradientActiveCaption;
            bookingSummaryGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            bookingSummaryGrid.EnableHeadersVisualStyles = false;
            bookingSummaryGrid.Location = new Point(58, 217);
            bookingSummaryGrid.MultiSelect = false;
            bookingSummaryGrid.Name = "bookingSummaryGrid";
            bookingSummaryGrid.ReadOnly = true;
            bookingSummaryGrid.RowHeadersVisible = false;
            bookingSummaryGrid.ShowCellErrors = false;
            bookingSummaryGrid.ShowCellToolTips = false;
            bookingSummaryGrid.ShowEditingIcon = false;
            bookingSummaryGrid.ShowRowErrors = false;
            bookingSummaryGrid.Size = new Size(412, 187);
            bookingSummaryGrid.TabIndex = 69;
            // 
            // addServiceBtn
            // 
            addServiceBtn.Location = new Point(210, 188);
            addServiceBtn.Name = "addServiceBtn";
            addServiceBtn.Size = new Size(90, 23);
            addServiceBtn.TabIndex = 70;
            addServiceBtn.Text = "Add Service";
            addServiceBtn.UseVisualStyleBackColor = true;
            addServiceBtn.Click += addServiceBtn_Click;
            // 
            // hourlyRateLabel
            // 
            hourlyRateLabel.AutoSize = true;
            hourlyRateLabel.Location = new Point(128, 167);
            hourlyRateLabel.Name = "hourlyRateLabel";
            hourlyRateLabel.Size = new Size(72, 15);
            hourlyRateLabel.TabIndex = 71;
            hourlyRateLabel.Text = "Hourly Rate:";
            // 
            // clientNameBox
            // 
            clientNameBox.Enabled = false;
            clientNameBox.Location = new Point(226, 44);
            clientNameBox.Name = "clientNameBox";
            clientNameBox.Size = new Size(100, 23);
            clientNameBox.TabIndex = 72;
            // 
            // totalAmountBox
            // 
            totalAmountBox.Enabled = false;
            totalAmountBox.Location = new Point(226, 446);
            totalAmountBox.Name = "totalAmountBox";
            totalAmountBox.Size = new Size(100, 23);
            totalAmountBox.TabIndex = 73;
            // 
            // EditBookingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(510, 517);
            Controls.Add(totalAmountBox);
            Controls.Add(clientNameBox);
            Controls.Add(hourlyRateLabel);
            Controls.Add(addServiceBtn);
            Controls.Add(bookingSummaryGrid);
            Controls.Add(label8);
            Controls.Add(hoursRenderedInput);
            Controls.Add(label7);
            Controls.Add(serviceBox);
            Controls.Add(labelclient);
            Controls.Add(label5);
            Controls.Add(saveBookingBtn);
            Controls.Add(datePicker);
            Controls.Add(label3);
            Controls.Add(totalAmountLabel);
            Name = "EditBookingForm";
            Text = "AddBookingForm";
            ((System.ComponentModel.ISupportInitialize)hoursRenderedInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)bookingSummaryGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button saveBookingBtn;
        private DateTimePicker datePicker;
        private Label label3;
        private Label totalAmountLabel;
        private Label label5;
        private Label labelclient;
        private ComboBox serviceBox;
        private Label label7;
        private NumericUpDown hoursRenderedInput;
        private Label label8;
        private DataGridView bookingSummaryGrid;
        private Label hourlyRateLabel;
        private TextBox clientNameBox;
        private Button addServiceBtn;
        private TextBox totalAmountBox;
    }
}