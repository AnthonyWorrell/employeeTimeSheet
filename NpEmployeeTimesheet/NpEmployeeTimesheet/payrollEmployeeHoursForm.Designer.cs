using System;

namespace NpEmployeeTimesheet
{
    partial class payrollEmployeeHoursForm
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
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txt_totalHours = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_totalReg = new System.Windows.Forms.TextBox();
            this.txt_totalSick = new System.Windows.Forms.TextBox();
            this.txt_totalHol = new System.Windows.Forms.TextBox();
            this.txt_totalVac = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl_supSig = new System.Windows.Forms.Label();
            this.lbl_employeeSig = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_connection = new System.Windows.Forms.Label();
            this.cmb_employees = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_selected = new System.Windows.Forms.Label();
            this.btn_view = new System.Windows.Forms.Button();
            this.lbl_notes = new System.Windows.Forms.Label();
            this.groupBox7.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txt_totalHours);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.txt_totalReg);
            this.groupBox7.Controls.Add(this.txt_totalSick);
            this.groupBox7.Controls.Add(this.txt_totalHol);
            this.groupBox7.Controls.Add(this.txt_totalVac);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Location = new System.Drawing.Point(251, 115);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(212, 200);
            this.groupBox7.TabIndex = 50;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Pay Period Totals";
            // 
            // txt_totalHours
            // 
            this.txt_totalHours.Location = new System.Drawing.Point(136, 162);
            this.txt_totalHours.Name = "txt_totalHours";
            this.txt_totalHours.ReadOnly = true;
            this.txt_totalHours.Size = new System.Drawing.Size(49, 20);
            this.txt_totalHours.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Hours Worked";
            // 
            // txt_totalReg
            // 
            this.txt_totalReg.Location = new System.Drawing.Point(136, 126);
            this.txt_totalReg.Name = "txt_totalReg";
            this.txt_totalReg.ReadOnly = true;
            this.txt_totalReg.Size = new System.Drawing.Size(49, 20);
            this.txt_totalReg.TabIndex = 11;
            // 
            // txt_totalSick
            // 
            this.txt_totalSick.Location = new System.Drawing.Point(136, 93);
            this.txt_totalSick.Name = "txt_totalSick";
            this.txt_totalSick.ReadOnly = true;
            this.txt_totalSick.Size = new System.Drawing.Size(49, 20);
            this.txt_totalSick.TabIndex = 10;
            // 
            // txt_totalHol
            // 
            this.txt_totalHol.Location = new System.Drawing.Point(136, 60);
            this.txt_totalHol.Name = "txt_totalHol";
            this.txt_totalHol.ReadOnly = true;
            this.txt_totalHol.Size = new System.Drawing.Size(49, 20);
            this.txt_totalHol.TabIndex = 9;
            // 
            // txt_totalVac
            // 
            this.txt_totalVac.Location = new System.Drawing.Point(136, 29);
            this.txt_totalVac.Name = "txt_totalVac";
            this.txt_totalVac.ReadOnly = true;
            this.txt_totalVac.Size = new System.Drawing.Size(49, 20);
            this.txt_totalVac.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Regular Hours";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Sick Hours";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Holiday Hours";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Vacation Hours";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbl_supSig);
            this.groupBox3.Controls.Add(this.lbl_employeeSig);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Location = new System.Drawing.Point(251, 321);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(212, 98);
            this.groupBox3.TabIndex = 47;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Signature";
            // 
            // lbl_supSig
            // 
            this.lbl_supSig.AutoSize = true;
            this.lbl_supSig.Location = new System.Drawing.Point(139, 68);
            this.lbl_supSig.Name = "lbl_supSig";
            this.lbl_supSig.Size = new System.Drawing.Size(56, 13);
            this.lbl_supSig.TabIndex = 7;
            this.lbl_supSig.Text = "not signed";
            // 
            // lbl_employeeSig
            // 
            this.lbl_employeeSig.AutoSize = true;
            this.lbl_employeeSig.Location = new System.Drawing.Point(139, 35);
            this.lbl_employeeSig.Name = "lbl_employeeSig";
            this.lbl_employeeSig.Size = new System.Drawing.Size(56, 13);
            this.lbl_employeeSig.TabIndex = 6;
            this.lbl_employeeSig.Text = "not signed";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Employee Status:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(20, 68);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(93, 13);
            this.label26.TabIndex = 1;
            this.label26.Text = "Supervisor Status:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_connection);
            this.groupBox1.Location = new System.Drawing.Point(3, 410);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 37);
            this.groupBox1.TabIndex = 51;
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
            // cmb_employees
            // 
            this.cmb_employees.FormattingEnabled = true;
            this.cmb_employees.Location = new System.Drawing.Point(105, 75);
            this.cmb_employees.Name = "cmb_employees";
            this.cmb_employees.Size = new System.Drawing.Size(121, 21);
            this.cmb_employees.TabIndex = 53;
            this.cmb_employees.SelectedIndexChanged += new System.EventHandler(this.cmb_employees_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Employee Name:";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(12, 9);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(35, 13);
            this.lbl_name.TabIndex = 54;
            this.lbl_name.Text = "Name";
            // 
            // lbl_selected
            // 
            this.lbl_selected.AutoSize = true;
            this.lbl_selected.Location = new System.Drawing.Point(287, 78);
            this.lbl_selected.Name = "lbl_selected";
            this.lbl_selected.Size = new System.Drawing.Size(129, 13);
            this.lbl_selected.TabIndex = 55;
            this.lbl_selected.Text = "Selected Employee Name";
            // 
            // btn_view
            // 
            this.btn_view.Location = new System.Drawing.Point(125, 115);
            this.btn_view.Name = "btn_view";
            this.btn_view.Size = new System.Drawing.Size(75, 23);
            this.btn_view.TabIndex = 56;
            this.btn_view.Text = "View Notes";
            this.btn_view.UseVisualStyleBackColor = true;
            this.btn_view.Click += new System.EventHandler(this.btn_view_Click);
            // 
            // lbl_notes
            // 
            this.lbl_notes.AutoSize = true;
            this.lbl_notes.Location = new System.Drawing.Point(136, 144);
            this.lbl_notes.Name = "lbl_notes";
            this.lbl_notes.Size = new System.Drawing.Size(52, 13);
            this.lbl_notes.TabIndex = 57;
            this.lbl_notes.Text = "No Notes";
            // 
            // payrollEmployeeHoursForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 450);
            this.Controls.Add(this.lbl_notes);
            this.Controls.Add(this.btn_view);
            this.Controls.Add(this.lbl_selected);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.cmb_employees);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox3);
            this.Name = "payrollEmployeeHoursForm";
            this.Text = "payrollEmployeeHoursForm";
            this.Load += new System.EventHandler(this.payrollEmployeeHoursForm_Load);
            this.Shown += new System.EventHandler(this.payrollEmployeeHoursForm_Loaded);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        

        #endregion

        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txt_totalHours;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_totalReg;
        private System.Windows.Forms.TextBox txt_totalSick;
        private System.Windows.Forms.TextBox txt_totalHol;
        private System.Windows.Forms.TextBox txt_totalVac;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbl_supSig;
        private System.Windows.Forms.Label lbl_employeeSig;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_connection;
        private System.Windows.Forms.ComboBox cmb_employees;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_selected;
        private System.Windows.Forms.Button btn_view;
        private System.Windows.Forms.Label lbl_notes;
    }
}