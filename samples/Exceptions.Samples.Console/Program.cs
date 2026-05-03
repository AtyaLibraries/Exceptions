// <copyright file="Program.cs" company="Atya">
// Copyright (c) Atya. All rights reserved.
// </copyright>

using Atya.Errors.Exceptions;
using Atya.Errors.Exceptions.Models;

namespace Exceptions.Samples.Console;

public static class Program
{
    public static void Main()
    {
        IReadOnlyDictionary<string, object?> metadata = new Dictionary<string, object?>
        {
            ["entityId"] = 42,
            ["entityName"] = "Customer"
        };

        AtyaException[] exceptions =
        [
            new NotFoundException(
                "Customer was not found.",
                errorCode: "customer.not_found",
                metadata: metadata),
            new ValidationException(
                "Customer request is invalid.",
                [
                    new ValidationExceptionItem("Email", "Email is required.", "validation.required"),
                    new ValidationExceptionItem("Age", "Age must be greater than zero.", "validation.range", 0)
                ])
        ];

        foreach (AtyaException exception in exceptions)
        {
            System.Console.WriteLine($"{exception.GetType().Name}: {exception.Message}");
            System.Console.WriteLine($"  Error code: {exception.ErrorCode ?? "<none>"}");
            System.Console.WriteLine($"  Metadata entries: {exception.Metadata.Count}");
        }
    }
}

