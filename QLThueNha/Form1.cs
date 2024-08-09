using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThueNha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += new EventHandler(Load_Form);
            btnThem.Click += new EventHandler(Them);
            btnSua.Click += new EventHandler(Sua);
            btnXoa.Click += new EventHandler(Xoa);
            btnThoat.Click += new EventHandler(Thoat);
            dataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);
        }

        // Kiểm tra dữ liệu là số 
        public bool isNumber(string value)
        {
            bool ktra;
            float result;
            ktra = float.TryParse(value, out result);
            return ktra;
        }
        // lấy dữ liệu
        public void load_NHA()
        {
            string sql = "select * from NHA";
            dataGridView1.DataSource = Data_Provider.getTable(sql);
        }
        private void Thoat(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Xoa(object sender, EventArgs e)
        {
            Data_Provider.moKetNoi();

            try
            {
                // Lấy mã nhà từ dòng đã chọn trên DataGridView
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string maNha = dataGridView1.SelectedRows[0].Cells["MaNha"].Value.ToString();

                    // Thực hiện xóa
                    string sql = "DELETE FROM NHA WHERE MaNha = @mn";
                    object[] value = { maNha };
                    string[] name = { "@mn" };

                    Data_Provider.updateData(sql, value, name);// Thực hiện xóa
                    MessageBox.Show("Đã xóa thành công!");
                    load_NHA();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một dòng để xóa.");
                }
            }
            finally
            {
                Data_Provider.dongKetNoi(); 
            }
        }


        private void Sua(object sender, EventArgs e)
        {
            Data_Provider.moKetNoi(); 

            try
            {
                // Lấy mã nhà từ dòng đã chọn trên DataGridView
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string maNha = dataGridView1.SelectedRows[0].Cells["MaNha"].Value.ToString();

                    // Thực hiện sửa
                    if (isNumber(txtGiaThue.Text) && !string.IsNullOrEmpty(txtTenChuNha.Text))
                    {
                        string sql = "UPDATE NHA SET TenChuNha = @tcn, GiaThue = @gt, DaCHoThue = @dct WHERE MaNha = @mn";
                        bool dct = cbDaChoThue.Checked;

                        object[] value = { txtTenChuNha.Text, float.Parse(txtGiaThue.Text), dct, maNha };
                        string[] name = { "@tcn", "@gt", "@dct", "@mn" };

                        Data_Provider.updateData(sql, value, name);
                        MessageBox.Show("Đã sửa thành công!");
                        load_NHA(); 
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu không hợp lệ!");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một dòng để sửa.");
                }
            }
            finally
            {
                Data_Provider.dongKetNoi(); 
            }
        }


        private void Them(object sender, EventArgs e)
        {
            Data_Provider.moKetNoi(); 

            try
            {
                // Kiểm tra nếu mã nhà đã tồn tại trong cơ sở dữ liệu
                string checkMaNhaSql = $"SELECT COUNT(*) FROM NHA WHERE MaNha = '{txtMaNha.Text}'";
                int count = Data_Provider.checkData(checkMaNhaSql);

                if (count > 0)
                {
                    MessageBox.Show("Mã nhà đã tồn tại. Vui lòng nhập mã nhà khác.");
                }
                else
                {
                    if (isNumber(txtGiaThue.Text) && !string.IsNullOrEmpty(txtTenChuNha.Text))
                    {
                        string sql = "INSERT INTO NHA(MaNha, TenChuNha, GiaThue, DaCHoThue)" +
                                     "VALUES(@mn, @tcn, @gt, @dct)";

                        bool dct = cbDaChoThue.Checked;

                        object[] value = { txtMaNha.Text, txtTenChuNha.Text, float.Parse(txtGiaThue.Text), dct };
                        string[] name = { "@mn", "@tcn", "@gt", "@dct" };

                        Data_Provider.updateData(sql, value, name); // Thực hiện thêm mới
                        MessageBox.Show("Đã thêm thành công!");
                        load_NHA(); 
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu không hợp lệ!");
                    }
                }
            }
            finally
            {
                Data_Provider.dongKetNoi(); 
            }
        }


        private void Load_Form(object sender, EventArgs e)
        {
            Data_Provider.moKetNoi();
            load_NHA();
            Data_Provider.dongKetNoi();
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];

                // Lấy dữ liệu từ dòng đã chọn trên DataGridView với kiểm tra null
                string maNha = selectedRow.Cells["MaNha"].Value?.ToString() ?? string.Empty;
                string tenChuNha = selectedRow.Cells["TenChuNha"].Value?.ToString() ?? string.Empty;
                string giaThue = selectedRow.Cells["GiaThue"].Value?.ToString() ?? string.Empty;
                bool daChoThue = selectedRow.Cells["DaCHoThue"].Value != null && Convert.ToBoolean(selectedRow.Cells["DaCHoThue"].Value);

                // Hiển thị dữ liệu trên các control
                txtMaNha.Text = maNha;
                txtTenChuNha.Text = tenChuNha;
                txtGiaThue.Text = giaThue;
                cbDaChoThue.Checked = daChoThue;
            }
        }



    }
}
