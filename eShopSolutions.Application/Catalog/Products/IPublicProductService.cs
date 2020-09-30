
using eShopSolutions.ViewModel.Catalog.Products;
using eShopSolutions.ViewModel.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolutions.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request);
        Task<List<ProductViewModel>> GetAll();
    }
}
