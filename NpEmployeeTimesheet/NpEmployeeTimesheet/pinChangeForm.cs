using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NpEmployeeTimesheet
{
    
    public partial class pinChangeForm : Form
    {
        private static string conString = @"connection string here";

        private SqlConnection conn = new SqlConnection(conString);
        private SqlCommand cmd;
        private SqlDataReader reader;
        private Employee emp;

        public pinChangeForm(object employee)
        {
            InitializeComponent();
            emp = (Employee)employee;
        }

        private void pinChangeForm_Load(object sender, EventArgs e)
        {
            lbl_name.Text = emp.lastName + ", " + emp.firstName;
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            string cmdText = @"update [tbl_NpEmployeeLogin] set [Sig] = @newSig
                                where [EmployeeId] = @empId";

            cmd = new SqlCommand(cmdText, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@newSig", txt_confirm.Text.ToString());
            cmd.Parameters.AddWithValue("@empId", emp.id);
            cmd.ExecuteScalar();
            conn.Close();
            MessageBox.Show("E-Signiture Updated");
        }
    }
}
