﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using KetNoiDB;
using BangThuVien;

namespace QL_ThuVien
{
    public partial class MuonSach : Form
    {
        BUS_BanDoc bd = new BUS_BanDoc();
        BUS_TaiLieu tl = new BUS_TaiLieu();
        BUS_TaiKhoan tk = new BUS_TaiKhoan();
        BUS_PhieuMuon pm = new BUS_PhieuMuon();
        BUS_ChiTietPM ctpm = new BUS_ChiTietPM();
        List<BUS_TaiLieu> listTLMuon = new List<BUS_TaiLieu>();
        public MuonSach()
        {
            InitializeComponent();
        }

        private void btnMuon_Click(object sender, EventArgs e)
        {
            if (txtMaBD.Text == null)
                MessageBox.Show("Chưa có mã bạn đọc!");
            else if (txtMaTL.Text == null)
                MessageBox.Show("Chưa có mã tài liệu!");
            else if(bd.TimKiemBDID(txtMaBD.Text).Rows.Count < 1)
                MessageBox.Show("Mã Bạn Đọc Không Tồn Tại!");
            else if(tl.TimKiemTLID(txtMaTL.Text).Rows.Count < 1)
                MessageBox.Show("Mã Tài Liệu Không Tồn Tại!");
            else
            {
                dgvSachDaMuon.DataSource = bd.ThongKeSachDaMuonTheoID(txtMaBD.Text);
                DataTable dt = tl.TimKiemSoLuongTLID(txtMaTL.Text);
                if(int.Parse(dt.Rows[0]["SoLuong"].ToString()) < 1)
                    MessageBox.Show("Tài Liệu Này Hiện Đã Hết!");
                else
                {
                    tl = new BUS_TaiLieu();
                    DataTable bangtam = new DataTable();

                    bangtam = tl.TimKiemTLID(txtMaTL.Text);
                    tl.Matl = bangtam.Rows[0]["MaTL"].ToString();
                    tl.Nhande = bangtam.Rows[0]["NhanDe"].ToString();
                    tl.Tacgia = bangtam.Rows[0]["TacGia"].ToString();
                    tl.Soluong = int.Parse(bangtam.Rows[0]["SoLuong"].ToString());
                    tl.Domat = int.Parse(bangtam.Rows[0]["DoMat"].ToString());
                    tl.Ngonngu = bangtam.Rows[0]["NgonNgu"].ToString();
                    tl.MaTheLoai = bangtam.Rows[0]["MaTheLoai"].ToString();
                    tl.MaNXB = bangtam.Rows[0]["MaNXB"].ToString();

                    listTLMuon.Add(tl);
                    Show(dgvSachMuon);
                }
            }
        }

        public void Show(DataGridView dgv)
        {
            int i = 0;
            dgv.RowCount = listTLMuon.Count;
            for (i = 0; i < listTLMuon.Count; i++)
            {
                dgv.Rows[i].Cells[0].Value = listTLMuon[i].Matl.ToString();
                dgv.Rows[i].Cells[1].Value = listTLMuon[i].Nhande.ToString();
                dgv.Rows[i].Cells[2].Value = listTLMuon[i].Tacgia.ToString();
                dgv.Rows[i].Cells[3].Value = listTLMuon[i].Soluong.ToString();
                dgv.Rows[i].Cells[4].Value = listTLMuon[i].Domat.ToString();
                dgv.Rows[i].Cells[5].Value = listTLMuon[i].Ngonngu.ToString();
                dgv.Rows[i].Cells[6].Value = listTLMuon[i].MaTheLoai.ToString();
                dgv.Rows[i].Cells[7].Value = listTLMuon[i].MaNXB.ToString();
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvSachMuon.Rows.Count; i++)
            {
                DataTable dt = new DataTable();
                dt = tl.TimKiemSoLuongTLID(dgvSachMuon.Rows[i].Cells[0].Value.ToString());

                if (int.Parse(dt.Rows[0]["SoLuong"].ToString()) >= 1)
                {
                    dt = new DataTable();
                    dt = tl.TimKiemGTCBTheoMaTL(dgvSachMuon.Rows[i].Cells[0].Value.ToString());
                    if (dt.Rows.Count >= 1)
                    {
                        string GTCB = "";
                        GTCB = dt.Rows[0]["GTCB"].ToString();                    

                        string MaPM = "";
                        dt = new DataTable();
                        dt = pm.ThemPhieuMuon(txtMaBD.Text);
                        MaPM = dt.Rows[0]["MaPM"].ToString();
                        MessageBox.Show(MaPM);
                        bool b = ctpm.ThemCTPM(MaPM, GTCB, DateTime.Now, DateTime.Now.AddMonths(6), DateTime.Now, DateTime.Now.AddMonths(6), "");
                        if (b == false)
                            MessageBox.Show("Thêm Thất Bại Cuốn :" + dgvSachMuon.Rows[i].Cells[0].Value.ToString());
                        tl.UodateSoLuongTLID(dgvSachMuon.Rows[i].Cells[0].Value.ToString());
                    }
                    else
                        MessageBox.Show("Không tìm thấy giá trị cá biệt khớp");
                }
            }

            if (MessageBox.Show("Mượn Thành công! Có Muốn kết thúc??", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }
    }
}
