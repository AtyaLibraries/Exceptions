// <copyright file="InfrastructureException.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

namespace Atya.Errors.Exceptions;

/// <summary>
/// Represents an infrastructure or technical failure, such as database, network, file system,
/// or third-party dependency issues.
/// </summary>
public sealed class InfrastructureException : AtyaException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InfrastructureException"/> class.
    /// </summary>
    public InfrastructureException(
        string message,
        string? errorCode = "infrastructure.failure",
        IReadOnlyDictionary<string, object?>? metadata = null)
        : base(message, errorCode, metadata)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InfrastructureException"/> class.
    /// </summary>
    public InfrastructureException(
        string message,
        Exception innerException,
        string? errorCode = "infrastructure.failure",
        IReadOnlyDictionary<string, object?>? metadata = null)
        : base(message, innerException, errorCode, metadata)
    {
    }
}
