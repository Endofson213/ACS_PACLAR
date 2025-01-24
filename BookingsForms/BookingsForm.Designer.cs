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
            bookingsData = new DataGridView();
            label4 = new Label();
            button3 = new Button();
            button1 = new Button();
            label1 = new Label();
            bookingSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)bookingsData).BeginInit();
            SuspendLayout();
            // 
            // bookingsData
            // 
            bookingsData.AllowUserToAddRows = false;
            bookingsData.AllowUserToDeleteRows = false;
            bookingsData.AllowUserToResizeColumns = false;
            bookingsData.AllowUserToResizeRows = false;
            bookingsData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            bookingsData.Location = new Point(12, 106);
            bookingsData.MultiSelect = false;
            bookingsData.Name = "bookingsData";
            bookingsData.ReadOnly = true;
            bookingsData.RowHeadersVisible = false;
            bookingsData.ShowCellErrors = false;
            bookingsData.ShowCellToolTips = false;
            bookingsData.ShowEditingIcon = false;
            bookingsData.ShowRowErrors = false;
            bookingsData.Size = new Size(508, 245);
            bookingsData.TabIndex = 24;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(171, 14);
            label4.Name = "label4";
            label4.Size = new Size(170, 21);
            label4.TabIndex = 39;
            label4.Text = "Booking Information";
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
            // button1
            // 
            button1.Location = new Point(66, 77);
            button1.Name = "button1";
            button1.Size = new Size(85, 23);
            button1.TabIndex = 49;
            button1.Text = "Add Booking";
            button1.UseVisualStyleBackColor = true;
            button1.Click += addBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(266, 85);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 50;
            label1.Text = "Search:";
            // 
            // bookingSearch
            // 
            bookingSearch.Location = new Point(317, 77);
            bookingSearch.Name = "bookingSearch";
            bookingSearch.Size = new Size(100, 23);
            bookingSearch.TabIndex = 51;
            // 
            // BookingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(532, 368);
            Controls.Add(bookingSearch);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(button3);
            Controls.Add(label4);
            Controls.Add(bookingsData);
            Name = "BookingsForm";
            Text = "BookingsForm";
            ((System.ComponentModel.ISupportInitialize)bookingsData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView bookingsData;
        private Label label4;
        private Button button3;
        private Button button1;
        private Label label1;
        private TextBox bookingSearch;
    }
}