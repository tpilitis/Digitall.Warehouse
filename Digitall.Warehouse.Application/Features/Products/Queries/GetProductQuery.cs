﻿using Digitall.Warehouse.Application.Abstractions.Messaging;
using Digitall.Warehouse.Application.Contracts.Responses;

namespace Digitall.Warehouse.Application.Features.Products.Queries;

public sealed record GetProductQuery(Guid ProductId) : IQuery<GetProductResponse>;
