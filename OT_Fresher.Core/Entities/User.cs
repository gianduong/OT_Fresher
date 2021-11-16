using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT_Fresher.Core.Entities
{
	/// <summary>
	/// Khách hàng
	/// </summary>
	/// CreatedBy: NGDUong (15/11/2021)
    public class User:BaseEntity
    {
		/// <summary>
		/// id
		/// </summary>
		public Guid UserId { get; set; }
		/// <summary>
		/// tên đệm
		/// </summary>
		public string LastName { get; set; }
		/// <summary>
		/// mật khâu, hiện tại lưu dưới dạng string
		/// </summary>
		public string Password { get; set; }
		/// <summary>
		/// email
		/// </summary>
		public string Email { get; set; }
		/// <summary>
		/// địa chỉ
		/// </summary>
		public string Address { get; set; }
		/// <summary>
		/// Tên đầu
		/// </summary>
		public string FirstName { get; set; }
		/// <summary>
		/// số điện thoại
		/// </summary>
        public string PhoneNumber { get; set; }
		/// <summary>
		/// kinh độ vị trí
		/// </summary>
        public string Longitude { get; set; }
		/// <summary>
		/// Vĩ độ vị trí
		/// </summary>
        public string Latitude { get; set; }
    }
}
