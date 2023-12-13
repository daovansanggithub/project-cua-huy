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
    public partial class fromadmin : Form
    {
        string strconnn;
        SqlConnection conn;
        SqlCommand cmdd;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        public fromadmin()
        {
            // kết nối
            InitializeComponent();
            strconnn = @"Data Source=LAPTOP-Q0PAQT9D;Initial Catalog=kkkkk;Integrated Security=True";
            conn = new SqlConnection(strconnn);
            cmdd = new SqlCommand();
            cmdd.Connection = conn;
        }


        // load lại bảng
        public void Filldata()
        {
            conn.Open();
            string query = "Select * from Sach";
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            ad.Fill(dt);
            dataGridViewsachh.DataSource = dt;
            conn.Close();
        }

        // khi mở phần mềm tự động hiện bảng
        private void fromadmin_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(strconnn);
            dataAdapter = new SqlDataAdapter("SELECT * FROM Sach", conn);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridViewsachh.DataSource = dataTable;
        }


        // thêm
        private void buttonThem_Click(object sender, EventArgs e)
        {
            int loi = 0;

            string masach = textBoxma.Text;
            if (masach.Equals(""))
            {
                loi++;
                MessageBox.Show("Trống Mã","thôg báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("OK");
            }

            string tensach = textBoxten.Text;
            if (tensach.Equals(""))
            {
                loi++;
                MessageBox.Show("Trống tên ","thông báo", MessageBoxButtons.OK);
            }
            else //check ID trùng
            {
                try
                {
                    conn.Open();
                    string query = "select * from Sach where MaSach = @MaSach";

                    SqlCommand commcheck = new SqlCommand(query, conn);
                    commcheck.Parameters.AddWithValue("@MaSach", SqlDbType.Int);
                    commcheck.Parameters["@MaSach"].Value = masach;
                    SqlDataReader reader = commcheck.ExecuteReader();

                    if (reader.Read())
                    {
                        loi++;
                        MessageBox.Show("Mã có", "thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Ok");
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

            string TacGia = textBoxtacg.Text;
            string NamXuatBan = textBoxnam.Text;
            string MaLoaiSach = textBoxmaloai.Text;

            if (loi == 0)   // thực hiện thêm 
            {

                string Themm = "Insert into Sach values (@masach,@tensach,@tacgia,@nam,@maloai)";
                conn.Open();

                SqlCommand themmoi = new SqlCommand(Themm, conn);

                themmoi.Parameters.AddWithValue("@masach", SqlDbType.Int);
                themmoi.Parameters["@masach"].Value = masach;

                themmoi.Parameters.AddWithValue("@tensach", SqlDbType.NVarChar);
                themmoi.Parameters["@tensach"].Value = tensach;

                themmoi.Parameters.AddWithValue("@tacgia", SqlDbType.NVarChar);
                themmoi.Parameters["@tacgia"].Value = TacGia;

                themmoi.Parameters.AddWithValue("@nam", SqlDbType.Int);
                themmoi.Parameters["@nam"].Value = NamXuatBan;

                themmoi.Parameters.AddWithValue("@maloai", SqlDbType.Int);
                themmoi.Parameters["@maloai"].Value = MaLoaiSach;


                themmoi.ExecuteNonQuery();

                conn.Close();

                Filldata();

                MessageBox.Show("Bạn thêm thành công", "thôg báo", MessageBoxButtons.OK);
            }
        }



        // chọn dữ liệu khi clich vào
        string data;
        private void dataGridViewsachh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            conn.Open();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewsachh.Rows[e.RowIndex];
                data = row.Cells["MaSach"].Value.ToString();
                textBoxma.Text = row.Cells["MaSach"].Value.ToString();
                textBoxten.Text = row.Cells["TenSach"].Value.ToString();
                textBoxtacg.Text = row.Cells["TacGia"].Value.ToString();
                textBoxnam.Text = row.Cells["NamXuatBan"].Value.ToString();
                textBoxmaloai.Text = row.Cells["MaLoaiSach"].Value.ToString();

                conn.Close();
            }
        }


        // sửa 
        private void buttonsua_Click(object sender, EventArgs e)
        {
          
                if ((MessageBox.Show("Bạn có sửa không ? ", "thông báo ", MessageBoxButtons.YesNo) == DialogResult.Yes))
                {
                    conn.Open();
                    string suamoi = "UPDATE Sach SET TenSach = @TenSach, TacGia = @TacGia, NamXuatBan = @NamXuatBan, MaLoaiSach = @MaLoaiSach " +
                        "WHERE MaSach = @MaSach;";

                    SqlCommand sua = new SqlCommand(suamoi, conn);
                    sua.Parameters.Add("@MaSach", SqlDbType.Int);
                    sua.Parameters["@MaSach"].Value = textBoxma.Text;

                    sua.Parameters.Add("@TenSach", SqlDbType.NVarChar);
                    sua.Parameters["@TenSach"].Value = textBoxten.Text;

                    sua.Parameters.Add("@TacGia", SqlDbType.NVarChar);
                    sua.Parameters["@TacGia"].Value = textBoxtacg.Text;

                    sua.Parameters.Add("@NamXuatBan", SqlDbType.Int);
                    sua.Parameters["@NamXuatBan"].Value = textBoxnam.Text;

                    sua.Parameters.Add("@MaLoaiSach", SqlDbType.Int);
                    sua.Parameters["@MaLoaiSach"].Value = textBoxmaloai.Text;

                    int iii = sua.ExecuteNonQuery();

                    // Kiểm tra
                    if (iii > 0)
                    {

                        MessageBox.Show("Sửa thành công","thông báo", MessageBoxButtons.OK);
                    }
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("lỗi");
                }
                Filldata();
            
        }



        //xóa
        private void buttonxoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (data != null)
                {
                    DialogResult result = MessageBox.Show("Bạn muốn xóa không: " + data + "!!!!", "thông báo", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        conn.Open();

                        string sqlQuery = "DELETE FROM Sach WHERE MaSach = @MaSach";

                        SqlCommand comm = new SqlCommand(sqlQuery, conn);
                        comm.Parameters.AddWithValue("@MaSach", data);

                        comm.ExecuteNonQuery();

                        conn.Close();

                        Filldata();

                        MessageBox.Show(" xóa thành công ","thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("muốn xóa phải click vào dữ liệu cần xóa ","thông báo",MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi " + ex.Message, "lỗi");
            }
            finally
            {
                conn.Close();
            }
        }


        // nút tải lại
        private void btntai_Click(object sender, EventArgs e)
        {
            Filldata();
            textBoxma.Text = null;
            textBoxten.Text = null;
            textBoxtacg.Text = null;
            textBoxnam.Text = null;
            textBoxmaloai.Text = null;
        }


        // chuyển về form đăng nhập
        private void buttontrove_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn muốn thoát không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            this.Hide();
            Formdangnhap log = new Formdangnhap();
            log.ShowDialog();
            this.Dispose();
        }
    }
}
