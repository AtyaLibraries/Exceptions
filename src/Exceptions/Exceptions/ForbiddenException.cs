// <copyright file="ForbiddenException.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

namespace Atya.Errors.Exceptions;

/// <summary>
/// Represents a failure where the caller is authenticated but not allowed to perform the action.
/// </summary>
public sealed class ForbiddenException : AtyaException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ForbiddenException"/> class.
    /// </summary>
    public ForbiddenException(
        string message,
        string? errorCode = "auth.forbidden",
        IReadOnlyDictionary<string, object?>? metadata = null)
        : base(message, errorCode, metadata)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ForbiddenException"/> class.
    /// </summary>
    public ForbiddenException(
        string message,
        Exception innerException,
        string? errorCode = "auth.forbidden",
        IReadOnlyDictionary<string, object?>? metadata = null)
        : base(message, innerException, errorCode, metadata)
    {
    }
}
