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
    public partial class InsertReportForm : Form
    {
        protected OracleConnection conn;
        public InsertReportForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = DB.DBConnection.Conn();
            String Insertsql = "insert into DISH_EVALUATION values (f.nextval," + textBox1.Text.Trim().ToString() + ",'" + textBox2.Text.Trim().ToString() + "','" + textBox3.Text.Trim().ToString() + "',sysdate)";
            OracleCommand cmd = new OracleCommand(Insertsql, conn);
            cmd.CommandType = CommandType.Text;
            object a = cmd.ExecuteScalar();
            MessageBox.Show("添加成功！", "提示");
            this.Hide();
        }
    }
}
