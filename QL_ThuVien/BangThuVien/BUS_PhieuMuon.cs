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

        public bool ThemPhieuMuon(string _MaBD)
        {
            bool b = false;
            string str = string.Format("ThemPhieuMuon");

            return b;
        }
    }
}
