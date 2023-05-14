using Server.Context;
using Server.Interface;
using Server.Models;
using System.Numerics;

namespace Server.Repository
{
    public class VendorRepository : IVendorRepository
    {
        private readonly DbContexts _contexts;
        public VendorRepository(DbContexts contexts)
        {
            _contexts = contexts;
        }

        public bool CreateVendor(Vendor vendor)
        {
            _contexts.Add(vendor);
            return Save();
        }

        public bool DeleteVendor(Vendor vendor)
        {
            _contexts.Remove(vendor);
            return Save();
        }

        public Vendor GetVendor(int id)
        {
            return _contexts.Vendor.Where(v => v.Id == id).FirstOrDefault();
        }


        public ICollection<Vendor> GetVendors()
        {
            return _contexts.Vendor.OrderBy(l => l.Id).ToList();
        }

        public bool Save()
        {
            var saved = _contexts.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateVendor(Vendor vendor)
        {
            _contexts.Update(vendor);
            return Save();
        }


        public bool vendorExists(int id)
        {
            return _contexts.Vendor.Any(p => p.Id == id);
        }
    }
}
