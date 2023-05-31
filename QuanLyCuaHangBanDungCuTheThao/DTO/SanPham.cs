using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPham
    {
        public SanPham( string id, string name, string hang, string loai, string mota, string giaBan, string soLuong) 
        { 
            this.Id = id;
            this.Name = name;
            this.Hang = hang;
            this.Loai = loai;
            this.MoTa = mota;
            this.GiaBan= giaBan;
            this.SoLuong= soLuong;
        
        }

        public SanPham() { }

        public SanPham( DataRow row) 
        {

            this.Id = row["idSanPham"].ToString();
            this.Name = row["tenSanPham"].ToString(); 
            this.Hang = row["hangSx"].ToString();
            this.Loai = row["loaiSanPham"].ToString();
            this.MoTa = row["moTa"].ToString();
            this.GiaBan = row["giaBan"].ToString();
            this.SoLuong = row["soLuong"].ToString();

        }
        

        // crtrl + r + e
        private string id;
        private string name;
        private string hang;
        private string loai;
        private string moTa;
        private string giaBan;
        private string soLuong;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Hang { get => hang; set => hang = value; }
        public string Loai { get => loai; set => loai = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public string GiaBan { get => giaBan; set => giaBan = value; }
        public string SoLuong { get => soLuong; set => soLuong = value; }
    }
}
