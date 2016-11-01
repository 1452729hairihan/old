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
    public partial class DelDishForm : Form
    {
        protected OracleConnection conn;
        public DelDishForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = DB.DBConnection.Conn();

            String searchsql0 = "select * from DISH_INFO where DISH_NO=" + textBox1.Text.Trim().ToString();
            OracleCommand cmd1 = new OracleCommand(searchsql0, conn);
            cmd1.CommandType = CommandType.Text;
            object b = cmd1.ExecuteScalar();

            if (b != null)
            {
                String Deletesql = "delete from DISH_INFO where DISH_NO=" + textBox1.Text.Trim().ToString();
                OracleCommand cmd = new OracleCommand(Deletesql, conn);
                cmd.CommandType = CommandType.Text;
                object a = cmd.ExecuteScalar();
                MessageBox.Show("删除菜品成功！", "提示");
                this.Hide();

                String Deletesql1 = "delete from MENU where DISH_NO=" + textBox1.Text.Trim().ToString();
                OracleCommand cmd2 = new OracleCommand(Deletesql1, conn);
                cmd2.CommandType = CommandType.Text;
                object c = cmd2.ExecuteScalar();
            }
            else
            {
                MessageBox.Show("该菜品不存在，请再次确认！", "提示");
            }
        }
    }
}
