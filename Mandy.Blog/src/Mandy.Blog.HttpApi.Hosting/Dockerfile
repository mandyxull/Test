#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Mandy.Blog.HttpApi.Hosting/Mandy.Blog.HttpApi.Hosting.csproj", "src/Mandy.Blog.HttpApi.Hosting/"]
COPY ["src/Mandy.Blog.Swagger/Mandy.Blog.Swagger.csproj", "src/Mandy.Blog.Swagger/"]
COPY ["src/Mandy.Blog.Domain.Shared/Mandy.Blog.Domain.Shared.csproj", "src/Mandy.Blog.Domain.Shared/"]
COPY ["src/Mandy.Blog.Domain/Mandy.Blog.Domain.csproj", "src/Mandy.Blog.Domain/"]
COPY ["src/Mandy.Blog.EntityFrameworkCore/Mandy.Blog.EntityFrameworkCore.csproj", "src/Mandy.Blog.EntityFrameworkCore/"]
COPY ["src/Mandy.Blog.EntityFrameworkCore.DbMigrations/Mandy.Blog.EntityFrameworkCore.DbMigrations.csproj", "src/Mandy.Blog.EntityFrameworkCore.DbMigrations/"]
COPY ["src/Mandy.Blog.HttpApi/Mandy.Blog.HttpApi.csproj", "src/Mandy.Blog.HttpApi/"]
COPY ["src/Mandy.Blog.Application/Mandy.Blog.Application.csproj", "src/Mandy.Blog.Application/"]
COPY ["src/Mandy.Blog.Application.Caching/Mandy.Blog.Application.Caching.csproj", "src/Mandy.Blog.Application.Caching/"]
COPY ["src/Mandy.Blog.ToolKits/Mandy.Blog.ToolKits.csproj", "src/Mandy.Blog.ToolKits/"]
COPY ["src/Mandy.Blog.Application.Contracts/Mandy.Blog.Application.Contracts.csproj", "src/Mandy.Blog.Application.Contracts/"]
COPY ["src/Mandy.Blog.BackgroundJobs/Mandy.Blog.BackgroundJobs.csproj", "src/Mandy.Blog.BackgroundJobs/"]
RUN dotnet restore "src/Mandy.Blog.HttpApi.Hosting/Mandy.Blog.HttpApi.Hosting.csproj"
COPY . .
WORKDIR "/src/src/Mandy.Blog.HttpApi.Hosting"
RUN dotnet build "Mandy.Blog.HttpApi.Hosting.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mandy.Blog.HttpApi.Hosting.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mandy.Blog.HttpApi.Hosting.dll"]