namespace webapi.Services
{
    public interface IFaviconService
    {
        Task<byte[]> GetFaviconAsync(int tenantId);
        Task UploadFaviconAsync(int tenantId, byte[] faviconData);
    }
    public class FaviconService : IFaviconService
    {
      
        public Task<byte[]> GetFaviconAsync(int tenantId)
        {
            throw new NotImplementedException();
        }

        public Task UploadFaviconAsync(int tenantId, byte[] faviconData)
        {
            throw new NotImplementedException();
        }
    }

}
