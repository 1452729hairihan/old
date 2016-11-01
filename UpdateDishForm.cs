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
    public partial class UpdateDishForm : Form
    {
        protected OracleConnection conn;
        String upDish;
        public UpdateDishForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = DB.DBConnection.Conn();
            String Updatesql = "update DISH_INFO set DISH_NO=" + textBox1.Text.Trim().ToString() + ",DISH_CATEGORY='" + textBox3.Text.Trim().ToString() + "',MATERIAL_NAME='" + textBox4.Text.Trim().ToString() + "',FLAVOR='" + textBox5.Text.Trim().ToString() + "',DISH_NAME='" + textBox2.Text.Trim().ToString() + "' where DISH_NO=" + upDish;
            OracleCommand cmd = new OracleCommand(Updatesql, conn);
            cmd.CommandType = CommandType.Text;
            object a = cmd.ExecuteScalar();
            MessageBox.Show("修改成功！", "提示");
            this.Hide();

            String Updatesql1 = "update MENU set DISH_NO=" + textBox1.Text.Trim().ToString() + ",DISH_NAME='" + textBox2.Text.Trim().ToString() + "',PRICE=" + textBox6.Text.Trim().ToString() + " where DISH_NO=" + upDish;
            OracleCommand cmd2 = new OracleCommand(Updatesql1, conn);
            cmd2.CommandType = CommandType.Text;
            object c = cmd2.ExecuteScalar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            upDish = textBox1.Text.Trim().ToString();
        }
    }
}
