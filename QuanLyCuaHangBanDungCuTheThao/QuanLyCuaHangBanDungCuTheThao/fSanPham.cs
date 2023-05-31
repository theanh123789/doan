using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangBanDungCuTheThao
{
    public partial class fSanPham : Form
    {
        public fSanPham()
        {
            InitializeComponent();
        }
        SanPham Data()
        {
            SanPham a = new SanPham();
            a.Id = txtId.Text;
            a.Name = txtName.Text;
            a.Hang = txtHang.Text;
            a.MoTa = txtMoTa.Text;
            a.Loai = ccbLoaiSp.SelectedItem.ToString();
            a.GiaBan = txtGiaBan.Text;

            return a;
        }

        void xoa()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtMoTa.Text = "";
            txtId.Enabled = true;
            txtGiaBan.Text = "";
            ccbLoaiSp.SelectedItem = null;
            txtHang.Text = "";
        }
        void load()
        {
            sanPhamBLL.Instance.ds(dgvDS);
            btnBoQua.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }

        private void fSanPham_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            try
            {
               MessageBox.Show(sanPhamBLL.Instance.them(Data()));
            load();
            xoa();
            }
            catch
            {
                MessageBox.Show("bạn phải nhập lại có thể bị trùng id");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(sanPhamBLL.Instance.sua(Data()));
                load();
                xoa();
            }
            catch
            {
                MessageBox.Show("bạn phải nhập lại có thể bị trùng id");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("bạn có muốn xóa", "thông báo", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                try
                {
                    MessageBox.Show(sanPhamBLL.Instance.xoa(Data()));
                    load();
                    xoa();
                }
                catch
                {
                    MessageBox.Show("bạn phải nhập lại có thể bị trùng id");
                }
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            load();
            xoa();
        }

        private void dgvDS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // kiểm tra hàng được click là hàng thực sự, không phải hàng tiêu đề
            {
                DataGridViewRow row = dgvDS.Rows[e.RowIndex];

                txtId.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtHang.Text = row.Cells[2].Value.ToString();
                ccbLoaiSp.SelectedItem = row.Cells[3].Value.ToString();
                txtMoTa.Text = row.Cells[4].Value.ToString();

                txtGiaBan.Text = row.Cells[5].Value.ToString();



                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtId.Enabled = false;
                btnThem.Enabled = false;
                btnBoQua.Enabled = true;
            }
        }
    }
}
