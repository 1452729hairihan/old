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
    public partial class ExpendForm : Form
    {
        protected OracleConnection conn;
        public ExpendForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = DB.DBConnection.Conn();
            String Expendsql = "insert into EXPENDITURE values (c.nextval,'" + textBox2.Text.Trim().ToString() + "'," + textBox1.Text.Trim().ToString() + ",sysdate)";
            OracleCommand cmd = new OracleCommand(Expendsql, conn);
            cmd.CommandType = CommandType.Text;
            object a = cmd.ExecuteScalar();
            //this.Hide();
            MessageBox.Show("添加支出成功！", "提示");
        }

        private void ExpendForm_Load(object sender, EventArgs e)
        {
            conn = DB.DBConnection.Conn();
            string queryString1 = "SELECT * FROM EXPENDITURE";
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
            ExpendForm_Load(sender, e);
        }
    }
}
