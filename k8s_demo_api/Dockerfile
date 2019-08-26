FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
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
ENV ASPNETCORE_URLS https://+:5001
ENV ASPNETCORE_HTTPS_PORT=5001

ENV ASPNETCORE_Kestrel__Certificates__Default__Password="acid@dev1234"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=./acid-dev-cert.pfx

ENTRYPOINT ["dotnet", "k8s_demo_api.dll"]

# Create HTTPS Cert for .net core
# https://github.com/dotnet/dotnet-docker/blob/master/samples/aspnetapp/aspnetcore-docker-https.md

#dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p crypticpassword
#dotnet dev-certs https --trust
