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

namespace QuanLi100
{
    public partial class Formtim : Form
    {
        string strconnn;
        SqlConnection conn;
        SqlCommand cmdd;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        public Formtim()
        {

            // kết nối sql
            InitializeComponent();
            strconnn = @"Data Source=LAPTOP-Q0PAQT9D;Initial Catalog=kkkkk;Integrated Security=True";
            conn = new SqlConnection(strconnn);
            cmdd = new SqlCommand();
            cmdd.Connection = conn;
        }


        // tại lại bảng 
        public void Filldata()
        {
            conn.Open();
            string query = "Select * from Sach";
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            ad.Fill(dt);
            dataGridViewtim.DataSource = dt;
            conn.Close();
        }

        // nút tìm kiếm trong form này
        private void button1_Click(object sender, EventArgs e)
        {
            string timk = textBoxtim.Text.Trim();

            if (!string.IsNullOrEmpty(timk))
            {
                string query = "SELECT * FROM Sach WHERE  TenSach LIKE @timk";
                conn.Open();
                SqlCommand cmm = new SqlCommand(query, conn);
                cmm.Parameters.AddWithValue("@timk", "%" + timk + "%");
                SqlDataAdapter ad = new SqlDataAdapter(cmm);
                DataTable tabless = new DataTable();
                ad.Fill(tabless);
                conn.Close();

                if (tabless.Rows.Count > 0)
                {
                    dataGridViewtim.DataSource = tabless;

                    MessageBox.Show("Bạn đã tìm thấy");
                }
                else
                {
                    dataGridViewtim.DataSource = null;
                    MessageBox.Show("bạn không tìm thấy");

                }
            }
            else
            {
                MessageBox.Show("điền vào ô để tìm");
            }
        }

        // khi mở form lên nó sẽ hiện bảng sách 
        private void Formtim_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(strconnn);
            dataAdapter = new SqlDataAdapter("SELECT * FROM Sach", conn);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridViewtim.DataSource = dataTable;
        }


        // nút trở về form người dùng
        private void buttonve_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn muốn thoát không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            this.Hide();
            fromuser u = new fromuser();
            u.ShowDialog();
            this.Dispose();
        }
    }
}
