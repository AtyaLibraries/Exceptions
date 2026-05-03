// <copyright file="Program.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

using Atya.Errors.Exceptions;
using Atya.Errors.Exceptions.Models;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Exceptions.Benchmarks;

public static class Program
{
    public static void Main(string[] args)
    {
        _ = args;
        BenchmarkRunner.Run<ExceptionConstructionBenchmarks>();
    }
}

[MemoryDiagnoser]
public class ExceptionConstructionBenchmarks
{
    private static readonly TimeoutException InnerException = new("sql-timeout");
    private static readonly IReadOnlyDictionary<string, object?> Metadata = new Dictionary<string, object?>
    {
        ["provider"] = "sqlserver",
        ["operation"] = "SaveChanges"
    };

    private static readonly ValidationExceptionItem[] ValidationErrors =
    [
        new("Email", "Email is required.", "validation.required"),
        new("Age", "Age must be greater than zero.", "validation.range", 0)
    ];

    [Benchmark]
    public static NotFoundException CreateNotFoundException()
    {
        return new NotFoundException("Customer was not found.", "customer.not_found");
    }

    [Benchmark]
    public static InfrastructureException CreateInfrastructureExceptionWithMetadata()
    {
        return new InfrastructureException(
            "The database operation failed.",
            InnerException,
            "infrastructure.failure",
            Metadata);
    }

    [Benchmark]
    public static ValidationException CreateValidationException()
    {
        return new ValidationException("Customer request is invalid.", ValidationErrors);
    }
}

