# C# (Csharp) Playground

**C#** is a high-level language that is part of Microsoft's .NET ecosystem. It is considered a general purpose language. As the native language for the Unity game engine, it gets a lot of use in video games.

This is my C# playground repository.

## File Extension

`.cs`

## Create Project Files

```bash
cd <path/to/file>
dotnet new console
```

## Build and Execute the Project

Assuming the current working directory is `<path/to/file>`:

```bash
dotnet run
```

## configit.sh

This repository's *devcontainer.json* uses a `postCreateCommand` to run `configit.sh`.

This script uses information particular to the user of the repository.

```shell
#!/bin/bash

git config --global user.email "yourEmail@mail.com"
git config --global user.name "yourGitUserName"
git config --global push.autoSetupRemote true
git config --global push.default current
git config --global init.defaultBranch main
git config --global --add safe.directory $1
```
