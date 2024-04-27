namespace webapi.Services
{
    public interface IHomeBannerService
    {
        Task<byte[]> GetHomeBannerAsync(int tenantId);
        Task UploadHomeBannerAsync(int tenantId, byte[] bannerData);
    }
    public class HomeBannerService : IHomeBannerService
    {      
        public Task<byte[]> GetHomeBannerAsync(int tenantId)
        {
            throw new NotImplementedException();
        }
        public Task UploadHomeBannerAsync(int tenantId, byte[] bannerData)
        {
            throw new NotImplementedException();
        }
    }

}
