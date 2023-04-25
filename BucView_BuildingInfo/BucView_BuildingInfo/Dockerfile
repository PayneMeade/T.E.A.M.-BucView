#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BucView_BuildingInfo/BucView_BuildingInfo.csproj", "BucView_BuildingInfo/"]
RUN dotnet restore "BucView_BuildingInfo/BucView_BuildingInfo.csproj"
COPY . .
WORKDIR "/src/BucView_BuildingInfo"
RUN dotnet build "BucView_BuildingInfo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BucView_BuildingInfo.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BucView_BuildingInfo.dll"]