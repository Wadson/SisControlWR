USE [bdsiscontrol]
GO
/****** Object:  Table [dbo].[SubCategoria]    Script Date: 13/01/2025 06:04:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCategoria](
	[SubCategoriaID] [int] NOT NULL,
	[NomeSubCategoria] [nvarchar](100) NOT NULL,
	[CategoriaID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SubCategoriaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SubCategoria]  WITH CHECK ADD FOREIGN KEY([CategoriaID])
REFERENCES [dbo].[Categoria] ([CategoriaID])
GO
