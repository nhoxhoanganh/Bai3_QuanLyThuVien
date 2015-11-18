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
    public class BUS_ChiTietPM
    {
        dbConnection dbcon = new dbConnection();
        public bool ThemCTPM(string MaPM, string GTCB, DateTime NgayMuon, DateTime NgayTra, DateTime NgayDK, DateTime NgayLay, string Ghichu)
        {
            bool b = false;
            string sql = string.Format("Insert into CHITIETPHIEUMUON (MaPM, GTCB, NgayMuon, NgayTra, NgayDangky, NgayLay, GhiChu) values ( @MaPM, @GTCB, @NgayMuon,@NgayTra, @NgayDangKy, @NgayLay, @GhiChu ");
            SqlParameter[] arr = new SqlParameter[7];
            arr[0] = new SqlParameter("@MaPM", SqlDbType.NVarChar, 10);
            arr[0].Value = MaPM;
            arr[1] = new SqlParameter("@GTCB", SqlDbType.NVarChar, 10);
            arr[1].Value = GTCB;
            arr[2] = new SqlParameter("@NgayMuon", SqlDbType.Date);
            arr[2].Value = NgayMuon;
            arr[3] = new SqlParameter("@NgayTra", SqlDbType.Date);
            arr[3].Value = NgayTra;
            arr[4] = new SqlParameter("@NgayDangKy", SqlDbType.Date);
            arr[4].Value = NgayDK;
            arr[5] = new SqlParameter("@NgayLay", SqlDbType.Date);
            arr[5].Value = NgayLay;
            arr[6] = new SqlParameter("@GhiChu", SqlDbType.NVarChar, 500);
            arr[6].Value = Ghichu;

            b = dbcon.executeInsertProcedureQuery(sql, arr);
            return b;
        }
    }
}
