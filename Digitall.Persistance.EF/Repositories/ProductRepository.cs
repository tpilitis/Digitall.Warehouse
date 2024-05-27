﻿using Digitall.Persistance.EF.Specifications;
using Digitall.Persistance.EF.Specifications.Products;
using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace Digitall.Persistance.EF.Repositories
{
    public class ProductRepository(WarehouseDbContext dbContext)
        : Repository<Product>(dbContext), IProductRepository
    {
        public void Remove(Product product)
        {
            DbContext.Set<Product>().Remove(product);
        }

        public async Task<ICollection<Product>> SearchProductsAsync(string title, int skip, int take, CancellationToken cancellationToken)
        {
            var getProductsByTitleSpecification = new SearchProductsSpecification(title, skip, take);
            return await ApplySpecification(getProductsByTitleSpecification)
                .ToListAsync(cancellationToken);
        }

        public async Task<Product?> GetByIdWithBrandAsync(Guid productId, CancellationToken cancellationToken)
        {
            var getByIdWithBrandSpecification = new GetProductByIdWithBrandSpecification(productId);
         
            return await ApplySpecification(getByIdWithBrandSpecification)
                .FirstOrDefaultAsync(cancellationToken);
        }

        private IQueryable<Product> ApplySpecification(Specification<Product> specification)
        {
            return SpecificationEvaluator.GetQuery(DbContext.Set<Product>(), specification);
        }
    }
}
