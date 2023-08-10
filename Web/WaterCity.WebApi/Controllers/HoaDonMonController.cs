using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterCity.Contract.Repository.Models;
using WaterCity.Contract.Service;
using WaterCity.Core.Constants;
using WaterCity.Core.Exceptions;
using WaterCity.Core.Models;
using WaterCity.Core.Models.HoaDonMon;
using WaterCity.Service;

namespace WaterCity.WebApi.Controllers
{
    [ApiController]
    public class HoaDonMonController : ControllerBase
    {
        private readonly IHoaDonMonService _iHoaDonMonService;

        public HoaDonMonController(IHoaDonMonService iHoaDonMonService)
        {
            _iHoaDonMonService = iHoaDonMonService;
        }

        /*[HttpGet]
        [Route(WebApiEndpoint.HoaDonMon.GetAllHoaDonMon)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _iHoaDonMonService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<HoaDonMonEntity>?>(
                statusCode: StatusCodes.Status200OK, 
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.HoaDonMon.GetHoaDonMon)]
        public async Task<IActionResult> GetHoaDonMonById(string keyId)
        {
            var data = await _iHoaDonMonService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                return BadRequest(data);
            }

            return Ok(new BaseResponseModel<HoaDonMonEntity?>
                    (statusCode: StatusCodes.Status200OK, 
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }*/

        [HttpGet]
        [Route(WebApiEndpoint.HoaDonMon.GetAllHoaDonMon)]
        public IActionResult GetAll()
        {
            var result = _iHoaDonMonService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<HoaDonMonEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.HoaDonMon.GetHoaDonMon)]
        public IActionResult GetHoaDonMonById(string keyId)
        {
            var data = _iHoaDonMonService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                return BadRequest(data);
            }

            return Ok(new BaseResponseModel<HoaDonMonEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.HoaDonMon.AddHoaDonMon)]
        public async Task<IActionResult> CreateHoaDonMon(HoaDonMonModel model)
        {
            try
            {
                var result = await _iHoaDonMonService.CreateAsync(model);
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
        [Route(WebApiEndpoint.HoaDonMon.UpdateHoaDonMon)]
        public async Task<IActionResult> UpdateHoaDonMon(string keyId, HoaDonMonModel model)
        {
            try
            {
                await _iHoaDonMonService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsHoaDonMon.UPDATE_HOADONMON_SUCCESS));
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
        [Route(WebApiEndpoint.HoaDonMon.DeleteHoaDonMon)]
        public async Task<IActionResult> DeleteHoaDonMon(string keyId)
        {
            try
            {
                await _iHoaDonMonService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsHoaDonMon.DELETE_HOADONMON_SUCCESS));
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
