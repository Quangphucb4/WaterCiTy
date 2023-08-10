
using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.HocSinh;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class HocSinhController : ControllerBase
    {
        private readonly IHocSinhService _iHocSinhService;

        public HocSinhController(IHocSinhService iHocSinhService)
        {
            _iHocSinhService = iHocSinhService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.HocSinh.GetAllHocSinh)]
        public IActionResult GetAll()
        {
            var result = _iHocSinhService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<HocSinhEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.HocSinh.GetHocSinh)]
        public IActionResult GetHocSinhById(string keyId)
        {
            var data = _iHocSinhService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsHocSinh.HOCSINH_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<HocSinhEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.HocSinh.AddHocSinh)]
        public async Task<IActionResult> CreateHocSinh(HocSinhModel model)
        {
            try
            {
                var result = await _iHocSinhService.CreateAsync(model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status201Created,
                    code: ResponseCodeConstants.SUCCESS,
                    data: result));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(
                        statusCode: error.StatusCode,
                        code: error.Code,
                        message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status500InternalServerError,
                    code: ResponseCodeConstants.FAILED,
                    message: e.Message);
                return BadRequest(result);
            }
        }

        [HttpPut]
        [Route(WebApiEndpoint.HocSinh.UpdateHocSinh)]
        public async Task<IActionResult> UpdateHocSinh(string keyId, HocSinhModel model)
        {
            try
            {
                await _iHocSinhService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsHocSinh.UPDATE_HOCSINH_SUCCESS));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(
                        statusCode: error.StatusCode,
                        code: error.Code,
                        message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status500InternalServerError,
                    code: ResponseCodeConstants.FAILED,
                    message: e.Message);
                return BadRequest(result);
            }

        }

        [HttpDelete]
        [Route(WebApiEndpoint.HocSinh.DeleteHocSinh)]
        public async Task<IActionResult> DeleteHocSinh(string keyId)
        {
            try
            {
                await _iHocSinhService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsHocSinh.DELETE_HOCSINH_SUCCESS));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(
                        statusCode: error.StatusCode,
                        code: error.Code,
                        message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status500InternalServerError,
                    code: ResponseCodeConstants.FAILED,
                    message: e.Message);
                return BadRequest(result);
            }
        }
    }
}
