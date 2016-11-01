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
    public partial class UpdateClerkForm : Form
    {
        protected OracleConnection conn;
        String St_ID;
        public UpdateClerkForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = DB.DBConnection.Conn();

            String sql = "select * from STAFF_INFO where STAFF_ID=" + St_ID;
            OracleCommand cmd1 = new OracleCommand(sql, conn);
            cmd1.CommandType = CommandType.Text;
            object b = cmd1.ExecuteScalar();
            if (b != null)
            {
                String Updatesql = "update STAFF_INFO set STAFF_ID=" + textBox1.Text.Trim().ToString() + ",STAFF_NAME='" + textBox2.Text.Trim().ToString() + "',GENDER='" + textBox3.Text.Trim().ToString() + "',POSITION='" + textBox4.Text.Trim().ToString() + "',CONTACT='" + textBox5.Text.Trim().ToString() + "',ADDRESS='" + textBox6.Text.Trim().ToString() + "',SALARY=" + textBox7.Text.Trim().ToString() + ",PASSWORD='" + textBox8.Text.Trim().ToString() + "' where STAFF_ID=" + St_ID;
                OracleCommand cmd = new OracleCommand(Updatesql, conn);
                cmd.CommandType = CommandType.Text;
                object a = cmd.ExecuteScalar();
                MessageBox.Show("修改成功！", "提示");
                this.Hide();
            }
            else
            {
                MessageBox.Show("未找到该员工，请重试!", "提示");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            St_ID = textBox1.Text.Trim().ToString();
        }
    }
}
