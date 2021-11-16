using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OT_Fresher.Core.Exceptions;
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
    /// API phục vụ các chức năng cơ bản
    /// </summary>
    /// <typeparam name="T">Đối tượng xử lý</typeparam>
    /// CreatedBy: NGDuong (18/08/2021)
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class BaseEntityController<T> : ControllerBase
    {
        #region Fields
        IBaseService<T> _baseServices;
        IBaseRepository<T> _baseRepository;
        #endregion

        #region Constructor
        public BaseEntityController(IBaseService<T> baseservice, IBaseRepository<T> baseRepository)
        {
            _baseServices = baseservice;
            _baseRepository = baseRepository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy tất cả thực thể T
        /// </summary>
        /// <returns>
        /// 200 - Có dữ liệu
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy: NGDuong(18/08/2021)
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var res = _baseRepository.GetAll();
                if (res.Count() > 0)
                {
                    var actionResult = new Core.Entities.ActionResult(200, Resources.getDataSuccess, "", res);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Core.Entities.ActionResult(204, Resources.noReturnData, "", new List<T>());
                    return Ok(actionResult);
                }
            }
            catch (Exception exception)
            {
                var actionResult = new Core.Entities.ActionResult(500, Resources.error, exception.Message, new List<T>());
                return Ok(actionResult);
            }
        }
        /// <summary>
        /// Lấy thông tin thực thể t
        /// </summary>
        /// <param name="id">id thực thể</param>
        /// <returns>
        /// 200 - Có dữ liệu
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy : NGDuong(18/08/2021)
        [HttpGet("{entityId}")]
        public IActionResult GetById(Guid entityId)
        {
            try
            {
                var res = _baseRepository.GetById(entityId);
                if (res != null)
                {
                    var actionResult = new Core.Entities.ActionResult(200, Resources.getDataSuccess, "", res);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Core.Entities.ActionResult(204, Resources.noReturnData, "", null);
                    return Ok(actionResult);
                }
            }
            catch (Exception exception)
            {
                var actionResult = new Core.Entities.ActionResult(500, Resources.error, exception.Message, null);
                return Ok(actionResult);
            }
        }
        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi được thêm mới </param>
        /// <returns>
        /// 200 - Có dữ liệu
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy : NGDuong(18/08/2021)
        [HttpPost]
        public IActionResult Insert(T entity)
        {
            try
            {
                var rowsAffect = _baseServices.Insert(entity);
                if (rowsAffect > 0)
                {
                    var actionResult = new Core.Entities.ActionResult(200, Resources.addDataSuccess, "", rowsAffect);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Core.Entities.ActionResult(204, Resources.addDataFail, "", 0);
                    return Ok(actionResult);
                }
            }
            catch (ValidateException exception)
            {
                var actionResult = new Core.Entities.ActionResult(400, exception.Message, "", exception.Data);
                return Ok(actionResult);

            }
            catch (Exception exception)
            {
                var actionResult = new Core.Entities.ActionResult(500, Resources.error, exception.Message, 0);
                return Ok(actionResult);
            }
        }
        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entityId">ID bản ghi cần cập nhật</param>
        /// <param name="entity">Bản ghi cập nhật</param>
        /// <returns>
        /// 200 - Có dữ liệu
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy : NGDuong(18/08/2021)
        [HttpPut("{entityId}")]
        public virtual IActionResult Update(Guid entityId, T entity)
        {
            try
            {
                var rowsAffect = _baseServices.Update(entityId, entity);
                if (rowsAffect > 0)
                {
                    var actionResult = new Core.Entities.ActionResult(200, Resources.editDataSuccess, "", rowsAffect);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Core.Entities.ActionResult(204, Resources.editDataFail, "", 0);
                    return Ok(actionResult);
                }
            }
            catch (ValidateException exception)
            {
                var actionResult = new Core.Entities.ActionResult(400, exception.Message, "", 0);
                return Ok(actionResult);
            }
            catch (Exception exception)
            {
                var actionResult = new Core.Entities.ActionResult(500, Resources.error, exception.Message, 0);
                return Ok(actionResult);
            }
        }
        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="entityId">Id bản ghi cần xóa</param>
        /// <returns>
        /// 200 - Có dữ liệu
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy: NGDuong(18/08/2021)
        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
        {
            try
            {
                var rowsAffect = _baseRepository.Delete(entityId);
                if (rowsAffect > 0)
                {
                    var actionResult = new Core.Entities.ActionResult(200, Resources.deleteDataSuccess, "", rowsAffect);
                    return Ok(actionResult);
                }
                else
                {
                    var actionResult = new Core.Entities.ActionResult(204, Resources.deleteDataFail, "", 0);
                    return Ok(actionResult);
                }
            }
            catch (ValidateException exception)
            {
                var actionResult = new Core.Entities.ActionResult(400, exception.Message, "", exception.Data);
                return Ok(actionResult);
            }
            catch (Exception exception)
            {
                var actionResult = new Core.Entities.ActionResult(500, Resources.error, exception.Message, 0);
                return Ok(actionResult);
            }
        }
        #endregion

    }
}

