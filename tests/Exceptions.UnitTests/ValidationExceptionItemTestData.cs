// <copyright file="ValidationExceptionItemTestData.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

using Atya.Errors.Exceptions.Models;
using Atya.Governance.Testing.Builders;

namespace Exceptions.UnitTests;

internal static class ValidationExceptionItemTestData
{
    public static ValidationExceptionItem Create(
        string propertyName = "Name",
        string errorMessage = "Validation failed.",
        string? errorCode = null,
        object? attemptedValue = null)
    {
        var failure = ValidationFailureBuilder
            .Create()
            .WithPropertyName(propertyName)
            .WithErrorMessage(errorMessage)
            .WithErrorCode(errorCode)
            .WithAttemptedValue(attemptedValue)
            .Build();

        return new ValidationExceptionItem(
            failure.PropertyName,
            failure.ErrorMessage,
            failure.ErrorCode,
            failure.AttemptedValue);
    }
}
