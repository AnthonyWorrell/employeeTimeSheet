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
    public partial class newUserForm : Form
    {
        private static string conString = @"Dconnection string here";

        private string cmdText;

        private SqlConnection conn = new SqlConnection(conString);
        private SqlCommand cmd;
        private SqlDataReader reader;

        private List<string> supervisors;

        public newUserForm()
        {
            InitializeComponent();
        }

        private void newUserForm_Load(object sender, EventArgs e)
        {
            supervisors = new List<string>();
            cmb_userRank.DisplayMember = "Text";
            cmb_userRank.ValueMember = "Value";

            var items = new[] 
            {
                new { Value = 1, Text = "User" },
                new { Value = 2, Text = "Supervisor" },
                new { Value = 3, Text = "Administrator" },
            };

            cmb_userRank.DataSource = items;
            cmdText = "select * from [tbl_NpSupervisors]";
            cmd = new SqlCommand(cmdText, conn);           

            try
            {
                conn.Open();
                lbl_connection.ForeColor = Color.Green;
                lbl_connection.Text = "Connected";
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    supervisors.Add(reader["SuperLastName"].ToString());
                }

                cmb_superName.DataSource = supervisors;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex);
            }
        }

        private void btn_enter_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] sqlParams = 
                {
                new SqlParameter("@empid", Convert.ToInt32(txt_empNumber.Text.ToString())),
                new SqlParameter("@fn", txt_firstName.Text.ToString()),
                new SqlParameter("@ln", txt_lastName.Text.ToString()),
                new SqlParameter("@un", txt_userName.Text.ToString()),
                new SqlParameter("@supername", cmb_superName.SelectedItem.ToString()),
                new SqlParameter("@sig", 1111),
                new SqlParameter("@Rank", Convert.ToInt32(cmb_userRank.SelectedValue)),
                new SqlParameter("@FirstLogin", true),
                new SqlParameter("@payrollpermission", cb_payrollPermission.Checked),
                new SqlParameter("@medsamplepermission", cb_msPermission.Checked),
                };
                
                cmd = new SqlCommand("dbo.addEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(sqlParams);
               
               
                conn.Open();

                cmd.ExecuteNonQuery();

                MessageBox.Show("New Employee Added Successfully");

                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex + "");
                conn.Close();
            }
            
        }

        private void txt_lastName_LostFocus(object sender, EventArgs e)
        {
            genUserName();
        }
        private void txt_firstName_LostFocus(object sender, EventArgs e)
        {
            genUserName();
        }

        private void genUserName()
        {
            if(txt_firstName.Text != "" && txt_lastName.Text != "")
            {
                string firstLetter = txt_firstName.Text.ToString().Substring(0,1);
                string lastName = txt_lastName.Text.ToString();
                string usern = (firstLetter + lastName).ToLower();

                txt_userName.Text = usern;
            }            
        }

        
    }
}
