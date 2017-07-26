namespace NpEmployeeTimesheet
{
    partial class employeeListForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.chb_all = new System.Windows.Forms.CheckBox();
            this.cmb_employees = new System.Windows.Forms.ComboBox();
            this.txt_sign = new System.Windows.Forms.Label();
            this.txt_empSig = new System.Windows.Forms.TextBox();
            this.btn_sign = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_connection = new System.Windows.Forms.Label();
            this.lbl_empName = new System.Windows.Forms.Label();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_view = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Name:";
            // 
            // chb_all
            // 
            this.chb_all.AutoSize = true;
            this.chb_all.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chb_all.Location = new System.Drawing.Point(52, 78);
            this.chb_all.Name = "chb_all";
            this.chb_all.Size = new System.Drawing.Size(67, 17);
            this.chb_all.TabIndex = 2;
            this.chb_all.Text = "Show All";
            this.chb_all.UseVisualStyleBackColor = true;
            // 
            // cmb_employees
            // 
            this.cmb_employees.FormattingEnabled = true;
            this.cmb_employees.Location = new System.Drawing.Point(125, 41);
            this.cmb_employees.Name = "cmb_employees";
            this.cmb_employees.Size = new System.Drawing.Size(121, 21);
            this.cmb_employees.TabIndex = 3;
            // 
            // txt_sign
            // 
            this.txt_sign.AutoSize = true;
            this.txt_sign.Location = new System.Drawing.Point(56, 156);
            this.txt_sign.Name = "txt_sign";
            this.txt_sign.Size = new System.Drawing.Size(63, 13);
            this.txt_sign.TabIndex = 4;
            this.txt_sign.Text = "E-signature:";
            // 
            // txt_empSig
            // 
            this.txt_empSig.Location = new System.Drawing.Point(125, 153);
            this.txt_empSig.Name = "txt_empSig";
            this.txt_empSig.PasswordChar = '*';
            this.txt_empSig.Size = new System.Drawing.Size(100, 20);
            this.txt_empSig.TabIndex = 5;
            // 
            // btn_sign
            // 
            this.btn_sign.Location = new System.Drawing.Point(139, 179);
            this.btn_sign.Name = "btn_sign";
            this.btn_sign.Size = new System.Drawing.Size(75, 23);
            this.btn_sign.TabIndex = 6;
            this.btn_sign.Text = "Sign";
            this.btn_sign.UseVisualStyleBackColor = true;
            this.btn_sign.Click += new System.EventHandler(this.btn_sign_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_connection);
            this.groupBox1.Location = new System.Drawing.Point(2, 198);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 37);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Status";
            // 
            // lbl_connection
            // 
            this.lbl_connection.AutoSize = true;
            this.lbl_connection.Location = new System.Drawing.Point(6, 17);
            this.lbl_connection.Name = "lbl_connection";
            this.lbl_connection.Size = new System.Drawing.Size(61, 13);
            this.lbl_connection.TabIndex = 0;
            this.lbl_connection.Text = "Connection";
            // 
            // lbl_empName
            // 
            this.lbl_empName.AutoSize = true;
            this.lbl_empName.Location = new System.Drawing.Point(12, 9);
            this.lbl_empName.Name = "lbl_empName";
            this.lbl_empName.Size = new System.Drawing.Size(81, 13);
            this.lbl_empName.TabIndex = 14;
            this.lbl_empName.Text = "employee name";
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(150, 74);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 15;
            this.btn_update.Text = "Update List";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_view
            // 
            this.btn_view.Location = new System.Drawing.Point(150, 103);
            this.btn_view.Name = "btn_view";
            this.btn_view.Size = new System.Drawing.Size(75, 23);
            this.btn_view.TabIndex = 16;
            this.btn_view.Text = "view";
            this.btn_view.UseVisualStyleBackColor = true;
            this.btn_view.Click += new System.EventHandler(this.btn_view_Click);
            // 
            // employeeListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 238);
            this.Controls.Add(this.btn_view);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.lbl_empName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_sign);
            this.Controls.Add(this.txt_empSig);
            this.Controls.Add(this.txt_sign);
            this.Controls.Add(this.cmb_employees);
            this.Controls.Add(this.chb_all);
            this.Controls.Add(this.label1);
            this.Name = "employeeListForm";
            this.Text = "employeeListForm";
            this.Load += new System.EventHandler(this.employeeListForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chb_all;
        private System.Windows.Forms.ComboBox cmb_employees;
        private System.Windows.Forms.Label txt_sign;
        private System.Windows.Forms.TextBox txt_empSig;
        private System.Windows.Forms.Button btn_sign;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_connection;
        private System.Windows.Forms.Label lbl_empName;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_view;
    }
}