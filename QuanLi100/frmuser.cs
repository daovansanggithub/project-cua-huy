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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLi100
{
    public partial class fromuser : Form
    {
        string strconnn;
        SqlConnection conn;
        SqlCommand cmdd;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        public fromuser()
        {
            // kết nối sql
            InitializeComponent();
            strconnn = @"Data Source=LAPTOP-Q0PAQT9D;Initial Catalog=kkkkk;Integrated Security=True";
            conn = new SqlConnection(strconnn);
            cmdd = new SqlCommand();
            cmdd.Connection = conn;
        }

        // tải lại bảng học sinh
        public void Filldata()
        {
            conn.Open();
            string query = "Select * from HocSinh";
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            ad.Fill(dt);
            dataGridViewhs.DataSource = dt;
            conn.Close();
        }

        // khi vào hiện bảng học sinh
        private void fromuser_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(strconnn);
            dataAdapter = new SqlDataAdapter("SELECT * FROM HocSinh", conn);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridViewhs.DataSource = dataTable;
        }


        // nút đăng kí để thêm thông tin
        private void btndangki_Click(object sender, EventArgs e)
        {
            int loi = 0;

            string MaHocSinh = textBoxma.Text;
            if (MaHocSinh.Equals(""))
            {
                loi++;
                MessageBox.Show("Trống Mã", "thôg báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("");
            }

            string ten = textBoxten.Text;
            if (ten.Equals(""))
            {
                loi++;
                MessageBox.Show("Trống tên ", "thông báo", MessageBoxButtons.OK);
            }
            else //check ID trùng
            {
                try
                {
                    conn.Open();
                    string query = "select * from HocSinh where MaHocSinh = @MaHocSinh";

                    SqlCommand commcheck = new SqlCommand(query, conn);
                    commcheck.Parameters.AddWithValue("@MaHocSinh", SqlDbType.Int);
                    commcheck.Parameters["@MaHocSinh"].Value = MaHocSinh;
                    SqlDataReader reader = commcheck.ExecuteReader();

                    if (reader.Read())
                    {
                        loi++;
                        MessageBox.Show("Mã có", "thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Thành Công");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("loi!" + ex.Message, "loi");
                }
                finally
                {
                    conn.Close();
                }

            }

            string DiaChi = textBoxdiachi.Text;
            string SoDienThoai = textBoxsdt.Text;
           

            if (loi == 0)
            {

                // thêm thông tin vào bảng
                string Themm = "Insert into HocSinh values (@MaHocSinh,@TenHocSinh,@DiaChi,@SoDienThoai)";
                conn.Open();

                SqlCommand themmoi = new SqlCommand(Themm, conn);

                themmoi.Parameters.AddWithValue("@MaHocSinh", SqlDbType.Int);
                themmoi.Parameters["@MaHocSinh"].Value = MaHocSinh;

                themmoi.Parameters.AddWithValue("@TenHocSinh", SqlDbType.NVarChar);
                themmoi.Parameters["@TenHocSinh"].Value = ten;

                themmoi.Parameters.AddWithValue("@DiaChi", SqlDbType.NVarChar);
                themmoi.Parameters["@DiaChi"].Value = DiaChi;

                themmoi.Parameters.AddWithValue("@SoDienThoai", SqlDbType.NVarChar);
                themmoi.Parameters["@SoDienThoai"].Value = SoDienThoai;




                themmoi.ExecuteNonQuery();

                conn.Close();

                Filldata();

                MessageBox.Show("Bạn đã thêm thông tin cá nhân thành công", "thôg báo", MessageBoxButtons.OK);
            }
        }


        //nút trở về form đăng nhập
        private void buttonve_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có muốn trở lại không ? ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
            this.Hide();
            Formdangnhap log = new Formdangnhap();
            log.ShowDialog();
            this.Dispose();
        }


        // nút chuyển sang form tìm kiếm sách
        private void buttontim_Click(object sender, EventArgs e)
        {
           
            MessageBox.Show("Đến khu tìm sách ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
            this.Hide();
            Formtim timmm = new Formtim();
            timmm.ShowDialog();
            this.Dispose();
        }
    }
}
