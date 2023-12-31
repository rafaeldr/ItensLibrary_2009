USE [rafael]
GO
/****** Object:  User [application]      01:00:49 ******/
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'application')
CREATE USER [application] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[application]
GO
/****** Object:  Schema [application]      01:00:47 ******/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'application')
EXEC sys.sp_executesql N'CREATE SCHEMA [application] AUTHORIZATION [application]'
GO
/****** Object:  StoredProcedure [dbo].[sp_grep]      01:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_grep]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[sp_grep](
	@cadeia varchar(150)
)
as

select distinct
	object_name(s1.id)
from
	sysobjects s1
inner join
	syscomments s2
on
	s1.id = s2.id
where
	s2.text like ''%'' + @cadeia + ''%''


' 
END
GO
/****** Object:  Table [dbo].[Pessoa]      01:00:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pessoa]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Pessoa](
	[nsu_Pessoa] [int] IDENTITY(1,1) NOT NULL,
	[nm_Pessoa] [varchar](90) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_Pessoa] PRIMARY KEY CLUSTERED 
(
	[nsu_Pessoa] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Pessoa] ON
INSERT [dbo].[Pessoa] ([nsu_Pessoa], [nm_Pessoa]) VALUES (1, N'Rafael Delalibera Rodrigues')
SET IDENTITY_INSERT [dbo].[Pessoa] OFF
/****** Object:  Table [dbo].[Localizacao]      01:00:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Localizacao]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Localizacao](
	[nsu_Localizacao] [int] IDENTITY(1,1) NOT NULL,
	[nm_Localizacao] [varchar](90) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_Localizacao] PRIMARY KEY CLUSTERED 
(
	[nsu_Localizacao] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Imagem]      01:00:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Imagem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Imagem](
	[nsu_Imagem] [int] NOT NULL,
	[img_Imagem] [image] NULL,
	[tp_imagem] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_Imagem] PRIMARY KEY CLUSTERED 
(
	[nsu_Imagem] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Filme_TipoMidia]      01:00:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Filme_TipoMidia]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Filme_TipoMidia](
	[nsu_TipoMidia] [int] IDENTITY(1,1) NOT NULL,
	[nm_TipoMidia] [varchar](30) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_Filmes_TipoMidia] PRIMARY KEY CLUSTERED 
(
	[nsu_TipoMidia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Filme_TipoMidia] ON
INSERT [dbo].[Filme_TipoMidia] ([nsu_TipoMidia], [nm_TipoMidia]) VALUES (1, N'DVD Original')
INSERT [dbo].[Filme_TipoMidia] ([nsu_TipoMidia], [nm_TipoMidia]) VALUES (2, N'DVD Cópia')
INSERT [dbo].[Filme_TipoMidia] ([nsu_TipoMidia], [nm_TipoMidia]) VALUES (3, N'VCD')
INSERT [dbo].[Filme_TipoMidia] ([nsu_TipoMidia], [nm_TipoMidia]) VALUES (4, N'HD')
INSERT [dbo].[Filme_TipoMidia] ([nsu_TipoMidia], [nm_TipoMidia]) VALUES (5, N'BOX Original')
SET IDENTITY_INSERT [dbo].[Filme_TipoMidia] OFF
/****** Object:  Table [dbo].[Filme_Genero]      01:00:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Filme_Genero]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Filme_Genero](
	[nsu_Genero] [int] IDENTITY(1,1) NOT NULL,
	[nm_Genero] [varchar](30) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_Filme_Genero] PRIMARY KEY CLUSTERED 
(
	[nsu_Genero] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Filme_Genero] ON
INSERT [dbo].[Filme_Genero] ([nsu_Genero], [nm_Genero]) VALUES (1, N'Ação')
INSERT [dbo].[Filme_Genero] ([nsu_Genero], [nm_Genero]) VALUES (2, N'Animação')
INSERT [dbo].[Filme_Genero] ([nsu_Genero], [nm_Genero]) VALUES (3, N'Aventura')
INSERT [dbo].[Filme_Genero] ([nsu_Genero], [nm_Genero]) VALUES (4, N'Comédia')
INSERT [dbo].[Filme_Genero] ([nsu_Genero], [nm_Genero]) VALUES (5, N'Comédia Romântica')
SET IDENTITY_INSERT [dbo].[Filme_Genero] OFF
/****** Object:  StoredProcedure [dbo].[crud_Filme_Genero_upd]      01:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[crud_Filme_Genero_upd]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[crud_Filme_Genero_upd]
(
	@nsu_Genero	INT,
	@nm_Genero	VARCHAR(30)
) 
AS 

UPDATE	Filme_Genero
SET	nm_Genero = @nm_Genero
WHERE	nsu_Genero = @nsu_Genero

RETURN
' 
END
GO
/****** Object:  StoredProcedure [dbo].[crud_Filme_Genero_sel]      01:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[crud_Filme_Genero_sel]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[crud_Filme_Genero_sel]
(
	@nsu_Genero	INT
) 
AS 

SELECT	*
FROM	Filme_Genero
WHERE	nsu_Genero = @nsu_Genero

RETURN
' 
END
GO
/****** Object:  StoredProcedure [dbo].[crud_Filme_Genero_list]      01:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[crud_Filme_Genero_list]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[crud_Filme_Genero_list]

AS

SELECT	*
FROM	Filme_Genero
ORDER BY nm_Genero


' 
END
GO
/****** Object:  StoredProcedure [dbo].[crud_Filme_Genero_ins]      01:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[crud_Filme_Genero_ins]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[crud_Filme_Genero_ins]
(
	@nm_Genero	VARCHAR(30)
)
AS

INSERT Filme_Genero
( 
	nm_Genero
)
VALUES
( 
	@nm_Genero
)

RETURN


' 
END
GO
/****** Object:  Table [dbo].[Filme]      01:00:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Filme]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Filme](
	[nsu_Filme] [int] IDENTITY(1,1) NOT NULL,
	[nm_Filme] [varchar](90) COLLATE Latin1_General_CI_AS NULL,
	[nsu_Imagem] [int] NULL,
	[nsu_Genero] [int] NULL,
	[nsu_TipoMidia] [int] NULL,
	[dt_Aquisicao] [smalldatetime] NULL,
	[nsu_Localizacao] [int] NULL,
 CONSTRAINT [PK_Filmes] PRIMARY KEY CLUSTERED 
(
	[nsu_Filme] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[crud_Pessoa_upd]      01:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[crud_Pessoa_upd]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[crud_Pessoa_upd]
(
	@nsu_Pessoa	INT,
	@nm_Pessoa	VARCHAR(30)
) 
AS 

UPDATE	Pessoa
SET	nm_Pessoa = @nm_Pessoa
WHERE	nsu_Pessoa = @nsu_Pessoa

RETURN


' 
END
GO
/****** Object:  StoredProcedure [dbo].[crud_Pessoa_sel]      01:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[crud_Pessoa_sel]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[crud_Pessoa_sel]
(
	@nsu_Pessoa	INT
) 
AS 

SELECT	*
FROM	Pessoa
WHERE	nsu_Pessoa = @nsu_Pessoa

RETURN


' 
END
GO
/****** Object:  StoredProcedure [dbo].[crud_Pessoa_list]      01:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[crud_Pessoa_list]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[crud_Pessoa_list]

AS

SELECT	*
FROM	Pessoa
ORDER BY nm_Pessoa



' 
END
GO
/****** Object:  StoredProcedure [dbo].[crud_Pessoa_ins]      01:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[crud_Pessoa_ins]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[crud_Pessoa_ins]
(
  @nm_Pessoa	VARCHAR(30)
)
AS

INSERT Pessoa
( 
	nm_Pessoa
)
VALUES
( 
	@nm_Pessoa
)

RETURN


' 
END
GO
/****** Object:  StoredProcedure [dbo].[crud_Localizacao_upd]      01:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[crud_Localizacao_upd]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[crud_Localizacao_upd]
(
	@nsu_Localizacao	INT,
	@nm_Localizacao		VARCHAR(30)
) 
AS 

UPDATE	Localizacao
SET	nm_Localizacao = @nm_Localizacao
WHERE	nsu_Localizacao = @nsu_Localizacao

RETURN
' 
END
GO
/****** Object:  StoredProcedure [dbo].[crud_Localizacao_sel]      01:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[crud_Localizacao_sel]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[crud_Localizacao_sel]
(
	@nsu_Localizacao	INT
) 
AS 

SELECT	*
FROM	Localizacao
WHERE	nsu_Localizacao = @nsu_Localizacao

RETURN
' 
END
GO
/****** Object:  StoredProcedure [dbo].[crud_Localizacao_list]      01:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[crud_Localizacao_list]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[crud_Localizacao_list]

AS

SELECT	*
FROM	Localizacao
ORDER BY nm_Localizacao

' 
END
GO
/****** Object:  StoredProcedure [dbo].[crud_Localizacao_ins]      01:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[crud_Localizacao_ins]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[crud_Localizacao_ins]
(
  @nm_Localizacao	VARCHAR(30)
)
AS

INSERT Localizacao
( 
	nm_Localizacao
)
VALUES
( 
	@nm_Localizacao
)

RETURN
' 
END
GO
/****** Object:  StoredProcedure [dbo].[crud_Filme_TipoMidia_upd]      01:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[crud_Filme_TipoMidia_upd]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[crud_Filme_TipoMidia_upd]
(
	@nsu_TipoMidia	INT,
	@nm_TipoMidia	VARCHAR(30)
) 
AS 

UPDATE	Filme_TipoMidia
SET	nm_TipoMidia = @nm_TipoMidia
WHERE	nsu_TipoMidia = @nsu_TipoMidia

RETURN
' 
END
GO
/****** Object:  StoredProcedure [dbo].[crud_Filme_TipoMidia_sel]      01:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[crud_Filme_TipoMidia_sel]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[crud_Filme_TipoMidia_sel]
(
	@nsu_TipoMidia	INT
) 
AS 

SELECT	*
FROM	Filme_TipoMidia
WHERE	nsu_TipoMidia = @nsu_TipoMidia

RETURN
' 
END
GO
/****** Object:  StoredProcedure [dbo].[crud_Filme_TipoMidia_list]      01:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[crud_Filme_TipoMidia_list]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[crud_Filme_TipoMidia_list]

AS

SELECT	*
FROM	Filme_TipoMidia
ORDER BY nm_TipoMidia
' 
END
GO
/****** Object:  StoredProcedure [dbo].[crud_Filme_TipoMidia_ins]      01:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[crud_Filme_TipoMidia_ins]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[crud_Filme_TipoMidia_ins]
(
	@nm_TipoMidia		VARCHAR(30)
)
AS

INSERT Filme_TipoMidia
( 
	nm_TipoMidia
)
VALUES
( 
	@nm_TipoMidia
)

RETURN


' 
END
GO
/****** Object:  Table [dbo].[Filme_Assistido]      01:00:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Filme_Assistido]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Filme_Assistido](
	[nsu_Assistido] [int] NOT NULL,
	[nsu_Filme] [int] NOT NULL,
	[dt_Assistido] [smalldatetime] NULL,
	[nsu_Pessoa] [int] NOT NULL,
 CONSTRAINT [PK_Filme_Assistido] PRIMARY KEY CLUSTERED 
(
	[nsu_Assistido] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [dbo].[crud_Filme_ins]      01:00:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[crud_Filme_ins]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[crud_Filme_ins]
(
	@nm_Filme		VARCHAR(90),
	@nsu_Genero		INT,
	@nsu_TipoMidia		INT,
	@nsu_Localizacao	INT,
	@dt_Aquisicao		SMALLDATETIME
)
AS

INSERT Filme
( 
	nm_Filme,
	nsu_Genero,
	nsu_TipoMidia,
	nsu_Localizacao,
	dt_Aquisicao,
	nsu_Imagem
)
VALUES
( 
	@nm_Filme,
	@nsu_Genero,
	@nsu_TipoMidia,
	@nsu_Localizacao,
	@dt_Aquisicao,
	NULL
)

select nsu_Filme = @@identity

RETURN




' 
END
GO
/****** Object:  ForeignKey [FK_Filme_Filme_Genero]      01:00:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Filme_Filme_Genero]') AND parent_object_id = OBJECT_ID(N'[dbo].[Filme]'))
ALTER TABLE [dbo].[Filme]  WITH NOCHECK ADD  CONSTRAINT [FK_Filme_Filme_Genero] FOREIGN KEY([nsu_Genero])
REFERENCES [dbo].[Filme_Genero] ([nsu_Genero])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Filme_Filme_Genero]') AND parent_object_id = OBJECT_ID(N'[dbo].[Filme]'))
ALTER TABLE [dbo].[Filme] CHECK CONSTRAINT [FK_Filme_Filme_Genero]
GO
/****** Object:  ForeignKey [FK_Filme_Filme_TipoMidia]      01:00:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Filme_Filme_TipoMidia]') AND parent_object_id = OBJECT_ID(N'[dbo].[Filme]'))
ALTER TABLE [dbo].[Filme]  WITH NOCHECK ADD  CONSTRAINT [FK_Filme_Filme_TipoMidia] FOREIGN KEY([nsu_TipoMidia])
REFERENCES [dbo].[Filme_TipoMidia] ([nsu_TipoMidia])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Filme_Filme_TipoMidia]') AND parent_object_id = OBJECT_ID(N'[dbo].[Filme]'))
ALTER TABLE [dbo].[Filme] CHECK CONSTRAINT [FK_Filme_Filme_TipoMidia]
GO
/****** Object:  ForeignKey [FK_Filme_Imagem]      01:00:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Filme_Imagem]') AND parent_object_id = OBJECT_ID(N'[dbo].[Filme]'))
ALTER TABLE [dbo].[Filme]  WITH NOCHECK ADD  CONSTRAINT [FK_Filme_Imagem] FOREIGN KEY([nsu_Imagem])
REFERENCES [dbo].[Imagem] ([nsu_Imagem])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Filme_Imagem]') AND parent_object_id = OBJECT_ID(N'[dbo].[Filme]'))
ALTER TABLE [dbo].[Filme] CHECK CONSTRAINT [FK_Filme_Imagem]
GO
/****** Object:  ForeignKey [FK_Filme_Localizacao]      01:00:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Filme_Localizacao]') AND parent_object_id = OBJECT_ID(N'[dbo].[Filme]'))
ALTER TABLE [dbo].[Filme]  WITH NOCHECK ADD  CONSTRAINT [FK_Filme_Localizacao] FOREIGN KEY([nsu_Localizacao])
REFERENCES [dbo].[Localizacao] ([nsu_Localizacao])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Filme_Localizacao]') AND parent_object_id = OBJECT_ID(N'[dbo].[Filme]'))
ALTER TABLE [dbo].[Filme] CHECK CONSTRAINT [FK_Filme_Localizacao]
GO
/****** Object:  ForeignKey [FK_Filme_Assistido_Filme]      01:00:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Filme_Assistido_Filme]') AND parent_object_id = OBJECT_ID(N'[dbo].[Filme_Assistido]'))
ALTER TABLE [dbo].[Filme_Assistido]  WITH NOCHECK ADD  CONSTRAINT [FK_Filme_Assistido_Filme] FOREIGN KEY([nsu_Filme])
REFERENCES [dbo].[Filme] ([nsu_Filme])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Filme_Assistido_Filme]') AND parent_object_id = OBJECT_ID(N'[dbo].[Filme_Assistido]'))
ALTER TABLE [dbo].[Filme_Assistido] CHECK CONSTRAINT [FK_Filme_Assistido_Filme]
GO
/****** Object:  ForeignKey [FK_Filme_Assistido_Pessoa]      01:00:49 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Filme_Assistido_Pessoa]') AND parent_object_id = OBJECT_ID(N'[dbo].[Filme_Assistido]'))
ALTER TABLE [dbo].[Filme_Assistido]  WITH NOCHECK ADD  CONSTRAINT [FK_Filme_Assistido_Pessoa] FOREIGN KEY([nsu_Pessoa])
REFERENCES [dbo].[Pessoa] ([nsu_Pessoa])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Filme_Assistido_Pessoa]') AND parent_object_id = OBJECT_ID(N'[dbo].[Filme_Assistido]'))
ALTER TABLE [dbo].[Filme_Assistido] CHECK CONSTRAINT [FK_Filme_Assistido_Pessoa]
GO
