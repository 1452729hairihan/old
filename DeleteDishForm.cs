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
    public partial class DeleteDishForm : Form
    {
        protected OracleConnection conn;
        String dish_no;
        public DeleteDishForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = DB.DBConnection.Conn();

            String searchsql0 = "select * from ORDER_LIST where DISH_NO=" + dish_no + "and ORDER_NO=" + DishForm.order_list_no;
            OracleCommand cmd1 = new OracleCommand(searchsql0, conn);
            cmd1.CommandType = CommandType.Text;
            object b = cmd1.ExecuteScalar();

            if (b != null)
            {
                String Deletesql = "delete from ORDER_LIST where DISH_NO=" + dish_no + "and ORDER_NO=" + DishForm.order_list_no;
                OracleCommand cmd = new OracleCommand(Deletesql, conn);
                cmd.CommandType = CommandType.Text;
                object a = cmd.ExecuteScalar();
                MessageBox.Show("删除成功！", "提示");
                this.Hide();
                String Deletesql1 = "delete from DISH_STATE where DISH_NO=" + dish_no + "and ORDER_NO=" + DishForm.order_list_no + "and TABLE_NO=" + DishForm.table_no;
                OracleCommand cmd2 = new OracleCommand(Deletesql1, conn);
                cmd2.CommandType = CommandType.Text;
                object c = cmd2.ExecuteScalar();
            }
            else
            {
                MessageBox.Show("该菜品未点过，请再次确认！", "提示");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dish_no = textBox1.Text.Trim().ToString();
        }
    }
}
