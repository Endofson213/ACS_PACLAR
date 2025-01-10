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
            Title = new Label();
            clientsData = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            nameBox = new TextBox();
            addressBox = new TextBox();
            contactBox = new TextBox();
            emailBox = new TextBox();
            notesBox = new TextBox();
            addBtn = new Button();
            editBtn = new Button();
            deleteBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)clientsData).BeginInit();
            SuspendLayout();
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            Title.Location = new Point(130, 9);
            Title.Name = "Title";
            Title.Size = new Size(529, 54);
            Title.TabIndex = 1;
            Title.Text = "Client Profile Management";
            Title.TextAlign = ContentAlignment.TopCenter;
            // 
            // clientsData
            // 
            clientsData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            clientsData.Location = new Point(290, 66);
            clientsData.Name = "clientsData";
            clientsData.ReadOnly = true;
            clientsData.Size = new Size(498, 372);
            clientsData.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 80);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 3;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 106);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 4;
            label2.Text = "Address:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 135);
            label3.Name = "label3";
            label3.Size = new Size(99, 15);
            label3.TabIndex = 5;
            label3.Text = "Contact Number:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 160);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 6;
            label4.Text = "Email:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 185);
            label5.Name = "label5";
            label5.Size = new Size(41, 15);
            label5.TabIndex = 7;
            label5.Text = "Notes:";
            // 
            // nameBox
            // 
            nameBox.Location = new Point(110, 72);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(126, 23);
            nameBox.TabIndex = 8;
            // 
            // addressBox
            // 
            addressBox.Location = new Point(110, 101);
            addressBox.Name = "addressBox";
            addressBox.Size = new Size(126, 23);
            addressBox.TabIndex = 9;
            // 
            // contactBox
            // 
            contactBox.Location = new Point(110, 130);
            contactBox.Name = "contactBox";
            contactBox.Size = new Size(126, 23);
            contactBox.TabIndex = 10;
            // 
            // emailBox
            // 
            emailBox.Location = new Point(110, 156);
            emailBox.Name = "emailBox";
            emailBox.Size = new Size(126, 23);
            emailBox.TabIndex = 11;
            // 
            // notesBox
            // 
            notesBox.Location = new Point(110, 182);
            notesBox.Name = "notesBox";
            notesBox.Size = new Size(126, 23);
            notesBox.TabIndex = 12;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(34, 224);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(52, 23);
            addBtn.TabIndex = 13;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // editBtn
            // 
            editBtn.Location = new Point(110, 224);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(52, 23);
            editBtn.TabIndex = 14;
            editBtn.Text = "Edit";
            editBtn.UseVisualStyleBackColor = true;
            editBtn.Click += editBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(184, 224);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(52, 23);
            deleteBtn.TabIndex = 15;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // ClientsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(800, 450);
            Controls.Add(deleteBtn);
            Controls.Add(editBtn);
            Controls.Add(addBtn);
            Controls.Add(notesBox);
            Controls.Add(emailBox);
            Controls.Add(contactBox);
            Controls.Add(addressBox);
            Controls.Add(nameBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(clientsData);
            Controls.Add(Title);
            Name = "ClientsForm";
            Text = "ClientsForm";
            Load += ClientsForm_Load;
            ((System.ComponentModel.ISupportInitialize)clientsData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Title;
        private DataGridView clientsData;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox nameBox;
        private TextBox addressBox;
        private TextBox contactBox;
        private TextBox emailBox;
        private TextBox notesBox;
        private Button addBtn;
        private Button editBtn;
        private Button deleteBtn;
    }
}