﻿using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace Digitall.Persistance.EF.Repositories
{
    public class CategoryRepository(WarehouseDbContext dbContext)
                : Repository<Category>(dbContext), ICategoryRepository
    {
        public async Task<ICollection<Category>> GetAllByIdsAsync(List<Guid> categoryIds, CancellationToken cancellationToken)
        {
            var categories = await DbContext
                .Set<Category>()
                .Where(category => categoryIds.Contains(category.Id))
                .ToListAsync();

            return categories;
        }

        public async Task<Category?> GetByNameAsync(string name)
        {
            var category = await DbContext
                .Set<Category>()
                .SingleOrDefaultAsync(category => category.Name == name);

            return category;
        }

        public async Task<IReadOnlyCollection<Product>> GetCategoryProductsAsync(string categoryName)
        {
            var category = await DbContext
                .Set<Category>()
                .Include(category => category.Products)
                .SingleOrDefaultAsync(category => category.Name == categoryName);

            if (category == null)
            {
                return [];
            }

            return category.Products;
        }
    }
}
