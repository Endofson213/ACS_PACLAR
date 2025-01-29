namespace ACS_PACLAR
{
    partial class EditInventoryForm
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
            serviceBox = new ComboBox();
            quantityBox = new NumericUpDown();
            label2 = new Label();
            addBtn = new Button();
            nameBox = new TextBox();
            label3 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)quantityBox).BeginInit();
            SuspendLayout();
            // 
            // serviceBox
            // 
            serviceBox.DropDownStyle = ComboBoxStyle.DropDownList;
            serviceBox.FormattingEnabled = true;
            serviceBox.Location = new Point(185, 111);
            serviceBox.Name = "serviceBox";
            serviceBox.Size = new Size(126, 23);
            serviceBox.TabIndex = 49;
            // 
            // quantityBox
            // 
            quantityBox.Location = new Point(185, 82);
            quantityBox.Name = "quantityBox";
            quantityBox.Size = new Size(126, 23);
            quantityBox.TabIndex = 48;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(87, 119);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 47;
            label2.Text = "Service:";
            // 
            // addBtn
            // 
            addBtn.Location = new Point(155, 156);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(54, 23);
            addBtn.TabIndex = 46;
            addBtn.Text = "Save";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += saveBtn_Click;
            // 
            // nameBox
            // 
            nameBox.Location = new Point(185, 53);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(126, 23);
            nameBox.TabIndex = 45;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(87, 90);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 44;
            label3.Text = "Quantity:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(87, 61);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 43;
            label1.Text = "Name:";
            // 
            // EditInventoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(373, 207);
            Controls.Add(serviceBox);
            Controls.Add(quantityBox);
            Controls.Add(label2);
            Controls.Add(addBtn);
            Controls.Add(nameBox);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "EditInventoryForm";
            Text = "EditInventoryForm";
            ((System.ComponentModel.ISupportInitialize)quantityBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox serviceBox;
        private NumericUpDown quantityBox;
        private Label label2;
        private Button addBtn;
        private TextBox nameBox;
        private Label label3;
        private Label label1;
    }
}