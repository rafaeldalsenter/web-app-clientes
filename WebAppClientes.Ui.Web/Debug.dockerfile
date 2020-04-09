FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["WebAppClientes.Ui.Web/WebAppClientes.Ui.Web.csproj", "WebAppClientes.Ui.Web/"]
COPY ["WebAppClientes.Infra.CrossCutting.Ioc/WebAppClientes.Infra.CrossCutting.Ioc.csproj", "WebAppClientes.Infra.CrossCutting.Ioc/"]
COPY ["WebAppClientes.Services/WebAppClientes.Services.csproj", "WebAppClientes.Services/"]
COPY ["WebAppClientes.Infra.CrossCutting.Dtos/WebAppClientes.Infra.CrossCutting.Dtos.csproj", "WebAppClientes.Infra.CrossCutting.Dtos/"]
COPY ["WebAppClientes.Domain/WebAppClientes.Domain.csproj", "WebAppClientes.Domain/"]
COPY ["WebAppClientes.Repositories/WebAppClientes.Repositories.csproj", "WebAppClientes.Repositories/"]
COPY ["WebAppClientes.Infra.Data/WebAppClientes.Infra.Data.csproj", "WebAppClientes.Infra.Data/"]
COPY ["WebAppClientes.Infra.CrossCutting.AutoMapper/WebAppClientes.Infra.CrossCutting.AutoMapper.csproj", "WebAppClientes.Infra.CrossCutting.AutoMapper/"]
RUN dotnet restore "WebAppClientes.Ui.Web/WebAppClientes.Ui.Web.csproj"
COPY . .
WORKDIR "/src/WebAppClientes.Ui.Web"
RUN dotnet build "WebAppClientes.Ui.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAppClientes.Ui.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh