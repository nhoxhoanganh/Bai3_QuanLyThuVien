using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using KetNoiDB;
using BangThuVien;

namespace QL_ThuVien
{
    public partial class frmTraSach : Form
    {
        BUS_BanDoc bd = new BUS_BanDoc();
        BUS_TaiLieu tl = new BUS_TaiLieu();
        BUS_TaiKhoan tk = new BUS_TaiKhoan();
        BUS_PhieuMuon pm = new BUS_PhieuMuon();
        BUS_ChiTietPM ctpm = new BUS_ChiTietPM();
        List<BUS_TaiLieu> listTLMuon = new List<BUS_TaiLieu>();
        public frmTraSach()
        {
            InitializeComponent();
        }

        public void KhoiTaoTxt()
        {
            txtHoTen.Text = txtCMND.Text = txtDiaChi.Text = txtEmail.Text = txtGT.Text = txtMaLop.Text = txtNS.Text = txtSoDT.Text = "";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            KhoiTaoTxt();

            string str = string.Format("Select * from BanDoc where MaBD like '%' + '" + txtMaBD.Text + "' + '%'");
            SqlConnection con = new SqlConnection(AppConfig.connectionString());
            DataTable dt = new DataTable();
            con.Open();

            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                txtHoTen.Text = dt.Rows[0]["Hoten"].ToString();
                txtGT.Text = dt.Rows[0]["GioiTinh"].ToString();
                txtNS.Text = dt.Rows[0]["NgaySinh"].ToString();
                txtCMND.Text = dt.Rows[0]["CMND"].ToString();
                txtMaLop.Text = dt.Rows[0]["MaLop"].ToString();
                txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtSoDT.Text = dt.Rows[0]["DienThoai"].ToString();
            }
            con.Close();
        }

        private void txtMaTL_TextChanged(object sender, EventArgs e)
        {
            txtNhanDe.Text = txttacGia.Text = txtTheLoai.Text = txtNXB.Text = "";

            string str = string.Format(@"SELECT     dbo.TaiLieu.NhanDe, dbo.TaiLieu.TacGia, dbo.TheLoai.TenTheLoai, dbo.NXB.TenNXB
                                            FROM         dbo.TaiLieu INNER JOIN
                                                            dbo.TheLoai ON dbo.TaiLieu.MaTheLoai = dbo.TheLoai.MaTheLoai INNER JOIN
                                                            dbo.NXB ON dbo.TaiLieu.MaNXB = dbo.NXB.MaNXB 
                                            where MaTL like '%' + '" + txtMaTL.Text + "' + '%'");
            SqlConnection con = new SqlConnection(AppConfig.connectionString());
            DataTable dt = new DataTable();
            con.Open();

            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtNhanDe.Text = dt.Rows[0]["NhanDe"].ToString();
                txttacGia.Text = dt.Rows[0]["TacGia"].ToString();
                txtNXB.Text = dt.Rows[0]["TenNXB"].ToString();
                txtTheLoai.Text = dt.Rows[0]["TenTheLoai"].ToString();
            }
            con.Close();
            
        }
    }
}
