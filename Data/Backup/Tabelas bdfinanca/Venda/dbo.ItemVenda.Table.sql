USE [bdsiscontrol]
GO
/****** Object:  Table [dbo].[ItemVenda]    Script Date: 13/01/2025 06:05:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemVenda](
	[ItemVendaID] [int] NOT NULL,
	[VendaID] [int] NULL,
	[ProdutoID] [int] NULL,
	[Quantidade] [int] NOT NULL,
	[PrecoUnitario] [decimal](10, 2) NOT NULL,
	[Subtotal]  AS ([Quantidade]*[PrecoUnitario]),
PRIMARY KEY CLUSTERED 
(
	[ItemVendaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ItemVenda]  WITH CHECK ADD FOREIGN KEY([ProdutoID])
REFERENCES [dbo].[Produto] ([ProdutoID])
GO
ALTER TABLE [dbo].[ItemVenda]  WITH CHECK ADD FOREIGN KEY([VendaID])
REFERENCES [dbo].[Venda] ([VendaID])
GO
