FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /app

# Copy SDK source and examples (mirrors local repo structure)
COPY src/ src/
COPY examples/ examples/

# Build
RUN dotnet build examples/Examples.csproj -c Release

# Default example: FilesExample. Override with: docker run ... FoldersExample
ENTRYPOINT ["dotnet", "run", "--project", "examples/Examples.csproj", "-c", "Release", "--no-build", "--"]
CMD ["FilesExample"]
