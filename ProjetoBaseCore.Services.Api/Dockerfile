FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY BeautySalon.sln ./
COPY ProjetoBaseCore.Services.Api/ProjetoBaseCore.Services.Api.csproj ProjetoBaseCore.Services.Api/
COPY ProjetoBaseCore.Infra.CrossCutting.IoC/ProjetoBaseCore.Infra.CrossCutting.IoC.csproj ProjetoBaseCore.Infra.CrossCutting.IoC/
COPY src/ProjetoBaseCore.Infra.Data/ProjetoBaseCore.Infra.Data.csproj src/ProjetoBaseCore.Infra.Data/
COPY src/ProjetoBaseCore.Domain/ProjetoBaseCore.Domain.csproj src/ProjetoBaseCore.Domain/
COPY ProjetoBaseCore.Domain.Core/ProjetoBaseCore.Domain.Core.csproj ProjetoBaseCore.Domain.Core/
COPY ProjetoBaseCore.Infra.CrossCutting.Jwt/ProjetoBaseCore.Infra.CrossCutting.Jwt.csproj ProjetoBaseCore.Infra.CrossCutting.Jwt/
COPY ProjetoBaseCore.Application/ProjetoBaseCore.Application.csproj ProjetoBaseCore.Application/
COPY ProjetoBaseCore.Infra.CrossCutting.Identity/ProjetoBaseCore.Infra.CrossCutting.Identity.csproj ProjetoBaseCore.Infra.CrossCutting.Identity/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/ProjetoBaseCore.Services.Api
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProjetoBaseCore.Services.Api.dll"]
