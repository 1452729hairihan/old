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
    public partial class InsertDishForm : Form
    {
        protected OracleConnection conn;
        String dish_no;
        String dish_amount;
        public InsertDishForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dish_no = textBox1.Text.Trim().ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dish_amount = textBox2.Text.Trim().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = DB.DBConnection.Conn();

            String searchsql0 = "select * from ORDER_LIST where DISH_NO=" + dish_no + "and TABLE_NO=" + textBox4.Text.Trim().ToString() + "and ORDER_NO=" + textBox3.Text.Trim().ToString();
            OracleCommand cmd1 = new OracleCommand(searchsql0, conn);
            cmd1.CommandType = CommandType.Text;
            object b = cmd1.ExecuteScalar();
         
            if (b == null)
            {
                String searchsql = "select DISH_NAME from MENU where DISH_NO=" + dish_no;
                OracleCommand cmd0 = new OracleCommand(searchsql, conn);
                cmd0.CommandType = CommandType.Text;
                object aa = cmd0.ExecuteScalar();
                String dish_name = aa.ToString();
                String Insertsql = "insert into ORDER_LIST values (" + textBox3.Text.Trim().ToString() + "," + textBox4.Text.Trim().ToString() + "," + dish_no + "," + "N'" + dish_name + "'" + "," + dish_amount + ")";
                OracleCommand cmd = new OracleCommand(Insertsql, conn);
                cmd.CommandType = CommandType.Text;
                object a = cmd.ExecuteScalar();
                MessageBox.Show("点菜成功！", "提示");
                this.Hide();

                String sql = "insert into DISH_STATE values(" + DishForm.order_list_no + "," + DishForm.table_no + ",'" + dish_name + "','制作中'," + dish_no + ")";
                OracleCommand cmd2 = new OracleCommand(sql, conn);
                cmd2.CommandType = CommandType.Text;
                object c = cmd2.ExecuteScalar();
            }
            else
            {
                String searchsql3 = "select DISH_AMOUNT from ORDER_LIST where DISH_NO=" + dish_no + "and TABLE_NO=" + textBox4.Text.Trim().ToString() + "and ORDER_NO=" + textBox3.Text.Trim().ToString();
                OracleCommand cmd3 = new OracleCommand(searchsql3, conn);
                cmd3.CommandType = CommandType.Text;
                object d = cmd3.ExecuteScalar();
                int amount = int.Parse(d.ToString());
                int dish_a = int.Parse(dish_amount);
                amount += dish_a;
                String searchsql2 = "update ORDER_LIST set DISH_AMOUNT=" + amount + " where DISH_NO=" + dish_no + "and TABLE_NO=" + textBox4.Text.Trim().ToString() + "and ORDER_NO=" + textBox3.Text.Trim().ToString();
                OracleCommand cmd2 = new OracleCommand(searchsql2, conn);
                cmd1.CommandType = CommandType.Text;
                object c = cmd2.ExecuteScalar();
                MessageBox.Show("加菜成功！", "提示");
                this.Hide();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        

       
    }
}
