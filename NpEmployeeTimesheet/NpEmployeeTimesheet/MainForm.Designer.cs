namespace NpEmployeeTimesheet
{
    partial class MainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_connection = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.lbl_empName = new System.Windows.Forms.Label();
            this.btn_selDate = new System.Windows.Forms.Button();
            this.btn_updateSig = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_connection);
            this.groupBox1.Location = new System.Drawing.Point(8, 218);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 37);
            this.groupBox1.TabIndex = 10;
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
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(63, 149);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(97, 23);
            this.btn_add.TabIndex = 11;
            this.btn_add.Text = "Add New User";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Visible = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // lbl_empName
            // 
            this.lbl_empName.AutoSize = true;
            this.lbl_empName.Location = new System.Drawing.Point(14, 18);
            this.lbl_empName.Name = "lbl_empName";
            this.lbl_empName.Size = new System.Drawing.Size(81, 13);
            this.lbl_empName.TabIndex = 12;
            this.lbl_empName.Text = "employee name";
            // 
            // btn_selDate
            // 
            this.btn_selDate.Location = new System.Drawing.Point(63, 59);
            this.btn_selDate.Name = "btn_selDate";
            this.btn_selDate.Size = new System.Drawing.Size(97, 23);
            this.btn_selDate.TabIndex = 13;
            this.btn_selDate.Text = "Select Date";
            this.btn_selDate.UseVisualStyleBackColor = true;
            this.btn_selDate.Click += new System.EventHandler(this.btn_selDate_Click);
            // 
            // btn_updateSig
            // 
            this.btn_updateSig.Location = new System.Drawing.Point(63, 103);
            this.btn_updateSig.Name = "btn_updateSig";
            this.btn_updateSig.Size = new System.Drawing.Size(97, 23);
            this.btn_updateSig.TabIndex = 14;
            this.btn_updateSig.Text = "Update Signiture";
            this.btn_updateSig.UseVisualStyleBackColor = true;
            this.btn_updateSig.Click += new System.EventHandler(this.btn_updateSig_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 262);
            this.Controls.Add(this.btn_updateSig);
            this.Controls.Add(this.btn_selDate);
            this.Controls.Add(this.lbl_empName);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu Form";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_connection;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label lbl_empName;
        private System.Windows.Forms.Button btn_selDate;
        private System.Windows.Forms.Button btn_updateSig;
    }
}

