using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using MDERP.Business.IService;
using MDERP.Business.Models;
using MDERP.Business.Models.Entities;
using MDERP.Business.Models.ViewModels;
using MDERP.Business.Service;
using MDERP.Common.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;

namespace MDERP.Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeDepartmentRelService _employeeDepartmentRelService;
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(IDepartmentService departmentService, IEmployeeDepartmentRelService employeeDepartmentRelService, ILogger<DepartmentController> logger)
        {
            _departmentService = departmentService;
            _employeeDepartmentRelService = employeeDepartmentRelService;
            _logger = logger;
        }

        [HttpGet("{deptID}")]
        public async Task<JsonResult> GetDepartmentInfo(string deptID)
        {
            ApiResult result = new ApiResult();
            try
            {
                if (string.IsNullOrEmpty(deptID) || string.IsNullOrWhiteSpace(deptID))
                {
                    result.Success = false;
                    result.Msg = "参数不能为空";
                    result.ErrorCode = 10002;
                }
                else
                {
                    var departmentInfo = await _departmentService.GetModelById(deptID);
                    result.Data = departmentInfo;
                    result.Success = true;
                    result.Msg = "获取成功";
                }
            }
            catch (Exception ex) 
            {
                result.Success = false;
                result.Msg = ex.Message;
                result.ErrorCode = 99;
                _logger.LogError(ex, ex.Message);
            }
            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<JsonResult> SaveDepartment(object jsonText)
        {
            ApiResult result = new ApiResult();
            try
            {
                if (string.IsNullOrEmpty(jsonText.ToString()))
                {
                    result.Success = false;
                    result.Msg = "参数不能为空";
                    result.ErrorCode = 10002;
                }
                else
                {
                    Sys_DepartmentVM tempDepartmentVM = JsonConvert.DeserializeObject<Sys_DepartmentVM>(jsonText.ToString()!)!;
                    Sys_Department tempDepartmentEnt = EntityHelper.MapTo<Sys_Department, Sys_DepartmentVM>(tempDepartmentVM);
                    string departmentId = tempDepartmentEnt.D_DeptId;
                    bool isNew = false;
                    DateTime dt = DateTime.Now;
                    var expression = Extention.True<Sys_Department>();
                    expression = expression.And(x => x.D_DeptName.Equals(tempDepartmentVM.D_DeptName));
                    var tempEnt = await _departmentService.GetModelByExpression(expression);
                    if (tempEnt != null)
                    {
                        result.Success = false;
                        result.Msg = "部门名称已存在，请重新输入";
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(departmentId) && string.IsNullOrWhiteSpace(departmentId))
                        {
                            isNew = true;
                            departmentId = GuidHelper.GetGuidN();
                            tempDepartmentEnt.D_DeptId = departmentId;
                            tempDepartmentEnt.D_CreateDate = dt;
                            tempDepartmentEnt.D_IsDel = 0;
                        }
                        else
                        {
                            var oldEnt = await _departmentService.GetModelById(departmentId);
                            tempDepartmentEnt.D_CreateDate = oldEnt.D_CreateDate;
                        }
                        var processResult = false;
                        if (isNew)
                        {
                            processResult = await _departmentService.Add(tempDepartmentEnt) > 0;
                        }
                        else
                        {
                            processResult = await _departmentService.Update(tempDepartmentEnt);
                        }
                        if (processResult)
                        {
                            result.Success = true;
                            result.Msg = "操作成功";
                        }
                        else
                        {
                            result.Success = false;
                            result.Msg = "操作失败";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Msg = "Exception：" + ex.Message;
                result.ErrorCode = 99;
                _logger.LogError(ex, ex.Message);
            }
            return new JsonResult(result);
        }

        [HttpPost("{departmentid}")]
        public async Task<JsonResult> DeleteDepartment(string departmentid)
        {
            ApiResult result = new ApiResult();
            try
            {
                if (string.IsNullOrEmpty(departmentid) && string.IsNullOrWhiteSpace(departmentid))
                {
                    result.Success = false;
                    result.Msg = "参数不能为空";
                    result.ErrorCode = 10002;
                }
                else
                {
                    var deptEmpRelExpression = Extention.True<Sys_EmployeeDepartmentRel>();
                    deptEmpRelExpression = deptEmpRelExpression.And(x => x.D_DeptId == departmentid);
                    var relList = _employeeDepartmentRelService.QueryableByExpression(deptEmpRelExpression).Result;
                    if (relList != null)
                    {
                        result.Success = false;
                        result.Msg = "该部门下存在人员无法删除！";
                        return new JsonResult(result);
                    }
                    Sys_Department deptModel = _departmentService.GetModelById(departmentid).Result;
                    bool isflag = await _departmentService.Delete(deptModel);
                    if (isflag)
                    {
                        result.Success = true;
                        result.Msg = "删除成功";
                    }
                    else
                    {
                        result.Success = false;
                        result.Msg = "删除失败";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Msg = "Exception：" + ex.Message;
                result.ErrorCode = 99;
                _logger.LogError(ex, ex.Message);
            }
            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<JsonResult> GetDepartmentList(object jsonText)
        {
            ApiResult result = new ApiResult();
            try
            {
                if (string.IsNullOrEmpty(jsonText.ToString()))
                {
                    result.Success = true;
                    result.Msg = "参数不能为空";
                    result.ErrorCode = 10002;
                }
                else
                {
                    PageModel<Sys_DepartmentVM> pageModel = JsonConvert.DeserializeObject<PageModel<Sys_DepartmentVM>>(jsonText.ToString()!)!;
                    var expression = Extention.True<Sys_Department>();
                    if (!string.IsNullOrEmpty(pageModel.QueryCriteria.D_DeptName) && !string.IsNullOrWhiteSpace(pageModel.QueryCriteria.D_DeptName))
                    {
                        expression = expression.And(x => x.D_DeptName.Contains(pageModel.QueryCriteria.D_DeptName));
                    }
                    if (!string.IsNullOrEmpty(pageModel.QueryCriteria.D_CompanyId) && !string.IsNullOrWhiteSpace(pageModel.QueryCriteria.D_CompanyId))
                    {
                        expression = expression.And(x => x.D_CompanyId == pageModel.QueryCriteria.D_CompanyId);
                    }
                    if (!string.IsNullOrEmpty(pageModel.QueryCriteria.D_DeptNo) && !string.IsNullOrWhiteSpace(pageModel.QueryCriteria.D_DeptNo))
                    {
                        expression = expression.And(x => x.D_DeptNo.Contains(pageModel.QueryCriteria.D_DeptNo));
                    }
                    var data = await _departmentService.GetPageModel(expression, pageModel.PageIndex, pageModel.PageSize, " D_CreateDate desc");

                    result.Success = true;
                    result.Msg = "获取成功";
                    result.Data = data;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Msg = "Exception：" + ex.Message;
                result.ErrorCode = 99;
                _logger.LogError(ex, ex.Message);
            }
            return new JsonResult(result);
        }
    }
}
