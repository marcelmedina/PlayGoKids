#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GrpcServiceSample/GrpcServiceSample.csproj", "GrpcServiceSample/"]
RUN dotnet restore "GrpcServiceSample/GrpcServiceSample.csproj"
COPY . .
WORKDIR "/src/GrpcServiceSample"
RUN dotnet build "GrpcServiceSample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GrpcServiceSample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GrpcServiceSample.dll"]