// <copyright file="ValidationExceptionTests.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

using Atya.Errors.Exceptions;
using Atya.Errors.Exceptions.Models;

namespace Exceptions.UnitTests;

public sealed class ValidationExceptionTests
{
    [Fact]
    public void Constructor_Should_Store_Errors()
    {
        var errors = new[]
        {
            ValidationExceptionItemTestData.Create("Email", "Email is required.", "validation.required"),
            ValidationExceptionItemTestData.Create("Age", "Age must be greater than zero.", "validation.range", 0)
        };

        var exception = new ValidationException("Validation failed.", errors);

        exception.Message.Should().Be("Validation failed.");
        exception.ErrorCode.Should().Be("validation.failed");
        exception.Errors.Should().HaveCount(2);
        exception.Errors[0].PropertyName.Should().Be("Email");
        exception.Errors[1].AttemptedValue.Should().Be(0);
    }

    [Fact]
    public void Constructor_With_InnerException_Should_Store_It()
    {
        var errors = new[]
        {
            ValidationExceptionItemTestData.Create("Name", "Name is required.")
        };

        var innerException = new InvalidOperationException("inner");

        var exception = new ValidationException("Validation failed.", errors, innerException);

        exception.InnerException.Should().BeSameAs(innerException);
    }

    [Fact]
    public void Constructor_Should_Throw_When_Errors_Are_Null()
    {
        var act = () => new ValidationException("Validation failed.", null!);

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Constructor_Should_Throw_When_Errors_Are_Empty()
    {
        var act = () => new ValidationException("Validation failed.", Array.Empty<ValidationExceptionItem>());

        act.Should().Throw<ArgumentException>()
            .WithMessage("*cannot be empty*");
    }

    [Fact]
    public void Constructor_Should_Throw_When_Errors_Contain_Null_Item()
    {
        var errors = new ValidationExceptionItem?[]
        {
            ValidationExceptionItemTestData.Create("Email", "Email is required."),
            null
        };

        var act = () => new ValidationException("Validation failed.", errors!);

        act.Should().Throw<ArgumentException>()
            .WithMessage("*cannot contain null items*")
            .WithParameterName("errors");
    }

    [Fact]
    public void Errors_Should_Be_Immutable_From_Original_Array_Changes()
    {
        var errors = new[]
        {
            ValidationExceptionItemTestData.Create("Email", "Email is required.")
        };

        var exception = new ValidationException("Validation failed.", errors);

        errors[0] = ValidationExceptionItemTestData.Create("Changed", "Changed");

        exception.Errors.Should().ContainSingle();
        exception.Errors[0].PropertyName.Should().Be("Email");
    }
}

