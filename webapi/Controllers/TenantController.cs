using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Services;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TenantController : ControllerBase
    {
        private readonly TenantService _tenantService;
        private readonly IFaviconService _faviconService;
        private readonly IHomeBannerService _homeBannerService;
        private readonly IAssetDisplayService _assetDisplayService;
        public TenantController(TenantService tenantService, IFaviconService faviconService, IHomeBannerService homeBannerService, IAssetDisplayService assetDisplayService)
        {
            _tenantService = tenantService;
            _faviconService = faviconService;
            _homeBannerService = homeBannerService;
            _assetDisplayService = assetDisplayService;
        }
        [HttpGet("{host}")]
        public IActionResult GetTenant(string host)
        {
            var tenant = _tenantService.GetTenant(host);

            if (tenant == null)
            {
                return NotFound("Tenant not found");
            }

            return Ok(tenant);
        }


        [HttpPost("upload-favicon/{tenantId}")]
        public async Task<IActionResult> UploadFavicon(string tenantName, [FromBody] byte[] faviconData)
        {
            try
            {
                await _faviconService.UploadFaviconAsync(tenantName, faviconData);
                return Ok("Favicon uploaded successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("upload-home-banner/{tenantId}")]
        public async Task<IActionResult> UploadHomeBanner(string tenantId, [FromBody] byte[] bannerData)
        {
            try
            {
                await _homeBannerService.UploadHomeBannerAsync(tenantId, bannerData);
                return Ok("Home banner uploaded successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("favicon/{tenantId}")]
        public async Task<IActionResult> GetFavicon(string tenantName)
        {
            try
            {
                var favicon = await _assetDisplayService.GetCustomAssetAsync(tenantName, "favicon");
                if (favicon != null)
                    return File(favicon, "image/png"); // Assuming favicon is PNG format
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("home-banner/{tenantId}")]
        public async Task<IActionResult> GetHomeBanner(string tenantName)
        {
            try
            {
                var homeBanner = await _assetDisplayService.GetCustomAssetAsync(tenantName, "homeBanner");
                if (homeBanner != null)
                    return File(homeBanner, "image/jpeg"); // Assuming home banner is JPEG format
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
