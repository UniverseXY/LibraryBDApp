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
    public partial class Form_Select_Multitable : Form
    {
        MySqlConnection conn = new MySqlConnection("server=127.0.0.1;port=3306;user id=root;password=1234; Database = car_service");
        public Form_Select_Multitable()
        {
            InitializeComponent();
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadData()
        {

            conn.Open();
            List<string[]> data = new List<string[]>();
            string query = "SELECT CONCAT(lastname, ' ', SUBSTR(firstname, 1, 1), '.', IF (middlename != '', CONCAT(SUBSTR(middlename, 1, 1), '.'), '' ))" +
                "AS fio, orders.id, delivery_date FROM owners JOIN orders ON owners.id = orders.owner_code" +
                 " WHERE CAST(SUBSTR(delivery_date, 1, 4) AS INT) > 2021 ORDER BY lastname";

            var cmd = conn.CreateCommand();
            cmd.CommandText = query;
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    data.Add(new string[reader.FieldCount]);
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        data[data.Count - 1][i] = reader[i].ToString();
                    }

                }
            }
            reader.Close();
            conn.Close();
            foreach (string[] s in data)
            {
                dataGridView1.Rows.Add(s);
            }

        }
    }
}
