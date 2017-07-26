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
    public partial class dateSelectorForm : Form
    {

        private static string conString = @"connection string here";
        private int range;

        private SqlConnection conn = new SqlConnection(conString);
        private SqlCommand cmd;
        private SqlDataReader reader;
        private Employee emp;
        private timeDataForm tdf;

        private DateTime[] dateRange;

        public dateSelectorForm(object employee)
        {
            emp = (Employee)employee;
            InitializeComponent();
        }
        private void dateSelectorForm_Load(object sender, EventArgs e)
        {

            if (emp.rank >= 2)
            {
                btn_viewEmployeeSheets.Visible = true;
            }
            if(emp.payrollPermission)
            {
                btn_viewHours.Visible = true;
            }
            try
            {
                conn.Open();

                lbl_connection.ForeColor = Color.Green;
                lbl_connection.Text = "Connected";
                lbl_empName.Text = emp.firstName + " " + emp.lastName;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex);
            }
        }

        private void btn_enter_Click(object sender, EventArgs e)
        {
            initDaterange();
            if (dateRange.Length < 14)
            {
                MessageBox.Show("please select 2 weeks. select more then one day by right clicking the start of the week (sunday) and holding down the right mouse button until the end of the second week (saturday)");
            }
            else
            {
                tdf = new timeDataForm(emp, dateRange);
                tdf.ShowDialog();
            }           
        }
        private void btn_viewEmployeeSheets_Click(object sender, EventArgs e)
        {
            initDaterange();
            if (dateRange.Length < 14)
            {
                MessageBox.Show("please select 2 weeks. select more then one day by right clicking the start of the week (sunday) and holding down the right mouse button until the end of the second week (saturday)");
            }
            else
            {
                employeeListForm elf = new employeeListForm(emp, dateRange);
                elf.ShowDialog();
            }          
        }
        private void initDaterange()
        {
            int counter = 0;
            DateTime temp;

            range = Convert.ToInt32(msc_daySelector.SelectionEnd.Day - msc_daySelector.SelectionStart.Day + 1);

            if (range < 0)
                range = -range;

            dateRange = new DateTime[range];
            temp = msc_daySelector.SelectionStart;

            while (counter < dateRange.Length)
            {
                dateRange[counter] = temp;
                temp = temp.AddDays(1);
                counter++;
            }           
        }

        private void btn_viewHours_Click(object sender, EventArgs e)
        {
            initDaterange();
            if (dateRange.Length < 14)
            {
                MessageBox.Show("please select 2 weeks. select more then one day by right clicking the start of the week (sunday) and holding down the right mouse button until the end of the second week (saturday)");
            }
            else
            {
                payrollEmployeeHoursForm pf = new payrollEmployeeHoursForm(emp, dateRange[0]);
                pf.ShowDialog();
            }
           
        }
    }
}
