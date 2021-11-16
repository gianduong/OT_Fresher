using OT_Fresher.Core.Attributes;
using OT_Fresher.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT_Fresher.Core.Entities
{
    /// <summary>
    /// Các thuộc tính entity dùng chung
    /// </summary>
    /// CreatedBy : NGDuong (18/08/2021)
    public class BaseEntity
    {
        /// <summary>
        /// Ngày tạo
        /// </summary>
        /// CreatedBy : NGDuong (18/08/2021)
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        /// CreatedBy : NGDuong (18/08/2021)
        [MaxSize(MaxLength: 100)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày sửa
        /// </summary>
        /// CreatedBy : NGDuong (18/08/2021)
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người sửa
        /// </summary>
        /// CreatedBy : NGDuong (18/08/2021)
        [MaxSize(MaxLength: 100)]
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Trạng thái cập nhật hay thêm 
        /// </summary>
        /// CreatedBy: NGDuong (18/08/2021)
        public EntityState EntityState { get; set; } = EntityState.Add;
    }
}
