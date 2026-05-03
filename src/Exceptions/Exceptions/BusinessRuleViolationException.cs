// <copyright file="BusinessRuleViolationException.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

namespace Atya.Errors.Exceptions;

/// <summary>
/// Represents a business rule violation.
/// </summary>
public sealed class BusinessRuleViolationException : AtyaException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BusinessRuleViolationException"/> class.
    /// </summary>
    public BusinessRuleViolationException(
        string message,
        string? errorCode = "business.rule_violation",
        IReadOnlyDictionary<string, object?>? metadata = null)
        : base(message, errorCode, metadata)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BusinessRuleViolationException"/> class.
    /// </summary>
    public BusinessRuleViolationException(
        string message,
        Exception innerException,
        string? errorCode = "business.rule_violation",
        IReadOnlyDictionary<string, object?>? metadata = null)
        : base(message, innerException, errorCode, metadata)
    {
    }
}
