﻿using Digitall.Warehouse.Domain.Abstraction;

namespace Digitall.Warehouse.Domain.Entities.Products;

public class Product : IIdentifiable<Guid>
{
    public Guid Id { get; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public Brand? Brand { get; set; }

    public Guid BrandId { get; protected set; }

    public Price Price { get; set; } = null!;

    public ICollection<Category> Categories { get; set; } = [];

    public ICollection<ProductVariant> Variants { get; set; } = [];
}
