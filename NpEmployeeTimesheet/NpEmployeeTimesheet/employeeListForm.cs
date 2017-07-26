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
    public partial class employeeListForm : Form
    {
        private static string conString = @"Data Source=H01SQL2;Initial Catalog = NpEmployeeData; User ID = sa; Password=SQL*Admin1";
        private string cmdText;
        private string cmdText2;

        private SqlConnection conn = new SqlConnection(conString);
        private SqlCommand cmd;
        private SqlCommand cmd2;
        private SqlDataReader reader;
        private SqlDataReader reader2;
        private Employee emp;

        private List<Employee> empList;
        private DateTime[] dateRange;

        public employeeListForm(object employee, DateTime[] Daterange)
        {
            InitializeComponent();
            emp = (Employee)employee;
            empList = new List<Employee>();
            dateRange = Daterange;
        }

        private void employeeListForm_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                lbl_connection.ForeColor = Color.Green;
                lbl_connection.Text = "Connected";
                lbl_empName.Text = emp.firstName + " " + emp.lastName;           
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex);
            }
            conn.Close();
            initEmployees();
        }

        private void initEmployees()
        {
            Employee temp;

            empList.Clear();
            cmb_employees.DataSource = null;
           
            cmdText = @"select * from [tbl_NpEmployeeLogin] where Supervisorname = @empName";
            cmdText2 = @"select * from [tbl_NpEmployeeLogin]";

            cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.AddWithValue("@empName", emp.lastName);

            cmd2 = new SqlCommand(cmdText2, conn);

            conn.Open();
           
            if (chb_all.Checked)
            {
                reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    temp = new Employee(reader2["First"].ToString(), reader2["Last"].ToString(), reader2["Username"].ToString(), Convert.ToInt32(reader2["Rank"].ToString()), reader2["Sig"].ToString(), Convert.ToInt32(reader2["EmployeeId"].ToString()));
                    empList.Add(temp);
                }
                reader2.Close();
                conn.Close();
            }
            else
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    temp = new Employee(reader["First"].ToString(), reader["Last"].ToString(), reader["Username"].ToString(), Convert.ToInt32(reader["Rank"].ToString()), reader["Sig"].ToString(), Convert.ToInt32(reader["EmployeeId"].ToString()));
                    empList.Add(temp);
                }
                reader.Close();
                conn.Close();
            }                          
            cmb_employees.DataSource = empList;
            conn.Close();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Employee List Updated");
            initEmployees();
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            Employee emp2;

            emp2 = (Employee)cmb_employees.SelectedItem;
            timeDataForm tdf = new timeDataForm(emp2, dateRange);
            tdf.ShowDialog();

        }

        private void btn_sign_Click(object sender, EventArgs e)
        {
            string cmdText = @"update [tbl_EmployeeTime]
                               set [SupervisorSigned] = 1
                               where [empId] = @empId
                               AND [StartDate] = @start
                               AND [EndDate] = @end";

            cmd = new SqlCommand(cmdText, conn);
            Employee temp;
            temp = (Employee)cmb_employees.SelectedItem;
            conn.Open();

            cmd.Parameters.AddWithValue("@empId", Convert.ToInt32(temp.id));
            cmd.Parameters.AddWithValue("@start", dateRange[0]);
            cmd.Parameters.AddWithValue("@end", dateRange[13]);

            if (emp.sig == txt_empSig.Text.ToString())
            {
                cmd.ExecuteScalar();
                MessageBox.Show("Timesheet signed");                
            }
            else
            {
                MessageBox.Show("incorrect pin");
            }
            conn.Close();
        }
    }
}
