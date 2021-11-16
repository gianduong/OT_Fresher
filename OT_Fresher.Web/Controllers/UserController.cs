using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OT_Fresher.Core.Entities;
using OT_Fresher.Core.Interfaces.Repository;
using OT_Fresher.Core.Interfaces.Service;
using OT_Fresher.Web.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OT_Fresher.Web.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class UserController : BaseEntityController<User>
    {
        #region Field
        IUserRepository repository;
        IUserService service;
        #endregion
        #region Constructure
        public UserController(IUserService baseService, IUserRepository baseRepository) : base(baseService, baseRepository)
        {
            repository = baseRepository;
            service = baseService;
        }
        #endregion
        #region API
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
                var users = repository.GetByPaginationFilter(pageInt, pageSize, filterString);
                var totalItem = repository.GetTotalByFilter(filterString);
                if (users.Count() > 0)
                {
                    var actionResult = new Core.Entities.ActionResult(200, Resources.getDataSuccess, "", users,totalItem);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Core.Entities.ActionResult(204, Resources.noReturnData, "", new List<User>());
                    return Ok(actionResult);
                }
            }
            catch (Exception exception)
            {
                var actionResult = new Core.Entities.ActionResult(500, Resources.error, exception.Message, new List<User>());
                return Ok(actionResult);
            }
        }
        #endregion
    }
}
