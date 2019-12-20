FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY * DikshaAssignment.sln .
COPY DikshaAssignment/*.csproj ./DikshaAssignment/
# COPY DikshaAssignment.Test/*.csproj ./DikshaAssignment.Test/
RUN dotnet restore

# copy everything else and build app
COPY DikshaAssignment/. ./DikshaAssignment/
WORKDIR /app/DikshaAssignment
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
WORKDIR /app
COPY --from=build /app/DikshaAssignment/out ./
ENTRYPOINT ["dotnet", "DikshaAssignment.dll"]