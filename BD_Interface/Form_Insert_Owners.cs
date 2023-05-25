using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BD_Interface
{
    public partial class Form_Insert_Owners : Form
    {
        MySqlConnection conn = new MySqlConnection("server=127.0.0.1;port=3306;user id = root;password=1234; Database = car_service");
        public Form_Insert_Owners()
        {
            InitializeComponent();
        }

        private void InsertData()
        {
            conn.Open();

            string ins_string = "INSERT INTO `owners`(`lastname`, `firstname`, `middlename`, `phone_number`, `bonus_card`) VALUES ('" + textBox1.Text + "', '" +
                                    textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + " ')";
            var cmd = conn.CreateCommand();
            cmd.CommandText = ins_string;
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                {
                    throw new Exception();
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Добавлено!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                
                MessageBox.Show("Заполните все поля!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            finally
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertData();
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
