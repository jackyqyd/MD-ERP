using MDERP.Business.IService;
using MDERP.Common.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MDERP.Business.Models.Entities;
using MDERP.Business.Models.ViewModels;
using MDERP.Business.Models;

namespace MDERP.Web.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ICompanyService companyService, ILogger<CompanyController> logger)
        {
            _companyService = companyService;
            _logger = logger;
        }

        [HttpGet("{companyid}")]
        public async Task<JsonResult> GetCompanyInfo(string companyid)
        {
            ApiResult result = new ApiResult();

            try
            {
                if (string.IsNullOrEmpty(companyid) || string.IsNullOrWhiteSpace(companyid))
                {
                    result.Success = false;
                    result.Msg = "参数不能为空";
                    result.ErrorCode = 10002;
                }
                else
                {
                    var companyinfo = await _companyService.GetModelById(companyid);
                    result.Data = companyinfo;
                    result.Success = true;
                    result.Msg = "获取成功";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Msg = "Exception:" + ex.Message;
                result.ErrorCode = 99;
                _logger.LogError(ex, ex.Message);
            }
            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<JsonResult> SaveCompany(object jsonText)
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
                    Sys_CompanyVM tempCompanyVM = JsonConvert.DeserializeObject<Sys_CompanyVM>(jsonText.ToString()!)!;
                    Sys_Company tempCompanyEnt = EntityHelper.MapTo<Sys_Company, Sys_CompanyVM>(tempCompanyVM);
                    string companyId = tempCompanyEnt.C_Id;
                    bool isNew = false;
                    DateTime dt = DateTime.Now;
                    var expression = Extention.True<Sys_Company>();
                    expression = expression.And(x => x.C_Name.Equals(tempCompanyVM.C_Name));
                    var tempEnt = await _companyService.GetModelByExpression(expression);
                    if (tempEnt != null)
                    {
                        result.Success = false;
                        result.Msg = "公司/集团 名称已存在，请重新输入";
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(companyId) && string.IsNullOrWhiteSpace(companyId))
                        {
                            isNew = true;
                            companyId = GuidHelper.GetGuidN();
                            tempCompanyEnt.C_Id = companyId;
                            tempCompanyEnt.C_CreateTime = dt;
                            tempCompanyEnt.C_IsDel = 0;
                        }
                        else
                        {
                            var oldEnt = await _companyService.GetModelById(companyId);
                            tempCompanyEnt.C_CreateTime = oldEnt.C_CreateTime;
                        }
                        var processResult = false;
                        if (isNew)
                        {
                            processResult = await _companyService.Add(tempCompanyEnt) > 0;
                        }
                        else
                        {
                            processResult = await _companyService.Update(tempCompanyEnt);
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

        [HttpPost("{companyid}")]
        public async Task<JsonResult> DeleteCompany(string companyid)
        {
            ApiResult result = new ApiResult();
            try
            {
                if (string.IsNullOrEmpty(companyid) && string.IsNullOrWhiteSpace(companyid))
                {
                    result.Success = false;
                    result.Msg = "参数不能为空";
                    result.ErrorCode = 10002;
                }
                else
                {
                    var companyInfo = await _companyService.GetModelById(companyid);
                    if (companyInfo != null)
                    {
                        if (companyInfo.C_ParentId != "0")
                        {
                            result.Success = false;
                            result.Msg = "该公司/集团下存在子公司，无法删除！";
                            return new JsonResult(result);
                        }
                        bool deleteResult = await _companyService.Delete(companyInfo);
                        if (deleteResult)
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
                    else
                    {
                        result.Success = false;
                        result.Msg = "要删除的公司/集团不存在！";
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
        public async Task<JsonResult> GetCompanyList(object jsonText)
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
                    PageModel<Sys_CompanyVM> pageModel = JsonConvert.DeserializeObject<PageModel<Sys_CompanyVM>>(jsonText.ToString()!)!;
                    var expression = Extention.True<Sys_Company>();
                    List<Sys_CompanyVM> list = new List<Sys_CompanyVM>();
                    if (!string.IsNullOrEmpty(pageModel.QueryCriteria.C_Name) && !string.IsNullOrWhiteSpace(pageModel.QueryCriteria.C_Name))
                    {
                        expression = expression.And(x => x.C_Name.Contains(pageModel.QueryCriteria.C_Name));
                    }
                    var data=await _companyService.GetPageModel(expression,pageModel.PageIndex,pageModel.PageSize, " C_CreateTime desc");

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
