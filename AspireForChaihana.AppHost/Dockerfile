# ���������� ����������� ����� SDK ��� ������
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# 1. �������� ���� solution � ����� ��������
COPY ["AspireForChaihana.sln", "."]
COPY ["AspireForChaihana.AppHost/AspireForChaihana.AppHost.csproj", "AspireForChaihana.AppHost/"]
COPY ["AspireForChaihana.ServiceDefaults/AspireForChaihana.ServiceDefaults.csproj", "AspireForChaihana.ServiceDefaults/"]
COPY ["ChaihanaForCustomers/WebApplication1.csproj", "ChaihanaForCustomers/"]
COPY ["ChaihanaForEmplyee/ChaihanaForEmplyee.csproj", "ChaihanaForEmplyee/"]

# 2. ��������������� �����������
RUN dotnet restore "AspireForChaihana.sln"

# 3. �������� ���� �������� ���
COPY . .

# 4. �������� � ��������� AppHost
WORKDIR /app
RUN dotnet build -c Release -o "./out"

# 5. ��������� �����
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "AspireForChaihana.AppHost.dll"]