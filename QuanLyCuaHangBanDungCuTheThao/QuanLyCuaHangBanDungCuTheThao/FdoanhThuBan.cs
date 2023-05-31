using cuaHangBanRauCu;
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
    public partial class FdoanhThuBan : Form
    {
        public FdoanhThuBan()
        {
            InitializeComponent();
        }

        private void txtTongKe_Click(object sender, EventArgs e)
        {

            if (txtThang.Text == "" || txtNam.Text == "")
            {
                MessageBox.Show("nhập đầy đủ");
            }
            else
            {
                thongKeBLL.Instance.dsNhapNgay(txtThang.Text, txtNam.Text, dgvDsTk);
            }
        }

        private void txtInTK_Click(object sender, EventArgs e)
        {
            if (txtThang.Text == "" || txtNam.Text == "")
            {
                MessageBox.Show("nhập đầy đủ");
            }
            else
            {
                thongKeBLL.Instance.inthongKethang(txtThang.Text, txtNam.Text);
            }
        }
    }
}
