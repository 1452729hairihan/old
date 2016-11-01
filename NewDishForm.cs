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
    public partial class NewDishForm : Form
    {
        protected OracleConnection conn;
        public NewDishForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = DB.DBConnection.Conn();
            String Insertsql = "insert into DISH_INFO values (" + textBox1.Text.Trim().ToString() + ",'" + textBox3.Text.Trim().ToString() + "','" + textBox4.Text.Trim().ToString() + "','" + textBox5.Text.Trim().ToString() + "','" + textBox2.Text.Trim().ToString() + "')";
            OracleCommand cmd = new OracleCommand(Insertsql, conn);
            cmd.CommandType = CommandType.Text;
            object a = cmd.ExecuteScalar();
            MessageBox.Show("添加成功！", "提示");
            this.Hide();

            String Insertsql1 = "insert into MENU values (" + textBox1.Text.Trim().ToString() + ",'" + textBox2.Text.Trim().ToString() + "'," + textBox6.Text.Trim().ToString() +")";
            OracleCommand cmd1 = new OracleCommand(Insertsql1, conn);
            cmd1.CommandType = CommandType.Text;
            object b = cmd1.ExecuteScalar();
        }
    }
}
