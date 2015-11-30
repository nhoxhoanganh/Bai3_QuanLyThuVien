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

        private string matl;

        public string Matl
        {
            get { return matl; }
            set { matl = value; }
        }
        private string tacgia;
        private string nhande;
        private int soluong;
        private int domat;
        private string ngonngu;
        private string maTheLoai;
        private string maNXB;

        public string MaNXB
        {
            get { return maNXB; }
            set { maNXB = value; }
        }

        public string MaTheLoai
        {
            get { return maTheLoai; }
            set { maTheLoai = value; }
        }

        public string Ngonngu
        {
            get { return ngonngu; }
            set { ngonngu = value; }
        }

        public int Domat
        {
            get { return domat; }
            set { domat = value; }
        }

        public int Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }

        public string Nhande
        {
            get { return nhande; }
            set { nhande = value; }
        }
        public string Tacgia
        {
            get { return tacgia; }
            set { tacgia = value; }
        }
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
        public DataTable TimKiemGTCBTheoMaTL(string _MaTL)
        {
            DataTable dt = new DataTable();
            string str = string.Format("Select GTCB from GiaTriCaBiet where (MaTL = @MaTL)");
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
            string str = string.Format("UpdateSLTL");
            SqlConnection con = new SqlConnection(AppConfig.connectionString());
            con.Open();

            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@MaTL", _MaTL);
            cmd.Parameters.AddWithValue("@SoLuong", -1);
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.ExecuteNonQuery() > 0)
                b = true;
            con.Close();
            return b;
        }
        public bool UodateSoLuongTLID_TraSach(string _MaTL)
        {
            bool b = false;
            string str = string.Format("UpdateSLTL");
            SqlConnection con = new SqlConnection(AppConfig.connectionString());
            con.Open();

            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@MaTL", _MaTL);
            cmd.Parameters.AddWithValue("@SoLuong", 1);
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.ExecuteNonQuery() > 0)
                b = true;
            con.Close();
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
