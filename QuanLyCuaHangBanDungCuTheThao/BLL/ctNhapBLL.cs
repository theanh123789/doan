﻿using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class ctNhapBLL
    {


        private static ctNhapBLL instance; // Ctrl + R + E

        public static ctNhapBLL Instance
        {
            get { if (instance == null) instance = new ctNhapBLL(); return ctNhapBLL.instance; }
            private set { ctNhapBLL.instance = value; }
        }


        public void ds(string id, DataGridView data)
        {
            data.DataSource = ctHoaDonNhapDAO.Instance.ds(id);
        }


        public string them(ctHoaDonNhap a)
        {
            if (!ctHoaDonNhapDAO.Instance.them(a))
            {
                return " thành công";
            }
            else
            {
                return "thất bại";
            }
        }
        public string xoa(ctHoaDonNhap a)
        {
            if (ctHoaDonNhapDAO.Instance.xoa(a))
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
