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
    public partial class loginForm : Form
    {
        #region<class variables>

        private static string conString = @"connection string here";
        private bool firstLogin;
        private bool hasPayrollPermission;

        private string cmdText;
        private string tempPassword = "Newpoint1";
        private string password;
        private string hashedPassword;

        private changePasswordForm cf;
        private SecurePasswordHasher hasher;

        private SqlConnection conn = new SqlConnection(conString);
        private SqlCommand cmd;
        private SqlDataReader reader;
        private Employee emp;

        private MainForm mf;

        #endregion</class variables>

        #region<class drivers and constructors>

        public loginForm()
        {
            InitializeComponent();
        }

        //check connection on load and display connection status
        private void loginForm_Load(object sender, EventArgs e)
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

        //verify valid username and password
        private void btn_logIn_Click(object sender, EventArgs e)
        {
            //paramaterized query
            cmdText = "select * from [tbl_NpEmployeeLogin] where [Username]=@user";

            conn.Open();

            cmd = new SqlCommand(cmdText, conn);

            cmd.Parameters.AddWithValue("@user", txt_username.Text);
            reader = cmd.ExecuteReader();

            if (reader.Read())//if valid user name
            {
                firstLogin = (bool)reader["FirstLogin"];

                if (firstLogin)
                {
                    password = tempPassword;//hard coded temp password for first time users

                    if (txt_password.Text.ToString().Equals(password))
                    {
                        cf = new changePasswordForm(reader["Username"].ToString());
                        MessageBox.Show("Your password must be changed.");
                        txt_password.Text = "";
                        cf.ShowDialog();
                    }                        
                    else
                        MessageBox.Show("invalid username or password");
                }
                else
                {
                    hasher = new SecurePasswordHasher();
                    password = txt_password.Text.ToString();

                    //get hashed password from database
                    hashedPassword = reader["HashedPassword"].ToString();  

                    if (hasher.Verify(password, hashedPassword))
                    {
                        //enter valid log in code here                        
                        MessageBox.Show("login successful");
                        emp = new Employee(reader["First"].ToString(), reader["Last"].ToString(), reader["Username"].ToString(),Convert.ToInt32(reader["Rank"].ToString()), reader["Sig"].ToString(), Convert.ToInt32(reader["EmployeeId"].ToString()));
                        hasPayrollPermission = (bool)reader["PayrollPermission"];
                        emp.payrollPermission = hasPayrollPermission;
                        conn.Close();
                        reader.Close();
                        
                        mf = new MainForm(emp);
                        this.Hide();
                        txt_password.Text = "";
                        mf.ShowDialog();
                        this.Show();
                    }
                    else
                        MessageBox.Show("invalid username or password");
                }
       
            }
            else//if invalid log in
                MessageBox.Show("invalid username or password");

            conn.Close();
        }

        #endregion</event handlers>

        #region<void functions>

        #endregion</void functions>
        
    }
}
