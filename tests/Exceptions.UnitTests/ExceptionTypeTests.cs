// <copyright file="ExceptionTypeTests.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

using Atya.Errors.Exceptions;

namespace Exceptions.UnitTests;

public sealed class ExceptionTypeTests
{
    [Theory]
    [InlineData(typeof(BusinessRuleViolationException))]
    [InlineData(typeof(NotFoundException))]
    [InlineData(typeof(ConflictException))]
    [InlineData(typeof(UnauthorizedException))]
    [InlineData(typeof(ForbiddenException))]
    [InlineData(typeof(ConcurrencyException))]
    [InlineData(typeof(InfrastructureException))]
    [InlineData(typeof(ValidationException))]
    public void All_Known_Exception_Types_Should_Inherit_From_AtyaException(Type exceptionType)
    {
        typeof(AtyaException).IsAssignableFrom(exceptionType).Should().BeTrue();
    }

    [Theory]
    [MemberData(nameof(DefaultExceptionData))]
    public void Known_Exception_Types_Should_Use_Default_ErrorCode(
        Func<string, AtyaException> factory,
        string expectedErrorCode)
    {
        var exception = factory("Failure.");

        exception.Message.Should().Be("Failure.");
        exception.ErrorCode.Should().Be(expectedErrorCode);
    }

    [Theory]
    [MemberData(nameof(InnerExceptionData))]
    public void Known_Exception_Types_With_InnerException_Should_Store_InnerException_And_Default_ErrorCode(
        Func<string, Exception, AtyaException> factory,
        string expectedErrorCode)
    {
        var innerException = new InvalidOperationException("Inner.");

        var exception = factory("Failure.", innerException);

        exception.Message.Should().Be("Failure.");
        exception.InnerException.Should().BeSameAs(innerException);
        exception.ErrorCode.Should().Be(expectedErrorCode);
    }

    public static TheoryData<Func<string, AtyaException>, string> DefaultExceptionData()
    {
        return new TheoryData<Func<string, AtyaException>, string>
        {
            { message => new BusinessRuleViolationException(message), "business.rule_violation" },
            { message => new ConcurrencyException(message), "resource.concurrency_conflict" },
            { message => new ConflictException(message), "resource.conflict" },
            { message => new ForbiddenException(message), "auth.forbidden" },
            { message => new InfrastructureException(message), "infrastructure.failure" },
            { message => new NotFoundException(message), "resource.not_found" },
            { message => new UnauthorizedException(message), "auth.unauthorized" },
        };
    }

    public static TheoryData<Func<string, Exception, AtyaException>, string> InnerExceptionData()
    {
        return new TheoryData<Func<string, Exception, AtyaException>, string>
        {
            { (message, innerException) => new BusinessRuleViolationException(message, innerException), "business.rule_violation" },
            { (message, innerException) => new ConcurrencyException(message, innerException), "resource.concurrency_conflict" },
            { (message, innerException) => new ConflictException(message, innerException), "resource.conflict" },
            { (message, innerException) => new ForbiddenException(message, innerException), "auth.forbidden" },
            { (message, innerException) => new InfrastructureException(message, innerException), "infrastructure.failure" },
            { (message, innerException) => new NotFoundException(message, innerException), "resource.not_found" },
            { (message, innerException) => new UnauthorizedException(message, innerException), "auth.unauthorized" },
        };
    }
}

