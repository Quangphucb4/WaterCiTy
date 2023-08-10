using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.CTHDMon;
using WaterCity.Service;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class CTHDMonController : ControllerBase
    {
        private readonly ICTHDMonService _iCTHDMonService;

        public CTHDMonController(ICTHDMonService iCTHDMonService)
        {
            _iCTHDMonService = iCTHDMonService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.CTHDMon.GetAllCTHDMon)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iCTHDMonService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<CTHDMonEntity>?>(
                statusCode: StatusCodes.Status200OK, 
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.CTHDMon.GetCTHDMon)]
        public async Task<IActionResult> GetCTHDMonById(string keyId)
        {
            var data = await _iCTHDMonService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                return BadRequest(data);
            }

            return Ok(new BaseResponseModel<CTHDMonEntity?>
                    (statusCode: StatusCodes.Status200OK, 
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.CTHDMon.GetAllCTHDMon)]
        public IActionResult GetAll()
        {
            var result = _iCTHDMonService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<CTHDMonEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.CTHDMon.GetCTHDMon)]
        public IActionResult GetCTHDMonById(string keyId)
        {
            var data = _iCTHDMonService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                return BadRequest(data);
            }

            return Ok(new BaseResponseModel<CTHDMonEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.CTHDMon.AddCTHDMon)]
        public async Task<IActionResult> CreateCTHDMon(CTHDMonModel model)
        {
            try
            {
                var result = await _iCTHDMonService.CreateAsync(model);
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
        [Route(WebApiEndpoint.CTHDMon.UpdateCTHDMon)]
        public async Task<IActionResult> UpdateCTHDMon(string keyId, CTHDMonModel model)
        {
            try
            {
                await _iCTHDMonService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsCTHDMon.UPDATE_CTHDMON_SUCCESS));
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
        [Route(WebApiEndpoint.CTHDMon.DeleteCTHDMon)]
        public async Task<IActionResult> DeleteCTHDMon(string keyId)
        {
            try
            {
                await _iCTHDMonService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsCTHDMon.DELETE_CTHDMON_SUCCESS));
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
