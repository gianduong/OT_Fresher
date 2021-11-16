using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT_Fresher.Core.Entities
{
    /// <summary>
    /// Thông tin kết quả trả về cho client
    /// </summary>
    /// CreatedBy: NGDuong (24/08/2021)
    public class ActionResult
    {
        #region Field
        /// <summary>
        /// Trạng thái kết quả trả về
        /// </summary>
        /// CreatedBy: NGDuong (24/08/2021)
        public int status { get; set; }

        /// <summary>
        /// Thông báo cho Client
        /// </summary>
        /// CreatedBy: NGDuong (24/08/2021)
        public string userMsg { get; set; }

        /// <summary>
        /// Thông báo dành cho Lập trình viên
        /// </summary>
        /// CreatedBy: NGDuong (24/08/2021)
        public string devMsg { get; set; }

        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        /// CreatedBy: NGDuong (24/08/2021)
        public dynamic data { get; set; }

        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        /// CreatedBy: NGDuong (24/08/2021)
        public int total { get; set; }
        #endregion

        #region Constructure
        /// <summary>
        /// hàm khởi tạo một danh sách trả về cho client
        /// </summary>
        /// <param name="statusCode">Status response</param>
        /// <param name="userMessage">Thông điệp lỗi cho khách hàng</param>
        /// <param name="devMessage">Thông điệp lỗi cho dev</param>
        /// <param name="data">dũ liệu trả về</param>
        /// Createdby: NGDuong (25/08/2021)
        public ActionResult(int statusCode, string userMessage, string devMessage, dynamic data)
        {
            this.status = statusCode;
            this.userMsg = userMessage;
            this.devMsg = devMessage;
            this.data = data;
        }
        /// <summary>
        /// hàm khởi tạo một danh sách trả về cho client
        /// </summary>
        /// <param name="statusCode">Status response</param>
        /// <param name="userMessage">Thông điệp lỗi cho khách hàng</param>
        /// <param name="devMessage">Thông điệp lỗi cho dev</param>
        /// <param name="data">dũ liệu trả về</param>
        /// <param name="totalRecord">số bản ghi</param>
        /// Createdby: NGDuong (25/08/2021)
        public ActionResult(int statusCode, string userMessage, string devMessage, dynamic data, int totalRecord)
        {
            this.status = statusCode;
            this.userMsg = userMessage;
            this.devMsg = devMessage;
            this.total = totalRecord;
            this.data = data;
        }
        #endregion
    }
}