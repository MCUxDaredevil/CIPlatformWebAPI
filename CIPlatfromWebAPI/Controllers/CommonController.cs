using Microsoft.AspNetCore.Mvc;
using Business_logic_Layer;
using Data_Access_Layer.Repository.Entities;
using System.Net.Http.Headers;


namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly BALCommon _balCommon;
        ResponseResult result = new ResponseResult();
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;


        public CommonController(BALCommon balCommon, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _balCommon = balCommon;
            _environment = environment;
        }

        [HttpGet]
        [Route("CountryList")]
        public ResponseResult GetCountryList()
        {
            try
            {
                var response = _balCommon.GetCountryList();
                result.Data = response.Data;
                result.Result = ResponseStatus.Success;
                result.Message = response.Message;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpGet]
        [Route("CityList/{id}")]
        public ResponseResult GetCityList(int id)
        {
            try
            {
                var response = _balCommon.GetCityList(id);
                result.Data = response.Data;
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Result = ResponseStatus.Error;
                result.Message = ex.Message;
            }
            return result;
        }

        [HttpPost]
        [Route("UploadImage")]
        public async Task<IActionResult> UploadImage([FromForm] List<IFormFile> upload)
        {
            try
            {
                string filePath = "";
                string fullPath = "";
                var files = Request.Form.Files;
                List<string> fileList = new List<string>();
                if (files != null && files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        filePath = Path.Combine("UploadMissionImage", "Mission");
                        string fileRootPath = Path.Combine(_environment.WebRootPath, filePath);

                        if (!Directory.Exists(fileRootPath))
                        {
                            Directory.CreateDirectory(fileRootPath);
                        }

                        string name = Path.GetFileNameWithoutExtension(fileName);
                        string extension = Path.GetExtension(fileName);
                        string fullFileName = name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                        fullPath = Path.Combine(fileRootPath, fullFileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        fileList.Add(fullPath);
                    }
                }
                return Ok(fileList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}