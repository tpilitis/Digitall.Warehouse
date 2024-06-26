﻿using Digitall.Warehouse.Application.Abstractions.Messaging;
using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Application.Contracts.Responses;
using Digitall.Warehouse.Domain.Shared;

namespace Digitall.Warehouse.Application.Features.Categories.Queries.GetCategoryByName
{
    public class GetCategoryByNameQueryHandler(ICategoryRepository categoryRepository)
        : IQueryHandler<GetCategoryByNameQuery, GetCategoryByNameResponse>
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        public async Task<Result<GetCategoryByNameResponse>> Handle(
            GetCategoryByNameQuery request,
            CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByNameAsync(request.Name);
            if (category == null)
            {
                return Result.Failure<GetCategoryByNameResponse>(Error.NotFoundValue("Category", request.Name));
            }

            var getCategoryByNameResponse = new GetCategoryByNameResponse(category.Id, category.Name);

            return Result.Success(getCategoryByNameResponse);
        }
    }
}
