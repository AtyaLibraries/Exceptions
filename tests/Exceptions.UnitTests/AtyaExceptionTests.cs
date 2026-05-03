// <copyright file="AtyaExceptionTests.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

using Atya.Errors.Exceptions;

namespace Exceptions.UnitTests;

public sealed class AtyaExceptionTests
{
    [Fact]
    public void Derived_Exception_Should_Store_Message_ErrorCode_And_Metadata()
    {
        var metadata = new Dictionary<string, object?>
        {
            ["entityId"] = 42,
            ["entityName"] = "Customer"
        };

        var exception = new NotFoundException(
            "Customer was not found.",
            errorCode: "customer.not_found",
            metadata: metadata);

        exception.Message.Should().Be("Customer was not found.");
        exception.ErrorCode.Should().Be("customer.not_found");
        exception.Metadata.Should().ContainKey("entityId");
        exception.Metadata["entityId"].Should().Be(42);
        exception.Metadata["entityName"].Should().Be("Customer");
    }

    [Fact]
    public void Derived_Exception_With_InnerException_Should_Store_It()
    {
        var innerException = new InvalidOperationException("Inner failure.");

        var exception = new InfrastructureException(
            "Database failed.",
            innerException,
            errorCode: "db.failure");

        exception.Message.Should().Be("Database failed.");
        exception.InnerException.Should().BeSameAs(innerException);
        exception.ErrorCode.Should().Be("db.failure");
    }

    [Fact]
    public void Derived_Exception_With_Null_InnerException_Should_Throw()
    {
        var act = () => new InfrastructureException("Database failed.", innerException: null!);

        act.Should().Throw<ArgumentNullException>()
            .WithParameterName("innerException");
    }

    [Fact]
    public void Metadata_Should_Be_Immutable_From_Original_Dictionary_Changes()
    {
        var metadata = new Dictionary<string, object?>
        {
            ["key"] = "initial"
        };

        var exception = new ConflictException("Conflict.", metadata: metadata);

        metadata["key"] = "changed";
        metadata["other"] = "new";

        exception.Metadata.Should().ContainSingle();
        exception.Metadata["key"].Should().Be("initial");
        exception.Metadata.Should().NotContainKey("other");
    }

    [Fact]
    public void Constructor_Should_Throw_When_Message_Is_NullOrWhiteSpace()
    {
        var act = () => new NotFoundException(" ");

        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Constructor_Should_Throw_When_Metadata_Key_Is_Empty()
    {
        var metadata = new Dictionary<string, object?>
        {
            [string.Empty] = "value"
        };

        var act = () => new ConflictException("Conflict.", metadata: metadata);

        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Constructor_Should_Normalize_Empty_ErrorCode_To_Null()
    {
        var exception = new ForbiddenException("Forbidden.", errorCode: " ");

        exception.ErrorCode.Should().BeNull();
    }
}

