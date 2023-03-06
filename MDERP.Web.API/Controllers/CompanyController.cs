using MDERP.Business.IService;
using MDERP.Common.Helper;
using Microsoft.AspNetCore.Mvc;

namespace MDERP.Web.API.Controllers
{
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("{companyid}")]
        public async Task<JsonResult> GetNoticeInfo(string companyid)
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
                    int cid = int.Parse(companyid);
                    var companyinfo = await _companyService.GetModelById(cid);
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
            }
            return new JsonResult(result);
        }
     }
}
