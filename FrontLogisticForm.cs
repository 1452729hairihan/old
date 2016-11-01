using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace RestService
{
    public partial class FrontLogisticForm : Form
    {
        protected OracleConnection conn;
        public FrontLogisticForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String loginID = Form1.userID;
            conn = DB.DBConnection.Conn();
            String attendancesql1 = "select STAFF_NAME from STAFF_INFO where STAFF_ID="+loginID;
            OracleCommand cmd = new OracleCommand(attendancesql1, conn);
            cmd.CommandType = CommandType.Text;
            object a = cmd.ExecuteScalar();
            MessageBox.Show("考勤成功！", "提示");
            String attendancesql2 = " update WORK_ATTENDANCE set IS_PRESENT=1 where STAFF_ID=" + loginID;
            OracleCommand cmd2 = new OracleCommand(attendancesql2, conn);
            cmd2.CommandType = CommandType.Text;
            object b = cmd2.ExecuteScalar();

            String updatesql = "update WORK_ATTENDANCE set ATT_DATE=sysdate where STAFF_ID=" + loginID;
            OracleCommand cmd3 = new OracleCommand(updatesql, conn);
            cmd3.CommandType = CommandType.Text;
            object c = cmd3.ExecuteScalar();
        }

        private void FrontLogisticForm_Load(object sender, EventArgs e)
        {
            conn = DB.DBConnection.Conn();
            string queryString1 = "SELECT * FROM WORK_ATTENDANCE";
            OracleCommand Command1 = conn.CreateCommand();
            Command1.CommandText = queryString1;
            OracleDataAdapter oraDA1 = new OracleDataAdapter(Command1);
            DataSet ds1 = new DataSet();
            oraDA1.Fill(ds1);
            DataTable dtbl1 = ds1.Tables[0];
            this.dataGridView1.DataSource = dtbl1;

            string queryString = "SELECT * FROM PREPAID_CARD";
            OracleCommand Command = conn.CreateCommand();
            Command.CommandText = queryString;
            OracleDataAdapter oraDA = new OracleDataAdapter(Command);
            DataSet ds = new DataSet();
            oraDA.Fill(ds);
            DataTable dtbl = ds.Tables[0];
            this.dataGridView2.DataSource = dtbl;

            string queryString2 = "SELECT * FROM CLEANING";
            OracleCommand Command2 = conn.CreateCommand();
            Command2.CommandText = queryString2;
            OracleDataAdapter oraDA2 = new OracleDataAdapter(Command2);
            DataSet ds2 = new DataSet();
            oraDA2.Fill(ds2);
            DataTable dtbl2 = ds2.Tables[0];
            this.dataGridView3.DataSource = dtbl2;

            string queryString3 = "SELECT * FROM FACILITIES";
            OracleCommand Command3 = conn.CreateCommand();
            Command3.CommandText = queryString3;
            OracleDataAdapter oraDA3 = new OracleDataAdapter(Command3);
            DataSet ds3 = new DataSet();
            oraDA3.Fill(ds3);
            DataTable dtbl3 = ds3.Tables[0];
            this.dataGridView4.DataSource = dtbl3;

            string queryString4 = "SELECT * FROM DISH_EVALUATION";
            OracleCommand Command4 = conn.CreateCommand();
            Command4.CommandText = queryString4;
            OracleDataAdapter oraDA4 = new OracleDataAdapter(Command4);
            DataSet ds4 = new DataSet();
            oraDA4.Fill(ds4);
            DataTable dtbl4 = ds4.Tables[0];
            this.dataGridView5.DataSource = dtbl4;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrontLogisticForm_Load(sender,e);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 考勤信息_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            ExpendForm exForm = new ExpendForm();
            exForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AttendanceForm atForm = new AttendanceForm();
            atForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            InsertReportForm inForm = new InsertReportForm();
            inForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DeleteReportForm deForm = new DeleteReportForm();
            deForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            NewCardForm neForm = new NewCardForm();
            neForm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            UpdateCardForm upForm = new UpdateCardForm();
            upForm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DeleteCardForm deForm = new DeleteCardForm();
            deForm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            UpdateCleaningForm updForm = new UpdateCleaningForm();
            updForm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            InsertFacilityForm insForm = new InsertFacilityForm();
            insForm.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DeleteFacilityForm delForm = new DeleteFacilityForm();
            delForm.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            UpdateFacilityForm updaForm = new UpdateFacilityForm();
            updaForm.Show();
        }
    }
}
