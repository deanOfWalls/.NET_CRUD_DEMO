# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /workspace/app
COPY YourAppName/*.csproj ./
RUN dotnet restore
COPY YourAppName ./
RUN dotnet publish -c Release -o out

# Final Stage
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app

# Explicitly Expose and document desired port
EXPOSE 8080

# Set up volumes and arguments
VOLUME /tmp
ARG DEPENDENCY=/workspace/app/out

# Copy published files
COPY --from=build ${DEPENDENCY} .

# Entry Point for Starting the Application
ENTRYPOINT ["dotnet", "YourAppName.dll"]
