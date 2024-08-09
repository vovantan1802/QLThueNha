using System;
using System.Data;
using System.Windows.Forms;

namespace QLThueNha
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Load += new EventHandler(Load_Form);
            btnTaiHopDong.Click += new EventHandler(TaiHopDong);
            btnHopDongCaoNhat.Click += new EventHandler(HopDongCaoNhat);
        }

        public void load_HopDong()
        {
            string sql = @"SELECT HD.SoHD, N.TenChuNha, KH.TenKhach, HD.NgayBatDau, 
                          HD.NgayKetThuc, DATEDIFF(month, HD.NgayBatDau, HD.NgayKetThuc) * N.GiaThue AS ThanhTien
                   FROM HopDong HD
                   JOIN NHA N ON HD.MaNha = N.MaNha
                   JOIN KHACHTHUENHA KH ON HD.MaKhach = KH.MaKhach";

            DataTable dt = Data_Provider.getTable(sql);
            dataGridView1.DataSource = dt;
        }

        private void TaiHopDongCaoNhat()
        {
            string sql = @"SELECT TOP 1 HD.SoHD, N.TenChuNha, KH.TenKhach, HD.NgayBatDau, 
                          HD.NgayKetThuc, DATEDIFF(month, HD.NgayBatDau, HD.NgayKetThuc) * N.GiaThue AS ThanhTien
                   FROM HopDong HD
                   JOIN NHA N ON HD.MaNha = N.MaNha
                   JOIN KHACHTHUENHA KH ON HD.MaKhach = KH.MaKhach
                   ORDER BY ThanhTien DESC";

            DataTable dt = Data_Provider.getTable(sql);
            dataGridView1.DataSource = dt;  // Cập nhật DataGridView với kết quả
        }

        private void HopDongCaoNhat(object sender, EventArgs e)
        {
            Data_Provider.moKetNoi();
            TaiHopDongCaoNhat();  // Hiển thị hợp đồng có giá thuê cao nhất
            Data_Provider.dongKetNoi();
        }

        private void TaiHopDong(object sender, EventArgs e)
        {
            load_HopDong();  // Tải và hiển thị tất cả các hợp đồng
        }

        private void Load_Form(object sender, EventArgs e)
        {
            Data_Provider.moKetNoi();
            load_HopDong();  // Tải hợp đồng khi form được load
            Data_Provider.dongKetNoi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
