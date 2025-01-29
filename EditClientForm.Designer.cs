namespace ACS_PACLAR
{
    partial class EditClientForm
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
            button1 = new Button();
            label6 = new Label();
            SuspendLayout();
            // 
            // emailBox
            // 
            emailBox.Location = new Point(197, 141);
            emailBox.Name = "emailBox";
            emailBox.Size = new Size(126, 23);
            emailBox.TabIndex = 26;
            // 
            // addressBox
            // 
            addressBox.Location = new Point(197, 112);
            addressBox.Name = "addressBox";
            addressBox.Size = new Size(126, 23);
            addressBox.TabIndex = 25;
            // 
            // contactBox
            // 
            contactBox.Location = new Point(197, 86);
            contactBox.Name = "contactBox";
            contactBox.Size = new Size(126, 23);
            contactBox.TabIndex = 24;
            // 
            // nameBox
            // 
            nameBox.Location = new Point(197, 57);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(126, 23);
            nameBox.TabIndex = 23;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(99, 149);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 22;
            label4.Text = "Email:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(99, 94);
            label3.Name = "label3";
            label3.Size = new Size(99, 15);
            label3.TabIndex = 21;
            label3.Text = "Contact Number:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(99, 120);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 20;
            label2.Text = "Address:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(99, 65);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 19;
            label1.Text = "Name:";
            // 
            // button1
            // 
            button1.Location = new Point(170, 185);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 27;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += saveBtn_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(170, 9);
            label6.Name = "label6";
            label6.Size = new Size(89, 21);
            label6.TabIndex = 28;
            label6.Text = "Edit Client";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // EditClientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(422, 220);
            Controls.Add(label6);
            Controls.Add(button1);
            Controls.Add(emailBox);
            Controls.Add(addressBox);
            Controls.Add(contactBox);
            Controls.Add(nameBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "EditClientForm";
            Text = "EditClientForm";
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
        private Button button1;
        private Label label6;
    }
}