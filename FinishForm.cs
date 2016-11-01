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

    public partial class FinishForm : Form
    {
        protected OracleConnection conn;
        public FinishForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = DB.DBConnection.Conn();
            String finishsql = " update DISH_STATE set DISH_STATE='已做好' where DISH_NO=" + textBox3.Text.Trim().ToString() + "and TABLE_NO=" + textBox2.Text.Trim().ToString() + "and ORDER_NO=" + textBox1.Text.Trim().ToString();
            OracleCommand cmd4 = new OracleCommand(finishsql, conn);
            cmd4.CommandType = CommandType.Text;
            object d = cmd4.ExecuteScalar();
            this.Hide();
            MessageBox.Show("菜品状态已更新！", "提示");
        }
    }
}
