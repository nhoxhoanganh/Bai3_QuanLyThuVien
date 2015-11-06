using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using KetNoiDB;
namespace BangThuVien
{
    public class BUS_BanDoc
    {
        KetNoi cn = new KetNoi();

        public DataTable HienThiBanDoc()
        {
            string sql = "SELECT * FROM BanDoc";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(KetNoi.connect());
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            return dt;
        }

        public void ThemBanDoc(string HoTen, string GioiTinh, DateTime NgaySinh, string CMND, string MaLop, string DiaChi, string Email, string DienThoai)
        {
            string sql = "ADDBanDoc";
            SqlConnection con = new SqlConnection(KetNoi.connect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@HoTen", HoTen);
            cmd.Parameters.AddWithValue("@GioiTinh", GioiTinh);
            cmd.Parameters.AddWithValue("@NgaySinh", NgaySinh);
            cmd.Parameters.AddWithValue("@CMND", CMND);
            cmd.Parameters.AddWithValue("@MaLop", MaLop);
            cmd.Parameters.AddWithValue("@DiaChi", DiaChi);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@DienThoai", DienThoai);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void SuaBanDoc(string MaBD, string HoTen, string GioiTinh, DateTime NgaySinh, string CMND, string MaLop, string DiaChi, string Email, string DienThoai)
        {
            string sql = "SuaBanDoc";
            SqlConnection con = new SqlConnection(KetNoi.connect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaBD", MaBD);
            cmd.Parameters.AddWithValue("@HoTen", HoTen);
            cmd.Parameters.AddWithValue("@GioiTinh", GioiTinh);
            cmd.Parameters.AddWithValue("@NgaySinh", NgaySinh);
            cmd.Parameters.AddWithValue("@CMND", CMND);
            cmd.Parameters.AddWithValue("@MaLop", MaLop);
            cmd.Parameters.AddWithValue("@DiaChi", DiaChi);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@DienThoai", DienThoai);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void XoaBanDoc(string MaBD)
        {
            string sql = "Xoa_BD";
            SqlConnection con = new SqlConnection(KetNoi.connect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaBD", MaBD);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
    }
}
