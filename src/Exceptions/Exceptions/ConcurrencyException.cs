// <copyright file="ConcurrencyException.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

namespace Atya.Errors.Exceptions;

/// <summary>
/// Represents an optimistic concurrency or competing update failure.
/// </summary>
public sealed class ConcurrencyException : AtyaException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConcurrencyException"/> class.
    /// </summary>
    public ConcurrencyException(
        string message,
        string? errorCode = "resource.concurrency_conflict",
        IReadOnlyDictionary<string, object?>? metadata = null)
        : base(message, errorCode, metadata)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ConcurrencyException"/> class.
    /// </summary>
    public ConcurrencyException(
        string message,
        Exception innerException,
        string? errorCode = "resource.concurrency_conflict",
        IReadOnlyDictionary<string, object?>? metadata = null)
        : base(message, innerException, errorCode, metadata)
    {
    }
}
