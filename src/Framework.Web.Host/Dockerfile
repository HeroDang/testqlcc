#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Framework.Web.Host/Framework.Web.Host.csproj", "src/Framework.Web.Host/"]
COPY ["src/Framework.Web.Core/Framework.Web.Core.csproj", "src/Framework.Web.Core/"]
COPY ["src/Framework.Application/Framework.Application.csproj", "src/Framework.Application/"]
COPY ["src/Framework.Application.Shared/Framework.Application.Shared.csproj", "src/Framework.Application.Shared/"]
COPY ["src/Framework.Core.Shared/Framework.Core.Shared.csproj", "src/Framework.Core.Shared/"]
COPY ["src/Framework.Core/Framework.Core.csproj", "src/Framework.Core/"]
COPY ["src/Framework.EntityFrameworkCore/Framework.EntityFrameworkCore.csproj", "src/Framework.EntityFrameworkCore/"]
COPY ["src/Framework.GraphQL/Framework.GraphQL.csproj", "src/Framework.GraphQL/"]
RUN dotnet restore "src/Framework.Web.Host/Framework.Web.Host.csproj"
COPY . .
WORKDIR "/src/src/Framework.Web.Host"
RUN dotnet build "Framework.Web.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Framework.Web.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Framework.Web.Host.dll"]
