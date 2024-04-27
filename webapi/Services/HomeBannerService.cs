namespace webapi.Services
{
    public interface IHomeBannerService
    {
        Task<byte[]> GetHomeBannerAsync(string tenantName);
        Task UploadHomeBannerAsync(string tenantName, byte[] bannerData);
    }
    public class HomeBannerService : IHomeBannerService
    {      
        public Task<byte[]> GetHomeBannerAsync(string tenantName)
        {
            throw new NotImplementedException();
        }
        public Task UploadHomeBannerAsync(string tenantName, byte[] bannerData)
        {
            throw new NotImplementedException();
        }
    }

}
