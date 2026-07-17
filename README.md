# LPG-csharp-runtime

C# runtime for [LPG2](https://github.com/A-LPG/LPG2).

## Install / coordinates

| Field | Value |
|-------|-------|
| Package | NuGet [`LPG2.Runtime`](https://www.nuget.org/packages/LPG2.Runtime) |
| Version | 1.0.2 |
| Compatible generator | LPG2 ≥ 2.3.0 — see [`ecosystem/compat.json`](https://github.com/A-LPG/LPG2/blob/main/ecosystem/compat.json) |

```bash
dotnet add package LPG2.Runtime
```

## Minimum toolchain

.NET 8 SDK. Library targets `netstandard2.0;net8.0`.

## Build and test

```bash
cd LPG2.Runtime
dotnet build -c Release
```

## Wiring generated files

1. Generate with `-programming_language=csharp -table` and `dtParserTemplateF.gi`
2. Reference this package from your project
3. Add generated sources to the compilation

## Features

| Feature | Status |
|---------|--------|
| Deterministic parser | yes |
| Backtracking | yes |
| Nested automatic AST | yes |
| `%Recover` prosthetic AST | yes |

## Publish status

- Channel: NuGet
- Automation: `.github/workflows/publish.yml` (requires `NUGET_API_KEY`)

## Links

- Generator: https://github.com/A-LPG/LPG2
- Ecosystem: https://github.com/A-LPG/LPG2/blob/main/docs/ECOSYSTEM.md
