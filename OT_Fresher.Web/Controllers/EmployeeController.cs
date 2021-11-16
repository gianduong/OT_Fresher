using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OT_Fresher.Core.Entities;
using OT_Fresher.Core.Enum;
using OT_Fresher.Core.Interfaces.Repository;
using OT_Fresher.Core.Interfaces.Service;
using OT_Fresher.Web.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OT_Fresher.Web.Controllers
{
    /// <summary>
    /// Api thực hiện các tác vụ của nhân viên
    /// Createdby: NGDuong(18/08/2021)
    /// </summary>
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class EmployeeController : BaseEntityController<Employee>
    {
        #region Field
        IEmployeeRepository _employeeRepository;
        IEmployeeService _employeeService;
        #endregion

        #region Constructor 
        public EmployeeController(IEmployeeService employeeService, IEmployeeRepository employeeRepository) : base(employeeService, employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;
        }
        #endregion

        #region Methods
        [HttpPut("{employeeId}")]
        public override IActionResult Update(Guid employeeId, Employee employee)
        {
            employee.EntityState = EntityState.Update;
            return base.Update(employeeId, employee);
        }

        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns> Mã nhân viên mới có dạng NV-{...}
        /// 200 - lấy được mã nhân viên mới
        /// 500 - lỗi server
        /// </returns>
        /// Createdby: NGDuong(18/08/2021)
        [HttpGet("NewCode")]
        public IActionResult getBiggestEmployeeCode()
        {
            try
            {
                var newEmployeeCode = _employeeService.GenNewEmployeeCode();
                var actionResult = new Core.Entities.ActionResult(200, Resources.getDataSuccess, "", newEmployeeCode);
                return Ok(actionResult);
            }
            catch (Exception exception)
            { 
                var actionResult = new Core.Entities.ActionResult(500, Resources.error, exception.Message, "");
                return Ok(actionResult);
            }
        }

        /// <summary>
        /// Lấy danh sách nhân viên theo filter
        /// </summary>
        /// <param name="pageInt">page hiện tại</param>
        /// <param name="pageSize">số bản ghi trên page</param>
        /// <param name="filterString">điều kiện filter</param>
        /// <returns>Dữ liệu trả về có phân trang
        /// 500 - lỗi serve
        /// 400 - lỗi dữ liệu đầu vào
        /// 200 -  lấy dữ liệu thành công
        /// </returns>
        /// Createdby: NGDuong(18/08/2021)
        [HttpGet("Filter")]
        public IActionResult GetByPagination(int pageInt, int pageSize, string filterString = null)
        {
            try
            {
                var employees = _employeeRepository.GetByPaginationFilter(pageInt, pageSize, filterString);
                var totalItem = _employeeRepository.GetTotalByFilter(filterString);
                if (employees.Count() > 0)
                {
                    var actionResult = new Core.Entities.ActionResult(200, Resources.getDataSuccess, "", employees, totalItem);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Core.Entities.ActionResult(204, Resources.noReturnData, "", new List<Employee>());
                    return Ok(actionResult);
                }
            }
            catch (Exception exception)
            {
                var actionResult = new Core.Entities.ActionResult(500, Resources.error, exception.Message, new List<Employee>());
                return Ok(actionResult);
            }
        }

        /// <summary>
        /// Xuất khẩu dữ liệu ra file Excel
        /// </summary>
        /// <returns>
        /// File Excel chưa dữ liệu xuất khẩu
        /// Createdby: NGDuong(18/08/2021)
        /// </returns>
        [HttpGet("Export")]
        public IActionResult Export()
        {
            var stream = _employeeService.ExportExcel();
            string fileName = Properties.Resources.excel_save;
            return File(stream, Properties.Resources.excel_source, fileName);

        }
        /// <summary>
        /// Kiểm tra mã code có tồn tai không
        /// </summary>
        /// <param name="code">EmployeeCode</param>
        /// <returns>
        /// 500 - lỗi serve
        /// 204 - không có dữ liệu
        /// 200 - có dữ liệu
        /// </returns>
        /// CreatedBy: NGDuong (18/08/2021)
        [HttpGet("CodeExists")]
        public IActionResult CheckCode(String code)
        {
            try
            {
                if (_employeeRepository.CheckEmployeeCodeExits(code))
                {
                    var actionResult = new Core.Entities.ActionResult(200, Resources.noReturnData, "", code);
                    return Ok(actionResult);
                }
                return Ok(new Core.Entities.ActionResult(204, Resources.noReturnData, "", ""));
            }
            catch (Exception exception)
            {
                var actionResult = new Core.Entities.ActionResult(500, Resources.error, exception.Message, "");
                return Ok(actionResult);
            }
        }
        #endregion

    }
}
