// <copyright file="AtyaException.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

using System.Collections.ObjectModel;
using Atya.Foundation.Guards;

namespace Atya.Errors.Exceptions;

/// <summary>
/// Base exception type for the Atya exception taxonomy.
/// </summary>
public abstract class AtyaException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AtyaException"/> class.
    /// </summary>
    /// <param name="message">The exception message.</param>
    /// <param name="errorCode">An optional machine-readable error code.</param>
    /// <param name="metadata">Optional metadata for diagnostics and interoperability.</param>
    protected AtyaException(
        string message,
        string? errorCode = null,
        IReadOnlyDictionary<string, object?>? metadata = null)
        : base(EnsureMessage(message))
    {
        ErrorCode = Normalize(errorCode);
        Metadata = CreateMetadata(metadata);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AtyaException"/> class.
    /// </summary>
    /// <param name="message">The exception message.</param>
    /// <param name="innerException">The inner exception.</param>
    /// <param name="errorCode">An optional machine-readable error code.</param>
    /// <param name="metadata">Optional metadata for diagnostics and interoperability.</param>
    protected AtyaException(
        string message,
        Exception innerException,
        string? errorCode = null,
        IReadOnlyDictionary<string, object?>? metadata = null)
        : base(EnsureMessage(message), innerException ?? throw new ArgumentNullException(nameof(innerException)))
    {
        ErrorCode = Normalize(errorCode);
        Metadata = CreateMetadata(metadata);
    }

    /// <summary>
    /// Gets the optional machine-readable error code.
    /// </summary>
    public string? ErrorCode { get; }

    /// <summary>
    /// Gets optional exception metadata.
    /// </summary>
    public IReadOnlyDictionary<string, object?> Metadata { get; }

    private static string EnsureMessage(string message)
    {
        return Guard.AgainstNullOrWhiteSpace(message);
    }

    private static string? Normalize(string? errorCode)
    {
        return string.IsNullOrWhiteSpace(errorCode) ? null : errorCode.Trim();
    }

    private static ReadOnlyDictionary<string, object?> CreateMetadata(IReadOnlyDictionary<string, object?>? metadata)
    {
        if (metadata is null || metadata.Count == 0)
        {
            return ReadOnlyDictionary<string, object?>.Empty;
        }

        var copy = new Dictionary<string, object?>(StringComparer.Ordinal);

        foreach (var pair in metadata)
        {
            Guard.AgainstNullOrWhiteSpace(pair.Key);
            copy[pair.Key] = pair.Value;
        }

        return new ReadOnlyDictionary<string, object?>(copy);
    }
}
