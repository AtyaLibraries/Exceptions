// <copyright file="ValidationExceptionItem.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

namespace Atya.Errors.Exceptions.Models;

/// <summary>
/// Represents a single validation failure item used by <see cref="ValidationException"/>.
/// </summary>
/// <param name="PropertyName">The related property or logical field name.</param>
/// <param name="Message">The validation failure message.</param>
/// <param name="ErrorCode">The optional machine-readable validation error code.</param>
/// <param name="AttemptedValue">The optional attempted value that failed validation.</param>
#pragma warning disable SA1313 // Positional record parameters define PascalCase public API properties.
public sealed record ValidationExceptionItem(
    string PropertyName,
    string Message,
    string? ErrorCode = null,
    object? AttemptedValue = null);
#pragma warning restore SA1313
