USE [bdsiscontrol]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 13/01/2025 06:04:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[EstadoID] [int] NOT NULL,
	[NomeEstado] [nvarchar](100) NULL,
	[Uf] [nvarchar](2) NULL,
	[Ibge] [int] NULL,
	[Pais] [int] NULL,
	[ddd] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
