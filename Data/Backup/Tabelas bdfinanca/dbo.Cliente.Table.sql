USE [bdsiscontrol]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 13/01/2025 06:04:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ClienteID] [int] NOT NULL,
	[NomeCliente] [nvarchar](100) NOT NULL,
	[Cpf] [varchar](14) NULL,
	[Email] [nvarchar](100) NULL,
	[Endereco] [varchar](150) NULL,
	[Telefone] [varchar](20) NULL,
	[CidadeID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ClienteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Cidade] FOREIGN KEY([CidadeID])
REFERENCES [dbo].[Cidade] ([CidadeID])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Cidade]
GO
