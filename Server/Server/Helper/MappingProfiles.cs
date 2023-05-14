using AutoMapper;
using Server.Models;
using Server.ViewModels;

namespace Server.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
            CreateMap<Vendor, VendorViewModel>();
            CreateMap<VendorViewModel, Vendor>();
        }
    }
}
