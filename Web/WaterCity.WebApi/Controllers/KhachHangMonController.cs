using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.KhachHangMon;
using WaterCity.Service;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class KhachHangMonController : ControllerBase
    {
        private readonly IKhachHangMonService _iKhachHangMonService;

        public KhachHangMonController(IKhachHangMonService iKhachHangMonService)
        {
            _iKhachHangMonService = iKhachHangMonService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.KhachHangMon.GetAllKhachHangMon)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iKhachHangMonService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<KhachHangMonEntity>?>(
                statusCode: StatusCodes.Status200OK, 
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.KhachHangMon.GetKhachHangMon)]
        public async Task<IActionResult> GetKhachHangMonById(string keyId)
        {
            var data = await _iKhachHangMonService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                return BadRequest(data);
            }

            return Ok(new BaseResponseModel<KhachHangMonEntity?>
                    (statusCode: StatusCodes.Status200OK, 
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.KhachHangMon.GetAllKhachHangMon)]
        public IActionResult GetAll()
        {
            var result = _iKhachHangMonService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<KhachHangMonEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.KhachHangMon.GetKhachHangMon)]
        public IActionResult GetKhachHangMonById(string keyId)
        {
            var data = _iKhachHangMonService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                return BadRequest(data);
            }

            return Ok(new BaseResponseModel<KhachHangMonEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.KhachHangMon.AddKhachHangMon)]
        public async Task<IActionResult> CreateKhachHangMon(KhachHangMonModel model)
        {
            try
            {
                var result = await _iKhachHangMonService.CreateAsync(model);
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
        [Route(WebApiEndpoint.KhachHangMon.UpdateKhachHangMon)]
        public async Task<IActionResult> UpdateKhachHangMon(string keyId, KhachHangMonModel model)
        {
            try
            {
                await _iKhachHangMonService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsKhachHangMon.UPDATE_KHACHHANGMON_SUCCESS));
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
        [Route(WebApiEndpoint.KhachHangMon.DeleteKhachHangMon)]
        public async Task<IActionResult> DeleteKhachHangMon(string keyId)
        {
            try
            {
                await _iKhachHangMonService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsKhachHangMon.DELETE_KHACHHANGMON_SUCCESS));
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
