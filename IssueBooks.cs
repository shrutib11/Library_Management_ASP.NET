using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LibraryManagement
{
    public partial class IssueBooks : Form
    {
        public IssueBooks()
        {
            InitializeComponent();
        }

        private void IssueBooks_Load(object sender, EventArgs e)
        {
            String connection = "Data Source=DESKTOP-8CIT305\\SQLEXPRESS;Initial Catalog=loginTb;Integrated Security=True";
            String insertQuery = "select bName from NewBook";
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    while(sqlDataReader.Read())
                    {
                        for(int i = 0; i < sqlDataReader.FieldCount; i++)
                        {
                            txtBName.Items.Add(sqlDataReader.GetString(i));
                        }
                    }
                    sqlDataReader.Close();
                }
            }
        }

        int count;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtEnrollment.Text != "")
            {
                String edi = txtEnrollment.Text;
                String connection = "Data Source=DESKTOP-8CIT305\\SQLEXPRESS;Initial Catalog=loginTb;Integrated Security=True";
                String Query = "select * from NewStudent where enroll = @enroll";
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(Query, con))
                    {
                        cmd.Parameters.AddWithValue("@enroll", edi);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        //---------------------------------------------------------------------
                        //Code to count how many book has been issued on this enrollment no.

                        String countQuery = "select count(stu_enroll) from IRBook where stu_enroll = @edi and book_return_date is null";
                        SqlCommand cmd1 = new SqlCommand(countQuery, con);
                        cmd1.Parameters.AddWithValue("@edi", edi);
                        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1);

                        count = int.Parse(ds1.Tables[0].Rows[0][0].ToString());             //how many books student had taken

                        //---------------------------------------------------------------------

                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            txtStuName.Text = ds.Tables[0].Rows[0][1].ToString();       //we have only one row hence row[0] and we extract 1st column from it hence [0][1]
                            txtDept.Text = ds.Tables[0].Rows[0][3].ToString();
                            txtStuSem.Text = ds.Tables[0].Rows[0][4].ToString();
                            txtStuContact.Text = ds.Tables[0].Rows[0][5].ToString();
                            txtEmail.Text = ds.Tables[0].Rows[0][6].ToString();
                        }
                        else                                                            //here comes only when id in not matched with anyone and rows count is 0
                        {
                            txtStuName.Clear();
                            txtDept.Clear();
                            txtStuSem.Clear();
                            txtStuContact.Clear();
                            txtEmail.Clear();
                            MessageBox.Show("Invalid Enrollment Number", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if (txtStuName.Text != "")
            {
                if (txtBName.SelectedIndex != -1 && count <= 2)
                {
                    String enroll = txtEnrollment.Text;
                    String sname = txtStuName.Text;
                    String sdep = txtDept.Text;
                    String sem = txtStuSem.Text;
                    Int64 contact = Int64.Parse(txtStuContact.Text);
                    String email = txtEmail.Text;
                    String bname = txtBName.Text;
                    String bookIssueDate = txtIssueDate.Text;

                    String edi = txtEnrollment.Text;
                    String connection = "Data Source=DESKTOP-8CIT305\\SQLEXPRESS;Initial Catalog=loginTb;Integrated Security=True";
                    String Query = "insert into IRBook (stu_enroll, stu_name, stu_dept, stu_sem, stu_contact, stu_email, book_name, book_issue_book) values (@enroll, @name, @dept, @sem, @contact, @email, @bookname, @issuedate)";
                    using (SqlConnection con = new SqlConnection(connection))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(Query, con))
                        {
                            cmd.Parameters.AddWithValue("@enroll", enroll);
                            cmd.Parameters.AddWithValue("@name", sname);
                            cmd.Parameters.AddWithValue("@dept", sdep);
                            cmd.Parameters.AddWithValue("@sem", sem);
                            cmd.Parameters.AddWithValue("@contact", contact);
                            cmd.Parameters.AddWithValue("@bookname", bname);
                            cmd.Parameters.AddWithValue("@issuedate", bookIssueDate);
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.ExecuteNonQuery();

                            count++;
                        }
                    }
                    MessageBox.Show("Book issued", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Select Book or Maximum number of book has been issued", "No book selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter valid Enrollment No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEnrollment_TextChanged(object sender, EventArgs e)
        {
            if(txtEnrollment.Text == "")
            {
                txtStuName.Clear();
                txtDept.Clear();
                txtEmail.Clear();
                txtStuContact.Clear();
                txtStuSem.Clear();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEnrollment.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
