# Используем официальный образ SDK для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1. Копируем весь solution и файлы проектов
COPY ["AspireForChaihana.sln", "."]
COPY ["AspireForChaihana.AppHost/AspireForChaihana.AppHost.csproj", "AspireForChaihana.AppHost/"]
COPY ["AspireForChaihana.ServiceDefaults/AspireForChaihana.ServiceDefaults.csproj", "AspireForChaihana.ServiceDefaults/"]
COPY ["ChaihanaForCustomers/ChaihanaForCustomers.csproj", "ChaihanaForCustomers/"]
COPY ["ChaihanaForEmployee/ChaihanaForEmplyee.csproj", "ChaihanaForEmplyee/"]

# 2. Восстанавливаем зависимости
RUN dotnet restore "AspireForChaihana.AppHost/AspireForChaihana.AppHost.csproj"

# 3. Копируем весь исходный код
COPY . .

# 4. Собираем и публикуем AppHost
WORKDIR "/src/AspireForChaihana.AppHost"
RUN dotnet publish "AspireForChaihana.AppHost.csproj" -c Release -o /app/publish

# 5. Финальный образ
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "AspireForChaihana.AppHost.dll"]