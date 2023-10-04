using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class CompleteBookDetails : Form
    {
        public CompleteBookDetails()
        {
            InitializeComponent();
        }

        private void CompleteBookDetails_Load(object sender, EventArgs e)
        {
            String connection = "Data Source=DESKTOP-8CIT305\\SQLEXPRESS;Initial Catalog=loginTb;Integrated Security=True";
            String Query1 = "select * from IRBook where book_return_date is null";
            String Query2 = "select * from IRBook where book_return_date is not null";
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(Query1, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    dataGridView1.DataSource = ds.Tables[0];
                }
                using(SqlCommand cmd = new SqlCommand(Query2, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter( cmd);
                    DataSet ds2 = new DataSet();
                    da.Fill(ds2);

                    dataGridView2.DataSource = ds2.Tables[0];
                }
            }
        }
    }
}
