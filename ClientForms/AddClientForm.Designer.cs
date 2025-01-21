namespace ACS_PACLAR.ClientForms
{
    partial class AddClientForm
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
            emailBox = new TextBox();
            addressBox = new TextBox();
            contactBox = new TextBox();
            nameBox = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label6 = new Label();
            addBtn = new Button();
            SuspendLayout();
            // 
            // emailBox
            // 
            emailBox.Location = new Point(165, 173);
            emailBox.Name = "emailBox";
            emailBox.Size = new Size(126, 23);
            emailBox.TabIndex = 27;
            // 
            // addressBox
            // 
            addressBox.Location = new Point(165, 144);
            addressBox.Name = "addressBox";
            addressBox.Size = new Size(126, 23);
            addressBox.TabIndex = 26;
            // 
            // contactBox
            // 
            contactBox.Location = new Point(165, 118);
            contactBox.Name = "contactBox";
            contactBox.Size = new Size(126, 23);
            contactBox.TabIndex = 25;
            // 
            // nameBox
            // 
            nameBox.Location = new Point(165, 89);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(126, 23);
            nameBox.TabIndex = 24;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(67, 181);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 23;
            label4.Text = "Email:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(67, 126);
            label3.Name = "label3";
            label3.Size = new Size(99, 15);
            label3.TabIndex = 22;
            label3.Text = "Contact Number:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(67, 152);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 21;
            label2.Text = "Address:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 97);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 20;
            label1.Text = "Name:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(136, 20);
            label6.Name = "label6";
            label6.Size = new Size(90, 21);
            label6.TabIndex = 19;
            label6.Text = "Add Client";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(136, 224);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(90, 23);
            addBtn.TabIndex = 28;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // AddClientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(349, 272);
            Controls.Add(addBtn);
            Controls.Add(emailBox);
            Controls.Add(addressBox);
            Controls.Add(contactBox);
            Controls.Add(nameBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label6);
            Name = "AddClientForm";
            Text = "AddClientForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox emailBox;
        private TextBox addressBox;
        private TextBox contactBox;
        private TextBox nameBox;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label6;
        private Button addBtn;
    }
}