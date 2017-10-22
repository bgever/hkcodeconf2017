# Sample contents of Dockerfile

# Stage 1
FROM microsoft/aspnetcore-build:2 AS builder
WORKDIR /source

# caches restore result by copying csproj file separately
COPY *.csproj .
RUN dotnet restore

# copies the rest of your code
COPY . .
RUN dotnet publish --output /app/ --configuration Release

# Stage 2
FROM microsoft/aspnetcore:2

WORKDIR /app
COPY --from=builder /app .
ENTRYPOINT ["dotnet", "CodeConf.Api.dll"]