#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5003

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/Order/EShop.Services.Order.Api/EShop.Services.Order.Api.csproj", "src/Services/Order/EShop.Services.Order.Api/"]
RUN dotnet restore "src/Services/Order/EShop.Services.Order.Api/EShop.Services.Order.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Order/EShop.Services.Order.Api"
RUN dotnet build "EShop.Services.Order.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EShop.Services.Order.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EShop.Services.Order.Api.dll"]