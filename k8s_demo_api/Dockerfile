FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

EXPOSE 5001

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY k8s_demo_api/k8s_demo_api.csproj k8s_demo_api/
RUN dotnet restore "k8s_demo_api/k8s_demo_api.csproj"
COPY . .
WORKDIR "/src/k8s_demo_api"
RUN dotnet build "k8s_demo_api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "k8s_demo_api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
COPY acid-dev-cert.pfx .
RUN ls -la .

# Set ASP.NET Core environment variables
ENV ASPNETCORE_ENVIRONMENT="Production"
ENV ASPNETCORE_URLS=https://+:443;http://+:5001
ENV ASPNETCORE_HTTPS_PORT=443



ENV ASPNETCORE_Kestrel__Certificates__Default__Password="acid@dev1234"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=./acid-dev-cert.pfx

ENTRYPOINT ["dotnet", "k8s_demo_api.dll"]