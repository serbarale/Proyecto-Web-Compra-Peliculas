USE [master]
GO
/****** Object:  Database [PELICULAS]    Script Date: 6/25/2023 16:55:02 ******/
CREATE DATABASE [PELICULAS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PELICULAS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PELICULAS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PELICULAS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PELICULAS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PELICULAS] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PELICULAS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PELICULAS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PELICULAS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PELICULAS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PELICULAS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PELICULAS] SET ARITHABORT OFF 
GO
ALTER DATABASE [PELICULAS] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PELICULAS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PELICULAS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PELICULAS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PELICULAS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PELICULAS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PELICULAS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PELICULAS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PELICULAS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PELICULAS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PELICULAS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PELICULAS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PELICULAS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PELICULAS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PELICULAS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PELICULAS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PELICULAS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PELICULAS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PELICULAS] SET  MULTI_USER 
GO
ALTER DATABASE [PELICULAS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PELICULAS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PELICULAS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PELICULAS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PELICULAS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PELICULAS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PELICULAS] SET QUERY_STORE = OFF
GO
USE [PELICULAS]
GO
/****** Object:  Table [dbo].[TB_ADMINISTRADORES]    Script Date: 6/25/2023 16:55:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_ADMINISTRADORES](
	[Id_Administrador] [int] IDENTITY(1,1) NOT NULL,
	[NombreAdministrador] [varchar](30) NOT NULL,
	[ApellidoAdministrador] [varchar](30) NOT NULL,
	[CorreoAdministrador] [varchar](30) NOT NULL,
	[UsuarioAdmin] [varchar](30) NOT NULL,
	[PasswordAdministrador] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Administradores] PRIMARY KEY CLUSTERED 
(
	[Id_Administrador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_CLIENTE]    Script Date: 6/25/2023 16:55:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_CLIENTE](
	[Id_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[NombreCliente] [varchar](30) NOT NULL,
	[ApellidoCliente] [varchar](30) NOT NULL,
	[CorreoCliente] [varchar](50) NOT NULL,
	[UsuarioCliente] [varchar](30) NOT NULL,
	[PasswordCliente] [varchar](30) NOT NULL,
	[DireccionCliente] [varchar](50) NULL,
	[DistritoCliente] [varchar](30) NULL,
	[ProvinciaCliente] [varchar](30) NULL,
	[TarjetaNuestraCliente] [varchar](10) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_DETALLECOMPRA]    Script Date: 6/25/2023 16:55:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_DETALLECOMPRA](
	[Id_Detalle] [int] IDENTITY(1,1) NOT NULL,
	[Id_Factura] [int] NOT NULL,
	[Id_Pelicula] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio_Unitario] [decimal](18, 2) NOT NULL,
	[Sub_Total] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_DetalleCompra] PRIMARY KEY CLUSTERED 
(
	[Id_Detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_FACTURA]    Script Date: 6/25/2023 16:55:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_FACTURA](
	[Id_Factura] [int] IDENTITY(1,1) NOT NULL,
	[Id_Cliente] [int] NOT NULL,
	[Id_Administrador] [int] NOT NULL,
	[Fecha_Factura] [date] NOT NULL,
	[Descuento] [float] NULL,
	[Total] [float] NULL,
	[FormaDePago] [varchar](30) NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[Id_Factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_GENERO]    Script Date: 6/25/2023 16:55:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_GENERO](
	[Id_Genero] [int] IDENTITY(1,1) NOT NULL,
	[NombreGenero] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Genero] PRIMARY KEY CLUSTERED 
(
	[Id_Genero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_PELICULAS]    Script Date: 6/25/2023 16:55:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_PELICULAS](
	[Id_Pelicula] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](50) NOT NULL,
	[Genero_Id] [int] NOT NULL,
	[Duracion] [int] NULL,
	[Sinopsis] [text] NULL,
	[FechaLanzamiento] [date] NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[ImagenUrl] [varchar](max) NULL,
 CONSTRAINT [PK_Peliculas] PRIMARY KEY CLUSTERED 
(
	[Id_Pelicula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_TARJETA_CLIENTE]    Script Date: 6/25/2023 16:55:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_TARJETA_CLIENTE](
	[Id_TarjetaC] [int] IDENTITY(1,1) NOT NULL,
	[Id_Cliente] [int] NOT NULL,
	[Numero_Tarjeta] [varchar](30) NOT NULL,
	[Tipo_Tarjeta] [varchar](30) NOT NULL,
	[Cantidad] [decimal](18, 2) NOT NULL,
	[Fecha_Movimiento] [date] NOT NULL,
 CONSTRAINT [PK_Tarjeta_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id_TarjetaC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_TARJETA_EMPRESA]    Script Date: 6/25/2023 16:55:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_TARJETA_EMPRESA](
	[Id_Tarjeta] [int] IDENTITY(1,1) NOT NULL,
	[Id_Cliente] [int] NOT NULL,
	[Tipo_Movimiento] [varchar](30) NOT NULL,
	[Saldo] [decimal](18, 2) NOT NULL,
	[Puntos_Acumulados] [int] NOT NULL,
	[Fecha_Movimiento] [date] NOT NULL,
	[Numero_Tarjeta] [varchar](30) NULL,
 CONSTRAINT [PK_Tarjeta_Empresa] PRIMARY KEY CLUSTERED 
(
	[Id_Tarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_TARJETA_RECARGAS]    Script Date: 6/25/2023 16:55:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_TARJETA_RECARGAS](
	[Id_Tarjeta_Recarga] [int] IDENTITY(1,1) NOT NULL,
	[Id_Tarjeta_Empresa] [int] NOT NULL,
	[Forma_Recarga] [varchar](30) NOT NULL,
	[Numero_Recibo] [varchar](30) NOT NULL,
	[Cantidad] [decimal](18, 2) NOT NULL,
	[Fecha_Recargar] [date] NOT NULL,
 CONSTRAINT [PK_Tarjeta_Recargas] PRIMARY KEY CLUSTERED 
(
	[Id_Tarjeta_Recarga] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TB_ADMINISTRADORES] ON 
GO
INSERT [dbo].[TB_ADMINISTRADORES] ([Id_Administrador], [NombreAdministrador], [ApellidoAdministrador], [CorreoAdministrador], [UsuarioAdmin], [PasswordAdministrador]) VALUES (1, N'Joseph', N'Chombo', N'joseph@buymyfilms.com', N'pepe', N'123456')
GO
INSERT [dbo].[TB_ADMINISTRADORES] ([Id_Administrador], [NombreAdministrador], [ApellidoAdministrador], [CorreoAdministrador], [UsuarioAdmin], [PasswordAdministrador]) VALUES (2, N'Junior', N'Perez', N'junior@buymyfilms.com', N'prueba', N'qwerty')
GO
INSERT [dbo].[TB_ADMINISTRADORES] ([Id_Administrador], [NombreAdministrador], [ApellidoAdministrador], [CorreoAdministrador], [UsuarioAdmin], [PasswordAdministrador]) VALUES (3, N'Sebastian', N'Barrantes', N'sebastian@buymyfilms.com', N'sebarran', N'12345mn')
GO
SET IDENTITY_INSERT [dbo].[TB_ADMINISTRADORES] OFF
GO
SET IDENTITY_INSERT [dbo].[TB_CLIENTE] ON 
GO
INSERT [dbo].[TB_CLIENTE] ([Id_Cliente], [NombreCliente], [ApellidoCliente], [CorreoCliente], [UsuarioCliente], [PasswordCliente], [DireccionCliente], [DistritoCliente], [ProvinciaCliente], [TarjetaNuestraCliente]) VALUES (8, N'joseph jjjj', N'chombo', N'josepg@gmail.com', N'jose12', N'123', N'lima', N'LINCE', N'LIMA', N'SI')
GO
INSERT [dbo].[TB_CLIENTE] ([Id_Cliente], [NombreCliente], [ApellidoCliente], [CorreoCliente], [UsuarioCliente], [PasswordCliente], [DireccionCliente], [DistritoCliente], [ProvinciaCliente], [TarjetaNuestraCliente]) VALUES (9, N'calrlos', N'werwq', N'dfsdf@gmaio.com', N'wer2', N'123', N'lima', N'LINCE', N'LIMA', N'SI')
GO
SET IDENTITY_INSERT [dbo].[TB_CLIENTE] OFF
GO
SET IDENTITY_INSERT [dbo].[TB_DETALLECOMPRA] ON 
GO
INSERT [dbo].[TB_DETALLECOMPRA] ([Id_Detalle], [Id_Factura], [Id_Pelicula], [Cantidad], [Precio_Unitario], [Sub_Total]) VALUES (1, 2, 1, 1, CAST(12.99 AS Decimal(18, 2)), CAST(12.99 AS Decimal(18, 2)))
GO
INSERT [dbo].[TB_DETALLECOMPRA] ([Id_Detalle], [Id_Factura], [Id_Pelicula], [Cantidad], [Precio_Unitario], [Sub_Total]) VALUES (2, 3, 1, 20, CAST(12.99 AS Decimal(18, 2)), CAST(259.80 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[TB_DETALLECOMPRA] OFF
GO
SET IDENTITY_INSERT [dbo].[TB_FACTURA] ON 
GO
INSERT [dbo].[TB_FACTURA] ([Id_Factura], [Id_Cliente], [Id_Administrador], [Fecha_Factura], [Descuento], [Total], [FormaDePago]) VALUES (2, 8, 2, CAST(N'2023-06-02' AS Date), 1, 12.989999771118164, N'TARJETA DE LA EMPRESA')
GO
INSERT [dbo].[TB_FACTURA] ([Id_Factura], [Id_Cliente], [Id_Administrador], [Fecha_Factura], [Descuento], [Total], [FormaDePago]) VALUES (3, 8, 2, CAST(N'2023-06-02' AS Date), 1, 259.79998779296875, N'TARJETA DE LA EMPRESA')
GO
SET IDENTITY_INSERT [dbo].[TB_FACTURA] OFF
GO
SET IDENTITY_INSERT [dbo].[TB_GENERO] ON 
GO
INSERT [dbo].[TB_GENERO] ([Id_Genero], [NombreGenero]) VALUES (1, N'Accion
')
GO
INSERT [dbo].[TB_GENERO] ([Id_Genero], [NombreGenero]) VALUES (2, N'Aventura
')
GO
INSERT [dbo].[TB_GENERO] ([Id_Genero], [NombreGenero]) VALUES (3, N'Comedia
')
GO
INSERT [dbo].[TB_GENERO] ([Id_Genero], [NombreGenero]) VALUES (4, N'Drama
')
GO
INSERT [dbo].[TB_GENERO] ([Id_Genero], [NombreGenero]) VALUES (5, N'Terror')
GO
INSERT [dbo].[TB_GENERO] ([Id_Genero], [NombreGenero]) VALUES (6, N'Ciencia ficcion')
GO
INSERT [dbo].[TB_GENERO] ([Id_Genero], [NombreGenero]) VALUES (7, N'Animación')
GO
INSERT [dbo].[TB_GENERO] ([Id_Genero], [NombreGenero]) VALUES (8, N'Romance')
GO
INSERT [dbo].[TB_GENERO] ([Id_Genero], [NombreGenero]) VALUES (9, N'Thriller')
GO
INSERT [dbo].[TB_GENERO] ([Id_Genero], [NombreGenero]) VALUES (10, N'Fantasía')
GO
INSERT [dbo].[TB_GENERO] ([Id_Genero], [NombreGenero]) VALUES (11, N'Documental')
GO
INSERT [dbo].[TB_GENERO] ([Id_Genero], [NombreGenero]) VALUES (12, N'Suspenso')
GO
INSERT [dbo].[TB_GENERO] ([Id_Genero], [NombreGenero]) VALUES (13, N'Misterio')
GO
SET IDENTITY_INSERT [dbo].[TB_GENERO] OFF
GO
SET IDENTITY_INSERT [dbo].[TB_PELICULAS] ON 
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (1, N'Avengers: Endgame', 1, 182, N'Después de que Thanos aniquiló a la mitad del universo, los Vengadores restantes se unen en un último intento de deshacer las devastadoras consecuencias del chasquido del infinito.', CAST(N'2019-04-26' AS Date), CAST(12.99 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=1vbKXrceisGYfe_Td-OPRCZevMaQe0HnX
')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (2, N'La La Land', 4, 128, N'En medio del bullicio de Los Ángeles, un pianista de jazz y una aspirante a actriz se enamoran y luchan por equilibrar sus ambiciones profesionales con la creciente atracción entre ellos.', CAST(N'2016-12-09' AS Date), CAST(9.99 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=12-l1aLUpbdbREQJTj1qnudasAby0vcgX
')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (3, N'El Padrino', 1, 175, N'En el mundo del crimen organizado, la familia Corleone lucha por mantener su poder mientras los enemigos y las rivalidades internas amenazan con destruir todo lo que han construido.', CAST(N'1972-03-24' AS Date), CAST(7.99 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=1CDuqSgYL12LfMohQUQ2y9-yoMvvGDuJ-
')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (4, N'El Conjuro', 5, 112, N'Una pareja de investigadores paranormales se enfrenta a una aterradora presencia en una casa embrujada, desatando una serie de eventos sobrenaturales que pondrán sus vidas en peligro.', CAST(N'2013-08-02' AS Date), CAST(6.99 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=1pt9rjqMOZsdLgWAtffwd2hz5G1Bbefh7
')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (5, N'Volver al Futuro', 6, 116, N'Marty McFly viaja accidentalmente en el tiempo a 1955 y debe asegurarse de que sus padres se enamoren para poder regresar al futuro, mientras evita alterar el curso de la historia.', CAST(N'1985-07-03' AS Date), CAST(8.99 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=1Ef413DqyrAKlMVmZhNxvrIlAwcuVuwWQ
')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (6, N'Buscando a Nemo', 7, 100, N'Cuando el pez payaso Marlin pierde a su hijo Nemo, se embarca en una emocionante aventura por el océano para encontrarlo, enfrentándose a peligros y haciendo nuevos amigos en el camino.', CAST(N'2003-05-30' AS Date), CAST(5.99 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=1Lbw5ordgUOlX7pQTdraf2pPQmfMs_hX3
')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (7, N'Fall', 9, 146, N'Para los mejores amigos Becky y Hunter, la vida se trata de conquistar miedos y superar límites. Sin embargo, después de escalar 2,000 pies hasta la cima de una torre de radio remota y abandonada, se encuentran atrapados sin forma de bajar. Ahora, sus habilidades expertas en escalada se ponen a prueba mientras luchan desesperadamente por sobrevivir a los elementos, la falta de suministros y alturas que inducen vértigo.', CAST(N'2022-08-22' AS Date), CAST(7.99 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=1mHKWVdFz2yx5e3SL68bYiG-sI_LqA0gD
')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (8, N'Titanic', 8, 107, N'En el trágico viaje inaugural del RMS Titanic, un joven artista se enamora de una mujer comprometida, mientras ambos luchan por sobrevivir cuando el barco se hunde en las gélidas aguas del Atlántico.', CAST(N'1998-01-23' AS Date), CAST(10.99 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=1yQ0n8-EbFz6hA6kVYb2o0ffZVJVs35Pc
')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (9, N'La vida de Pi', 2, 127, N'Después de decidir vender su zoológico en India y mudarse a Canadá, Santosh y Gita Patel abordan un barco de carga junto a sus hijos y algunos animales restantes. La tragedia golpea cuando una terrible tormenta hunde el barco, dejando al hijo adolescente de los Patel, Pi (Suraj Sharma), como el único sobreviviente humano. Sin embargo, Pi no está solo; un temible tigre de Bengala también ha encontrado refugio a bordo del bote salvavidas. A medida que los días se convierten en semanas y las semanas se arrastran en meses, Pi y el tigre deben aprender a confiar el uno en el otro si ambos quieren sobrevivir.', CAST(N'2012-12-27' AS Date), CAST(12.88 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=1yaGiQygDOQ028dU5Ens0BfFzbTKvL6i9
')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (10, N'Interestelar', 6, 169, N'En un futuro donde la Tierra se está volviendo inhabitable, un grupo de astronautas se embarca en un viaje espacial en busca de un nuevo hogar para la humanidad.', CAST(N'2014-11-05' AS Date), CAST(10.49 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=1LHyC6QMSc3QEe44D09Npt2oUUlAo4B3Q
')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (11, N'Avatar: La Forma del Agua', 10, 117, N'Jake, Neytiri y sus tres hijos tienen muchos problemas a los que enfrentarse, por lo que tendrán que cambiar su vida para intentar mantenerse a salvo. Por el camino, batallas que libran con antiguos enemigos y muchas tragedias.', CAST(N'2022-12-16' AS Date), CAST(13.12 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=1m3Bm01MHzzqG3gMimQZ8g3uKu924ApjX
')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (12, N'Smile', 12, 118, N'Después de presenciar un incidente traumático y extraño que involucra a un paciente, la Dra. Rose Cotter comienza a experimentar sucesos aterradores que no puede explicar. A medida que un terror abrumador comienza a apoderarse de su vida, Rose debe enfrentar su problemático pasado para poder sobrevivir y escapar de su espantosa nueva realidad.', CAST(N'2022-07-30' AS Date), CAST(8.99 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=1zYPhpZ_dU4uhho7asnkGHmNKjXk2eB5g
')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (13, N'Blade Runner', 13, 117, N'En un futuro distópico, un cazador de androides persigue a replicantes fugitivos en una ciudad lluviosa y oscura.', CAST(N'2017-06-25' AS Date), CAST(7.99 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=19pcmpBxeRbyYWEQneBAQbrs0G2TPjrc_
')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (14, N'El Señor de los Anillos: La Comunidad del Anillo', 6, 178, N'Un joven hobbit se embarca en una aventura épica para destruir un poderoso anillo y salvar a la Tierra Media de la oscuridad.', CAST(N'2001-12-19' AS Date), CAST(10.99 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=1UbmY9jGWXDf-_yxg9BvkPMtbVIlQ4El5
')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (15, N'Bienvenidos al Wrexham', 11, 154, N'En 2020, Rob y Ryan se asocian para comprar los Red Dragons de la quinta categoría con la esperanza de convertir al Wrexham Football Club en una historia de desaventajados que todo el mundo pueda apoyar. ¿El problema? Rob y Ryan no tienen experiencia en el fútbol ni trabajando juntos.', CAST(N'2022-08-22' AS Date), CAST(8.99 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=1PCbcqNPurjrjYROBXkgp6596DY2TLRSm
')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (16, N'El Rey León', 7, 88, N'Un joven león debe enfrentarse a la adversidad y reclamar su lugar como rey de la sabana en esta película animada de Disney.', CAST(N'1994-06-15' AS Date), CAST(5.99 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=1_LeiGzIoPOJFXIvJJniQ3fUKKiPYZh38
')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (17, N'Forrest Gump', 3, 142, N'Forrest Gump narra su extraordinaria vida llena de eventos históricos y personajes inolvidables.', CAST(N'1994-07-06' AS Date), CAST(8.99 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=1QFL97jLQ0onGotkwaKueu5oA4XeEQR9I
')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (18, N'The Super Mario Bros. Movie', 7, 92, N'Mario y Luigi, dos intrépidos fontaneros, se adentran en un mundo oculto para rescatar a la Princesa Peach, secuestrada por el malvado Rey Bowser. Enfrentándose a un ejército de setas animadas y superando peligrosas rutas de ladrillos y castillos, los hermanos deberán mostrar su valentía y habilidades para cumplir su misión y salvar el reino de las garras del villano.', CAST(N'2023-04-05' AS Date), CAST(18.96 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=1GcyUDuhjCIGkbfv1OZgnwThAr1YB7BXZ
')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (19, N'Misterio a la Vista', 13, 90, N'Un policía de Nueva York y su esposa van de vacaciones a Europa para revitalizar la chispa en su matrimonio. Un encuentro fortuito los lleva a ser acusados ??por el asesinato de un multimillonario anciano.', CAST(N'2019-07-14' AS Date), CAST(19.99 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=14EibFaRhyY9XsYltoxdqlqYgSlv3jdd2
')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (20, N'Free Guy', 6, 115, N'Cuando un cajero de banco descubre que en realidad es un personaje secundario en un videojuego de mundo abierto, decide convertirse en el héroe de su propia historia, una que puede reescribir él mismo. En un mundo sin límites, está decidido a salvar el día a su manera antes de que sea demasiado tarde, y tal vez encontrar un poco de romance con el programador que lo concibió.', CAST(N'2021-08-13' AS Date), CAST(15.12 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=1lKL_qeQuv1qEL3X5RGv2yphlaVdCOTal
')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (21, N'La noche del Demonio', 5, 103, N'Un grupo de padres (Patrick Wilson, Rose Byrne) toma medidas drásticas cuando parece que su nueva casa está siendo acosada por presencias sobrenaturales y su hijo en estado de coma está poseído por una entidad maligna.', CAST(N'2011-08-11' AS Date), CAST(9.22 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=1JMlIEQxK_tnnEl1C-EpEFXybLvIpV7oi
')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (22, N'Son como niños', 3, 101, N'Un hombre soltero que bebe demasiado. Un padre con tres hijas a las que rara vez ve. Un hombre con sobrepeso y desempleado. Un marido dominado por su esposa. Un exitoso agente de Hollywood casado con una diseñadora de moda. ¿Qué tienen en común estos cinco hombres? Solían jugar en el mismo equipo de baloncesto en la escuela. Ahora su antiguo entrenador ha fallecido y se reencuentran en su funeral. ¿Podrá el grupo redescubrir viejos lazos?', CAST(N'2010-08-19' AS Date), CAST(8.56 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=1EDV31IZqaQ5nN9FDRd1TFAkfCdr0uv4w
')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (23, N'Lightyear', 7, 105, N'El legendario ranger espacial Buzz Lightyear se embarca en una aventura intergaláctica junto a los ambiciosos reclutas Izzy, Mo, Darby y su compañero robot, Sox. Mientras esta disparatada tripulación enfrenta su misión más difícil hasta el momento, deben aprender a trabajar juntos como un equipo para escapar del malvado Zurg y su fiel ejército de robots, que nunca están muy lejos.', CAST(N'2022-06-17' AS Date), CAST(19.99 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=165hHO9va1w0xBYCfSfmDDTkE7vMb0fSc
')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (24, N'El niño de Pijama a Rayas', 4, 94, N'Durante la Segunda Guerra Mundial, el niño de 8 años Bruno y su familia se mudan de Berlín para vivir cerca del campo de concentración donde su padre acaba de convertirse en comandante. Infeliz y solitario, un día Bruno se aventura detrás de su casa y encuentra a Shmuel, un niño judío de su edad. Aunque la cerca de alambre de púas del campo los separa, los niños comienzan una amistad prohibida, sin ser conscientes de la verdadera naturaleza de su entorno.', CAST(N'2008-09-12' AS Date), CAST(6.46 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=1kUGX2gX7MU9FDXKheTiDmBoR7iLFxQi6
')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (25, N'Uncharted
', 2, 116, N'El cazador de tesoros Victor "Sully" Sullivan recluta al astuto Nathan Drake para ayudarlo a recuperar una fortuna perdida de 500 años acumulada por el explorador Ferdinand Magellan. Lo que comienza como un robo pronto se convierte en una carrera por todo el mundo, llena de emoción y tensión, para llegar al premio antes de que el despiadado Santiago Moncada pueda ponerle las manos encima. Si Sully y Nate pueden descifrar las pistas y resolver uno de los misterios más antiguos del mundo, podrían encontrar 5 mil millones de dólares en tesoro, pero solo si aprenden a trabajar juntos.
', CAST(N'2022-02-18' AS Date), CAST(13.25 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=1qnQ2MJ89IMHF9VSMD3MrGLD0fsJ-EH8X
')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (26, N'Peter Pan y Wendy', 10, 106, N'Wendy Darling, una joven que busca evitar ir a un internado, conoce a Peter Pan, un niño que se niega a crecer. Wendy, sus hermanos y Campanita viajan con Peter al mágico mundo de Nunca Jamás, donde se encuentran con un malvado capitán pirata.', CAST(N'2023-04-28' AS Date), CAST(21.99 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=d8vzM5huBYnFBWOcZ-rZHysMqhYUCaNv')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (27, N'The Black Phone', 12, 142, N'Finney Shaw es un chico tímido pero inteligente de 13 años que está siendo retenido en un sótano insonorizado por un asesino sádico y enmascarado. Cuando un teléfono desconectado en la pared comienza a sonar, pronto descubre que puede escuchar las voces de las víctimas anteriores del asesino, y están decididas a asegurarse de que lo que les ocurrió a ellos no le suceda a Finney.', CAST(N'2022-06-24' AS Date), CAST(18.29 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=14U-tI16V_h1B4vv7s21Q264SIEowo3gG')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (28, N'Ghosted', 8, 116, N'Cole, un hombre sincero y trabajador, se enamora perdidamente de la enigmática Sadie, pero luego hace el sorprendente descubrimiento de que ella es una agente secreta. Antes de que puedan decidir sobre una segunda cita, Cole y Sadie se ven arrastrados a una aventura internacional para salvar el mundo.', CAST(N'2023-04-21' AS Date), CAST(21.78 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=1YmVLEzL6zF1racn2bQHmY4BiVuLUnGzk')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (29, N'Stutz', 11, 96, N'En conversaciones francas con el actor Jonah Hill, el destacado psiquiatra Phil Stutz explora sus experiencias de vida temprana y su singular modelo visual de terapia.', CAST(N'2022-11-04' AS Date), CAST(16.99 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=1perMHpx_mmnoESB9FJoppCl5QW2mQxa0')
GO
INSERT [dbo].[TB_PELICULAS] ([Id_Pelicula], [Titulo], [Genero_Id], [Duracion], [Sinopsis], [FechaLanzamiento], [Precio], [ImagenUrl]) VALUES (30, N'La Calle Del Terror Parte 2: 1978', 9, 110, N'Un verano lleno de diversión se convierte en una espeluznante lucha por la supervivencia cuando un asesino aterroriza el Campamento Nightwing en el pueblo maldito de Shadyside.', CAST(N'2021-07-08' AS Date), CAST(18.42 AS Decimal(18, 2)), N'https://drive.google.com/uc?id=1b7oTVr3JPkJ9RkPykvpg1p-ZLqPbZ844')
GO
SET IDENTITY_INSERT [dbo].[TB_PELICULAS] OFF
GO
SET IDENTITY_INSERT [dbo].[TB_TARJETA_EMPRESA] ON 
GO
INSERT [dbo].[TB_TARJETA_EMPRESA] ([Id_Tarjeta], [Id_Cliente], [Tipo_Movimiento], [Saldo], [Puntos_Acumulados], [Fecha_Movimiento], [Numero_Tarjeta]) VALUES (15, 8, N'REGISTRO', CAST(0.00 AS Decimal(18, 2)), 0, CAST(N'2023-06-02' AS Date), N'ch44720jo')
GO
INSERT [dbo].[TB_TARJETA_EMPRESA] ([Id_Tarjeta], [Id_Cliente], [Tipo_Movimiento], [Saldo], [Puntos_Acumulados], [Fecha_Movimiento], [Numero_Tarjeta]) VALUES (16, 8, N'Gasto', CAST(33.96 AS Decimal(18, 2)), 1, CAST(N'2023-06-02' AS Date), N'ch44720jo')
GO
INSERT [dbo].[TB_TARJETA_EMPRESA] ([Id_Tarjeta], [Id_Cliente], [Tipo_Movimiento], [Saldo], [Puntos_Acumulados], [Fecha_Movimiento], [Numero_Tarjeta]) VALUES (17, 8, N'Gasto', CAST(12.99 AS Decimal(18, 2)), 0, CAST(N'2023-06-02' AS Date), N'ch44720jo')
GO
INSERT [dbo].[TB_TARJETA_EMPRESA] ([Id_Tarjeta], [Id_Cliente], [Tipo_Movimiento], [Saldo], [Puntos_Acumulados], [Fecha_Movimiento], [Numero_Tarjeta]) VALUES (18, 8, N'Gasto', CAST(259.80 AS Decimal(18, 2)), 7, CAST(N'2023-06-02' AS Date), N'ch44720jo')
GO
INSERT [dbo].[TB_TARJETA_EMPRESA] ([Id_Tarjeta], [Id_Cliente], [Tipo_Movimiento], [Saldo], [Puntos_Acumulados], [Fecha_Movimiento], [Numero_Tarjeta]) VALUES (19, 9, N'REGISTRO', CAST(0.00 AS Decimal(18, 2)), 0, CAST(N'2023-06-02' AS Date), N'we93637ca')
GO
SET IDENTITY_INSERT [dbo].[TB_TARJETA_EMPRESA] OFF
GO
SET IDENTITY_INSERT [dbo].[TB_TARJETA_RECARGAS] ON 
GO
INSERT [dbo].[TB_TARJETA_RECARGAS] ([Id_Tarjeta_Recarga], [Id_Tarjeta_Empresa], [Forma_Recarga], [Numero_Recibo], [Cantidad], [Fecha_Recargar]) VALUES (1, 8, N'MASTER CARD', N'R-000', CAST(1232.00 AS Decimal(18, 2)), CAST(N'2023-06-02' AS Date))
GO
SET IDENTITY_INSERT [dbo].[TB_TARJETA_RECARGAS] OFF
GO
ALTER TABLE [dbo].[TB_DETALLECOMPRA]  WITH CHECK ADD  CONSTRAINT [FK_DetalleCompra_Factura] FOREIGN KEY([Id_Factura])
REFERENCES [dbo].[TB_FACTURA] ([Id_Factura])
GO
ALTER TABLE [dbo].[TB_DETALLECOMPRA] CHECK CONSTRAINT [FK_DetalleCompra_Factura]
GO
ALTER TABLE [dbo].[TB_DETALLECOMPRA]  WITH CHECK ADD  CONSTRAINT [FK_DetalleCompra_Peliculas] FOREIGN KEY([Id_Pelicula])
REFERENCES [dbo].[TB_PELICULAS] ([Id_Pelicula])
GO
ALTER TABLE [dbo].[TB_DETALLECOMPRA] CHECK CONSTRAINT [FK_DetalleCompra_Peliculas]
GO
ALTER TABLE [dbo].[TB_FACTURA]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Administradores] FOREIGN KEY([Id_Administrador])
REFERENCES [dbo].[TB_ADMINISTRADORES] ([Id_Administrador])
GO
ALTER TABLE [dbo].[TB_FACTURA] CHECK CONSTRAINT [FK_Factura_Administradores]
GO
ALTER TABLE [dbo].[TB_FACTURA]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Cliente] FOREIGN KEY([Id_Cliente])
REFERENCES [dbo].[TB_CLIENTE] ([Id_Cliente])
GO
ALTER TABLE [dbo].[TB_FACTURA] CHECK CONSTRAINT [FK_Factura_Cliente]
GO
ALTER TABLE [dbo].[TB_PELICULAS]  WITH CHECK ADD  CONSTRAINT [FK_Peliculas_Genero] FOREIGN KEY([Genero_Id])
REFERENCES [dbo].[TB_GENERO] ([Id_Genero])
GO
ALTER TABLE [dbo].[TB_PELICULAS] CHECK CONSTRAINT [FK_Peliculas_Genero]
GO
USE [master]
GO
ALTER DATABASE [PELICULAS] SET  READ_WRITE 
GO
