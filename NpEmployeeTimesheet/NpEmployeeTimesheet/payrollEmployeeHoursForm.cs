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
    public partial class payrollEmployeeHoursForm : Form
    {
        private static string conString = @"Data Source=H01SQL2;Initial Catalog = NpEmployeeData; User ID = sa; Password=SQL*Admin1";
        private string cmdText;

        private SqlConnection conn = new SqlConnection(conString);
        private SqlCommand cmd;
        private SqlDataReader reader;
        private Employee emp;
        private Employee selectedEmployee;
        private List<Employee> empList;
        private DateTime startDate;

        public payrollEmployeeHoursForm(object employee, DateTime StartDate)
        {
            InitializeComponent();
            emp = (Employee)employee;
            startDate = StartDate;
            empList = new List<Employee>();
        }

        private void payrollEmployeeHoursForm_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                lbl_connection.ForeColor = Color.Green;
                lbl_connection.Text = "Connected";
                lbl_name.Text = emp.firstName + ", " + emp.lastName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex);
            }
            conn.Close();            
            
        }
        private void payrollEmployeeHoursForm_Loaded(object sender, EventArgs e)
        {
            initEmployees();
        }

        private void initEmployees()
        {
            Employee temp;
            cmdText =  @"select * from tbl_EmployeeTime 
                        where [StartDate] = @start";


            cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.AddWithValue("@start", startDate);

            conn.Open();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                temp = new Employee(reader["FirstName"].ToString(), reader["LastName"].ToString(), Convert.ToInt32(reader["empId"]));
                empList.Add(temp);
            }
            reader.Close();
            conn.Close();
            cmb_employees.DataSource = empList;
        }

        private void cmb_employees_SelectedIndexChanged(object sender, EventArgs e)
        {           
            clear();
            cmdText = @"select * from tbl_EmployeeTime where [StartDate] = @start AND [empId] = @id";

            selectedEmployee = (Employee)cmb_employees.SelectedItem;

            cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.AddWithValue("@start", startDate);
            cmd.Parameters.AddWithValue("@id", selectedEmployee.id);

            conn.Open();

            reader = cmd.ExecuteReader();
            reader.Read();

            lbl_selected.Text = reader["LastName"].ToString() + ", " +reader["FirstName"].ToString();
            txt_totalHol.Text = (Convert.ToInt32(reader["Week1Holiday"]) + Convert.ToInt32(reader["Week2Holiday"]))+"";
            txt_totalReg.Text = (Convert.ToInt32(reader["Week1Regular"]) + Convert.ToInt32(reader["Week2Regular"])) + "";
            txt_totalSick.Text = (Convert.ToInt32(reader["Week1Sick"]) + Convert.ToInt32(reader["Week2Sick"])) + "";
            txt_totalVac.Text = (Convert.ToInt32(reader["Week1Vacation"]) + Convert.ToInt32(reader["Week2Vacation"])) + "";
            txt_totalHours.Text = (Convert.ToInt32(txt_totalHol.Text) + Convert.ToInt32(txt_totalReg.Text) + Convert.ToInt32(txt_totalSick.Text) + Convert.ToInt32(txt_totalVac.Text))+"";

            bool empSigned = (bool)reader["EmployeeSigned"];
            bool supSigned = (bool)reader["SupervisorSigned"];
            bool hasNotes = (bool)reader["employeeHasNotes"];

            if (empSigned)
            {
                lbl_employeeSig.Text = "Signed";
                lbl_employeeSig.ForeColor = Color.Green;
            }
            if (supSigned)
            {
                lbl_supSig.Text = "Signed";
                lbl_supSig.ForeColor = Color.Green;
            }
            if (hasNotes)
            {
                MessageBox.Show("This employee has left notes that may effect their hours worked. please view.");
                lbl_notes.Text = "This Employee \n Has Notes";
            }

            reader.Close();
            conn.Close();
        }

        private void clear()
        {
            lbl_employeeSig.Text = "Not Signed";
            lbl_employeeSig.ForeColor = Color.Black;
            lbl_supSig.Text = "Not Signed";
            lbl_supSig.ForeColor = Color.Black;

            txt_totalHol.Text = "";
            txt_totalReg.Text = "";
            txt_totalSick.Text = "";
            txt_totalVac.Text = "";
            txt_totalHours.Text = "";
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_employees.SelectedItem.ToString() == "" || cmb_employees.SelectedItem == null)
                {
                    MessageBox.Show("Please selected an employee from the drop down box");
                }
                else
                {
                    noteForm nf = new noteForm(selectedEmployee, startDate, false);
                    nf.ShowDialog();
                }
            }
            catch(NullReferenceException ex)
            {
                MessageBox.Show("Please selected an employee from the drop down box");
            }
            catch(Exception unknownEx)
            {
                MessageBox.Show("Unknown error: send following error message to Network Administrator:/n" + unknownEx);
            }
            
            
        }
      
    }
}
