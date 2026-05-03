// <copyright file="ValidationExceptionItemTests.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

using Atya.Errors.Exceptions.Models;

namespace Exceptions.UnitTests;

public sealed class ValidationExceptionItemTests
{
    [Fact]
    public void Constructor_Should_Store_All_Values()
    {
        var item = new ValidationExceptionItem(
            "Email",
            "Email is invalid.",
            "validation.email",
            "not-an-email");

        item.PropertyName.Should().Be("Email");
        item.Message.Should().Be("Email is invalid.");
        item.ErrorCode.Should().Be("validation.email");
        item.AttemptedValue.Should().Be("not-an-email");
    }

    [Fact]
    public void Constructor_Should_Allow_Optional_Values_To_Be_Omitted()
    {
        var item = new ValidationExceptionItem("Name", "Name is required.");

        item.PropertyName.Should().Be("Name");
        item.Message.Should().Be("Name is required.");
        item.ErrorCode.Should().BeNull();
        item.AttemptedValue.Should().BeNull();
    }

    [Fact]
    public void ValidationExceptionItem_Should_Use_Record_Value_Equality()
    {
        var left = new ValidationExceptionItem("Age", "Age is invalid.", "validation.range", 0);
        var right = new ValidationExceptionItem("Age", "Age is invalid.", "validation.range", 0);

        left.Should().Be(right);
    }
}
