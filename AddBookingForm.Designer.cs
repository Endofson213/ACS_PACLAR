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
            addBookingBtn = new Button();
            datePicker = new DateTimePicker();
            label3 = new Label();
            totalAmountLabel = new Label();
            label1 = new Label();
            label5 = new Label();
            clientListView = new DataGridView();
            clientSearch = new TextBox();
            label4 = new Label();
            serviceBox = new ComboBox();
            label7 = new Label();
            hoursRenderedInput = new NumericUpDown();
            label8 = new Label();
            bookingSummaryGrid = new DataGridView();
            addServiceBtn = new Button();
            hourlyRateLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)clientListView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)hoursRenderedInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bookingSummaryGrid).BeginInit();
            SuspendLayout();
            // 
            // addBookingBtn
            // 
            addBookingBtn.Location = new Point(210, 598);
            addBookingBtn.Name = "addBookingBtn";
            addBookingBtn.Size = new Size(90, 23);
            addBookingBtn.TabIndex = 58;
            addBookingBtn.Text = "Add Booking";
            addBookingBtn.UseVisualStyleBackColor = true;
            addBookingBtn.Click += addBookingBtn_Click;
            // 
            // datePicker
            // 
            datePicker.Location = new Point(226, 529);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(188, 23);
            datePicker.TabIndex = 54;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(126, 537);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 52;
            label3.Text = "Booking Date:";
            // 
            // totalAmountLabel
            // 
            totalAmountLabel.AutoSize = true;
            totalAmountLabel.Location = new Point(128, 573);
            totalAmountLabel.Name = "totalAmountLabel";
            totalAmountLabel.Size = new Size(82, 15);
            totalAmountLabel.TabIndex = 51;
            totalAmountLabel.Text = "Total Amount:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(267, 58);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 50;
            label1.Text = "Search:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(201, 9);
            label5.Name = "label5";
            label5.Size = new Size(109, 21);
            label5.TabIndex = 60;
            label5.Text = "Add Booking";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // clientListView
            // 
            clientListView.AllowUserToAddRows = false;
            clientListView.AllowUserToDeleteRows = false;
            clientListView.AllowUserToResizeColumns = false;
            clientListView.AllowUserToResizeRows = false;
            clientListView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            clientListView.ColumnHeadersVisible = false;
            clientListView.EnableHeadersVisualStyles = false;
            clientListView.Location = new Point(106, 79);
            clientListView.MultiSelect = false;
            clientListView.Name = "clientListView";
            clientListView.ReadOnly = true;
            clientListView.RowHeadersVisible = false;
            clientListView.ShowCellErrors = false;
            clientListView.ShowCellToolTips = false;
            clientListView.ShowEditingIcon = false;
            clientListView.ShowRowErrors = false;
            clientListView.Size = new Size(331, 100);
            clientListView.TabIndex = 61;
            // 
            // clientSearch
            // 
            clientSearch.Location = new Point(318, 50);
            clientSearch.Name = "clientSearch";
            clientSearch.Size = new Size(119, 23);
            clientSearch.TabIndex = 63;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(106, 58);
            label4.Name = "label4";
            label4.Size = new Size(91, 15);
            label4.TabIndex = 64;
            label4.Text = "Choose a client:";
            // 
            // serviceBox
            // 
            serviceBox.DropDownStyle = ComboBoxStyle.DropDownList;
            serviceBox.FormattingEnabled = true;
            serviceBox.Location = new Point(226, 197);
            serviceBox.Name = "serviceBox";
            serviceBox.Size = new Size(121, 23);
            serviceBox.TabIndex = 65;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(126, 205);
            label7.Name = "label7";
            label7.Size = new Size(72, 15);
            label7.TabIndex = 66;
            label7.Text = "Add Service:";
            // 
            // hoursRenderedInput
            // 
            hoursRenderedInput.Location = new Point(226, 244);
            hoursRenderedInput.Name = "hoursRenderedInput";
            hoursRenderedInput.Size = new Size(120, 23);
            hoursRenderedInput.TabIndex = 67;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(125, 252);
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
            bookingSummaryGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            bookingSummaryGrid.EnableHeadersVisualStyles = false;
            bookingSummaryGrid.Location = new Point(63, 336);
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
            addServiceBtn.Location = new Point(210, 307);
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
            hourlyRateLabel.Location = new Point(128, 286);
            hourlyRateLabel.Name = "hourlyRateLabel";
            hourlyRateLabel.Size = new Size(72, 15);
            hourlyRateLabel.TabIndex = 71;
            hourlyRateLabel.Text = "Hourly Rate:";
            // 
            // AddBookingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 640);
            Controls.Add(hourlyRateLabel);
            Controls.Add(addServiceBtn);
            Controls.Add(bookingSummaryGrid);
            Controls.Add(label8);
            Controls.Add(hoursRenderedInput);
            Controls.Add(label7);
            Controls.Add(serviceBox);
            Controls.Add(label4);
            Controls.Add(clientSearch);
            Controls.Add(clientListView);
            Controls.Add(label5);
            Controls.Add(addBookingBtn);
            Controls.Add(datePicker);
            Controls.Add(label3);
            Controls.Add(totalAmountLabel);
            Controls.Add(label1);
            Name = "AddBookingForm";
            Text = "AddBookingForm";
            ((System.ComponentModel.ISupportInitialize)clientListView).EndInit();
            ((System.ComponentModel.ISupportInitialize)hoursRenderedInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)bookingSummaryGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button addBookingBtn;
        private DateTimePicker datePicker;
        private TextBox totalAmountBox;
        private Label label3;
        private Label totalAmountLabel;
        private Label label1;
        private Label label5;
        private DataGridView clientListView;
        private TextBox clientSearch;
        private Label label4;
        private ComboBox serviceBox;
        private Label label7;
        private NumericUpDown hoursRenderedInput;
        private Label label8;
        private DataGridView bookingSummaryGrid;
        private Button addServiceBtn;
        private Label hourlyRateLabel;
    }
}