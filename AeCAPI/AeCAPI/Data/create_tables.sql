CREATE TABLE Aeroportos (
    id INT PRIMARY KEY,
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


CREATE TABLE Cidades (
    id INT PRIMARY KEY,
    cidade VARCHAR(255) NOT NULL,
    estado VARCHAR(255) NOT NULL,
    atualizado_em VARCHAR(255) NOT NULL
);


CREATE TABLE climas (
    id INT PRIMARY KEY IDENTITY,
    data NVARCHAR(255),
    condicao NVARCHAR(255),
    condicao_desc NVARCHAR(255),
    min INT,
    max INT,
    indice_uv INT,
    idCidade INT,
    FOREIGN KEY (idCidade) REFERENCES cidades(id)
);
