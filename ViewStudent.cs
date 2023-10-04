using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class ViewStudent : Form
    {
        public ViewStudent()
        {
            InitializeComponent();
        }

        private void txtSearchEnrollment_TextChanged(object sender, EventArgs e)
        {
            if(txtSearchEnrollment.Text != "")
            {
                label1.Visible = false;
                Image image = Image.FromFile("E:/.NET Framework/Liberay Management System/search1.gif");
                pictureBox1.Image = image;

                String connection = "Data Source=DESKTOP-8CIT305\\SQLEXPRESS;Initial Catalog=loginTb;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection);
                String insertQuery = "select * from NewStudent where enroll LIKE @enroll + '%'";

                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@enroll", txtSearchEnrollment.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                label1.Visible = true;
                Image image = Image.FromFile("E:/.NET Framework/Liberay Management System/search.gif");
                pictureBox1.Image = image;

                String connection = "Data Source=DESKTOP-8CIT305\\SQLEXPRESS;Initial Catalog=loginTb;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection);

                String insertQuery = "select * from NewStudent";
                SqlCommand cmd = new SqlCommand(insertQuery, con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;

            String connection = "Data Source=DESKTOP-8CIT305\\SQLEXPRESS;Initial Catalog=loginTb;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);

            String insertQuery = "select * from NewStudent";
            SqlCommand cmd = new SqlCommand(insertQuery, con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        int stuid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                stuid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());          //fetch data from 0th column
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;

            String connection = "Data Source=DESKTOP-8CIT305\\SQLEXPRESS;Initial Catalog=loginTb;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);

            String insertQuery = "select * from NewStudent where stuid = @stuid";
            
            SqlCommand cmd = new SqlCommand(insertQuery, con);
            cmd.Parameters.AddWithValue("@stuid", stuid);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            txtSName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtEnrollment.Text = ds.Tables[0].Rows[0][2].ToString();
            txtDept.Text = ds.Tables[0].Rows[0][3].ToString();
            txtSem.Text = ds.Tables[0].Rows[0][4].ToString();
            txtContact.Text = ds.Tables[0].Rows[0][5].ToString();
            txtSemail.Text = ds.Tables[0].Rows[0][6].ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                String sname = txtSName.Text;
                String  enroll = txtEnrollment.Text;
                String dept = txtDept.Text;
                String sem = txtSem.Text;
                Int64 contact = Int64.Parse(txtContact.Text);
                String email = txtSemail.Text;

                String connection = "Data Source=DESKTOP-8CIT305\\SQLEXPRESS;Initial Catalog=loginTb;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection);
                String insertQuery = "update NewStudent set sname = @sname, enroll = @enroll, dep = @dep, sem = @sem, contact = @contact, email = @email where stuid = @rowid";

                SqlCommand cmd = new SqlCommand(insertQuery, con);

                cmd.Parameters.AddWithValue("@rowid", rowid);
                cmd.Parameters.AddWithValue("@sname", sname);
                cmd.Parameters.AddWithValue("@enroll", enroll);
                cmd.Parameters.AddWithValue("@dep", dept);
                cmd.Parameters.AddWithValue("@sem", sem);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@email", email);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ViewStudent_Load(this, null);       //for reload the form
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be deleted. Confirm?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                String connection = "Data Source=DESKTOP-8CIT305\\SQLEXPRESS;Initial Catalog=loginTb;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection);
                String insertQuery = "delete from NewStudent where stuid = @rowid";

                SqlCommand cmd = new SqlCommand(insertQuery, con);

                cmd.Parameters.AddWithValue("@rowid", rowid);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                ViewStudent_Load(this, null);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchEnrollment.Clear();
            panel2.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Unsaved data will be lost", "Are you sure?",MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK);
            {
                this.Close();
            }
        }
    }
}
