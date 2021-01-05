

CREATE DATABASE ProjectBudget

use ProjectBudget

CREATE TABLE Client (
    IdClient int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [Name] varchar(1000) NOT NULL,
    Phone bigint,
	Email varchar(1000) NOT NULL,
	Cpf varchar(100) NOT NULL
);

CREATE TABLE ClientAddress (
    IdAddress int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	IdClient int Not null,
    Street varchar(1000) NOT NULL,
	Number int NOT NULL,
	Neighborhood varchar(1000) NOT NULL,
    City varchar(1000) NOT NULL,
	Cep varchar(100) NOT NULL,
	Country varchar(500) NOT NULL,
    FOREIGN KEY (IdClient) REFERENCES Client(IdClient)
);

CREATE TABLE MaterialsBudget (
	IdMaterials int IDENTITY(1,1) PRIMARY KEY Not null,
	IdClient int Not null,
    [Description] varchar(MAX) NOT NULL,
    Quantity int NOT NULL,
    CostPrice decimal NOT NULL,
    FOREIGN KEY (IdClient) REFERENCES Client(IdClient)
);

CREATE TABLE LaborBudget (
	IdLabor int IDENTITY(1,1) PRIMARY KEY  Not null,
	IdClient int Not null,
    [Description] varchar(MAX) NOT NULL,
    CostPrice decimal NOT NULL,
	FOREIGN KEY (IdClient) REFERENCES Client(IdClient)
);

CREATE TABLE Contractor (
	IdContractor int IDENTITY(1,1) PRIMARY KEY  Not null,
	[Name] varchar(200) not null,
	Phone bigint Not null,
	Cpf varchar(100) Not null,
);

CREATE TABLE [User] (
	IdUser int IDENTITY(1,1) PRIMARY KEY  Not null,
	IdContractor int NOT NULL,
	[Login] varchar(50) not null,
	[Password] varchar(10) Not null,
	FOREIGN KEY (IdContractor) REFERENCES Contractor(IdContractor)
);

--select * from ProjectBudget..Client
--select * from ProjectBudget..ClientAddress
--select * from ProjectBudget..MaterialsBudget
--select * from ProjectBudget..LaborBudget
--select * from ProjectBudget..Contractor
--select * from ProjectBudget..[User]

--drop table ClientAddress
--drop table MaterialsBudget
--drop table LaborBudget
--drop table Contractor	
--drop table Client