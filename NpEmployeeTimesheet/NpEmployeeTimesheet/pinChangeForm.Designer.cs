namespace NpEmployeeTimesheet
{
    partial class pinChangeForm
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
            this.txt_newPin = new System.Windows.Forms.TextBox();
            this.txt_confirm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_submit = new System.Windows.Forms.Button();
            this.lbl_name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_newPin
            // 
            this.txt_newPin.Location = new System.Drawing.Point(106, 44);
            this.txt_newPin.Name = "txt_newPin";
            this.txt_newPin.PasswordChar = '*';
            this.txt_newPin.Size = new System.Drawing.Size(100, 20);
            this.txt_newPin.TabIndex = 0;
            // 
            // txt_confirm
            // 
            this.txt_confirm.Location = new System.Drawing.Point(106, 95);
            this.txt_confirm.Name = "txt_confirm";
            this.txt_confirm.PasswordChar = '*';
            this.txt_confirm.Size = new System.Drawing.Size(100, 20);
            this.txt_confirm.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "New Pin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Confirm New Pin";
            // 
            // btn_submit
            // 
            this.btn_submit.Location = new System.Drawing.Point(119, 139);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(75, 23);
            this.btn_submit.TabIndex = 4;
            this.btn_submit.Text = "Submit";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(12, 9);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(35, 13);
            this.lbl_name.TabIndex = 5;
            this.lbl_name.Text = "Name";
            // 
            // pinChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 183);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_confirm);
            this.Controls.Add(this.txt_newPin);
            this.Name = "pinChangeForm";
            this.Text = "pinChangeForm";
            this.Load += new System.EventHandler(this.pinChangeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_newPin;
        private System.Windows.Forms.TextBox txt_confirm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.Label lbl_name;
    }
}