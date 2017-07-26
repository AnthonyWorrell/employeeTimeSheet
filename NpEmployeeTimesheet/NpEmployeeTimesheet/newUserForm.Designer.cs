namespace NpEmployeeTimesheet
{
    partial class newUserForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_firstName = new System.Windows.Forms.TextBox();
            this.txt_lastName = new System.Windows.Forms.TextBox();
            this.txt_userName = new System.Windows.Forms.TextBox();
            this.cmb_superName = new System.Windows.Forms.ComboBox();
            this.btn_enter = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_connection = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_empNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_userRank = new System.Windows.Forms.ComboBox();
            this.cb_payrollPermission = new System.Windows.Forms.CheckBox();
            this.cb_msPermission = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "User Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Supervisor Name:";
            // 
            // txt_firstName
            // 
            this.txt_firstName.Location = new System.Drawing.Point(132, 31);
            this.txt_firstName.Name = "txt_firstName";
            this.txt_firstName.Size = new System.Drawing.Size(100, 20);
            this.txt_firstName.TabIndex = 6;
            this.txt_firstName.LostFocus += new System.EventHandler(this.txt_firstName_LostFocus);
            // 
            // txt_lastName
            // 
            this.txt_lastName.Location = new System.Drawing.Point(132, 72);
            this.txt_lastName.Name = "txt_lastName";
            this.txt_lastName.Size = new System.Drawing.Size(100, 20);
            this.txt_lastName.TabIndex = 7;
            this.txt_lastName.LostFocus += new System.EventHandler(this.txt_lastName_LostFocus);
            // 
            // txt_userName
            // 
            this.txt_userName.Location = new System.Drawing.Point(132, 110);
            this.txt_userName.Name = "txt_userName";
            this.txt_userName.ReadOnly = true;
            this.txt_userName.Size = new System.Drawing.Size(100, 20);
            this.txt_userName.TabIndex = 8;
            // 
            // cmb_superName
            // 
            this.cmb_superName.DisplayMember = "1";
            this.cmb_superName.FormattingEnabled = true;
            this.cmb_superName.Items.AddRange(new object[] {
            "User",
            "Supervisor",
            "Administrator"});
            this.cmb_superName.Location = new System.Drawing.Point(132, 193);
            this.cmb_superName.Name = "cmb_superName";
            this.cmb_superName.Size = new System.Drawing.Size(101, 21);
            this.cmb_superName.TabIndex = 10;
            this.cmb_superName.ValueMember = "1 2 3";
            // 
            // btn_enter
            // 
            this.btn_enter.Location = new System.Drawing.Point(98, 306);
            this.btn_enter.Name = "btn_enter";
            this.btn_enter.Size = new System.Drawing.Size(75, 23);
            this.btn_enter.TabIndex = 12;
            this.btn_enter.Text = "Enter";
            this.btn_enter.UseVisualStyleBackColor = true;
            this.btn_enter.Click += new System.EventHandler(this.btn_enter_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_connection);
            this.groupBox1.Location = new System.Drawing.Point(7, 345);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 37);
            this.groupBox1.TabIndex = 13;
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Employee #:";
            // 
            // txt_empNumber
            // 
            this.txt_empNumber.Location = new System.Drawing.Point(132, 238);
            this.txt_empNumber.Name = "txt_empNumber";
            this.txt_empNumber.Size = new System.Drawing.Size(100, 20);
            this.txt_empNumber.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "User Rank:";
            // 
            // cmb_userRank
            // 
            this.cmb_userRank.FormattingEnabled = true;
            this.cmb_userRank.Location = new System.Drawing.Point(132, 153);
            this.cmb_userRank.Name = "cmb_userRank";
            this.cmb_userRank.Size = new System.Drawing.Size(100, 21);
            this.cmb_userRank.TabIndex = 9;
            // 
            // cb_payrollPermission
            // 
            this.cb_payrollPermission.AutoSize = true;
            this.cb_payrollPermission.Location = new System.Drawing.Point(16, 275);
            this.cb_payrollPermission.Name = "cb_payrollPermission";
            this.cb_payrollPermission.Size = new System.Drawing.Size(110, 17);
            this.cb_payrollPermission.TabIndex = 15;
            this.cb_payrollPermission.Text = "Payroll Permission";
            this.cb_payrollPermission.UseVisualStyleBackColor = true;
            // 
            // cb_msPermission
            // 
            this.cb_msPermission.AutoSize = true;
            this.cb_msPermission.Location = new System.Drawing.Point(148, 275);
            this.cb_msPermission.Name = "cb_msPermission";
            this.cb_msPermission.Size = new System.Drawing.Size(138, 17);
            this.cb_msPermission.TabIndex = 16;
            this.cb_msPermission.Text = "Med Sample Permission";
            this.cb_msPermission.UseVisualStyleBackColor = true;
            // 
            // newUserForm
            // 
            this.AcceptButton = this.btn_enter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(294, 392);
            this.Controls.Add(this.cb_msPermission);
            this.Controls.Add(this.cb_payrollPermission);
            this.Controls.Add(this.txt_empNumber);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_enter);
            this.Controls.Add(this.cmb_superName);
            this.Controls.Add(this.cmb_userRank);
            this.Controls.Add(this.txt_userName);
            this.Controls.Add(this.txt_lastName);
            this.Controls.Add(this.txt_firstName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "newUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "newUserForm";
            this.Load += new System.EventHandler(this.newUserForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_firstName;
        private System.Windows.Forms.TextBox txt_lastName;
        private System.Windows.Forms.TextBox txt_userName;
        private System.Windows.Forms.ComboBox cmb_superName;
        private System.Windows.Forms.Button btn_enter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_connection;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_empNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_userRank;
        private System.Windows.Forms.CheckBox cb_payrollPermission;
        private System.Windows.Forms.CheckBox cb_msPermission;
    }
}