#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WebAppCQRS/WebAppCQRS.csproj", "WebAppCQRS/"]
RUN dotnet restore "WebAppCQRS/WebAppCQRS.csproj"
COPY . .
WORKDIR "/src/WebAppCQRS"
RUN dotnet build "WebAppCQRS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAppCQRS.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAppCQRS.dll"]