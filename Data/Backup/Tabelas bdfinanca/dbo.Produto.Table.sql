USE [bdsiscontrol]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 13/01/2025 06:04:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produto](
	[ProdutoID] [int] NOT NULL,
	[NomeProduto] [nvarchar](100) NULL,
	[PrecoCusto] [decimal](18, 2) NULL,
	[Estoque] [int] NULL,
	[PrecoVenda] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProdutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
