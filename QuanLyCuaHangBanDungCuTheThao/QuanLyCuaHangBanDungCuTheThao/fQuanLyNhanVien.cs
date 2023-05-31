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
    public partial class fQuanLyNhanVien : Form
    {
        public fQuanLyNhanVien()
        {
            InitializeComponent();
        }

        nhanVien Data()
        {
            nhanVien a = new nhanVien();
            a.Id = txtId.Text;
            a.Name = txtName.Text;
            a.SdtNv = txtSdt.Text;
            a.QueQuanNv = txtQueQuan.Text;
            a.NamSinh = dtpNgaySinh.Value.ToString();
            a.LuongCb = txtLuongCoBan.Text;
            a.TaiKhoan = txtTaiKhoan.Text;
            a.MatKhau = txtMatKhau.Text;
            a.Quyen = ccbQuyen.SelectedIndex.ToString();
            return a;


        }

        void xoaText()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtSdt.Text = "";
            txtQueQuan.Text = "";
            dtpNgaySinh.Value = DateTime.UtcNow;
            txtLuongCoBan.Text = "";
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            ccbQuyen.SelectedIndex = 0;
            txtId.Enabled = true;


        }

        void load()
        {
            nhanVienBLL.Instance.ds(dgvDS);
            btnBoQua.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
        }

        private void fQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            load();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(nhanVienBLL.Instance.them(Data()));
                load();
                xoaText();
            }
            catch
            {
                MessageBox.Show("bạn phải nhập lại có thể bị trùng id");
            }
        }

        private void dgvDS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // kiểm tra hàng được click là hàng thực sự, không phải hàng tiêu đề
                {
                    DataGridViewRow row = dgvDS.Rows[e.RowIndex];

                    txtId.Text = row.Cells[0].Value.ToString();
                    txtName.Text = row.Cells[1].Value.ToString();
                    dtpNgaySinh.Text = row.Cells[2].Value.ToString();
                    txtQueQuan.Text = row.Cells[3].Value.ToString();
                    txtSdt.Text = row.Cells[4].Value.ToString();
                    txtLuongCoBan.Text = row.Cells[5].Value.ToString();
                    txtTaiKhoan.Text = row.Cells[6].Value.ToString();
                    txtMatKhau.Text = row.Cells[7].Value.ToString();
                    string asa = row.Cells[8].Value.ToString();
                    ccbQuyen.SelectedIndex = int.Parse(asa);




                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;

                    txtId.Enabled = false;
                    btnThem.Enabled = true;
                    btnBoQua.Enabled = true;
                }
            }
            catch { MessageBox.Show("lỗi"); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(nhanVienBLL.Instance.sua(Data()));
                load();
                xoaText();
            }
            catch
            {
                MessageBox.Show("bạn phải nhập lại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("bạn có muốn xóa", "thông báo", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                try
                {
                    MessageBox.Show(nhanVienBLL.Instance.xoa(Data()));
                    load();
                    xoaText();
                }
                catch
                {
                    MessageBox.Show("bạn phải nhập lại ");
                }
            }
            
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            load();
            xoaText();
        }
    }
}
