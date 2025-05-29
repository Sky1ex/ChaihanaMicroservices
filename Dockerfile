# ���������� ����������� ����� SDK ��� ������
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1. �������� ���� solution � ����� ��������
COPY ["AspireForChaihana.sln", "."]
COPY ["AspireForChaihana.AppHost/AspireForChaihana.AppHost.csproj", "AspireForChaihana.AppHost/"]
COPY ["AspireForChaihana.ServiceDefaults/AspireForChaihana.ServiceDefaults.csproj", "AspireForChaihana.ServiceDefaults/"]
COPY ["ChaihanaForCustomers/ChaihanaForCustomers.csproj", "ChaihanaForCustomers/"]
COPY ["ChaihanaForEmployee/ChaihanaForEmplyee.csproj", "ChaihanaForEmplyee/"]

# 2. ��������������� �����������
RUN dotnet restore "AspireForChaihana.AppHost/AspireForChaihana.AppHost.csproj"

# 3. �������� ���� �������� ���
COPY . .

# 4. �������� � ��������� AppHost
WORKDIR "/src/AspireForChaihana.AppHost"
RUN dotnet publish "AspireForChaihana.AppHost.csproj" -c Release -o /app/publish

# 5. ��������� �����
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "AspireForChaihana.AppHost.dll"]