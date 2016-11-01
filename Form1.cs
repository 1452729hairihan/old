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
    public partial class Form1 : Form
    {
        protected OracleConnection Conn;
        protected int amount;
        public static String userID;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString; string queryString;

            connectionString = "Data Source=(DESCRIPTION=" + "(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))"

                + "(CONNECT_DATA=(SERVICE_NAME=RestService)));"

                + "User Id=SWIFT;Password=Oracle12c";

            queryString = "SELECT * FROM TEST";

            Conn = new OracleConnection(connectionString);

            OracleCommand Command = Conn.CreateCommand();

            Command.CommandText = queryString;

            Conn.Open();

            if (loginbyusernameandpwd())
            {
                //登录成功
                
                userID = textBox1.Text.Trim().ToString();
                if (amount >= 100000 && amount < 110000)
                {
                    StaffForm sForm = new StaffForm();
                    sForm.Show();
                }
                else if (amount >= 110000 && amount < 120000)  
                {
                    ManagerForm mForm = new ManagerForm();
                    mForm.Show();
                }
                else if (amount >= 120000 && amount < 130000)
                {
                    CookForm coForm = new CookForm();
                    coForm.Show();
                }
                else if (amount >= 130000 && amount < 140000)
                {
                    CasherForm caForm = new CasherForm();
                    caForm.Show();
                }
                else if (amount >= 140000 && amount < 150000)
                {
                    FrontLogisticForm fForm = new FrontLogisticForm();
                    fForm.Show();
                }
                else if (amount >= 150000 && amount < 160000)
                {
                    KitchenLogisticForm kForm = new KitchenLogisticForm();
                    kForm.Show();
                }
                //this.Hide();
                //Console.WriteLine("yes!");
            }
            else
            {
                //用户名或密码错误
                ErrorForm1 eForm1 = new ErrorForm1();
                eForm1.Show();
                //Console.WriteLine("error");
            }
            Conn.Close();
        }

        private bool loginbyusernameandpwd()
        {

            String sql = "select * from STAFF_INFO where STAFF_ID='" + textBox1.Text.Trim().ToString() + "' and PASSWORD='" + textBox2.Text.Trim().ToString() + "' ";
            OracleCommand cmd = new OracleCommand(sql, Conn);
            cmd.CommandType = CommandType.Text;
            object a = cmd.ExecuteScalar();
            if (a == null)
                return false;
            else
            {
                amount = int.Parse(a.ToString());
                return true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
