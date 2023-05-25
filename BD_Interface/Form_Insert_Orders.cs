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
    public partial class Form_Insert_Orders : Form
    {
        MySqlConnection conn = new MySqlConnection("server=127.0.0.1;port=3306;user id = root;password=1234; Database = car_service");
        public Form_Insert_Orders()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertData();
            
        }

        private void InsertData()
        {
            conn.Open();

            string ins_string = "INSERT INTO `orders`(`car_code`, `owner_code`, `delivery_date`) VALUES ('" + textBox1.Text + "', '" +
                                    textBox2.Text + "', '" + textBox3.Text + "')";
            var cmd = conn.CreateCommand();
            cmd.CommandText = ins_string;
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    throw new Exception();
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Добавлено!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {

                MessageBox.Show("Заполните корректно все поля!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                conn.Close();
            }
        }
    }
}
