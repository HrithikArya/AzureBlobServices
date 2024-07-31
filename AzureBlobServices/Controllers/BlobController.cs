using AzureBlobServices.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AzureBlobServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlobController : ControllerBase
    {
        private readonly BlobStorageService _blobStorageService;

        public BlobController(BlobStorageService blobStorageService)
        {
            _blobStorageService = blobStorageService;
        }

        [HttpGet("download")]
        public async Task<IActionResult> Download([FromHeader] string connectionString, [FromHeader] string containerName, [FromQuery] string blobName)
        {
            try
            {
                var content = await _blobStorageService.DownloadBlobAsync(connectionString, containerName, blobName);
                return Ok(content);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromHeader] string connectionString, [FromHeader] string containerName, [FromQuery] string blobName, [FromBody] JsonElement jsonContent)
        {
            try
            {
                await _blobStorageService.UploadBlobAsync(connectionString, containerName, blobName, jsonContent.GetRawText());
                return Ok("Upload successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("modify")]
        public async Task<IActionResult> Modify([FromHeader] string connectionString, [FromHeader] string containerName, [FromQuery] string blobName, [FromBody] JsonElement jsonContent)
        {
            try
            {
                await _blobStorageService.ModifyBlobAsync(connectionString, containerName, blobName, jsonContent.GetRawText());
                return Ok("Modification successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("exists")]
        public async Task<IActionResult> Exists([FromHeader] string connectionString, [FromHeader] string containerName, [FromQuery] string blobName)
        {
            try
            {
                var exists = await _blobStorageService.BlobExistsAsync(connectionString, containerName, blobName);
                return Ok(exists);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromHeader] string connectionString, [FromHeader] string containerName, [FromQuery] string blobName)
        {
            try
            {
                if (string.IsNullOrEmpty(blobName))
                {
                    return BadRequest("Blob name is required");
                }

                await _blobStorageService.DeleteBlobAsync(connectionString, containerName, blobName);
                return Ok("Blob deleted successfully");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}