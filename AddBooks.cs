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
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtBookName.Text != "" && txtAuthor.Text != "" && txtPublication.Text != ""&& txtBookPrice.Text != ""&& txtQuantity.Text != ""){
                String bname = txtBookName.Text;
                String bauthor = txtAuthor.Text;
                String publication = txtPublication.Text;
                String date = dateTimePicker1.Text;
                Int64 price = Int64.Parse(txtBookPrice.Text);
                Int64 quan = Int64.Parse(txtQuantity.Text);

                String connection = "Data Source=DESKTOP-8CIT305\\SQLEXPRESS;Initial Catalog=loginTb;Integrated Security=True";
                String insertQuery = "insert into NewBook (bName, bAuthor, bPubl, bPDate, bPrice, bQuan) values (@bName, @bAuthor, @bPubl, @bPDate, @bPrice, @bQuan)";
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@bName", bname);
                        cmd.Parameters.AddWithValue("@bAuthor", bauthor);
                        cmd.Parameters.AddWithValue("@bPubl", publication);
                        cmd.Parameters.AddWithValue("@bPDate", date);
                        cmd.Parameters.AddWithValue("@bPrice", price);
                        cmd.Parameters.AddWithValue("@bQuan", quan);

                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Data saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBookName.Clear();
                txtAuthor.Clear();
                txtPublication.Clear();
                txtBookPrice.Clear();
                txtQuantity.Clear();
            }
            else
            {
                MessageBox.Show("Empty field not allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dashboard.restrictNewBook = 0;
            if (MessageBox.Show("This will DELETE your Unsaved data", "Are you Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
