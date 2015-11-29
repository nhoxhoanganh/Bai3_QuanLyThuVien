using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using KetNoiDB;
using System.Data.SqlClient;

namespace BangThuVien
{
    public class BUS_ChiTietPM
    {
        dbConnection dbcon = new dbConnection();
        public bool ThemCTPM(string MaPM, string GTCB, DateTime NgayMuon, DateTime HanTra, string Ghichu)
        {
            bool b = false;
            string sql = string.Format("Insert into CHITIETPHIEUMUON (MaPM, GTCB, NgayMuon, HanTra, GhiChu) values ( @MaPM, @GTCB, @NgayMuon, @HanTra, @GhiChu )");
            SqlParameter[] arr = new SqlParameter[5];
            arr[0] = new SqlParameter("@MaPM", SqlDbType.NVarChar, 10);
            arr[0].Value = MaPM;
            arr[1] = new SqlParameter("@GTCB", SqlDbType.NVarChar, 10);
            arr[1].Value = GTCB;
            arr[2] = new SqlParameter("@NgayMuon", SqlDbType.Date);
            arr[2].Value = NgayMuon;
            arr[3] = new SqlParameter("@HanTra", SqlDbType.Date);
            arr[3].Value = HanTra;
            arr[4] = new SqlParameter("@GhiChu", SqlDbType.NVarChar, 500);
            arr[4].Value = Ghichu;

            b = dbcon.executeInsertQuery(sql, arr);
            return b;
        }
    }
}
