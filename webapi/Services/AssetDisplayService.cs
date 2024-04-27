namespace webapi.Services
{
    public interface IAssetDisplayService
    {
        Task<byte[]> GetCustomAssetAsync(int tenantId, string assetType); // For example, "favicon" or "homeBanner"
    }
    public class AssetDisplayService : IAssetDisplayService
    {
        private readonly IFaviconService _faviconService;
        private readonly IHomeBannerService _homeBannerService;

        public AssetDisplayService(IFaviconService faviconService, IHomeBannerService homeBannerService)
        {
            _faviconService = faviconService;
            _homeBannerService = homeBannerService;
        }

        public async Task<byte[]> GetCustomAssetAsync(int tenantId, string assetType)
        {
            // Logic to determine which asset to retrieve based on assetType
            return assetType switch
            {
                "favicon" => await _faviconService.GetFaviconAsync(tenantId),
                "homeBanner" => await _homeBannerService.GetHomeBannerAsync(tenantId),
                _ => null,
            };
        }
    }

}
