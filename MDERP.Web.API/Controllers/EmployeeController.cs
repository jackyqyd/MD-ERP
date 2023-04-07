using Castle.Core.Internal;
using Castle.DynamicProxy.Generators.Emitters;
using MDERP.Business.IService;
using MDERP.Business.Models;
using MDERP.Business.Models.Entities;
using MDERP.Business.Models.ViewModels;
using MDERP.Business.Models.ViewModels.QueryVM;
using MDERP.Business.Service;
using MDERP.Common.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Npgsql.Replication.PgOutput.Messages;
using SqlSugar;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace MDERP.Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeInfoService employeeInfoService;
        //TODO 定义区域服务接口

        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeInfoService employeeInfoService, ILogger<EmployeeController> logger)
        {
            this.employeeInfoService = employeeInfoService;
            _logger = logger;
        }

        [HttpGet("{empID}")]
        public async Task<JsonResult> GetEmployeeInfoByID(string empID)
        {
            ApiResult result = new ApiResult();
            try
            {
                if (string.IsNullOrEmpty(empID) || string.IsNullOrWhiteSpace(empID))
                {
                    result.Success = false;
                    result.Msg = "参数不能为空";
                    result.ErrorCode = 10002;
                }
                else
                {
                    var employeeInfo=await employeeInfoService.GetModelById(empID);
                    result.Success = true;
                    result.Data = employeeInfo;
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
        public async Task<JsonResult> SaveEmployee(object jsonText)
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
                    Sys_EmployeeInfoVM tempEmployeeVM = JsonConvert.DeserializeObject<Sys_EmployeeInfoVM>(jsonText.ToString()!)!;
                    Sys_EmployeeInfo tempEmployeeEnt = EntityHelper.MapTo<Sys_EmployeeInfo, Sys_EmployeeInfoVM>(tempEmployeeVM);
                    string empID = tempEmployeeEnt.E_Id;
                    DateTime dt = DateTime.Now;
                    var expression = Extention.True<Sys_EmployeeInfo>();
                    expression = expression.And(x => x.E_IDCard.ToLower().Equals(tempEmployeeVM.E_IDCard.ToLower()));
                    var tempEnt = await employeeInfoService.GetModelByExpression(expression);
                    if (tempEnt != null)
                    {
                        result.Success = false;
                        result.Msg = "身份证号重复，请重新输入";
                    }
                    else
                    {
                        empID = GuidHelper.GetGuidN();
                        tempEmployeeEnt.E_Id = empID;
                        tempEmployeeEnt.E_CreateDate = dt;
                        tempEmployeeEnt.E_IsDel = 0;
                        tempEmployeeEnt.E_IsLock = 0;
                        var processResult = await employeeInfoService.Add(tempEmployeeEnt) > 0;
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
                result.Msg = ex.Message;
                result.ErrorCode = 99;
                _logger.LogError(ex, ex.Message);
            }
            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteEmployee(string employeeID)
        {
            ApiResult result = new ApiResult();
            try
            {
                if (string.IsNullOrEmpty(employeeID) || string.IsNullOrWhiteSpace(employeeID))
                {
                    result.Success = false;
                    result.Msg = "参数不能为空";
                    result.ErrorCode = 10002;
                }
                else
                {
                    Sys_EmployeeInfo empEnt = await employeeInfoService.GetModelById(employeeID);
                    var processResult = await employeeInfoService.Delete(empEnt);
                    if (processResult)
                    {
                        result.Success = true;
                        result.Msg = "删除员工信息成功";
                    }
                    else
                    {
                        result.Success = false;
                        result.Msg = "删除员工信息失败";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Msg = ex.Message;
                result.ErrorCode = 99;
                _logger.LogError (ex, ex.Message);
            }
            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<JsonResult> GetEmployeeList(object jsonText)
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
                    PageModel<Sys_EmpqueryVM> pageModel = JsonConvert.DeserializeObject<PageModel<Sys_EmpqueryVM>>(jsonText.ToString()!)!;
                    //表连接表达式
                    Expression<Func<Sys_EmployeeInfo, Sys_EmployeeDepartmentRel, Sys_Department, JoinQueryInfos>> joinExpression = (emp, rel, dep) => new JoinQueryInfos(JoinType.Inner, emp.E_Id == rel.E_Id, JoinType.Inner, rel.D_DeptId == dep.D_DeptId);
                    //查询条件表达式
                    var whereExpression = Extention.True<Sys_EmployeeInfo, Sys_EmployeeDepartmentRel, Sys_Department>();
                    if (!string.IsNullOrEmpty(pageModel.QueryCriteria.E_Name) && !string.IsNullOrWhiteSpace(pageModel.QueryCriteria.E_Name))
                    {
                        whereExpression = whereExpression.And((emp, rel, dep) => emp.E_Name.ToLower().Contains(pageModel.QueryCriteria.E_Name));
                    }
                    if (!string.IsNullOrEmpty(pageModel.QueryCriteria.E_IDCard) && !string.IsNullOrWhiteSpace(pageModel.QueryCriteria.E_IDCard))
                    {
                        whereExpression = whereExpression.And((emp, rel, dep) => emp.E_IDCard.ToLower().Contains(pageModel.QueryCriteria.E_IDCard));
                    }
                    if (!string.IsNullOrEmpty(pageModel.QueryCriteria.D_Department) && !string.IsNullOrWhiteSpace(pageModel.QueryCriteria.D_Department))
                    {
                        whereExpression = whereExpression.And((emp, rel, dep) => dep.D_CompanyId.Equals(pageModel.QueryCriteria.D_Department));
                    }
                    //返回数据表达式
                    Expression<Func<Sys_EmployeeInfo, Sys_EmployeeDepartmentRel, Sys_Department, Sys_EmployeeInfoVM>> selectExpression =
                            (emp, rel, dep) => new Sys_EmployeeInfoVM
                            {
                                E_Id = emp.E_Id,
                                E_Name = emp.E_Name,
                                E_Gender = emp.E_Gender == 1 ? "男" : "女",
                                E_Continent = "",//TODO 区域服务接口方法
                                E_Country = "",//TODO 区域服务接口方法
                                E_StateProvince = "",//TODO 区域服务接口方法
                                E_City = "",//TODO 区域服务接口方法
                                E_DetailAddress = emp.E_DetailAddress,
                                D_Department = dep.D_DeptName
                            };
                    var empData = await employeeInfoService.GetPageModelMuch(
                        joinExpression,
                        selectExpression,
                        whereExpression,
                        pageModel.PageIndex,pageModel.PageSize);
                    result.Success = true;
                    result.Msg = "获取成功";
                    result.Data = empData;
                }
            }
            catch (Exception ex) 
            {
                result.Success = false;
                result.Msg = ex.Message;
                _logger.LogError(ex, ex.Message);
            }
            return new JsonResult(result);
        }
    }
}
