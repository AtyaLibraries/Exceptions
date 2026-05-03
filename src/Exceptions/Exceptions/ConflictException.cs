// <copyright file="ConflictException.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

namespace Atya.Errors.Exceptions;

/// <summary>
/// Represents a conflict with the current state of a resource or operation.
/// </summary>
public sealed class ConflictException : AtyaException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConflictException"/> class.
    /// </summary>
    public ConflictException(
        string message,
        string? errorCode = "resource.conflict",
        IReadOnlyDictionary<string, object?>? metadata = null)
        : base(message, errorCode, metadata)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ConflictException"/> class.
    /// </summary>
    public ConflictException(
        string message,
        Exception innerException,
        string? errorCode = "resource.conflict",
        IReadOnlyDictionary<string, object?>? metadata = null)
        : base(message, innerException, errorCode, metadata)
    {
    }
}
