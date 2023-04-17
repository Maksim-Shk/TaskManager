#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TaskManager/Server/TaskManager.Server.csproj", "TaskManager/Server/"]
COPY ["TaskManager.Application/TaskManager.Application.csproj", "TaskManager.Application/"]
COPY ["TaskManager.Domain/TaskManager.Domain.csproj", "TaskManager.Domain/"]
COPY ["TaskManager.Persistence/TaskManager.Persistence.csproj", "TaskManager.Persistence/"]
COPY ["TaskManager/Client/TaskManager.Client.csproj", "TaskManager/Client/"]
RUN dotnet restore "TaskManager/Server/TaskManager.Server.csproj"
COPY . .
WORKDIR "/src/TaskManager/Server"
RUN dotnet build "TaskManager.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskManager.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskManager.Server.dll"]