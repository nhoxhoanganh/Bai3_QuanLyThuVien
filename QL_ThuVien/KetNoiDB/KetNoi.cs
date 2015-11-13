using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace KetNoiDB
{
    public class KetNoi
    {
        SqlConnection cn = new SqlConnection();

        public static String connect()
        {
<<<<<<< HEAD
<<<<<<< HEAD
            return (@"Data Source=NHOXHOANGANH\SQLEXPRESS;Initial Catalog=QL_ThuVien;Integrated Security=true;");
=======
            return (@"Data Source=ChiConCaiTen\SQLEXPRESS;Initial Catalog=QL_ThuVien;Integrated Security=true;");
>>>>>>> c440d652707baefcd3b80e71f1d260e2cb8d6347
=======
            return (@"Data Source=PHamVANLUONG\SQLEXPRESS;Initial Catalog=QL_ThuVien;Integrated Security=true;");
>>>>>>> 32a10882999b2f7300d078052a93c2e4fbe79f3a
        }
    }
}
