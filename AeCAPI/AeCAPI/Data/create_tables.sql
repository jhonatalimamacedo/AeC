USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'sqlbanco')
BEGIN
    CREATE DATABASE sqlbanco;
END
GO

USE sqlbanco;
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Aeroportos')
BEGIN
    CREATE TABLE Aeroportos (
        id INT PRIMARY KEY IDENTITY, 
        umidade INT,
        visibilidade NVARCHAR(255),
        codigo_icao NVARCHAR(255),
        pressao_atmosferica INT,
        vento INT,
        direcao_vento INT,
        condicao NVARCHAR(255),
        condicao_desc NVARCHAR(255),
        temp INT,
        atualizado_em DATETIME
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Cidade')
BEGIN
    CREATE TABLE Cidade (
        id INT PRIMARY KEY IDENTITY,
        cidade VARCHAR(255) NOT NULL,
        estado VARCHAR(255) NOT NULL,
        atualizado_em VARCHAR(255) NOT NULL
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'climas')
BEGIN
    CREATE TABLE climas (
        id INT PRIMARY KEY IDENTITY,
        data NVARCHAR(255),
        condicao NVARCHAR(255),
        condicao_desc NVARCHAR(255),
        min INT,
        max INT,
        indice_uv INT,
        idCidade INT,
        FOREIGN KEY (idCidade) REFERENCES Cidade(id)
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'log')
BEGIN
    CREATE TABLE log (
        id INT PRIMARY KEY IDENTITY,
        data NVARCHAR(255),
        codeMessage NVARCHAR(255),
        Messagem NVARCHAR(255)
    );
END
GO
