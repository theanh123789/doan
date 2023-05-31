using BLL;
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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("bạn có muốn thoát", "thông báo", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string[] arr= new string[2];
            string userName = txbUserName.Text;
            string passWord = txbPassWord.Text;
            if (nhanVienBLL.Instance.dangNhap(userName, passWord))
            {

                arr = nhanVienBLL.Instance.idQuyen(userName, passWord);
                Program.id = arr[0];
                Program.quyen = arr[1];
                TRangchucs f = new TRangchucs();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
            }
        }
    }
}
