namespace ACS_PACLAR
{
    partial class Dashboard
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
            Title = new Label();
            clientsBtn = new Button();
            servicesBtn = new Button();
            bookingsBtn = new Button();
            inventoryBtn = new Button();
            paymentsBtn = new Button();
            reportsBtn = new Button();
            SuspendLayout();
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            Title.Location = new Point(74, 9);
            Title.Name = "Title";
            Title.Size = new Size(552, 54);
            Title.TabIndex = 0;
            Title.Text = "Alexis Construction Services";
            Title.TextAlign = ContentAlignment.TopCenter;
            // 
            // clientsBtn
            // 
            clientsBtn.Location = new Point(80, 111);
            clientsBtn.Name = "clientsBtn";
            clientsBtn.Size = new Size(152, 87);
            clientsBtn.TabIndex = 1;
            clientsBtn.Text = "Clients";
            clientsBtn.UseVisualStyleBackColor = true;
            clientsBtn.Click += clientsBtn_Click;
            // 
            // servicesBtn
            // 
            servicesBtn.Location = new Point(269, 111);
            servicesBtn.Name = "servicesBtn";
            servicesBtn.Size = new Size(152, 87);
            servicesBtn.TabIndex = 2;
            servicesBtn.Text = "Services";
            servicesBtn.UseVisualStyleBackColor = true;
            // 
            // bookingsBtn
            // 
            bookingsBtn.Location = new Point(458, 111);
            bookingsBtn.Name = "bookingsBtn";
            bookingsBtn.Size = new Size(152, 87);
            bookingsBtn.TabIndex = 3;
            bookingsBtn.Text = "Bookings";
            bookingsBtn.UseVisualStyleBackColor = true;
            // 
            // inventoryBtn
            // 
            inventoryBtn.Location = new Point(80, 257);
            inventoryBtn.Name = "inventoryBtn";
            inventoryBtn.Size = new Size(152, 87);
            inventoryBtn.TabIndex = 4;
            inventoryBtn.Text = "Inventory";
            inventoryBtn.UseVisualStyleBackColor = true;
            // 
            // paymentsBtn
            // 
            paymentsBtn.Location = new Point(269, 257);
            paymentsBtn.Name = "paymentsBtn";
            paymentsBtn.Size = new Size(152, 87);
            paymentsBtn.TabIndex = 5;
            paymentsBtn.Text = "Payments";
            paymentsBtn.UseVisualStyleBackColor = true;
            // 
            // reportsBtn
            // 
            reportsBtn.Location = new Point(458, 257);
            reportsBtn.Name = "reportsBtn";
            reportsBtn.Size = new Size(152, 87);
            reportsBtn.TabIndex = 6;
            reportsBtn.Text = "Reports";
            reportsBtn.UseVisualStyleBackColor = true;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 419);
            Controls.Add(reportsBtn);
            Controls.Add(paymentsBtn);
            Controls.Add(inventoryBtn);
            Controls.Add(bookingsBtn);
            Controls.Add(servicesBtn);
            Controls.Add(clientsBtn);
            Controls.Add(Title);
            Name = "Dashboard";
            Text = "Dashboard";
            Load += Dashboard_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Title;
        private Button clientsBtn;
        private Button servicesBtn;
        private Button bookingsBtn;
        private Button inventoryBtn;
        private Button paymentsBtn;
        private Button reportsBtn;
    }
}
