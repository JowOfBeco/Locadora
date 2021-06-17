CREATE TABLE [dbo].[Aluguel] (
    [id]       INT           IDENTITY (1, 1) NOT NULL,
    [dataHora] DATETIME2 (7) NOT NULL,
    [filmeId]  INT           NULL,
    [dataEntrega] DATETIME2 NULL, 
    CONSTRAINT [PK_Aluguel] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Aluguel_Filme_filmeId] FOREIGN KEY ([filmeId]) REFERENCES [dbo].[Filme] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Aluguel_filmeId]
    ON [dbo].[Aluguel]([filmeId] ASC);

