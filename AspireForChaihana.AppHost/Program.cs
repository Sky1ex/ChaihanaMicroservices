using Aspire.Hosting;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Projects;
using Aspire.Hosting.Docker;

// ���������� ��� ������ ������������ ����� ������ � ����� (AspireForChaihana). Aspire ����� ������� ��� ������ ������ ����� ����� � ����������. � ������ � ���� ����� �����������.

var builder = DistributedApplication.CreateBuilder(args);

var employeeDb = builder.AddPostgres("postgres-employee")
	.WithPgWeb()
	.AddDatabase("WebDbForEmployee");

var customerDb = builder.AddPostgres("postgres-customer")
	.WithEnvironment("POSTGRES_DB", "WebDbForCustomers")
	.WithDataVolume()
	.WithBindMount(source: @"C:\������� �����\3 ���� 2 ���������\TestDocker\AspireForChaihana\AspireForChaihana.ServiceDefaults\DataBase and more\Dumps\CustomersDump", target: "/docker-entrypoint-initdb.d")
	.WithPgWeb()
	.AddDatabase("WebDbForCustomers");

var cafeDb = builder.AddPostgres("postgres-cafe")
	.WithEnvironment("POSTGRES_DB", "WebDbForCafe")
	.WithDataVolume()
	.WithBindMount(source: @"C:\������� �����\3 ���� 2 ���������\TestDocker\AspireForChaihana\AspireForChaihana.ServiceDefaults\DataBase and more\Dumps\CafeDump", target: "/docker-entrypoint-initdb.d")
	.WithPgWeb()
	.AddDatabase("WebDbForCafe");


var ChaihanaForCustomers = builder.AddProject<Projects.WebApplication1>("ChaihanaForCustomers")
	.WithReference(customerDb)
	.WithReference(cafeDb)
	.WaitFor(customerDb)
	.WaitFor(cafeDb);

var ChaihanaForEmployee = builder.AddProject<Projects.ChaihanaForEmplyee>("ChaihanaForEmployee")
	.WithReference(employeeDb)
	.WithReference(cafeDb);


builder.Build().Run();
