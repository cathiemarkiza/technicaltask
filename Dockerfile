# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /

# Copy and restore project dependencies
COPY / .
RUN dotnet restore

# Copy the rest of the source code
COPY / .
RUN dotnet publish -c Release -o out

# Stage 2: Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /
COPY --from=build / .

# Expose the port
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "RectangleApp.dll"]
