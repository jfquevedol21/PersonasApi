USE [Personas]
GO
/****** Object:  Table [dbo].[Documento]    Script Date: 10/3/2022 9:49:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documento](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Abreviatura] [nvarchar](50) NULL,
 CONSTRAINT [PK_Documento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genero]    Script Date: 10/3/2022 9:49:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genero](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[GeneroName] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Genero] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 10/3/2022 9:49:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdDocumento] [tinyint] NOT NULL,
	[IdGenero] [tinyint] NOT NULL,
	[Nombre] [nchar](50) NULL,
	[Apellido] [nchar](50) NULL,
	[NumeroDocumento] [nchar](100) NOT NULL,
	[FechaNacimiento] [date] NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[FechaActualizacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Documento] ON 

INSERT [dbo].[Documento] ([Id], [Nombre], [Abreviatura]) VALUES (1, N'Cedula de ciudadania', N'CC')
INSERT [dbo].[Documento] ([Id], [Nombre], [Abreviatura]) VALUES (2, N'Tarjeta de Identidad', N'TI')
INSERT [dbo].[Documento] ([Id], [Nombre], [Abreviatura]) VALUES (4, N'Registro Civil', N'RC')
INSERT [dbo].[Documento] ([Id], [Nombre], [Abreviatura]) VALUES (5, N'Pasaporte', N'PA')
INSERT [dbo].[Documento] ([Id], [Nombre], [Abreviatura]) VALUES (12, N'Matricula de Mascotas', N'MM')
INSERT [dbo].[Documento] ([Id], [Nombre], [Abreviatura]) VALUES (13, N'Cédula de extranjería', N'CE')
SET IDENTITY_INSERT [dbo].[Documento] OFF
GO
SET IDENTITY_INSERT [dbo].[Genero] ON 

INSERT [dbo].[Genero] ([Id], [GeneroName]) VALUES (2, N'Masculino                                         ')
INSERT [dbo].[Genero] ([Id], [GeneroName]) VALUES (3, N'Femenino                                          ')
INSERT [dbo].[Genero] ([Id], [GeneroName]) VALUES (4, N'No binario                                        ')
INSERT [dbo].[Genero] ([Id], [GeneroName]) VALUES (13, N'Creativo                                          ')
INSERT [dbo].[Genero] ([Id], [GeneroName]) VALUES (14, N'DEC                                               ')
SET IDENTITY_INSERT [dbo].[Genero] OFF
GO
SET IDENTITY_INSERT [dbo].[Persona] ON 

INSERT [dbo].[Persona] ([Id], [IdDocumento], [IdGenero], [Nombre], [Apellido], [NumeroDocumento], [FechaNacimiento], [FechaCreacion], [FechaActualizacion]) VALUES (1, 1, 2, N'Fer                                               ', N'string                                            ', N'1111                                                                                                ', CAST(N'2022-10-03' AS Date), CAST(N'2022-10-02T23:57:09.730' AS DateTime), CAST(N'2022-10-02T23:57:09.730' AS DateTime))
INSERT [dbo].[Persona] ([Id], [IdDocumento], [IdGenero], [Nombre], [Apellido], [NumeroDocumento], [FechaNacimiento], [FechaCreacion], [FechaActualizacion]) VALUES (2, 1, 3, N'Sonia                                             ', N'Lozano                                            ', N'1231231                                                                                             ', CAST(N'2022-10-03' AS Date), CAST(N'2022-10-03T00:23:06.213' AS DateTime), CAST(N'2022-10-03T00:24:02.803' AS DateTime))
INSERT [dbo].[Persona] ([Id], [IdDocumento], [IdGenero], [Nombre], [Apellido], [NumeroDocumento], [FechaNacimiento], [FechaCreacion], [FechaActualizacion]) VALUES (4, 1, 2, N'string                                            ', NULL, N'string                                                                                              ', CAST(N'2022-10-03' AS Date), CAST(N'2022-10-03T02:11:24.810' AS DateTime), CAST(N'2022-10-03T02:11:24.810' AS DateTime))
INSERT [dbo].[Persona] ([Id], [IdDocumento], [IdGenero], [Nombre], [Apellido], [NumeroDocumento], [FechaNacimiento], [FechaCreacion], [FechaActualizacion]) VALUES (5, 1, 2, N'sdf                                               ', NULL, N'string                                                                                              ', CAST(N'2022-10-03' AS Date), CAST(N'2022-10-03T02:13:27.450' AS DateTime), CAST(N'2022-10-03T02:13:27.450' AS DateTime))
INSERT [dbo].[Persona] ([Id], [IdDocumento], [IdGenero], [Nombre], [Apellido], [NumeroDocumento], [FechaNacimiento], [FechaCreacion], [FechaActualizacion]) VALUES (6, 1, 4, N'Adulto                                            ', N'Soy                                               ', N'5757                                                                                                ', CAST(N'1967-10-03' AS Date), CAST(N'2022-10-03T03:02:14.397' AS DateTime), CAST(N'2022-10-03T03:02:14.397' AS DateTime))
SET IDENTITY_INSERT [dbo].[Persona] OFF
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_IdDocumento] FOREIGN KEY([IdDocumento])
REFERENCES [dbo].[Documento] ([Id])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_IdDocumento]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_IdGenero] FOREIGN KEY([IdGenero])
REFERENCES [dbo].[Genero] ([Id])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_IdGenero]
GO
