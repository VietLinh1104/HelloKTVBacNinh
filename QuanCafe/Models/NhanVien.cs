using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanCafe.Models
{
    public class NhanVien
    {
        private int idNhanVien;
        private string tenNhanVien;
        private string chucVu;
        private string soDienThoai;
        private string email;

        public int IdNhanVien { get => idNhanVien; set => idNhanVien = value; }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string Email { get => email; set => email = value; }
    }

}
