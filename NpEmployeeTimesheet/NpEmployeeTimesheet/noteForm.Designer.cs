namespace NpEmployeeTimesheet
{
    partial class noteForm
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
            this.txt_notes = new System.Windows.Forms.TextBox();
            this.btn_sub = new System.Windows.Forms.Button();
            this.lbl_name = new System.Windows.Forms.Label();
            this.btn_check = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_notes
            // 
            this.txt_notes.Location = new System.Drawing.Point(12, 32);
            this.txt_notes.Multiline = true;
            this.txt_notes.Name = "txt_notes";
            this.txt_notes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_notes.Size = new System.Drawing.Size(406, 189);
            this.txt_notes.TabIndex = 0;
            // 
            // btn_sub
            // 
            this.btn_sub.Location = new System.Drawing.Point(77, 235);
            this.btn_sub.Name = "btn_sub";
            this.btn_sub.Size = new System.Drawing.Size(75, 23);
            this.btn_sub.TabIndex = 1;
            this.btn_sub.Text = "Submit";
            this.btn_sub.UseVisualStyleBackColor = true;
            this.btn_sub.Click += new System.EventHandler(this.btn_sub_Click);
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(12, 9);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(35, 13);
            this.lbl_name.TabIndex = 6;
            this.lbl_name.Text = "Name";
            // 
            // btn_check
            // 
            this.btn_check.Location = new System.Drawing.Point(283, 235);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(75, 23);
            this.btn_check.TabIndex = 7;
            this.btn_check.Text = "Check";
            this.btn_check.UseVisualStyleBackColor = true;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // noteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 270);
            this.Controls.Add(this.btn_check);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.btn_sub);
            this.Controls.Add(this.txt_notes);
            this.Name = "noteForm";
            this.Text = "noteForm";
            this.Load += new System.EventHandler(this.noteForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_notes;
        private System.Windows.Forms.Button btn_sub;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Button btn_check;
    }
}