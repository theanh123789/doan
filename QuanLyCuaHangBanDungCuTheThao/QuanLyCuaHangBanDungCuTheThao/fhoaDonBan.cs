using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace QuanLyCuaHangBanDungCuTheThao
{
    public partial class fhoaDonBan : Form
    {
        public fhoaDonBan()
        {
            InitializeComponent();
        }
        hoaDonBan get()
        {
            hoaDonBan a = new hoaDonBan();
            a.Id = txtId.Text;
            a.IdNhanVien = Program.id;

            a.IdKhachHang = txtKhachHnag.Text;

            a.NgayBan = DateTime.Now.ToString();
            return a;
        }


        ctHoaDonBan getCtDon()
        {
            ctHoaDonBan a = new ctHoaDonBan();
            a.IdHoaDonBan = txtId.Text;
            a.IdSanpham = txtMaSp.Text;
            a.SoLuong = (int)Soluong.Value;
            return a;

        }

        void load()
        {
            banBLL.Instance.ds(DateTime.Now.ToString(), dsvHD);


        }


        void loadSp()
        {


            ctBanBLL.Instance.ds(getCtDon(), dgvSanPham);
        }

        void xoaTextHD()
        {
            txtId.Enabled = true;
            btnXoaHD.Enabled = false;
            btnThemHD.Enabled = true;
            btnXoaHD.Enabled = true;
        }

        void xoaTextsp()
        {
            txtMaSp.Enabled = true;
            btnThemSp.Enabled = true;
            btnXoaSp.Enabled = false;

        }

        private void btnThemSp_Click(object sender, EventArgs e)
        {
            try
            {

                MessageBox.Show(ctBanBLL.Instance.them(getCtDon()));
                load();
                loadSp();
                xoaTextHD();

            }
            catch (Exception ex) { MessageBox.Show("lỗi"); }
        }

        private void fhoaDonBan_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {

            try
            {
                MessageBox.Show(banBLL.Instance.them(get()));
                load();
                xoaTextHD();


            }
            catch (Exception ex) { MessageBox.Show("lỗi"); }
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("bạn có muốn xóa", "thông báo", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {

                try
                {

                    MessageBox.Show(banBLL.Instance.xoa(get()));
                    load();
                    xoaTextHD();

                }
                catch (Exception ex) { MessageBox.Show("lỗi"); }
            }
            
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {

            load();
            xoaTextHD();
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            banBLL.Instance.inHoaDon(txtId.Text);
        }

        private void btnXoaSp_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("bạn có muốn xóa", "thông báo", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                try
                {

                    MessageBox.Show(ctBanBLL.Instance.xoa(getCtDon()));
                    load();
                    loadSp();
                    xoaTextHD();

                }
                catch (Exception ex) { MessageBox.Show("lỗi"); }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            load();
            loadSp();
            xoaTextHD();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                banBLL.Instance.ds(dateTk.Value.ToString(), dsvHD);
            }
            catch { MessageBox.Show("lỗi"); }
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0) // kiểm tra hàng được click là hàng thực sự, không phải hàng tiêu đề
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];

                txtMaSp.Text = row.Cells[0].Value.ToString();




            }
        }

        private void dsvHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // kiểm tra hàng được click là hàng thực sự, không phải hàng tiêu đề
            {
                DataGridViewRow row = dsvHD.Rows[e.RowIndex];

                txtId.Text = row.Cells[0].Value.ToString();
                txtKhachHnag.Text = row.Cells[2].Value.ToString();
                Tong.Text = row.Cells[4].Value.ToString();
                txtId.Enabled = false;
                txtKhachHnag.Enabled = false;
                loadSp();




            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
