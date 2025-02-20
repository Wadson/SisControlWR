USE [bdsiscontrol]
GO
/****** Object:  Table [dbo].[Pagamento]    Script Date: 13/01/2025 06:04:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pagamento](
	[PagamentoID] [int] NOT NULL,
	[ParcelaID] [int] NULL,
	[DataPagamento] [datetime] NULL,
	[ValorPago] [decimal](10, 2) NULL,
	[MetodoPagamento] [nvarchar](50) NULL,
	[Observacao] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[PagamentoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pagamento]  WITH CHECK ADD FOREIGN KEY([ParcelaID])
REFERENCES [dbo].[Parcela] ([ParcelaID])
GO
