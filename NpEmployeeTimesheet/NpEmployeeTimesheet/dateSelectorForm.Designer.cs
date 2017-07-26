namespace NpEmployeeTimesheet
{
    partial class dateSelectorForm
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
            this.msc_daySelector = new System.Windows.Forms.MonthCalendar();
            this.btn_enter = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_connection = new System.Windows.Forms.Label();
            this.lbl_empName = new System.Windows.Forms.Label();
            this.btn_viewEmployeeSheets = new System.Windows.Forms.Button();
            this.btn_viewHours = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // msc_daySelector
            // 
            this.msc_daySelector.Location = new System.Drawing.Point(27, 38);
            this.msc_daySelector.MaxSelectionCount = 14;
            this.msc_daySelector.Name = "msc_daySelector";
            this.msc_daySelector.TabIndex = 0;
            // 
            // btn_enter
            // 
            this.btn_enter.Location = new System.Drawing.Point(103, 219);
            this.btn_enter.Name = "btn_enter";
            this.btn_enter.Size = new System.Drawing.Size(75, 23);
            this.btn_enter.TabIndex = 1;
            this.btn_enter.Text = "Enter Hours";
            this.btn_enter.UseVisualStyleBackColor = true;
            this.btn_enter.Click += new System.EventHandler(this.btn_enter_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_connection);
            this.groupBox1.Location = new System.Drawing.Point(3, 325);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 37);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Status";
            // 
            // lbl_connection
            // 
            this.lbl_connection.AutoSize = true;
            this.lbl_connection.Location = new System.Drawing.Point(6, 16);
            this.lbl_connection.Name = "lbl_connection";
            this.lbl_connection.Size = new System.Drawing.Size(61, 13);
            this.lbl_connection.TabIndex = 0;
            this.lbl_connection.Text = "Connection";
            // 
            // lbl_empName
            // 
            this.lbl_empName.AutoSize = true;
            this.lbl_empName.Location = new System.Drawing.Point(10, 10);
            this.lbl_empName.Name = "lbl_empName";
            this.lbl_empName.Size = new System.Drawing.Size(81, 13);
            this.lbl_empName.TabIndex = 13;
            this.lbl_empName.Text = "employee name";
            // 
            // btn_viewEmployeeSheets
            // 
            this.btn_viewEmployeeSheets.Location = new System.Drawing.Point(79, 254);
            this.btn_viewEmployeeSheets.Name = "btn_viewEmployeeSheets";
            this.btn_viewEmployeeSheets.Size = new System.Drawing.Size(127, 23);
            this.btn_viewEmployeeSheets.TabIndex = 14;
            this.btn_viewEmployeeSheets.Text = "View Employee Sheets";
            this.btn_viewEmployeeSheets.UseVisualStyleBackColor = true;
            this.btn_viewEmployeeSheets.Visible = false;
            this.btn_viewEmployeeSheets.Click += new System.EventHandler(this.btn_viewEmployeeSheets_Click);
            // 
            // btn_viewHours
            // 
            this.btn_viewHours.Location = new System.Drawing.Point(79, 283);
            this.btn_viewHours.Name = "btn_viewHours";
            this.btn_viewHours.Size = new System.Drawing.Size(127, 23);
            this.btn_viewHours.TabIndex = 15;
            this.btn_viewHours.Text = "View Employee Hours";
            this.btn_viewHours.UseVisualStyleBackColor = true;
            this.btn_viewHours.Visible = false;
            this.btn_viewHours.Click += new System.EventHandler(this.btn_viewHours_Click);
            // 
            // dateSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 365);
            this.Controls.Add(this.btn_viewHours);
            this.Controls.Add(this.btn_viewEmployeeSheets);
            this.Controls.Add(this.lbl_empName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_enter);
            this.Controls.Add(this.msc_daySelector);
            this.Name = "dateSelectorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dateSelectorForm";
            this.Load += new System.EventHandler(this.dateSelectorForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar msc_daySelector;
        private System.Windows.Forms.Button btn_enter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_connection;
        private System.Windows.Forms.Label lbl_empName;
        private System.Windows.Forms.Button btn_viewEmployeeSheets;
        private System.Windows.Forms.Button btn_viewHours;
    }
}