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
            addBtn = new Button();
            button1 = new Button();
            clientSearch = new TextBox();
            label5 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)clientsData).BeginInit();
            SuspendLayout();
            // 
            // clientsData
            // 
            clientsData.AllowUserToAddRows = false;
            clientsData.AllowUserToDeleteRows = false;
            clientsData.AllowUserToResizeColumns = false;
            clientsData.AllowUserToResizeRows = false;
            clientsData.BackgroundColor = SystemColors.GradientActiveCaption;
            clientsData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            clientsData.EditMode = DataGridViewEditMode.EditProgrammatically;
            clientsData.Location = new Point(12, 85);
            clientsData.MultiSelect = false;
            clientsData.Name = "clientsData";
            clientsData.ReadOnly = true;
            clientsData.RowHeadersVisible = false;
            clientsData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            clientsData.ShowCellErrors = false;
            clientsData.ShowCellToolTips = false;
            clientsData.ShowEditingIcon = false;
            clientsData.ShowRowErrors = false;
            clientsData.Size = new Size(613, 186);
            clientsData.TabIndex = 2;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(184, 56);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(83, 23);
            addBtn.TabIndex = 19;
            addBtn.Text = "Add Client";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
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
            clientSearch.Location = new Point(363, 56);
            clientSearch.Name = "clientSearch";
            clientSearch.Size = new Size(100, 23);
            clientSearch.TabIndex = 25;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(312, 64);
            label5.Name = "label5";
            label5.Size = new Size(45, 15);
            label5.TabIndex = 26;
            label5.Text = "Search:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(258, 12);
            label1.Name = "label1";
            label1.Size = new Size(105, 21);
            label1.TabIndex = 27;
            label1.Text = "Clients Form";
            // 
            // ClientsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(637, 285);
            Controls.Add(label1);
            Controls.Add(label5);
            Controls.Add(clientSearch);
            Controls.Add(button1);
            Controls.Add(addBtn);
            Controls.Add(clientsData);
            Name = "ClientsForm";
            Text = "ClientsForm";
            Load += ClientsForm_Load;
            ((System.ComponentModel.ISupportInitialize)clientsData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView clientsData;
        private Button addBtn;
        private Button button1;
        private TextBox clientSearch;
        private Label label5;
        private Label label1;
    }
}