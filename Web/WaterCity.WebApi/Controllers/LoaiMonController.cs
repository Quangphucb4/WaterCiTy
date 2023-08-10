using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.LoaiMon;
using WaterCity.Service;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class LoaiMonController : ControllerBase
    {
        private readonly ILoaiMonService _iLoaiMonService;

        public LoaiMonController(ILoaiMonService iLoaiMonService)
        {
            _iLoaiMonService = iLoaiMonService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.LoaiMon.GetAllLoaiMon)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iLoaiMonService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<LoaiMonEntity>?>(
                statusCode: StatusCodes.Status200OK, 
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.LoaiMon.GetLoaiMon)]
        public async Task<IActionResult> GetLoaiMonById(string keyId)
        {
            var data = await _iLoaiMonService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                return BadRequest(data);
            }

            return Ok(new BaseResponseModel<LoaiMonEntity?>
                    (statusCode: StatusCodes.Status200OK, 
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.LoaiMon.GetAllLoaiMon)]
        public IActionResult GetAll()
        {
            var result = _iLoaiMonService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<LoaiMonEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.LoaiMon.GetLoaiMon)]
        public IActionResult GetLoaiMonById(string keyId)
        {
            var data = _iLoaiMonService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                return BadRequest(data);
            }

            return Ok(new BaseResponseModel<LoaiMonEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.LoaiMon.AddLoaiMon)]
        public async Task<IActionResult> CreateLoaiMon(LoaiMonModel model)
        {
            try
            {
                var result = await _iLoaiMonService.CreateAsync(model);
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
        [Route(WebApiEndpoint.LoaiMon.UpdateLoaiMon)]
        public async Task<IActionResult> UpdateLoaiMon(string keyId, LoaiMonModel model)
        {
            try
            {
                await _iLoaiMonService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsLoaiMon.UPDATE_LOAIMON_SUCCESS));
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
        [Route(WebApiEndpoint.LoaiMon.DeleteLoaiMon)]
        public async Task<IActionResult> DeleteLoaiMon(string keyId)
        {
            try
            {
                await _iLoaiMonService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsLoaiMon.DELETE_LOAIMON_SUCCESS));
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
