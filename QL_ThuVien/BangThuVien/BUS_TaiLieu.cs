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
    public class BUS_TaiLieu
    {
        KetNoi cn = new KetNoi();
        dbConnection dbcon = new dbConnection();
        public DataTable TimKiemTLID(string _MaTL)
        {
            DataTable dt = new DataTable();
            string str = string.Format("Select * from TaiLieu where (MaTL = @MaTL)");
            SqlParameter[] arrPara = new SqlParameter[1];
            arrPara[0] = new SqlParameter("@MaTL", SqlDbType.NVarChar, 10);
            arrPara[0].Value = _MaTL;

            dt = dbcon.executeSelectQuery(str, arrPara);
            return dt;
        }
        public DataTable TimKiemSoLuongTLID(string _MaTL)
        {
            DataTable dt = new DataTable();
            string str = string.Format("Select SoLuong from TaiLieu where (MaTL = @MaTL)");
            SqlParameter[] arrPara = new SqlParameter[1];
            arrPara[0] = new SqlParameter("@MaTL", SqlDbType.NVarChar, 10);
            arrPara[0].Value = _MaTL;

            dt = dbcon.executeSelectQuery(str, arrPara);
            return dt;
        }
        public bool UodateSoLuongTLID(string _MaTL)
        {
            bool b = false;
            string str = string.Format("Update TaiLieu set (SoLuong = SoLuong -1) where (MaTL = @MaTL)");
            SqlParameter[] arrPara = new SqlParameter[1];
            arrPara[0] = new SqlParameter("@MaTL", SqlDbType.NVarChar, 10);
            arrPara[0].Value = _MaTL;

            b = dbcon.executeUpdateQuery(str, arrPara);
            return b;
        }
        public DataTable HienThiTaiLieu()
        {
            string sql = "SELECT * FROM TaiLieu";
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(KetNoi.connect());
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            return dt;
        }

        public void ThemTaiLieu(string TacGia, string NhanDe, int SoLuong,int DoMat, string NgonNgu, string MaTheLoai, string MaNXB)
        {
            string sql = "ADDTaiLieu";
            SqlConnection con = new SqlConnection(KetNoi.connect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TacGia", TacGia);
            cmd.Parameters.AddWithValue("@NhanDe", NhanDe);
            cmd.Parameters.AddWithValue("@SoLuong",SoLuong);
            cmd.Parameters.AddWithValue("@DoMat", DoMat);
            cmd.Parameters.AddWithValue("@NgonNgu", NgonNgu);
            cmd.Parameters.AddWithValue("@MaTheLoai", MaTheLoai);
            cmd.Parameters.AddWithValue("@MaNXB", MaNXB);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void SuaTaiLieu(string MaTL, string TacGia, string NhanDe, int SoLuong, int DoMat, string NgonNgu, string MaTheLoai, string MaNXB)
        {
            string sql = "SuaTaiLieu";
            SqlConnection con = new SqlConnection(KetNoi.connect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaTL", MaTL);
            cmd.Parameters.AddWithValue("@TacGia", TacGia);
            cmd.Parameters.AddWithValue("@NhanDe", NhanDe);
            cmd.Parameters.AddWithValue("@SoLuong", SoLuong);
            cmd.Parameters.AddWithValue("@DoMat", DoMat);
            cmd.Parameters.AddWithValue("@NgonNgu", NgonNgu);
            cmd.Parameters.AddWithValue("@MaTheLoai", MaTheLoai);
            cmd.Parameters.AddWithValue("@MaNXB", MaNXB);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }

        public void XoaTaiLieu(string MaTL)
        {
            string sql = "Xoa_TL";
            SqlConnection con = new SqlConnection(KetNoi.connect());
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaTL", MaTL);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
    }
}
