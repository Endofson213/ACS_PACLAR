namespace ACS_PACLAR
{
    partial class ServicesForm
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
            button2 = new Button();
            deleteBtn = new Button();
            editBtn = new Button();
            addBtn = new Button();
            hourlyrateBox = new TextBox();
            nameBox = new TextBox();
            label3 = new Label();
            label1 = new Label();
            servicesData = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)servicesData).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(224, 152);
            button2.Name = "button2";
            button2.Size = new Size(55, 23);
            button2.TabIndex = 38;
            button2.Text = "Clear";
            button2.UseVisualStyleBackColor = true;
            button2.Click += clearBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(164, 152);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(54, 23);
            deleteBtn.TabIndex = 37;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // editBtn
            // 
            editBtn.Location = new Point(104, 152);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(54, 23);
            editBtn.TabIndex = 36;
            editBtn.Text = "Edit";
            editBtn.UseVisualStyleBackColor = true;
            editBtn.Click += editBtn_Click;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(42, 152);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(54, 23);
            addBtn.TabIndex = 35;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // hourlyrateBox
            // 
            hourlyrateBox.Location = new Point(143, 98);
            hourlyrateBox.Name = "hourlyrateBox";
            hourlyrateBox.Size = new Size(126, 23);
            hourlyrateBox.TabIndex = 32;
            // 
            // nameBox
            // 
            nameBox.Location = new Point(143, 69);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(126, 23);
            nameBox.TabIndex = 31;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 106);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 29;
            label3.Text = "Hourly Rate:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 77);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 27;
            label1.Text = "Service Name:";
            // 
            // servicesData
            // 
            servicesData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            servicesData.Location = new Point(314, 50);
            servicesData.Name = "servicesData";
            servicesData.ReadOnly = true;
            servicesData.Size = new Size(269, 215);
            servicesData.TabIndex = 26;
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(63, 23);
            button1.TabIndex = 39;
            button1.Text = "Go Back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += backBtn_Click;
            // 
            // ServicesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(595, 280);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(deleteBtn);
            Controls.Add(editBtn);
            Controls.Add(addBtn);
            Controls.Add(hourlyrateBox);
            Controls.Add(nameBox);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(servicesData);
            Name = "ServicesForm";
            Text = "ServicesForm";
            ((System.ComponentModel.ISupportInitialize)servicesData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Button deleteBtn;
        private Button editBtn;
        private Button addBtn;
        private TextBox hourlyrateBox;
        private TextBox nameBox;
        private Label label3;
        private Label label1;
        private DataGridView servicesData;
        private Button button1;
    }
}