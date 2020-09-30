using eShopSolutions.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolutions.ViewModel.Catalog.Products
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        public int? CategoryId { get; set; }
    }
}
