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
    public partial class TRangchucs : Form
    {
        public TRangchucs()
        {
            InitializeComponent();
            OpenChildForm(new TrangChu());
        }

        private Form currentFormChild;
        private void OpenChildForm(Form FormChild)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = FormChild;
            FormChild.TopLevel = false;
            FormChild.FormBorderStyle = FormBorderStyle.None;
            FormChild.Dock = DockStyle.Fill;
            panel1.Controls.Add(currentFormChild);
            panel1.Tag = FormChild;
            FormChild.BringToFront();
            FormChild.Show();
        }

        private void TRangchucs_Load(object sender, EventArgs e)
        {

        }

        private void tRANGCHURToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChildForm(new TrangChu());

            }
            catch (Exception ex) { MessageBox.Show("lỗi"); }
        }

        private void nHÂNVIÊNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.Parse(Program.quyen) > 0)
            {
                nHÂNVIÊNToolStripMenuItem.Enabled = false;
                MessageBox.Show("bạn không đủ quyền hạn");


            }
            else
            {
                try
                {
                    OpenChildForm(new fQuanLyNhanVien());
                }
                catch (Exception ex) { MessageBox.Show("lỗi"); }
            }
        }

        private void nHÀCUNGCẤPToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (int.Parse(Program.quyen) > 0)
            {
                nHÂNVIÊNToolStripMenuItem.Enabled = false;
                MessageBox.Show("bạn không đủ quyền hạn");


            }
            else
            {
                try
                {
                    OpenChildForm(new fNhaCC());
                }
                catch (Exception ex) { MessageBox.Show("lỗi"); }
            }
        }

        private void sẢNPHẨMToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (int.Parse(Program.quyen) > 0)
            {
                nHÂNVIÊNToolStripMenuItem.Enabled = false;
                MessageBox.Show("bạn không đủ quyền hạn");


            }
            else
            {
                try
                {
                    OpenChildForm(new fSanPham());
                }
                catch (Exception ex) { MessageBox.Show("lỗi"); }
            }
        }

        private void kHÁCHHÀNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChildForm(new fKhachHang());
            }
            catch (Exception ex) { MessageBox.Show("lỗi"); }
        }

        private void hÓAĐƠNNHẬPToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (int.Parse(Program.quyen) > 0)
            {
                nHÂNVIÊNToolStripMenuItem.Enabled = false;
                MessageBox.Show("bạn không đủ quyền hạn");


            }
            else
            {
                try
                {
                    OpenChildForm(new FhoaDonNhap());
                }
                catch (Exception ex) { MessageBox.Show("lỗi"); }
            }
        }

        private void hÓAĐƠNBÁNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChildForm(new fhoaDonBan());
            }
            catch (Exception ex) { MessageBox.Show("lỗi"); }
        }

        private void tHỐNGKÊToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.Parse(Program.quyen) > 0)
            {
                nHÂNVIÊNToolStripMenuItem.Enabled = false;
                MessageBox.Show("bạn không đủ quyền hạn");


            }
            else
            {
                try
                {
                    OpenChildForm(new FdoanhThuBan());
                }
                catch (Exception ex) { MessageBox.Show("lỗi"); }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
