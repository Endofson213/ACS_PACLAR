namespace ACS_PACLAR
{
    partial class ClientsForm
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
            clientsData = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            nameBox = new TextBox();
            contactBox = new TextBox();
            addressBox = new TextBox();
            emailBox = new TextBox();
            addBtn = new Button();
            label6 = new Label();
            button1 = new Button();
            clientSearch = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)clientsData).BeginInit();
            SuspendLayout();
            // 
            // clientsData
            // 
            clientsData.AllowUserToAddRows = false;
            clientsData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            clientsData.Location = new Point(22, 266);
            clientsData.Name = "clientsData";
            clientsData.ReadOnly = true;
            clientsData.Size = new Size(688, 186);
            clientsData.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(229, 95);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 3;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(229, 150);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 4;
            label2.Text = "Address:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(229, 124);
            label3.Name = "label3";
            label3.Size = new Size(99, 15);
            label3.TabIndex = 5;
            label3.Text = "Contact Number:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(229, 179);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 6;
            label4.Text = "Email:";
            // 
            // nameBox
            // 
            nameBox.Location = new Point(327, 87);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(126, 23);
            nameBox.TabIndex = 8;
            // 
            // contactBox
            // 
            contactBox.Location = new Point(327, 116);
            contactBox.Name = "contactBox";
            contactBox.Size = new Size(126, 23);
            contactBox.TabIndex = 16;
            // 
            // addressBox
            // 
            addressBox.Location = new Point(327, 142);
            addressBox.Name = "addressBox";
            addressBox.Size = new Size(126, 23);
            addressBox.TabIndex = 17;
            // 
            // emailBox
            // 
            emailBox.Location = new Point(327, 171);
            emailBox.Name = "emailBox";
            emailBox.Size = new Size(126, 23);
            emailBox.TabIndex = 18;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(327, 213);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(54, 23);
            addBtn.TabIndex = 19;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(303, 26);
            label6.Name = "label6";
            label6.Size = new Size(90, 21);
            label6.TabIndex = 1;
            label6.Text = "Add Client";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(63, 23);
            button1.TabIndex = 24;
            button1.Text = "Go Back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += backBtn_Click;
            // 
            // clientSearch
            // 
            clientSearch.AcceptsReturn = true;
            clientSearch.Location = new Point(88, 237);
            clientSearch.Name = "clientSearch";
            clientSearch.Size = new Size(100, 23);
            clientSearch.TabIndex = 25;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(37, 240);
            label5.Name = "label5";
            label5.Size = new Size(45, 15);
            label5.TabIndex = 26;
            label5.Text = "Search:";
            // 
            // ClientsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(733, 506);
            Controls.Add(label5);
            Controls.Add(clientSearch);
            Controls.Add(button1);
            Controls.Add(addBtn);
            Controls.Add(emailBox);
            Controls.Add(addressBox);
            Controls.Add(contactBox);
            Controls.Add(nameBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(clientsData);
            Controls.Add(label6);
            Name = "ClientsForm";
            Text = "ClientsForm";
            Load += ClientsForm_Load;
            ((System.ComponentModel.ISupportInitialize)clientsData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView clientsData;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox nameBox;
        private TextBox contactBox;
        private TextBox addressBox;
        private TextBox emailBox;
        private Button addBtn;
        private Label label6;
        private Button button1;
        private TextBox clientSearch;
        private Label label5;
    }
}