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
    public class BUS_PhieuMuon
    {
        dbConnection dbcon = new dbConnection();

        public DataTable ThemPhieuMuon(string _MaBD)
        {
            DataTable dt = new DataTable();
            string str = string.Format("ThemPhieuMuon");
            SqlParameter[] arrpara = new SqlParameter[2];
            arrpara[0] = new SqlParameter("@MaBD", SqlDbType.NVarChar, 10);
            arrpara[0].Value = _MaBD;
            arrpara[1] = new SqlParameter("@TrangThai", SqlDbType.Int);
            arrpara[1].Value = 1;

            dt = dbcon.executeSelectProcedureQuery(str, arrpara);
            return dt;
        }
    }
}
