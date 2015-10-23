using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QL_ThuVien
{
    public class Sach
    {
        string strcon = @"Data Source=PHAMVANLUONG\SQLEXPRESS;Initial Catalog=QL_ThuVien;Integrated Security=True";
        public DataTable Show()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(@"select MaSach, TenSach, NamXuatBan, SoBanSach, SoTrangSach, GiaSach, 
				            SoTap, KhoSach, TinhTrangSach, NgonNgu, TenTacGia, TenTheLoai, TenNhaXuatBan
                            from Sach s, TacGia tg, TheLoai tl, NhaXuatBan nxb where s.MaTacGia = tg.MaTacGia and 
                            s.MaNhaXuatBan = nxb.MaNhaXuaBan and s.MaTheLoai = tl.MaTheLoai", con);
            //SqlDataAdapter da = new SqlDataAdapter(@"select * from DocGia", con);
            da.Fill(dt);
            con.Close();
            da.Dispose();
            return dt;
        }
    }
}
