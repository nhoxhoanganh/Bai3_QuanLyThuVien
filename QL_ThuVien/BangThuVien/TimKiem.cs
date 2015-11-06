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
    public class TimKiem
    {
        KetNoi cn = new KetNoi();


        // Tìm kiếm Tài liệu theo mã
        public DataTable TKTL_MaTL(string MaTL)
        {
            string sql = "SELECT * FROM TaiLieu WHERE MaTL LIKE N'%' + @MaTL + '%'";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(KetNoi.connect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Parameters.AddWithValue("@MaTL", MaTL);
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;

        }

        // Tìm kiếm tài liệu theo nhan đề
        public DataTable TKTL_NhanDe(string NhanDe)
        {
            string sql = "SELECT * FROM TaiLieu WHERE NhanDe LIKE N'%' + @NhanDe + '%'";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(KetNoi.connect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Parameters.AddWithValue("@NhanDe", NhanDe);
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
        // Tìm kiếm tài liệu theo tác giả
        public DataTable TKTL_TacGia(string TacGia)
        {
            string sql = "SELECT * FROM TaiLieu WHERE TacGia LIKE N'%' + @TacGia + '%'";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(KetNoi.connect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Parameters.AddWithValue("@TacGia", TacGia);
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
    }
}
