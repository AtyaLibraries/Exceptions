# Exceptions

`Exceptions` is the repository for the `Atya.Errors.Exceptions` NuGet package.

| | |
| --- | --- |
| Repository | [https://github.com/AtyaLibraries/Exceptions](https://github.com/AtyaLibraries/Exceptions) |
| NuGet | `Atya.Errors.Exceptions` |
| License | MIT |

This package provides a focused exception taxonomy for reusable .NET libraries
and applications that need clear failure categories without any ASP.NET Core or
transport-specific coupling.

## Included APIs

- `AtyaException`
- `BusinessRuleViolationException`
- `ConcurrencyException`
- `ConflictException`
- `ForbiddenException`
- `InfrastructureException`
- `NotFoundException`
- `UnauthorizedException`
- `ValidationException`
- `ValidationExceptionItem`

## Layout

```text
.
|-- src/Exceptions/
|-- tests/Exceptions.UnitTests/
|-- samples/Exceptions.Samples.Console/
|-- benchmarks/Exceptions.Benchmarks/
`-- .github/
```

## Build, test, pack

```bash
dotnet restore
dotnet build --configuration Release --no-restore
dotnet test ./tests/Exceptions.UnitTests/Exceptions.UnitTests.csproj --configuration Release --no-build --collect "XPlat Code Coverage"
dotnet pack ./src/Exceptions/Exceptions.csproj --configuration Release --no-build --output artifacts/packages
```

Artifacts land in `artifacts/packages/`.

## Versioning

Versions are derived from git tags via [MinVer](https://github.com/adamralph/minver).
Releases are published by the central publisher, not by a workflow in this repository. After promoting `development` to `master` and tagging the `master` commit, a maintainer runs `gh workflow run publish.yml --repo AtyaLibraries/publisher -f repository=AtyaLibraries/Exceptions -f ref=<tag>`; see the publisher RUNBOOK (https://github.com/AtyaLibraries/publisher/blob/main/docs/RUNBOOK.md).
