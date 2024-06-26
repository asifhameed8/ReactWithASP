﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Tenant
{
    public record Tenant(int Id, string Host, bool IsActive, string ThemeName);

    public class TenantService
    {
        private readonly List<Tenant> _tenants;
        public TenantService()
        {
            _tenants = new List<Tenant>
        {
            new Tenant(1, "foo", true, "theme1"),
            new Tenant(2, "bar", true, "theme2"),
            new Tenant(3, "baz", false, "theme3"),
        };
        }

        public Tenant GetTenant(string host)
        {
            return _tenants.FirstOrDefault(t => t.Host.Equals(host, StringComparison.OrdinalIgnoreCase));
        }
    }

}


