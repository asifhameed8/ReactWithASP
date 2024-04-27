namespace webapi.Services
{
    public record Tenant( string Host, bool IsActive, string ThemeName);
   
    public class TenantService
    {
        private readonly List<Tenant> _tenants;
        public TenantService()
        {
            _tenants = new List<Tenant>
        {
            new Tenant("foo", true, "theme1"),
            new Tenant ("bar", true, "theme2"),
        };
        }
        public Tenant GetTenant(string host)
        {
            return _tenants.FirstOrDefault(t => t.Host.Equals(host, StringComparison.OrdinalIgnoreCase));
        }
    }
}
