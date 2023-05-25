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
    public partial class Form_Select_NestedQueries : Form
    {
        MySqlConnection conn = new MySqlConnection("server=127.0.0.1;port=3306;user id=root;password=1234; Database = car_service");
        public Form_Select_NestedQueries()
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
            string query = "SELECT CONCAT(lastname, ' ', SUBSTR(firstname, 1, 1), '.', IF (middlename != '', CONCAT (SUBSTR(middlename, 1, 1), '.'), '')) " +
                "as FIO, SUBSTR(max_date,1, 10) FROM (SELECT owner_code, delivery_date as max_date FROM orders " +
                "WHERE delivery_date = (SELECT max(owner_max_date) FROM (SELECT owner_code, max(delivery_date) as owner_max_date FROM orders " +
                "GROUP BY owner_code) as t1)) as t2 JOIN owners on owners.id = t2.owner_code";

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
