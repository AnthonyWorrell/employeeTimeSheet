using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NpEmployeeTimesheet
{
    public partial class changePasswordForm : Form
    {
        #region<class variables>

        private static string conString = @"connection string here";

        private string username;
        private string hashedPassword;

        private SqlConnection conn = new SqlConnection(conString);
        private SqlCommand cmd;
        private SecurePasswordHasher hasher;

        #endregion</class variables>

        #region<class drivers and constructors>
        public changePasswordForm(string u)
        {
            InitializeComponent();
            username = u;
        }

        private void changePasswordForm_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                lbl_connection.ForeColor = Color.Green;
                lbl_connection.Text = "Connected";                
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex);
            }
        }
        #endregion</class drivers and constructors>

        #region<event handlers>
        private void btn_confirm_Click(object sender, EventArgs e)
        {
            string cmdText = "update [tbl_NpEmployeeLogin] set [HashedPassword] = @hash, [FirstLogin] = 0, [Sig] = @sig where [Username] = @user";
            conn.Open();

            cmd = new SqlCommand(cmdText, conn);            

            if (txt_pword.Text == txt_pwordConfirm.Text)
            {
                hasher = new SecurePasswordHasher();

                hashedPassword = hasher.Hash(txt_pword.Text.ToString());

                cmd.Parameters.AddWithValue("@hash", hashedPassword);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@sig", 1111);

                cmd.ExecuteScalar();

                MessageBox.Show("Password changed");

                this.Close();
            }
            else
                MessageBox.Show("passwords do not match");
            
            conn.Close();
            
        }
        #endregion</event handlers>
    }
}

