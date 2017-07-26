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
    public partial class noteForm : Form
    {
        private static string conString = @"Data Source=H01SQL2;Initial Catalog = NpEmployeeData; User ID = sa; Password=SQL*Admin1";
        private bool canEdit;

        private SqlConnection conn = new SqlConnection(conString);
        private SqlCommand cmd;
        private SqlDataReader reader;
        private Employee emp;
        private DateTime startDate;

        public noteForm(object employee, DateTime Startdate, bool can_edit)
        {
            InitializeComponent();
            emp = (Employee)employee;
            startDate = Startdate;
            canEdit = can_edit;
        }

        private void noteForm_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                              
                lbl_name.Text = emp.firstName + " " + emp.lastName;                

                conn.Close();

                if(isNoteInDatabase())
                    displayNotes();

                if (!canEdit)
                {
                    txt_notes.ReadOnly = true;
                    btn_sub.Visible = false;
                    btn_check.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex);
            }
            conn.Close();
            
        }

        private void btn_sub_Click(object sender, EventArgs e)
        {
           
            string cmdText = @"update [tbl_EmployeeTime] set [employeeNotes] = @empNotes, [employeeHasNotes] = 1
                               where ([StartDate] = @startdate AND [empId] = @id)";

            cmd = new SqlCommand(cmdText, conn);

            conn.Open();
            cmd.Parameters.AddWithValue("@empNotes", txt_notes.Text);
            cmd.Parameters.AddWithValue("@startdate", startDate);
            cmd.Parameters.AddWithValue("id", Convert.ToInt32(emp.id));
            cmd.ExecuteScalar();
            conn.Close();

            MessageBox.Show("Note submitted");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>note exists in database?</returns>
        private bool isNoteInDatabase()
        {
            string cmdText = @"select * from [tbl_EmployeeTime]
                               where [empId] = @Id AND ([StartDate] = @start AND [employeeHasNotes] = 1)";

            cmd = new SqlCommand(cmdText, conn);

            conn.Open();

            cmd.Parameters.AddWithValue("@Id", emp.id);
            cmd.Parameters.AddWithValue("@start", startDate);

            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                conn.Close();
                return true;
            }                
            else
            {
                conn.Close();
                return false;
            }                
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            displayNotes();
        }

        private void displayNotes()
        {
            string cmdText = @"select [employeeNotes] from [tbl_EmployeeTime]
                               where [empId] = @Id AND ([StartDate] = @start AND [employeeHasNotes] = 1)";

            cmd = new SqlCommand(cmdText, conn);

            conn.Open();

            cmd.Parameters.AddWithValue("@Id", emp.id);
            cmd.Parameters.AddWithValue("@start", startDate);

            reader = cmd.ExecuteReader();
            reader.Read();
            txt_notes.Text = reader["employeeNotes"].ToString();

            conn.Close();
        }
    }
}
