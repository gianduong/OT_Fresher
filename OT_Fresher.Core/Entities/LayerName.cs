using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT_Fresher.Core.Entities
{
    public class LayerName
    {
        public Guid LayerNameId { get; set; }
        public string cauHinhMoRong { get; set; }
        public string chuDe { get; set; }
        public string khungNhinHienTai { get; set; }
        public string loaiBanDo { get; set; }
        public string maBanDo { get; set; }
        public string maUngDung { get; set; }
        public string mauNenMacDinh { get; set; }
        public string moTa { get; set; }
        public string mucXemLonNhat { get; set; }
        public string mucXemNhoNhat { get; set; }
        public string tuKhoa { get; set; }
        public string tenBanDo { get; set; }
        public string vungBaoGioiHan { get; set; }
        public string vungBaoLonNhat { get; set; }
        public string vungBaoNhoNhat { get; set; }
        public string nguoiCapNhat { get; set; }
        public string nguoiTao { get; set; }
        public DateTime ngayCapNhat { get; set; }
        public DateTime ngayTao { get; set; }
    }
}
