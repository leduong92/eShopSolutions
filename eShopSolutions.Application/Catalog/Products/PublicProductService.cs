﻿
using eShopSolutions.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using eShopSolutions.ViewModel.Catalog.Products;
using eShopSolutions.ViewModel.Common;

namespace eShopSolutions.Application.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly EShopDbContext _context;
        public PublicProductService(EShopDbContext context)
        {
            _context = context;
        }

        //public async Task<List<ProductViewModel>> GetAll(string languageId)
        //{
        //    var query = from p in _context.Products
        //                join pt in _context.ProductTranslations on p.Id equals pt.ProductId
        //                join pc in _context.ProductCategories on p.Id equals pc.ProductId
        //                join c in _context.Categories on pc.CategoryId equals c.Id
        //                where pt.LanguageId == languageId
        //                select new { p, pt, pc };

        //    var data = await query
        //        .Select(x => new ProductViewModel()
        //        {
        //            Id = x.p.Id,
        //            Name = x.pt.Name,
        //            DateCreated = x.p.DateCreated,
        //            Description = x.pt.Description,
        //            Details = x.pt.Details,
        //            LanguageId = x.pt.LanguageId,
        //            OriginalPrice = x.p.OriginalPrice,
        //            Price = x.p.Price,
        //            SeoAlias = x.pt.SeoAlias,
        //            SeoDescription = x.pt.Description,
        //            SeoTitle = x.pt.SeoTitle,
        //            ViewCount = x.p.ViewCount
        //        }).ToListAsync();
        //    return data;
        //}

        public async Task<PagedResult<ProductViewModel>> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pc in _context.ProductCategories on p.Id equals pc.ProductId
                        join c in _context.Categories on pc.CategoryId equals c.Id
                        where pt.LanguageId == languageId
                        select new { p, pt, pc };
            //2. Filter
            if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
            {
                query = query.Where(p => p.pc.CategoryId == request.CategoryId);
            }
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.Description,
                    SeoTitle = x.pt.SeoTitle,
                    ViewCount = x.p.ViewCount
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }
    }
}