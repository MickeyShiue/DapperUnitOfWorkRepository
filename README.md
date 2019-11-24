# DapperUnitOfWorkRepository(專案架構)

* Dapper.Console  
* Dapper.DataAccess
* Dapper.Service

## Dapper.Console   專案

呼叫端 Applaction，參考  Dapper.DataAccess、Dapper.Service 專案

## Dapper.DataAccess 專案

定義 DBModel、透過 Dapper 操作資料庫，並且實作 GenericRepository

## Dapper.Service 專案

參考 Dapper.DataAccess 專案，並透過 GenericRepository 收容所有可以操作 DB 行為，間接操作 DB

### Using Package
* [Dapper Version 2.0.30](https://www.nuget.org/packages/Dapper/2.0.30) => NuGet 指令：Install-Package Dapper -Version 2.0.30
* [Dapper.SimpleCRUD Version 2.2.0](https://www.nuget.org/packages/Dapper.SimpleCRUD/2.2.0) => NuGet 指令：Install-Package Dapper.SimpleCRUD -Version 2.2.0
