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
    public partial class fKhachHang : Form
    {
        public fKhachHang()
        {
            InitializeComponent();
        }


        KhachHang Data()
        {
            KhachHang a = new KhachHang();
            a.Id = txtId.Text;
            a.Name = txtName.Text;
            a.Sdt = txtSdt.Text;
            return a;
        }

        void xoa()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtSdt.Text = "";
            txtId.Enabled = true;
        }
        void load()
        {
            khachHangBLL.Instance.ds(dgvDS);
            btnBoQua.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(khachHangBLL.Instance.them(Data()));
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
                MessageBox.Show(khachHangBLL.Instance.sua(Data()));
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
                    MessageBox.Show(khachHangBLL.Instance.xoa(Data()));
                    load();
                    xoa();
                }
                catch
                {
                    MessageBox.Show("bạn phải nhập lại có thể bị trùng id");
                }
            }
        }

        private void fKhachHang_Load(object sender, EventArgs e)
        {
            load();
        }

        private void dgvDS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // kiểm tra hàng được click là hàng thực sự, không phải hàng tiêu đề
            {
                DataGridViewRow row = dgvDS.Rows[e.RowIndex];

                txtId.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();

                txtSdt.Text = row.Cells[2].Value.ToString();




                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                txtId.Enabled = false;
                btnThem.Enabled = true;
                btnBoQua.Enabled = true;
            }
        }
    }
}
