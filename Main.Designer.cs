namespace ACS_PACLAR
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            mainData = new DataGridView();
            billingBtn = new Button();
            inventoryBtn = new Button();
            button4 = new Button();
            bookingsBtn = new Button();
            clientsBtn = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainData).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Location = new Point(27, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(691, 75);
            panel1.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(102, 12);
            label1.Name = "label1";
            label1.Size = new Size(483, 47);
            label1.TabIndex = 12;
            label1.Text = "Alexis Construction Services";
            // 
            // panel2
            // 
            panel2.Controls.Add(mainData);
            panel2.Controls.Add(billingBtn);
            panel2.Controls.Add(inventoryBtn);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(bookingsBtn);
            panel2.Controls.Add(clientsBtn);
            panel2.Location = new Point(12, 93);
            panel2.Name = "panel2";
            panel2.Size = new Size(716, 247);
            panel2.TabIndex = 12;
            // 
            // mainData
            // 
            mainData.AllowUserToAddRows = false;
            mainData.AllowUserToDeleteRows = false;
            mainData.AllowUserToResizeColumns = false;
            mainData.AllowUserToResizeRows = false;
            mainData.BackgroundColor = SystemColors.GradientActiveCaption;
            mainData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            mainData.EnableHeadersVisualStyles = false;
            mainData.Location = new Point(3, 8);
            mainData.MultiSelect = false;
            mainData.Name = "mainData";
            mainData.ReadOnly = true;
            mainData.RowHeadersVisible = false;
            mainData.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            mainData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            mainData.ShowCellErrors = false;
            mainData.ShowCellToolTips = false;
            mainData.ShowEditingIcon = false;
            mainData.ShowRowErrors = false;
            mainData.Size = new Size(608, 236);
            mainData.StandardTab = true;
            mainData.TabIndex = 19;
            mainData.TabStop = false;
            // 
            // billingBtn
            // 
            billingBtn.Location = new Point(617, 124);
            billingBtn.Name = "billingBtn";
            billingBtn.Size = new Size(92, 23);
            billingBtn.TabIndex = 18;
            billingBtn.Text = "Billing";
            billingBtn.UseVisualStyleBackColor = true;
            billingBtn.Click += billingBtn_Click;
            // 
            // inventoryBtn
            // 
            inventoryBtn.Location = new Point(617, 95);
            inventoryBtn.Name = "inventoryBtn";
            inventoryBtn.Size = new Size(92, 23);
            inventoryBtn.TabIndex = 17;
            inventoryBtn.Text = "Inventory Management";
            inventoryBtn.UseVisualStyleBackColor = true;
            inventoryBtn.Click += inventoryBtn_Click;
            // 
            // button4
            // 
            button4.Location = new Point(617, 66);
            button4.Name = "button4";
            button4.Size = new Size(92, 23);
            button4.TabIndex = 16;
            button4.Text = "Services";
            button4.UseVisualStyleBackColor = true;
            button4.Click += servicesBtn_Click;
            // 
            // bookingsBtn
            // 
            bookingsBtn.Location = new Point(617, 37);
            bookingsBtn.Name = "bookingsBtn";
            bookingsBtn.Size = new Size(92, 23);
            bookingsBtn.TabIndex = 15;
            bookingsBtn.Text = "Booking Transactions";
            bookingsBtn.UseVisualStyleBackColor = true;
            bookingsBtn.Click += bookingsBtn_Click;
            // 
            // clientsBtn
            // 
            clientsBtn.Location = new Point(617, 8);
            clientsBtn.Name = "clientsBtn";
            clientsBtn.Size = new Size(92, 23);
            clientsBtn.TabIndex = 14;
            clientsBtn.Text = "Client Profiles";
            clientsBtn.UseVisualStyleBackColor = true;
            clientsBtn.Click += clientsBtn_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(740, 352);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Main";
            Text = "Main";
            Load += main_load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainData).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Button bookingsBtn;
        private Button clientsBtn;
        private Button button4;
        private Button inventoryBtn;
        private Button billingBtn;
        private DataGridView mainData;
    }
}
