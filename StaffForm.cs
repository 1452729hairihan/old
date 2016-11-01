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
    public partial class StaffForm : Form
    {
        protected OracleConnection conn;
        public StaffForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void table001_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = DB.DBConnection.Conn();
            string queryString = "SELECT * FROM DINNING_TABLE";
            OracleCommand Command = conn.CreateCommand();

            Command.CommandText = queryString;

            //conn.Open();

            OracleDataAdapter oraDA = new OracleDataAdapter(Command);
            DataSet ds = new DataSet();
            oraDA.Fill(ds); 
            DataTable dtbl = ds.Tables[0];
            this.dataGridView1.DataSource = dtbl;
            //conn.Close();
        }

        private void table002_Click(object sender, EventArgs e)
        {

        }

        private void StaffForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenForm oForm1 = new OpenForm();
            oForm1.Show();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
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
            //Console.WriteLine(name);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DishForm dForm1 = new DishForm();
            dForm1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PayForm pForm = new PayForm();
            pForm.Show();
        }

        
    }
}
