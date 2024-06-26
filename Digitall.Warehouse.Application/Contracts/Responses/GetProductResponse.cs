﻿using Digitall.Warehouse.Application.Contracts.Shared;

namespace Digitall.Warehouse.Application.Contracts.Responses;

public sealed record GetProductResponse(
    Guid Id,
    string Title,
    string Description,
    Money Price,
    string? Brand);
