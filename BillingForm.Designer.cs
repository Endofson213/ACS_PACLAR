﻿namespace ACS_PACLAR
{
    partial class BillingForm
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
            billingSearch = new TextBox();
            label1 = new Label();
            backBtn = new Button();
            billingData = new DataGridView();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)billingData).BeginInit();
            SuspendLayout();
            // 
            // billingSearch
            // 
            billingSearch.Location = new Point(63, 68);
            billingSearch.Name = "billingSearch";
            billingSearch.Size = new Size(120, 23);
            billingSearch.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 76);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 2;
            label1.Text = "Search:";
            // 
            // backBtn
            // 
            backBtn.Location = new Point(12, 12);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(63, 23);
            backBtn.TabIndex = 25;
            backBtn.Text = "Go Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // billingData
            // 
            billingData.AllowUserToAddRows = false;
            billingData.AllowUserToDeleteRows = false;
            billingData.AllowUserToResizeColumns = false;
            billingData.AllowUserToResizeRows = false;
            billingData.BackgroundColor = SystemColors.GradientActiveCaption;
            billingData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            billingData.EditMode = DataGridViewEditMode.EditProgrammatically;
            billingData.Location = new Point(6, 97);
            billingData.MultiSelect = false;
            billingData.Name = "billingData";
            billingData.ReadOnly = true;
            billingData.RowHeadersVisible = false;
            billingData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            billingData.ShowCellErrors = false;
            billingData.ShowCellToolTips = false;
            billingData.ShowEditingIcon = false;
            billingData.ShowRowErrors = false;
            billingData.Size = new Size(759, 242);
            billingData.TabIndex = 26;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(323, 14);
            label6.Name = "label6";
            label6.Size = new Size(103, 21);
            label6.TabIndex = 27;
            label6.Text = "Billing Form";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // BillingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(769, 341);
            Controls.Add(label6);
            Controls.Add(billingData);
            Controls.Add(backBtn);
            Controls.Add(label1);
            Controls.Add(billingSearch);
            Name = "BillingForm";
            Text = "BillingForm";
            ((System.ComponentModel.ISupportInitialize)billingData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox billingSearch;
        private Label label1;
        private Button backBtn;
        private DataGridView billingData;
        private Label label6;
    }
}