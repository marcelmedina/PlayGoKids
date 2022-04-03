#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FluentValidationSample/FluentValidationSample.csproj", "FluentValidationSample/"]
RUN dotnet restore "FluentValidationSample/FluentValidationSample.csproj"
COPY . .
WORKDIR "/src/FluentValidationSample"
RUN dotnet build "FluentValidationSample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FluentValidationSample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FluentValidationSample.dll"]