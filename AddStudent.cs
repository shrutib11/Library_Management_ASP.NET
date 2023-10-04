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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Confirm ? " , "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtEnrollment.Clear();
            txtEmail.Text = "";
            txtDept.Clear();
            txtContact.Clear();
            txtSem.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDept.Text != "" && txtContact.Text != "" && txtEmail.Text != "" && txtEnrollment.Text != "" && txtName.Text != "" && txtSem.Text != "")
            {
                String name = txtName.Text;
                String enrollment = txtEnrollment.Text;
                String dep = txtDept.Text;
                String sem = txtSem.Text;
                Int64 mobile = Int64.Parse(txtContact.Text);
                String email = txtEmail.Text;

                String connection = "Data Source=DESKTOP-8CIT305\\SQLEXPRESS;Initial Catalog=loginTb;Integrated Security=True";
                String insertQuery = "insert into NewStudent (sname, enroll, dep, sem, contact, email) values (@sname, @enroll, @dep, @sem, @contact, @email)";

                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@sname", name);
                        cmd.Parameters.AddWithValue("@enroll", enrollment);
                        cmd.Parameters.AddWithValue("@dep", dep);
                        cmd.Parameters.AddWithValue("@sem", sem);
                        cmd.Parameters.AddWithValue("@contact", mobile);
                        cmd.Parameters.AddWithValue("@email", email);

                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Data saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Clear();
                txtEnrollment.Clear();
                txtSem.Clear();
                txtContact.Clear();
                txtEmail.Clear();
                txtDept.Clear();
            }
            else
            {
                MessageBox.Show("Empty field not allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
