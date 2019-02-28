using AutoMapper;
using DataAccessStoreItem = KatlaSport.DataAccess.ProductStore.StoreItem;

namespace KatlaSport.Services.HiveSectionManagement
{
    public sealed class HiveSectionManagementMappingProfile : Profile
    {
        public HiveSectionManagementMappingProfile()
        {
            CreateMap<DataAccessStoreItem, HiveSectionStoreItem>();
        }
    }
}
