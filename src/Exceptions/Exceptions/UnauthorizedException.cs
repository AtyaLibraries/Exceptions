// <copyright file="UnauthorizedException.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

namespace Atya.Errors.Exceptions;

/// <summary>
/// Represents an authentication failure or missing authentication.
/// </summary>
public sealed class UnauthorizedException : AtyaException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UnauthorizedException"/> class.
    /// </summary>
    public UnauthorizedException(
        string message,
        string? errorCode = "auth.unauthorized",
        IReadOnlyDictionary<string, object?>? metadata = null)
        : base(message, errorCode, metadata)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UnauthorizedException"/> class.
    /// </summary>
    public UnauthorizedException(
        string message,
        Exception innerException,
        string? errorCode = "auth.unauthorized",
        IReadOnlyDictionary<string, object?>? metadata = null)
        : base(message, innerException, errorCode, metadata)
    {
    }
}
