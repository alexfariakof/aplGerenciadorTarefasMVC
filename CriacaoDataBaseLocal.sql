USE [GerenciadorTarefas]
GO

/****** Object:  Table [dbo].[TarefaTB]    Script Date: 19/08/2018 11:58:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TarefaTB](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[titulo] [varchar](100) NULL,
 CONSTRAINT [PK_TarefaTB] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PermissaoTB](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [varchar](30) NULL,
 CONSTRAINT [PK_Permissao] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[UsuarioTB](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[senha] [varchar](10) NOT NULL,
	[idPermissao] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[PermissaoTB] ([tipo]) VALUES ('Administrador')
go
INSERT INTO [dbo].[PermissaoTB] ([tipo]) VALUES ('Usuário Básico')
go

GO
INSERT INTO [dbo].[UsuarioTB]
           ([nome], [email], [senha], [idPermissao])
     VALUES
           ('Administrador do Sistema', 'admin@admin', 'admin',1)
Go

INSERT INTO [dbo].[TarefaTB] ([titulo]) VALUES ('Primeira Tarefa')