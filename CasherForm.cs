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
    public partial class CasherForm : Form
    {
        protected OracleConnection conn;
        public static String t;
        public CasherForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String loginID = Form1.userID;
            conn = DB.DBConnection.Conn();
            String attendancesql1 = "select STAFF_NAME from STAFF_INFO where STAFF_ID=" + loginID;
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

        private void button3_Click(object sender, EventArgs e)
        {
            CasherForm_Load(sender, e);
        }

        private void CasherForm_Load(object sender, EventArgs e)
        {                     
            conn = DB.DBConnection.Conn();
            string queryString1 = "SELECT * FROM ORDER_LIST WHERE ORDER_NO=" + textBox2.Text.Trim().ToString() + "and TABLE_NO=" + textBox1.Text.Trim().ToString();
            OracleCommand Command1 = conn.CreateCommand();
            Command1.CommandText = queryString1;
            OracleDataAdapter oraDA1 = new OracleDataAdapter(Command1);
            DataSet ds1 = new DataSet();
            oraDA1.Fill(ds1);
            DataTable dtbl1 = ds1.Tables[0];
            this.dataGridView1.DataSource = dtbl1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn = DB.DBConnection.Conn();
            t = textBox2.Text.Trim().ToString();
            String updatesql = "insert into BILL values(a.nextval," + textBox1.Text.Trim().ToString() + "," + textBox2.Text.Trim().ToString() + "," + PayForm.result + ",0,sysdate)";
            //Console.WriteLine(PayForm.result);
            OracleCommand cmd3 = new OracleCommand(updatesql, conn);
            cmd3.CommandType = CommandType.Text;
            object c = cmd3.ExecuteScalar();
            
            string queryString1 = "SELECT * FROM BILL WHERE ORDER_NO=" + textBox2.Text.Trim().ToString() + "and TABLE_NO=" + textBox1.Text.Trim().ToString();
            OracleCommand Command1 = conn.CreateCommand();
            Command1.CommandText = queryString1;
            OracleDataAdapter oraDA1 = new OracleDataAdapter(Command1);
            DataSet ds1 = new DataSet();
            oraDA1.Fill(ds1);
            DataTable dtbl1 = ds1.Tables[0];
            this.dataGridView1.DataSource = dtbl1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PaymethodForm paymForm = new PaymethodForm();
            paymForm.Show();
        }

        private void 刷新_Click(object sender, EventArgs e)
        {
            CasherForm_Load(sender,e);
        }
    }
}
