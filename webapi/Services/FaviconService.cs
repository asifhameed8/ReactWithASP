namespace webapi.Services
{
    public interface IFaviconService
    {
        Task<byte[]> GetFaviconAsync(string tenantName);
        Task UploadFaviconAsync(string tenantName, byte[] faviconData);
    }
    public class FaviconService : IFaviconService
    {
      
        public Task<byte[]> GetFaviconAsync(string tenantName)
        {
            throw new NotImplementedException();
        }

        public Task UploadFaviconAsync(string tenantName, byte[] faviconData)
        {

            throw new NotImplementedException();
        }
    }

}
