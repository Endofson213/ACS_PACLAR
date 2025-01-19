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
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            bookingsBtn = new Button();
            clientsBtn = new Button();
            button7 = new Button();
            button8 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
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
            panel2.Controls.Add(button8);
            panel2.Controls.Add(button7);
            panel2.Controls.Add(button6);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(bookingsBtn);
            panel2.Controls.Add(clientsBtn);
            panel2.Location = new Point(12, 93);
            panel2.Name = "panel2";
            panel2.Size = new Size(716, 247);
            panel2.TabIndex = 12;
            // 
            // button6
            // 
            button6.Location = new Point(3, 119);
            button6.Name = "button6";
            button6.Size = new Size(128, 23);
            button6.TabIndex = 18;
            button6.Text = "Process Payments";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(3, 90);
            button5.Name = "button5";
            button5.Size = new Size(128, 23);
            button5.TabIndex = 17;
            button5.Text = "Inventory Management";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(3, 61);
            button4.Name = "button4";
            button4.Size = new Size(128, 23);
            button4.TabIndex = 16;
            button4.Text = "Services";
            button4.UseVisualStyleBackColor = true;
            button4.Click += servicesBtn_Click;
            // 
            // bookingsBtn
            // 
            bookingsBtn.Location = new Point(3, 32);
            bookingsBtn.Name = "bookingsBtn";
            bookingsBtn.Size = new Size(128, 23);
            bookingsBtn.TabIndex = 15;
            bookingsBtn.Text = "Booking Transactions";
            bookingsBtn.UseVisualStyleBackColor = true;
            bookingsBtn.Click += bookingsBtn_Click;
            // 
            // clientsBtn
            // 
            clientsBtn.Location = new Point(3, 3);
            clientsBtn.Name = "clientsBtn";
            clientsBtn.Size = new Size(128, 23);
            clientsBtn.TabIndex = 14;
            clientsBtn.Text = "Client Profiles";
            clientsBtn.UseVisualStyleBackColor = true;
            clientsBtn.Click += clientsBtn_Click;
            // 
            // button7
            // 
            button7.Location = new Point(3, 148);
            button7.Name = "button7";
            button7.Size = new Size(128, 23);
            button7.TabIndex = 19;
            button7.Text = "Reports/View";
            button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Location = new Point(3, 177);
            button8.Name = "button8";
            button8.Size = new Size(128, 23);
            button8.TabIndex = 20;
            button8.Text = "Weekly Schedule";
            button8.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(740, 352);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Main";
            Text = "Main";
            Load += main_load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Button bookingsBtn;
        private Button clientsBtn;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button8;
        private Button button7;
    }
}
