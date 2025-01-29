namespace ACS_PACLAR
{
    partial class InventoryForm
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
            addBtn = new Button();
            nameBox = new TextBox();
            label3 = new Label();
            label1 = new Label();
            inventoryData = new DataGridView();
            button1 = new Button();
            label2 = new Label();
            quantityBox = new NumericUpDown();
            serviceBox = new ComboBox();
            inventorySearch = new TextBox();
            label4 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)inventoryData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)quantityBox).BeginInit();
            SuspendLayout();
            // 
            // addBtn
            // 
            addBtn.Location = new Point(114, 212);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(54, 23);
            addBtn.TabIndex = 35;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // nameBox
            // 
            nameBox.Location = new Point(138, 111);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(126, 23);
            nameBox.TabIndex = 31;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 148);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 29;
            label3.Text = "Quantity:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 119);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 27;
            label1.Text = "Name:";
            // 
            // inventoryData
            // 
            inventoryData.AllowUserToAddRows = false;
            inventoryData.AllowUserToDeleteRows = false;
            inventoryData.AllowUserToResizeColumns = false;
            inventoryData.AllowUserToResizeRows = false;
            inventoryData.BackgroundColor = SystemColors.GradientActiveCaption;
            inventoryData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            inventoryData.Location = new Point(270, 92);
            inventoryData.MultiSelect = false;
            inventoryData.Name = "inventoryData";
            inventoryData.ReadOnly = true;
            inventoryData.RowHeadersVisible = false;
            inventoryData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            inventoryData.ShowCellErrors = false;
            inventoryData.ShowCellToolTips = false;
            inventoryData.ShowEditingIcon = false;
            inventoryData.ShowRowErrors = false;
            inventoryData.Size = new Size(508, 215);
            inventoryData.TabIndex = 26;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 177);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 40;
            label2.Text = "Service:";
            // 
            // quantityBox
            // 
            quantityBox.Location = new Point(138, 140);
            quantityBox.Name = "quantityBox";
            quantityBox.Size = new Size(126, 23);
            quantityBox.TabIndex = 41;
            // 
            // serviceBox
            // 
            serviceBox.DropDownStyle = ComboBoxStyle.DropDownList;
            serviceBox.FormattingEnabled = true;
            serviceBox.Location = new Point(138, 169);
            serviceBox.Name = "serviceBox";
            serviceBox.Size = new Size(126, 23);
            serviceBox.TabIndex = 42;
            // 
            // inventorySearch
            // 
            inventorySearch.Location = new Point(322, 63);
            inventorySearch.Name = "inventorySearch";
            inventorySearch.Size = new Size(100, 23);
            inventorySearch.TabIndex = 43;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(271, 71);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 44;
            label4.Text = "Search:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(322, 14);
            label6.Name = "label6";
            label6.Size = new Size(128, 21);
            label6.TabIndex = 45;
            label6.Text = "Inventory Form";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // InventoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(790, 319);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(inventorySearch);
            Controls.Add(serviceBox);
            Controls.Add(quantityBox);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(addBtn);
            Controls.Add(nameBox);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(inventoryData);
            Name = "InventoryForm";
            Text = "InventoryForm";
            ((System.ComponentModel.ISupportInitialize)inventoryData).EndInit();
            ((System.ComponentModel.ISupportInitialize)quantityBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button addBtn;
        private TextBox nameBox;
        private Label label3;
        private Label label1;
        private DataGridView inventoryData;
        private Button button1;
        private Label label2;
        private NumericUpDown quantityBox;
        private ComboBox serviceBox;
        private TextBox inventorySearch;
        private Label label4;
        private Label label6;
    }
}