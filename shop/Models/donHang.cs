using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shop.Models
{
    public class donHang
    {
        public int ID { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChiGiaoHang { get; set; }
        public DateTime NgayDatHang { get; set; }
        public List<dienThoai> DienThoaiDatMua = new List<dienThoai>();
    }
}