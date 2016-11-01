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
    public partial class DishForm : Form
    {
        protected OracleConnection conn;
        public static String table_no;
        public static String order_list_no;
        public DishForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        protected void DishForm_Load(object sender, EventArgs e)
        {
            conn = DB.DBConnection.Conn();
            string queryString = "SELECT * FROM MENU";
            OracleCommand Command = conn.CreateCommand();
            Command.CommandText = queryString;
            OracleDataAdapter oraDA = new OracleDataAdapter(Command);
            DataSet ds = new DataSet();
            oraDA.Fill(ds);
            DataTable dtbl = ds.Tables[0];
            this.dataGridView1.DataSource = dtbl;

            string queryString1 = "SELECT DISH_NAME,DISH_AMOUNT FROM ORDER_LIST WHERE ORDER_NO='" + order_list_no + "' and TABLE_NO=" + table_no;
            OracleCommand Command1 = conn.CreateCommand();
            Command1.CommandText = queryString1;
            OracleDataAdapter oraDA1 = new OracleDataAdapter(Command1);
            DataSet ds1 = new DataSet();
            oraDA1.Fill(ds1);
            DataTable dtbl1 = ds1.Tables[0];
            this.dataGridView2.DataSource = dtbl1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertDishForm iForm = new InsertDishForm();
            iForm.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            table_no = textBox1.Text.Trim().ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            order_list_no = textBox2.Text.Trim().ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DishForm_Load(sender,e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteDishForm delForm = new DeleteDishForm();
            delForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //conn = DB.DBConnection.Conn();

            /*String sql = "insert into DISH_STATE(DISH_STATE.ORDER_NO,DISH_STATE.TABLE_NO,DISH_STATE.DISH_NAME,DISH_STATE.DISH_NO) select ORDER_LIST.ORDER_NO,ORDER_LIST.TABLE_NO,ORDER_LIST.DISH_NAME,ORDER_LIST.DISH_NO from ORDER_LIST where ORDER_LIST.ORDER_NO=" + order_list_no+ "and ORDER_LIST.TABLE_NO=" +table_no;
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            object a = cmd.ExecuteScalar();*/
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DetailedDishForm detForm = new DetailedDishForm();
            detForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            StateDishForm stForm = new StateDishForm();
            stForm.Show();
        }
    }
}
