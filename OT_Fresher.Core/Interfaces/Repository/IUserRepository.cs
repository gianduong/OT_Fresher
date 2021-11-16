using OT_Fresher.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT_Fresher.Core.Interfaces.Repository
{
    /// <summary>
    /// Interface khách hàng 
    /// </summary>
    /// CreatedBy: NGDuong (15/11/2021)
    public interface IUserRepository : IBaseRepository<User>
    {
        /// <summary>
        /// phân trang
        /// </summary>
        /// <param name="pageInt">số trang</param>
        /// <param name="pageSize">kích cỡ trang</param>
        /// <param name="filterString">từ khóa nếu có</param>
        /// <returns>dan sách khách hàng</returns>
        /// CreatedBy: NGDuong (15/11/2021)
        IEnumerable<User> GetByPaginationFilter(int pageInt, int pageSize, string filterString);
        /// <summary>
        /// Lấy số lượng bản ghi hợp lệ
        /// </summary>
        /// <param name="filterString">chuỗi điều kiện</param>
        /// <returns>
        /// Số lượng bản ghi hợp lệ
        /// </returns>
        /// NGDuong (18/08/2021)
        int GetTotalByFilter(string filterString);
        /// <summary>
        /// Kiểm tra Email có bị trùng hay không
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns> true : có trùng; False: không trùnd</returns>
        /// CreatedBy: NGDuong (15/11/2021)
        bool CheckEmailExist(string email);
    }
}
