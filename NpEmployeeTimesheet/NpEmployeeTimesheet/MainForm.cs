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
    public partial class MainForm : Form
    {

        private static string conString = @"Data Source=H01SQL2;Initial Catalog = NpEmployeeData; User ID = sa; Password=SQL*Admin1";

        private SqlConnection conn = new SqlConnection(conString);
        private SqlCommand cmd;
        private SqlDataReader reader;
        private Employee emp;

        private newUserForm nuf;
        private dateSelectorForm dsf;
        private pinChangeForm pcf;
        private employeeListForm elf;

        public MainForm(object employee)
        {
            InitializeComponent();
            emp = (Employee)employee;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                lbl_connection.ForeColor = Color.Green;
                lbl_connection.Text = "Connected";
                lbl_empName.Text = emp.firstName + " " + emp.lastName;

                if (emp.rank >= 3)
                    btn_add.Visible = true;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            nuf = new newUserForm();
            nuf.ShowDialog();
        }

        private void btn_selDate_Click(object sender, EventArgs e)
        {
            dsf = new dateSelectorForm(emp);
            dsf.ShowDialog();
        }

        private void btn_updateSig_Click(object sender, EventArgs e)
        {
            pcf = new pinChangeForm(emp);
            pcf.ShowDialog();
        }
    }
}
