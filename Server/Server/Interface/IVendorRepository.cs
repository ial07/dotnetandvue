using Server.Models;

namespace Server.Interface
{
    public interface IVendorRepository
    {
        ICollection<Vendor> GetVendors();
        Vendor GetVendor(int id);
        bool vendorExists(int id);
        bool CreateVendor(Vendor user);
        bool UpdateVendor(Vendor user);
        bool DeleteVendor(Vendor user);
        bool Save();
    }
}
