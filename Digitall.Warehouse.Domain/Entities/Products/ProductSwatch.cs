﻿using Digitall.Warehouse.Domain.Abstraction;

namespace Digitall.Warehouse.Domain.Entities.Products;

public class ProductSwatch : Entity
{
    private HashSet<ProductVariant> _productVariants = [];

    private ProductSwatch(string name): base()
    {
        Name = name;
    }

    public string Name { get; private set; } = null!;

    public IReadOnlyList<ProductVariant> Variants => _productVariants.ToList();

    public static ProductSwatch Create(string name)
    {
        return new ProductSwatch(name);
    }
}
