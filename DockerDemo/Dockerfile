FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM base AS final
WORKDIR /app
COPY ./bin/Release/netcoreapp3.1/publish/ .
ENTRYPOINT ["dotnet", "DockerDemo.dll"]