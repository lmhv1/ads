CREATE TABLE [dbo].[Funcionario] (
    [Nome]               NVARCHAR (100) NOT NULL,
    [Sexo]               CHAR (1)       NOT NULL,
    [Data_de_nascimento] DATE           NOT NULL,
    [CPF]                CHAR (11)      NOT NULL,
    [Email]              VARCHAR (70)   NOT NULL,
    [Telefone]           CHAR (11)      NOT NULL,
    [Cargo]              NCHAR (11)     NOT NULL,
    [Id] INT NOT NULL IDENTITY, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

