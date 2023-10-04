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
    public partial class ViewBook : Form
    {
        public ViewBook()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ViewBook_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            String connection = "Data Source=DESKTOP-8CIT305\\SQLEXPRESS;Initial Catalog=loginTb;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);

            String insertQuery = "select * from NewBook";
            SqlCommand cmd = new SqlCommand(insertQuery, con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        int bid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;

            String connection = "Data Source=DESKTOP-8CIT305\\SQLEXPRESS;Initial Catalog=loginTb;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            String insertQuery = "select * from NewBook where bid = @bid";
            
            SqlCommand cmd = new SqlCommand(insertQuery, con);
            cmd.Parameters.AddWithValue("@bid", bid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            txtBName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtAuthor.Text = ds.Tables[0].Rows[0][2].ToString();
            txtPublication.Text = ds.Tables[0].Rows[0][3].ToString();
            txtPDate.Text = ds.Tables[0].Rows[0][4].ToString();
            txtPrice.Text = ds.Tables[0].Rows[0][5].ToString();
            txtQuantity.Text = ds.Tables[0].Rows[0][6].ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void txtBookname_TextChanged(object sender, EventArgs e)
        {
            if(txtBookname.Text != "")
            {
                String connection = "Data Source=DESKTOP-8CIT305\\SQLEXPRESS;Initial Catalog=loginTb;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection);
                String insertQuery = "select * from NewBook where bName LIKE @bName + '%'";

                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@bName", txtBookname.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                String connection = "Data Source=DESKTOP-8CIT305\\SQLEXPRESS;Initial Catalog=loginTb;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection);
                String insertQuery = "select * from NewBook";

                SqlCommand cmd = new SqlCommand(insertQuery, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtBookname.Clear();
            panel2.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                String bname = txtBName.Text;
                String bauthor = txtAuthor.Text;
                String publication = txtPublication.Text;
                String pdate = txtPDate.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                Int64 quantity = Int64.Parse(txtQuantity.Text);

                String connection = "Data Source=DESKTOP-8CIT305\\SQLEXPRESS;Initial Catalog=loginTb;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection);
                String insertQuery = "update NewBook set bName = @bName, bAuthor = @bAuthor, bPubl = @bPubl, bPDate = @bPDate, bPrice = @bPrice, bQuan = @bQuan where bid = @rowid";

                SqlCommand cmd = new SqlCommand(insertQuery, con);

                cmd.Parameters.AddWithValue("@rowid", rowid);
                cmd.Parameters.AddWithValue("@bName", bname);
                cmd.Parameters.AddWithValue("@bAuthor", bauthor);
                cmd.Parameters.AddWithValue("@bPubl", publication);
                cmd.Parameters.AddWithValue("@bPDate", pdate);
                cmd.Parameters.AddWithValue("@bPrice", price);
                cmd.Parameters.AddWithValue("@bQuan", quantity);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ViewBook_Load(this, null);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be deleted. Confirm?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                String connection = "Data Source=DESKTOP-8CIT305\\SQLEXPRESS;Initial Catalog=loginTb;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection);
                String insertQuery = "delete from NewBook where bid = @rowid";

                SqlCommand cmd = new SqlCommand(insertQuery, con);

                cmd.Parameters.AddWithValue("@rowid", rowid);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
