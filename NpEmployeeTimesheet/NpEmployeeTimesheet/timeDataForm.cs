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
    public partial class timeDataForm : Form
    {
        private static string conString = @"Data Source=H01SQL2;Initial Catalog = NpEmployeeData; User ID = sa; Password=SQL*Admin1";
        private double timeWorked;

        private SqlConnection conn = new SqlConnection(conString);
        private SqlCommand cmd;
        private SqlDataReader reader;
        private Employee emp;

        private DateTime[] dateRange;

         /*********************************************
         * Array Key:
         * 0 = vacation
         * 1 = holiday
         * 2 = sick
         * 3 = regular
         * 4 = total hours worked
         **********************************************/
        private double[] week1Totals;
        private double[] week2Totals;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="Daterange"></param>
        public timeDataForm(object employee, DateTime[] Daterange)
        {
            InitializeComponent();
            emp = (Employee)employee;
            dateRange = Daterange;
            week1Totals = new double[5];
            week2Totals = new double[5];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timeDataForm_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                lbl_connection.ForeColor = Color.Green;
                lbl_connection.Text = "Connected";
                lbl_empName.Text = emp.firstName + " " + emp.lastName;

                initLabels();
                initBoxes();
                initHourBoxes();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex);
            }
            conn.Close();
        }
        /// <summary>
        /// Sets labels to display dates
        /// </summary>
        private void initLabels()
        {
            lbl_sun1.Text = dateRange[0].DayOfWeek + "\n" + dateRange[0].ToShortDateString();
            lbl_mon1.Text = dateRange[1].DayOfWeek + "\n" + dateRange[1].ToShortDateString();
            lbl_tues1.Text = dateRange[2].DayOfWeek + "\n" + dateRange[2].ToShortDateString();
            lbl_wed1.Text = dateRange[3].DayOfWeek + "\n" + dateRange[3].ToShortDateString();
            lbl_thur1.Text = dateRange[4].DayOfWeek + "\n" + dateRange[4].ToShortDateString();
            lbl_fri1.Text = dateRange[5].DayOfWeek + "\n" + dateRange[5].ToShortDateString();
            lbl_sat1.Text = dateRange[6].DayOfWeek + "\n" + dateRange[6].ToShortDateString();

            lbl_sun2.Text = dateRange[7].DayOfWeek + "\n" + dateRange[7].ToShortDateString();
            lbl_mon2.Text = dateRange[8].DayOfWeek + "\n" + dateRange[8].ToShortDateString();
            lbl_tues2.Text = dateRange[9].DayOfWeek + "\n" + dateRange[9].ToShortDateString();
            lbl_wed2.Text = dateRange[10].DayOfWeek + "\n" + dateRange[10].ToShortDateString();
            lbl_thur2.Text = dateRange[11].DayOfWeek + "\n" + dateRange[11].ToShortDateString();
            lbl_fri2.Text = dateRange[12].DayOfWeek + "\n" + dateRange[12].ToShortDateString();
            lbl_sat2.Text = dateRange[13].DayOfWeek + "\n" + dateRange[13].ToShortDateString();
        }
        /// <summary>
        /// returns a list of datetime objects 
        /// </summary>
        /// <param name="date">the datetime</param>
        /// <returns>appropriate times for given datetime in 15 minute incriments</returns>
        private List<DateTime> initTimes(DateTime date)
        {
            DateTime temp = date;
            List<DateTime> selectableTimes = new List<DateTime>();

            for (int i = 0; i <= 95; i++)
            {
                selectableTimes.Add(temp);
                temp = temp.AddHours(.25);
            }

            return selectableTimes;                               
        }
      
      /// <summary>
      /// set combo boxes to display correct times
      /// </summary>
        private void initBoxes()
        {
            cmb_sun1In.DataSource = initTimes(dateRange[0]);
            cmb_sun1Out.DataSource = initTimes(dateRange[0]);
            cmb_mon1In.DataSource = initTimes(dateRange[1]);
            cmb_mon1Out.DataSource = initTimes(dateRange[1]);
            cmb_tues1In.DataSource = initTimes(dateRange[2]);
            cmb_tues1Out.DataSource = initTimes(dateRange[2]);
            cmb_wed1In.DataSource = initTimes(dateRange[3]);
            cmb_wed1Out.DataSource = initTimes(dateRange[3]);
            cmb_thur1In.DataSource = initTimes(dateRange[4]);
            cmb_thur1Out.DataSource = initTimes(dateRange[4]);
            cmb_fri1In.DataSource = initTimes(dateRange[5]);
            cmb_fri1Out.DataSource = initTimes(dateRange[5]);
            cmb_sat1In.DataSource = initTimes(dateRange[6]);
            cmb_sat1Out.DataSource = initTimes(dateRange[6]);

            cmb_sun2In.DataSource = initTimes(dateRange[7]);
            cmb_sun2Out.DataSource = initTimes(dateRange[7]);
            cmb_mon2In.DataSource = initTimes(dateRange[8]);
            cmb_mon2Out.DataSource = initTimes(dateRange[8]);
            cmb_tues2In.DataSource = initTimes(dateRange[9]);
            cmb_tues2Out.DataSource = initTimes(dateRange[9]);
            cmb_wed2In.DataSource = initTimes(dateRange[10]);
            cmb_wed2Out.DataSource = initTimes(dateRange[10]);
            cmb_thur2In.DataSource = initTimes(dateRange[11]);
            cmb_thur2Out.DataSource = initTimes(dateRange[11]);
            cmb_fri2In.DataSource = initTimes(dateRange[12]);
            cmb_fri2Out.DataSource = initTimes(dateRange[12]);
            cmb_sat2In.DataSource = initTimes(dateRange[13]);
            cmb_sat2Out.DataSource = initTimes(dateRange[13]);
        }
        /// <summary>
        /// evaluates hours worked
        /// if lunch is left blank, default to 0
        /// </summary>
        /// <param name="dateOut"></param>
        /// <param name="dateIn"></param>
        /// <param name="Lunch"></param>
        /// <param name="Hours"></param>
        private void evalHoursWorked(string dateOut, string dateIn, TextBox Lunch, TextBox Hours)
        {
            try
            {
                double timeOut = Convert.ToDateTime(dateOut).Hour;
                double timeIn = Convert.ToDateTime(dateIn).Hour;
                double lunch;

                if(Lunch.Text == "")
                    lunch = 0;                
                else
                    lunch = Convert.ToDouble(Lunch.Text.ToString());

                timeWorked = (timeOut - timeIn) - lunch;

                Hours.Text = "" + timeWorked;
            }
            catch (System.FormatException)
            {
                Hours.Text = "0";
            }
        }
        /// <summary>
        /// adds the possible types of hours 
        /// </summary>
        /// <param name="hourType"></param>
        private void initHourTypes(ComboBox hourType)
        {
            hourType.Items.Add("Regular");
            hourType.Items.Add("Sick");
            hourType.Items.Add("Holiday");
            hourType.Items.Add("Vacation");
            hourType.SelectedItem = "Regular";
        }
        /// <summary>
        /// 
        /// </summary>
        private void initHourBoxes()
        {
            initHourTypes(cmb_sun1Type);
            initHourTypes(cmb_mon1Type);
            initHourTypes(cmb_tues1Type);
            initHourTypes(cmb_wed1Type);
            initHourTypes(cmb_thur1Type);
            initHourTypes(cmb_fri1Type);
            initHourTypes(cmb_sat1Type);

            initHourTypes(cmb_sun2Type);
            initHourTypes(cmb_mon2Type);
            initHourTypes(cmb_tues2Type);
            initHourTypes(cmb_wed2Type);
            initHourTypes(cmb_thur2Type);
            initHourTypes(cmb_fri2Type);
            initHourTypes(cmb_sat2Type);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hourType"></param>
        /// <param name="hours"></param>
        private void calculateHourTypes1(ComboBox hourType, TextBox hours)
        {
            try
            {
                if (hourType.SelectedItem.ToString() == "Vacation")
                {
                    week1Totals[0] += Convert.ToDouble(hours.Text.ToString());
                }
                else if (hourType.SelectedItem.ToString() == "Holiday")
                {
                    week1Totals[1] += Convert.ToDouble(hours.Text.ToString());
                }
                else if (hourType.SelectedItem.ToString() == "Sick")
                {
                    week1Totals[2] += Convert.ToDouble(hours.Text.ToString());
                }
                else if (hourType.SelectedItem.ToString() == "Regular")
                {
                    week1Totals[3] += Convert.ToDouble(hours.Text.ToString());
                }
            }catch(Exception ex)
            {               
               
            }         
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hourType"></param>
        /// <param name="hours"></param>
        private void calculateHourTypes2(ComboBox hourType, TextBox hours)
        {
            try
            {
                if (hourType.SelectedItem.ToString() == "Vacation")
                {
                    week2Totals[0] += Convert.ToInt32(hours.Text.ToString());
                }
                else if (hourType.SelectedItem.ToString() == "Holiday")
                {
                    week2Totals[1] += Convert.ToInt32(hours.Text.ToString());
                }
                else if (hourType.SelectedItem.ToString() == "Sick")
                {
                    week2Totals[2] += Convert.ToInt32(hours.Text.ToString());
                }
                else if (hourType.SelectedItem.ToString() == "Regular")
                {
                    week2Totals[3] += Convert.ToInt32(hours.Text.ToString());
                }
            }catch(Exception ex)
            {

            }           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_calc_Click(object sender, EventArgs e)
        {
            MessageBox.Show("calculation complete");
            calcData();
        }
        /// <summary>
        /// 
        /// </summary>
        private void clearData()
        {
            //week 1 data
            week1Totals[0] = 0;
            week1Totals[1] = 0;
            week1Totals[2] = 0;
            week1Totals[3] = 0;
            week1Totals[4] = 0;

            txt_w1Vac.Text = "" + week1Totals[0];
            txt_w1Hol.Text = "" + week1Totals[1];
            txt_w1Sick.Text = "" + week1Totals[2];
            txt_w1Reg.Text = "" + week1Totals[3];

            //week 2 data
            week2Totals[0] = 0;
            week2Totals[1] = 0;
            week2Totals[2] = 0;
            week2Totals[3] = 0;
            week2Totals[4] = 0;

            txt_w2Vac.Text = "" + week2Totals[0];
            txt_w2Hol.Text = "" + week2Totals[1];
            txt_w2Sick.Text = "" + week2Totals[2];
            txt_w2Reg.Text = "" + week2Totals[3];

            //pay period total data
            txt_totalVac.Text = "" + (week1Totals[0] + week2Totals[0]);
            txt_totalHol.Text = "" + (week1Totals[1] + week2Totals[1]);
            txt_totalSick.Text = "" + (week1Totals[2] + week2Totals[2]);
            txt_totalReg.Text = "" + (week1Totals[3] + week2Totals[3]);
            txt_totalHours.Text = "" + (week1Totals[4] + week2Totals[4]);
        }
        /// <summary>
        /// 
        /// </summary>
        private void calcData()
        {
            clearData();//clear current stored data
       
            evalHoursWorked(cmb_sun1Out.SelectedItem.ToString(), cmb_sun1In.SelectedItem.ToString(),
                txt_sun1Lunch, txt_sun1Hours);

            evalHoursWorked(cmb_mon1Out.SelectedItem.ToString(), cmb_mon1In.SelectedItem.ToString(),
                txt_mon1Lunch, txt_mon1Hours);

            evalHoursWorked(cmb_tues1Out.SelectedItem.ToString(), cmb_tues1In.SelectedItem.ToString(),
                txt_tues1Lunch, txt_tues1Hours);

            evalHoursWorked(cmb_wed1Out.SelectedItem.ToString(), cmb_wed1In.SelectedItem.ToString(),
                txt_wed1Lunch, txt_wed1Hours);

            evalHoursWorked(cmb_thur1Out.SelectedItem.ToString(), cmb_thur1In.SelectedItem.ToString(),
                txt_thur1Lunch, txt_thur1Hours);

            evalHoursWorked(cmb_fri1Out.SelectedItem.ToString(), cmb_fri1In.SelectedItem.ToString(),
                txt_fri1Lunch, txt_fri1Hours);

            evalHoursWorked(cmb_sat1Out.SelectedItem.ToString(), cmb_sat1In.SelectedItem.ToString(),
                txt_sat1Lunch, txt_sat1Hours);

            evalHoursWorked(cmb_sun2Out.SelectedItem.ToString(), cmb_sun2In.SelectedItem.ToString(),
                txt_sun2Lunch, txt_sun2Hours);

            evalHoursWorked(cmb_mon2Out.SelectedItem.ToString(), cmb_mon2In.SelectedItem.ToString(),
               txt_mon2Lunch, txt_mon2Hours);

            evalHoursWorked(cmb_tues2Out.SelectedItem.ToString(), cmb_tues2In.SelectedItem.ToString(),
                txt_tues2Lunch, txt_tues2Hours);

            evalHoursWorked(cmb_wed2Out.SelectedItem.ToString(), cmb_wed2In.SelectedItem.ToString(),
                txt_wed2Lunch, txt_wed2Hours);

            evalHoursWorked(cmb_thur2Out.SelectedItem.ToString(), cmb_thur2In.SelectedItem.ToString(),
                txt_thur2Lunch, txt_thur2Hours);

            evalHoursWorked(cmb_fri2Out.SelectedItem.ToString(), cmb_fri2In.SelectedItem.ToString(),
                txt_fri2Lunch, txt_fri2Hours);

            evalHoursWorked(cmb_sat2Out.SelectedItem.ToString(), cmb_sat2In.SelectedItem.ToString(),
                txt_sat2Lunch, txt_sat2Hours);
        
            calculateHourTypes1(cmb_sun1Type, txt_sun1Hours);
            calculateHourTypes1(cmb_mon1Type, txt_mon1Hours);
            calculateHourTypes1(cmb_tues1Type, txt_tues1Hours);
            calculateHourTypes1(cmb_wed1Type, txt_wed1Hours);
            calculateHourTypes1(cmb_thur1Type, txt_thur1Hours);
            calculateHourTypes1(cmb_fri1Type, txt_fri1Hours);
            calculateHourTypes1(cmb_sat1Type, txt_sat1Hours);

            txt_w1Vac.Text = "" + week1Totals[0];
            txt_w1Hol.Text = "" + week1Totals[1];
            txt_w1Sick.Text = "" + week1Totals[2];
            txt_w1Reg.Text = "" + week1Totals[3];
            week1Totals[4] = week1Totals[0] + week1Totals[1] + week1Totals[2] + week1Totals[3];
            txt_w1Total.Text = "" + week1Totals[4];

            calculateHourTypes2(cmb_sun2Type, txt_sun2Hours);
            calculateHourTypes2(cmb_mon2Type, txt_mon2Hours);
            calculateHourTypes2(cmb_tues2Type, txt_tues2Hours);
            calculateHourTypes2(cmb_wed2Type, txt_wed2Hours);
            calculateHourTypes2(cmb_thur2Type, txt_thur2Hours);
            calculateHourTypes2(cmb_fri2Type, txt_fri2Hours);
            calculateHourTypes2(cmb_sat2Type, txt_sat2Hours);

            txt_w2Vac.Text = "" + week2Totals[0];
            txt_w2Hol.Text = "" + week2Totals[1];
            txt_w2Sick.Text = "" + week2Totals[2];
            txt_w2Reg.Text = "" + week2Totals[3];
            week2Totals[4] = week2Totals[0] + week2Totals[1] + week2Totals[2] + week2Totals[3];
            txt_w2Total.Text = "" + week2Totals[4];

            txt_totalVac.Text = "" + (week1Totals[0] + week2Totals[0]);
            txt_totalHol.Text = "" + (week1Totals[1] + week2Totals[1]);
            txt_totalSick.Text = "" + (week1Totals[2] + week2Totals[2]);
            txt_totalReg.Text = "" + (week1Totals[3] + week2Totals[3]);
            txt_totalHours.Text = "" + (week1Totals[4] + week2Totals[4]);
          
            btn_sub.Visible = true;
            btn_update.Visible = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_sub_Click(object sender, EventArgs e)
        {
            if (!isTimesheetInDatabase())
            {
                calcData();                

                string cmdText = @"insert into [tbl_EmployeeTime] ([empId],[FirstName],[LastName],[StartDate],[SundayIn1], [SundayOut1], [Sunday1HoursWorked],[Sunday1HourType], [MondayIn1], [MondayOut1], [Monday1HoursWorked],[Monday1HourType],[TuesdayIn1],[TuesdayOut1],[Tuesday1HoursWorked],[Tuesday1HourType],[WednesdayIn1],[WednesdayOut1],[Wednesday1HoursWorked],[Wednesday1HourType],[ThursdayIn1],[ThursdayOut1],[Thursday1HoursWorked],[Thursday1HourType],[FridayIn1],[FridayOut1],[Friday1HoursWorked],[Friday1HourType],[SaturdayIn1],[SaturdayOut1],[Saturday1HoursWorked],[Saturday1HourType],[Week1Vacation],[Week1Sick],[Week1Holiday],[Week1Regular],[Week1HoursWorked],[SundayIn2], [SundayOut2], [Sunday2HoursWorked],[Sunday2HourType],[MondayIn2],[MondayOut2],[Monday2HoursWorked],[Monday2HourType],[TuesdayIn2],[TuesdayOut2],[Tuesday2HoursWorked],[Tuesday2HourType],[WednesdayIn2],[WednesdayOut2],[Wednesday2HoursWorked],[Wednesday2HourType],[ThursdayIn2],[ThursdayOut2],[Thursday2HoursWorked],[Thursday2HourType],[FridayIn2],[FridayOut2],[Friday2HoursWorked],[Friday2HourType],[SaturdayIn2],[SaturdayOut2],[Saturday2HoursWorked],[Saturday2HourType],[Week2Vacation],[Week2Sick],[Week2Holiday],[Week2Regular],[Week2HoursWorked], [EndDate])
                                values(@Id,@first,@last, @start,@SundayIn1,@SundayOut1,@Sunday1HoursWorked,@Sunday1HourType, @MondayIn1, @MondayOut1, @Monday1HoursWorked,@Monday1HourType,@TuesdayIn1,@TuesdayOut1,@Tuesday1HoursWorked,@Tuesday1HourType,@WednesdayIn1,@WednesdayOut1,@Wednesday1HoursWorked,@Wednesday1HourType,@ThursdayIn1,@ThursdayOut1,@Thursday1HoursWorked,@Thursday1HourType,@FridayIn1,@FridayOut1,@Friday1HoursWorked,@Friday1HourType,@SaturdayIn1,@SaturdayOut1,@Saturday1HoursWorked,@Saturday1HourType,@Week1Vacation,@Week1Sick,@Week1Holiday,@Week1Regular,@Week1HoursWorked,@SundayIn2, @SundayOut2, @Sunday2HoursWorked,@Sunday2HourType,@MondayIn2,@MondayOut2,@Monday2HoursWorked,@Monday2HourType,@TuesdayIn2,@TuesdayOut2,@Tuesday2HoursWorked,@Tuesday2HourType,@WednesdayIn2,@WednesdayOut2,@Wednesday2HoursWorked,@Wednesday2HourType,@ThursdayIn2,@ThursdayOut2,@Thursday2HoursWorked,@Thursday2HourType,@FridayIn2,@FridayOut2,@Friday2HoursWorked,@Friday2HourType,@SaturdayIn2,@SaturdayOut2,@Saturday2HoursWorked,@Saturday2HourType,@Week2Vacation,@Week2Sick,@Week2Holiday,@Week2Regular,@Week2HoursWorked, @end)";

                cmd = new SqlCommand(cmdText, conn);

                conn.Open();
                try
                {
                    cmd.Parameters.AddWithValue("@Id", emp.id);
                    cmd.Parameters.AddWithValue("@first", emp.firstName);
                    cmd.Parameters.AddWithValue("@last", emp.lastName);
                    cmd.Parameters.AddWithValue("@start", dateRange[0]);
                    cmd.Parameters.AddWithValue("@SundayIn1", cmb_sun1In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SundayOut1", cmb_sun1Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Sunday1HoursWorked", Convert.ToDouble(txt_sun1Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Sunday1HourType", cmb_sun1Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@MondayIn1", cmb_mon1In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@mondayOut1", cmb_mon1Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Monday1HoursWorked", Convert.ToDouble(txt_mon1Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Monday1HourType", cmb_mon1Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@TuesdayIn1", cmb_tues1In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@TuesdayOut1", cmb_tues1Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Tuesday1HoursWorked", Convert.ToDouble(txt_tues1Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Tuesday1HourType", cmb_tues1Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@WednesdayIn1", cmb_wed1In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@WednesdayOut1", cmb_wed1Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Wednesday1HoursWorked", Convert.ToDouble(txt_wed1Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Wednesday1HourType", cmb_wed1Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ThursdayIn1", cmb_thur1In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ThursdayOut1", cmb_thur1Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Thursday1HoursWorked", Convert.ToDouble(txt_thur1Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Thursday1HourType", cmb_thur1Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@FridayIn1", cmb_fri1In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@FridayOut1", cmb_fri1Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Friday1HoursWorked", Convert.ToDouble(txt_fri1Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Friday1HourType", cmb_fri1Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SaturdayIn1", cmb_sat1In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SaturdayOut1", cmb_sat1Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Saturday1HoursWorked", Convert.ToDouble(txt_sat1Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Saturday1HourType", cmb_sat1Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Week1Vacation", Convert.ToDouble(txt_w1Vac.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Week1Sick", Convert.ToDouble(txt_w1Sick.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Week1Holiday", Convert.ToDouble(txt_w1Hol.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Week1Regular", Convert.ToDouble(txt_w1Reg.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Week1HoursWorked", Convert.ToDouble(txt_w1Total.Text.ToString()));

                    cmd.Parameters.AddWithValue("@SundayIn2", cmb_sun2In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SundayOut2", cmb_sun2Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Sunday2HoursWorked", Convert.ToDouble(txt_sun2Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Sunday2HourType", cmb_sun2Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@MondayIn2", cmb_mon2In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@mondayOut2", cmb_mon2Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Monday2HoursWorked", Convert.ToDouble(txt_mon2Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Monday2HourType", cmb_mon2Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@TuesdayIn2", cmb_tues2In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@TuesdayOut2", cmb_tues2Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Tuesday2HoursWorked", Convert.ToDouble(txt_tues2Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Tuesday2HourType", cmb_tues2Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@WednesdayIn2", cmb_wed2In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@WednesdayOut2", cmb_wed2Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Wednesday2HoursWorked", Convert.ToDouble(txt_wed2Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Wednesday2HourType", cmb_wed2Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ThursdayIn2", cmb_thur2In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ThursdayOut2", cmb_thur2Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Thursday2HoursWorked", Convert.ToDouble(txt_thur2Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Thursday2HourType", cmb_thur2Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@FridayIn2", cmb_fri2In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@FridayOut2", cmb_fri2Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Friday2HoursWorked", Convert.ToDouble(txt_fri2Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Friday2HourType", cmb_fri2Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SaturdayIn2", cmb_sat2In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SaturdayOut2", cmb_sat2Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Saturday2HoursWorked", Convert.ToDouble(txt_sat2Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Saturday2HourType", cmb_sat2Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Week2Vacation", Convert.ToDouble(txt_w2Vac.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Week2Sick", Convert.ToDouble(txt_w2Sick.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Week2Holiday", Convert.ToDouble(txt_w2Hol.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Week2Regular", Convert.ToDouble(txt_w2Reg.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Week2HoursWorked", Convert.ToDouble(txt_w2Total.Text.ToString()));
                    cmd.Parameters.AddWithValue("@end", dateRange[13]);
                }catch(Exception ex)
                {

                }
                
                cmd.ExecuteScalar();

                MessageBox.Show("Timesheet Submited");
            }else
            {
                MessageBox.Show("Time Sheet Data for this pay period already exists. If you need to update currently existing Hours, Please use the update button");
            }
            conn.Close();          
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_check_Click(object sender, EventArgs e)
        {
            string cmdText = @"select * from [tbl_EmployeeTime]
                               where [empId] = @Id AND [StartDate] = @start AND [EndDate] = @end";

            cmd = new SqlCommand(cmdText, conn);

            conn.Open();

            cmd.Parameters.AddWithValue("@Id", emp.id);
            cmd.Parameters.AddWithValue("@start", dateRange[0]);
            cmd.Parameters.AddWithValue("@end", dateRange[13]);

            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                cmb_sun1In.SelectedItem = reader["SundayIn1"];
                cmb_sun1Out.SelectedItem = reader["SundayOut1"];
                cmb_sun1Type.SelectedItem = reader["Sunday1HourType"];
                txt_sun1Hours.Text = reader["Sunday1HoursWorked"].ToString();
                cmb_mon1In.SelectedItem = reader["MondayIn1"];
                cmb_mon1Out.SelectedItem = reader["MondayOut1"];
                cmb_mon1Type.SelectedItem = reader["Monday1HourType"];
                txt_mon1Hours.Text = reader["Monday1HoursWorked"].ToString();
                cmb_tues1In.SelectedItem = reader["TuesdayIn1"];
                cmb_tues1Out.SelectedItem = reader["TuesdayOut1"];
                cmb_tues1Type.SelectedItem = reader["Tuesday1HourType"];
                txt_tues1Hours.Text = reader["Tuesday1HoursWorked"].ToString();
                cmb_wed1In.SelectedItem = reader["WednesdayIn1"];
                cmb_wed1Out.SelectedItem = reader["WednesdayOut1"];
                cmb_wed1Type.SelectedItem = reader["Wednesday1HourType"];
                txt_wed1Hours.Text = reader["Wednesday1HoursWorked"].ToString();
                cmb_thur1In.SelectedItem = reader["ThursdayIn1"];
                cmb_thur1Out.SelectedItem = reader["ThursdayOut1"];
                cmb_thur1Type.SelectedItem = reader["Thursday1HourType"];
                txt_thur1Hours.Text = reader["Thursday1HoursWorked"].ToString();
                cmb_fri1In.SelectedItem = reader["FridayIn1"];
                cmb_fri1Out.SelectedItem = reader["FridayOut1"];
                cmb_fri1Type.SelectedItem = reader["Friday1HourType"];
                txt_fri1Hours.Text = reader["Friday1HoursWorked"].ToString();
                cmb_sat1In.SelectedItem = reader["SaturdayIn1"];
                cmb_sat1Out.SelectedItem = reader["SaturdayOut1"];
                cmb_sat1Type.SelectedItem = reader["Saturday1HourType"];
                txt_sat1Hours.Text = reader["Saturday1HoursWorked"].ToString();

                cmb_sun2In.SelectedItem = reader["SundayIn2"];
                cmb_sun2Out.SelectedItem = reader["SundayOut2"];
                cmb_sun2Type.SelectedItem = reader["Sunday2HourType"];
                txt_sun2Hours.Text = reader["Sunday2HoursWorked"].ToString();
                cmb_mon2In.SelectedItem = reader["MondayIn2"];
                cmb_mon2Out.SelectedItem = reader["MondayOut2"];
                cmb_mon2Type.SelectedItem = reader["Monday2HourType"];
                txt_mon2Hours.Text = reader["Monday2HoursWorked"].ToString();
                cmb_tues2In.SelectedItem = reader["TuesdayIn2"];
                cmb_tues2Out.SelectedItem = reader["TuesdayOut2"];
                cmb_tues2Type.SelectedItem = reader["Tuesday2HourType"];
                txt_tues2Hours.Text = reader["Tuesday2HoursWorked"].ToString();
                cmb_wed2In.SelectedItem = reader["WednesdayIn2"];
                cmb_wed2Out.SelectedItem = reader["WednesdayOut2"];
                cmb_wed2Type.SelectedItem = reader["Wednesday2HourType"];
                txt_wed2Hours.Text = reader["Wednesday2HoursWorked"].ToString();
                cmb_thur2In.SelectedItem = reader["ThursdayIn2"];
                cmb_thur2Out.SelectedItem = reader["ThursdayOut2"];
                cmb_thur2Type.SelectedItem = reader["Thursday2HourType"];
                txt_thur2Hours.Text = reader["Thursday2HoursWorked"].ToString();
                cmb_fri2In.SelectedItem = reader["FridayIn2"];
                cmb_fri2Out.SelectedItem = reader["FridayOut2"];
                cmb_fri2Type.SelectedItem = reader["Friday2HourType"];
                txt_fri2Hours.Text = reader["Friday2HoursWorked"].ToString();
                cmb_sat2In.SelectedItem = reader["SaturdayIn2"];
                cmb_sat2Out.SelectedItem = reader["SaturdayOut2"];
                cmb_sat2Type.SelectedItem = reader["Saturday2HourType"];
                txt_sat2Hours.Text = reader["Saturday2HoursWorked"].ToString();
              
                txt_sun1Lunch.Text = Convert.ToString((Convert.ToDateTime(cmb_sun1Out.SelectedItem).Hour - Convert.ToDateTime(cmb_sun1In.SelectedItem).Hour) - Convert.ToDouble(txt_sun1Hours.Text.ToString()));
                txt_mon1Lunch.Text = Convert.ToString((Convert.ToDateTime(cmb_mon1Out.SelectedItem).Hour - Convert.ToDateTime(cmb_mon1In.SelectedItem).Hour) - Convert.ToDouble(txt_mon1Hours.Text.ToString()));
                txt_tues1Lunch.Text = Convert.ToString((Convert.ToDateTime(cmb_tues1Out.SelectedItem).Hour - Convert.ToDateTime(cmb_tues1In.SelectedItem).Hour) - Convert.ToDouble(txt_tues1Hours.Text.ToString()));
                txt_wed1Lunch.Text = Convert.ToString((Convert.ToDateTime(cmb_wed1Out.SelectedItem).Hour - Convert.ToDateTime(cmb_wed1In.SelectedItem).Hour) - Convert.ToDouble(txt_wed1Hours.Text.ToString()));
                txt_thur1Lunch.Text = Convert.ToString((Convert.ToDateTime(cmb_thur1Out.SelectedItem).Hour - Convert.ToDateTime(cmb_thur1In.SelectedItem).Hour) - Convert.ToDouble(txt_thur1Hours.Text.ToString()));
                txt_fri1Lunch.Text = Convert.ToString((Convert.ToDateTime(cmb_fri1Out.SelectedItem).Hour - Convert.ToDateTime(cmb_fri1In.SelectedItem).Hour) - Convert.ToDouble(txt_fri1Hours.Text.ToString()));
                txt_sat1Lunch.Text = Convert.ToString((Convert.ToDateTime(cmb_sat1Out.SelectedItem).Hour - Convert.ToDateTime(cmb_sat1In.SelectedItem).Hour) - Convert.ToDouble(txt_sat1Hours.Text.ToString()));

                txt_sun2Lunch.Text = Convert.ToString((Convert.ToDateTime(cmb_sun2Out.SelectedItem).Hour - Convert.ToDateTime(cmb_sun2In.SelectedItem).Hour) - Convert.ToDouble(txt_sun2Hours.Text.ToString()));
                txt_mon2Lunch.Text = Convert.ToString((Convert.ToDateTime(cmb_mon2Out.SelectedItem).Hour - Convert.ToDateTime(cmb_mon2In.SelectedItem).Hour) - Convert.ToDouble(txt_mon2Hours.Text.ToString()));
                txt_tues2Lunch.Text = Convert.ToString((Convert.ToDateTime(cmb_tues2Out.SelectedItem).Hour - Convert.ToDateTime(cmb_tues2In.SelectedItem).Hour) - Convert.ToDouble(txt_tues2Hours.Text.ToString()));
                txt_wed2Lunch.Text = Convert.ToString((Convert.ToDateTime(cmb_wed2Out.SelectedItem).Hour - Convert.ToDateTime(cmb_wed2In.SelectedItem).Hour) - Convert.ToDouble(txt_wed2Hours.Text.ToString()));
                txt_thur2Lunch.Text = Convert.ToString((Convert.ToDateTime(cmb_thur2Out.SelectedItem).Hour - Convert.ToDateTime(cmb_thur2In.SelectedItem).Hour) - Convert.ToDouble(txt_thur2Hours.Text.ToString()));
                txt_fri2Lunch.Text = Convert.ToString((Convert.ToDateTime(cmb_fri2Out.SelectedItem).Hour - Convert.ToDateTime(cmb_fri2In.SelectedItem).Hour) - Convert.ToDouble(txt_fri2Hours.Text.ToString()));
                txt_sat2Lunch.Text = Convert.ToString((Convert.ToDateTime(cmb_sat2Out.SelectedItem).Hour - Convert.ToDateTime(cmb_sat2In.SelectedItem).Hour) - Convert.ToDouble(txt_sat2Hours.Text.ToString()));

                calcData();
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
                    lbl_employeeNotes.Text = "Employee has notes";
                    MessageBox.Show("There are notes in the note section. Click \"Add/view Notes\" button to view"); 
                }               
            }
            else
            {
                MessageBox.Show("No data exists for this pay period");
            }
            reader.Close();
            conn.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool isTimesheetInDatabase()
        {
            string cmdText = @"select * from [tbl_EmployeeTime]
                               where [empId] = @Id AND [StartDate] = @start AND [EndDate] = @end";

            cmd = new SqlCommand(cmdText, conn);

            conn.Open();

            cmd.Parameters.AddWithValue("@Id", emp.id);
            cmd.Parameters.AddWithValue("@start", dateRange[0]);
            cmd.Parameters.AddWithValue("@end", dateRange[13]);

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

        private void btn_empSign_Click(object sender, EventArgs e)
        {
            string cmdText = @"update [tbl_EmployeeTime]
                               set [EmployeeSigned] = 1
                               where [empId] = @empId
                               AND [StartDate] = @start
                               AND [EndDate] = @end";

            cmd = new SqlCommand(cmdText, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@empId", Convert.ToInt32(emp.id));
            cmd.Parameters.AddWithValue("@start", dateRange[0]);
            cmd.Parameters.AddWithValue("@end", dateRange[13]);
           
            if (emp.sig == txt_sig.Text.ToString())
            {
                cmd.ExecuteScalar();
                MessageBox.Show("Timesheet signed");
                lbl_employeeSig.Text = "Signed";
                lbl_employeeSig.ForeColor = Color.Green;
            }
            else
            {
                MessageBox.Show("incorrect pin");
            }
            conn.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (isTimesheetInDatabase())
            {
                calcData();               

                string cmdText = @"update [tbl_EmployeeTime] 
                                   set [SundayIn1]=@SundayIn1, [SundayOut1]=@SundayOut1, [Sunday1HoursWorked]=@Sunday1HoursWorked,[Sunday1HourType]=@Sunday1HourType, [MondayIn1]=@MondayIn1, [MondayOut1]=@MondayOut1, [Monday1HoursWorked]=@Monday1HoursWorked,[Monday1HourType]=@Monday1HourType,[TuesdayIn1]=@TuesdayIn1,[TuesdayOut1]=@TuesdayOut1,[Tuesday1HoursWorked]=@Tuesday1HoursWorked,[Tuesday1HourType]=@Tuesday1HourType,
                                    [WednesdayIn1]=@WednesdayIn1,[WednesdayOut1]=@WednesdayOut1,[Wednesday1HoursWorked]=@Wednesday1HoursWorked,
                                    [Wednesday1HourType]=@Wednesday1HourType,[ThursdayIn1]=@ThursdayIn1,[ThursdayOut1]=@ThursdayOut1,[Thursday1HoursWorked]=@Thursday1HoursWorked,
                                    [Thursday1HourType]=@Thursday1HourType,[FridayIn1]=@FridayIn1,[FridayOut1]=@FridayOut1,[Friday1HoursWorked]=@Friday1HoursWorked,
                                    [Friday1HourType]=@Friday1HourType,[SaturdayIn1]=@SaturdayIn1,[SaturdayOut1]=@SaturdayOut1,[Saturday1HoursWorked]=@Saturday1HoursWorked,
                                    [Saturday1HourType]=@Saturday1HourType,[Week1Vacation]=@Week1Sick,[Week1Sick]=@Week1Vacation,[Week1Holiday]=@Week1Holiday,
                                    [Week1Regular]=@Week1Regular,[Week1HoursWorked]=@Week1HoursWorked,[SundayIn2]=@SundayIn2, [SundayOut2]=@SundayOut2, [Sunday2HoursWorked]=@Sunday2HoursWorked,
                                    [Sunday2HourType]=@Sunday2HourType,[MondayIn2]=@MondayIn2,[MondayOut2]=@MondayOut2,[Monday2HoursWorked]=@Monday2HoursWorked,
                                    [Monday2HourType]=@Monday2HourType,[TuesdayIn2]=@TuesdayIn2,[TuesdayOut2]=@TuesdayOut2,[Tuesday2HoursWorked]=@Tuesday2HoursWorked,
                                    [Tuesday2HourType]=@Tuesday2HourType,[WednesdayIn2]=@WednesdayIn2,[WednesdayOut2]=@WednesdayOut2,[Wednesday2HoursWorked]=@Wednesday2HoursWorked,
                                    [Wednesday2HourType]=@Wednesday2HourType,[ThursdayIn2]=@ThursdayIn2,[ThursdayOut2]=@ThursdayOut2,[Thursday2HoursWorked]=@Thursday2HoursWorked,
                                    [Thursday2HourType]=@Thursday2HourType,[FridayIn2]=@FridayIn2,[FridayOut2]=@FridayOut2,[Friday2HoursWorked]=@Friday2HoursWorked,
                                    [Friday2HourType]=@Friday2HourType,[SaturdayIn2]=@SaturdayIn2,[SaturdayOut2]=@SaturdayOut2,[Saturday2HoursWorked]=@Saturday2HoursWorked,
                                    [Saturday2HourType]=@Saturday2HourType,[Week2Vacation]=@Week2Vacation,[Week2Sick]=@Week2Sick,[Week2Holiday]=@Week2Holiday,[Week2Regular]=@Week2Regular,[Week2HoursWorked]=@Week2HoursWorked,
                                    [EmployeeSigned] = 0, [SupervisorSigned] = 0 where [StartDate]=@start AND [EndDate] = @end AND [EmployeeSigned] = @Id";

                cmd = new SqlCommand(cmdText, conn);

                conn.Open();
                try
                {
                    cmd.Parameters.AddWithValue("@Id", emp.id);               
                    cmd.Parameters.AddWithValue("@start", dateRange[0]);
                    cmd.Parameters.AddWithValue("@SundayIn1", cmb_sun1In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SundayOut1", cmb_sun1Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Sunday1HoursWorked", Convert.ToDouble(txt_sun1Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Sunday1HourType", cmb_sun1Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@MondayIn1", cmb_mon1In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@mondayOut1", cmb_mon1Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Monday1HoursWorked", Convert.ToDouble(txt_mon1Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Monday1HourType", cmb_mon1Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@TuesdayIn1", cmb_tues1In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@TuesdayOut1", cmb_tues1Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Tuesday1HoursWorked", Convert.ToDouble(txt_tues1Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Tuesday1HourType", cmb_tues1Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@WednesdayIn1", cmb_wed1In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@WednesdayOut1", cmb_wed1Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Wednesday1HoursWorked", Convert.ToDouble(txt_wed1Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Wednesday1HourType", cmb_wed1Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ThursdayIn1", cmb_thur1In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ThursdayOut1", cmb_thur1Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Thursday1HoursWorked", Convert.ToDouble(txt_thur1Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Thursday1HourType", cmb_thur1Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@FridayIn1", cmb_fri1In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@FridayOut1", cmb_fri1Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Friday1HoursWorked", Convert.ToDouble(txt_fri1Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Friday1HourType", cmb_fri1Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SaturdayIn1", cmb_sat1In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SaturdayOut1", cmb_sat1Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Saturday1HoursWorked", Convert.ToDouble(txt_sat1Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Saturday1HourType", cmb_sat1Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Week1Vacation", Convert.ToDouble(txt_w1Vac.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Week1Sick", Convert.ToDouble(txt_w1Sick.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Week1Holiday", Convert.ToDouble(txt_w1Hol.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Week1Regular", Convert.ToDouble(txt_w1Reg.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Week1HoursWorked", Convert.ToDouble(txt_w1Total.Text.ToString()));

                    cmd.Parameters.AddWithValue("@SundayIn2", cmb_sun2In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SundayOut2", cmb_sun2Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Sunday2HoursWorked", Convert.ToDouble(txt_sun2Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Sunday2HourType", cmb_sun2Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@MondayIn2", cmb_mon2In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@mondayOut2", cmb_mon2Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Monday2HoursWorked", Convert.ToDouble(txt_mon2Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Monday2HourType", cmb_mon2Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@TuesdayIn2", cmb_tues2In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@TuesdayOut2", cmb_tues2Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Tuesday2HoursWorked", Convert.ToDouble(txt_tues2Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Tuesday2HourType", cmb_tues2Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@WednesdayIn2", cmb_wed2In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@WednesdayOut2", cmb_wed2Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Wednesday2HoursWorked", Convert.ToDouble(txt_wed2Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Wednesday2HourType", cmb_wed2Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ThursdayIn2", cmb_thur2In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ThursdayOut2", cmb_thur2Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Thursday2HoursWorked", Convert.ToDouble(txt_thur2Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Thursday2HourType", cmb_thur2Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@FridayIn2", cmb_fri2In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@FridayOut2", cmb_fri2Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Friday2HoursWorked", Convert.ToDouble(txt_fri2Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Friday2HourType", cmb_fri2Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SaturdayIn2", cmb_sat2In.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SaturdayOut2", cmb_sat2Out.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Saturday2HoursWorked", Convert.ToDouble(txt_sat2Hours.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Saturday2HourType", cmb_sat2Type.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Week2Vacation", Convert.ToDouble(txt_w2Vac.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Week2Sick", Convert.ToDouble(txt_w2Sick.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Week2Holiday", Convert.ToDouble(txt_w2Hol.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Week2Regular", Convert.ToDouble(txt_w2Reg.Text.ToString()));
                    cmd.Parameters.AddWithValue("@Week2HoursWorked", Convert.ToDouble(txt_w2Total.Text.ToString()));
                    cmd.Parameters.AddWithValue("@end", dateRange[13]);
                }
                catch (Exception ex)
                {

                }

                cmd.ExecuteScalar();

                MessageBox.Show("Timesheet Updated");

                lbl_employeeSig.Text = "Not Signed";
                lbl_employeeSig.ForeColor = Color.Black;

                lbl_supSig.Text = "Not Signed";
                lbl_supSig.ForeColor = Color.Black;

            }
            else
            {
                MessageBox.Show("Time Sheet Data for this pay does not exist. Please use the Submit button");
            }
            conn.Close();
        }

        private void btn_note_Click(object sender, EventArgs e)
        {
            if (isTimesheetInDatabase())
            {
                noteForm nf = new noteForm(emp, dateRange[0], true);
                nf.ShowDialog();
            }
            else
            {
                MessageBox.Show("there is no time sheet data too add notes to. submit time sheet data before entering a note");
            }
        }
    }
}
