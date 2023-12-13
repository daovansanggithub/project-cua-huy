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
    public partial class Formdangnhap : Form
    {
        string chuoiketnoi;
        SqlConnection c;



        // kết nối sql
        public Formdangnhap()
        {
            InitializeComponent();
            chuoiketnoi = @"Data Source=LAPTOP-Q0PAQT9D;Initial Catalog=kkkkk;Integrated Security=True";
            c = new SqlConnection(chuoiketnoi);
            c.Open();
            MessageBox.Show("Mở kết nối", "thông báo", MessageBoxButtons.YesNo);
            c.Close();
        }


        // kiểm tra vai trò của từng người 
        // nếu là admin thì cho vào form admin
        // nếu là user thì cho sang form user
        private void btndn_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBoxTK.Text;
                string password = textBoxMK.Text;
                string query = "Select * from TaiKhoan where TenTaiKhoan =@tk and MatKhau =@mk";
                c.Open();
                SqlCommand cmd = new SqlCommand(query, c);
                cmd.Parameters.AddWithValue("@tk", SqlDbType.VarChar);
                cmd.Parameters["@tk"].Value = username;
                cmd.Parameters.AddWithValue("@mk", SqlDbType.VarChar);
                cmd.Parameters["@mk"].Value = password;
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string role = reader["VaiTro"].ToString();
                    if (role.Equals("Admin"))  // nếu là admin thì chuyển form admin
                    {
                        MessageBox.Show("Chúc Mừng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Hide();
                        fromadmin ad = new fromadmin();
                        ad.ShowDialog();
                        this.Dispose();
                    }
                    else if (role.Equals("user"))  // chuyển form người dùng
                    {
                        MessageBox.Show("Chào Mừng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Hide();
                        fromuser user = new fromuser(); 
                        user.ShowDialog(); 
                        this.Dispose(); 
                    }
                    else
                    {
                        MessageBox.Show("không được", "thông báo",MessageBoxButtons.OKCancel);
                    }

                }
                else
                {
                    MessageBox.Show("không được", "thông báo", MessageBoxButtons.OK);
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi " + ex.Message, "lỗi");

            }
            finally
            {
                c.Close();
            }
        }

        private void Formdangnhap_Load(object sender, EventArgs e)
        {

        }
    }
}
