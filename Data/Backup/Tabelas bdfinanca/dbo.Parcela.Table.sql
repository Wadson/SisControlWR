USE [bdsiscontrol]
GO
/****** Object:  Table [dbo].[Parcela]    Script Date: 13/01/2025 06:04:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parcela](
	[ParcelaID] [int] NOT NULL,
	[VendaID] [int] NOT NULL,
	[NumeroParcela] [int] NOT NULL,
	[DataVencimento] [datetime] NOT NULL,
	[ValorParcela] [decimal](18, 2) NOT NULL,
	[ValorRecebido] [decimal](18, 2) NOT NULL,
	[SaldoRestante] [decimal](18, 2) NOT NULL,
	[Pago] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ParcelaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Parcela] ADD  DEFAULT ((0)) FOR [ValorRecebido]
GO
ALTER TABLE [dbo].[Parcela] ADD  DEFAULT ((0)) FOR [Pago]
GO
ALTER TABLE [dbo].[Parcela]  WITH CHECK ADD FOREIGN KEY([VendaID])
REFERENCES [dbo].[Venda] ([VendaID])
GO
