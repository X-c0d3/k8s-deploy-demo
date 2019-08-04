FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 5001
EXPOSE 443

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
ENV ASPNETCORE_URLS http://*:5001
ENTRYPOINT ["dotnet", "k8s_demo_api.dll"]
