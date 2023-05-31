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
    public partial class fNhaCC : Form
    {
        public fNhaCC()
        {
            InitializeComponent();
        }
        nhaCungCap Data()
        {
            nhaCungCap a = new nhaCungCap();
            a.Id = txtId.Text;
            a.Name = txtName.Text;
            a.DiaChi = txtDiaChi.Text;
            a.Sdt = txtSdt.Text;
            return a;
        }

        void xoa()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtDiaChi.Text = "";
            txtSdt.Text = "";
            txtId.Enabled = true;
        }

        void load()
        {
            nhaCCBLL.Instance.ds(dgvDS);
            btnBoQua.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;

        }

        private void fNhaCC_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(nhaCCBLL.Instance.them(Data()));
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
                MessageBox.Show(nhaCCBLL.Instance.sua(Data()));
                load();
                xoa();
            }
            catch
            {
                MessageBox.Show("bạn phải nhập lại ");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("bạn có muốn xóa", "thông báo", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                try
                {
                    MessageBox.Show(nhaCCBLL.Instance.xoa(Data()));
                    load();
                    xoa();
                }
                catch
                {
                    MessageBox.Show("bạn không thể xóa ");
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
                txtDiaChi.Text = row.Cells[3].Value.ToString();
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
