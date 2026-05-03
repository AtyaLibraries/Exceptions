// <copyright file="ValidationException.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

using System.Collections.ObjectModel;
using Atya.Errors.Exceptions.Models;
using Atya.Foundation.Guards;

namespace Atya.Errors.Exceptions;

/// <summary>
/// Represents a validation failure containing one or more validation errors.
/// Use this exception for exceptional validation scenarios, not for routine control flow.
/// </summary>
public sealed class ValidationException : AtyaException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationException"/> class.
    /// </summary>
    /// <param name="message">The exception message.</param>
    /// <param name="errors">The validation errors.</param>
    /// <param name="errorCode">The optional machine-readable error code.</param>
    /// <param name="metadata">Optional metadata.</param>
    public ValidationException(
        string message,
        IEnumerable<ValidationExceptionItem> errors,
        string? errorCode = "validation.failed",
        IReadOnlyDictionary<string, object?>? metadata = null)
        : base(message, errorCode, metadata)
    {
        Errors = CreateErrors(errors);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationException"/> class.
    /// </summary>
    /// <param name="message">The exception message.</param>
    /// <param name="errors">The validation errors.</param>
    /// <param name="innerException">The inner exception.</param>
    /// <param name="errorCode">The optional machine-readable error code.</param>
    /// <param name="metadata">Optional metadata.</param>
    public ValidationException(
        string message,
        IEnumerable<ValidationExceptionItem> errors,
        Exception innerException,
        string? errorCode = "validation.failed",
        IReadOnlyDictionary<string, object?>? metadata = null)
        : base(message, innerException, errorCode, metadata)
    {
        Errors = CreateErrors(errors);
    }

    /// <summary>
    /// Gets the validation errors.
    /// </summary>
    public IReadOnlyList<ValidationExceptionItem> Errors { get; }

    private static ReadOnlyCollection<ValidationExceptionItem> CreateErrors(IEnumerable<ValidationExceptionItem> errors)
    {
        var items = Guard.AgainstNull(errors).ToArray();
        if (items.Length == 0)
        {
            throw new ArgumentException("Validation errors collection cannot be empty.", nameof(errors));
        }

        if (items.Any(static x => x is null))
        {
            throw new ArgumentException("Validation errors collection cannot contain null items.", nameof(errors));
        }

        return Array.AsReadOnly(items);
    }
}
