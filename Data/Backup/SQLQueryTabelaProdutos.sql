CREATE TABLE Produtos (
    ProdutoID INT PRIMARY KEY IDENTITY(1,1),
    NomeProduto VARCHAR(100) NOT NULL,
    Descricao VARCHAR(100) NOT NULL,
    PrecoCusto DECIMAL(10, 2) NOT NULL,
    Lucro DECIMAL(10, 2) NOT NULL,
    PrecoDeVenda DECIMAL(10, 2) NOT NULL,
    QuantidadeEmEstoque INT NOT NULL,
    DataDeEntrada DATETIME NOT NULL,
    CategoriaID INT,
    FabricanteID INT,
    UnidadeDeMedida VARCHAR(50),
    Status VARCHAR(50),
    DataDeVencimento DATETIME,
    Imagem VARBINARY(MAX),
    FornecedorID INT,
    FOREIGN KEY (CategoriaID) REFERENCES Categoria(CategoriaID),    
    FOREIGN KEY (FornecedorID) REFERENCES Fornecedor(FornecedorID)
);
