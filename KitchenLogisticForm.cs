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
    public partial class KitchenLogisticForm : Form
    {
        protected OracleConnection conn;
        public KitchenLogisticForm()
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

        private void KitchenLogisticForm_Load(object sender, EventArgs e)
        {
            conn = DB.DBConnection.Conn();
            string queryString1 = "SELECT * FROM MATERIAL";
            OracleCommand Command1 = conn.CreateCommand();
            Command1.CommandText = queryString1;
            OracleDataAdapter oraDA1 = new OracleDataAdapter(Command1);
            DataSet ds1 = new DataSet();
            oraDA1.Fill(ds1);
            DataTable dtbl1 = ds1.Tables[0];
            this.dataGridView1.DataSource = dtbl1;

            string queryString = "SELECT * FROM DISH_INFO";
            OracleCommand Command = conn.CreateCommand();
            Command.CommandText = queryString;
            OracleDataAdapter oraDA = new OracleDataAdapter(Command);
            DataSet ds = new DataSet();
            oraDA.Fill(ds);
            DataTable dtbl = ds.Tables[0];
            this.dataGridView2.DataSource = dtbl;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            KitchenLogisticForm_Load(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddMaterialForm adForm = new AddMaterialForm();
            adForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateMaterialForm umForm = new UpdateMaterialForm();
            umForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteMaterialForm delForm = new DeleteMaterialForm();
            delForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NewDishForm ndForm = new NewDishForm();
            ndForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UpdateDishForm udForm = new UpdateDishForm();
            udForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DelDishForm ddForm = new DelDishForm();
            ddForm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ExpendForm exForm = new ExpendForm();
            exForm.Show();
        }
    }
}
