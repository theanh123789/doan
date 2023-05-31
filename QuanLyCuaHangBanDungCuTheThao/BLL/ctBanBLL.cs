using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class ctBanBLL
    {


        private static ctBanBLL instance; // Ctrl + R + E

        public static ctBanBLL Instance
        {
            get { if (instance == null) instance = new ctBanBLL(); return ctBanBLL.instance; }
            private set { ctBanBLL.instance = value; }
        }


        public void ds(ctHoaDonBan id, DataGridView data)
        {
            data.DataSource = ctHoaDonBanDAO.Instance.ds(id);
        }


        public string them(ctHoaDonBan a)
        {
            if (!ctHoaDonBanDAO.Instance.them(a))
            {
                return " thành công";
            }
            else
            {
                return "thất bại";
            }
        }
        public string xoa(ctHoaDonBan a)
        {
            if (ctHoaDonBanDAO.Instance.xoa(a))
            {
                return " thành công";
            }
            else
            {
                return "thất bại";
            }
        }
    }
}
