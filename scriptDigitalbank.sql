USE [master]
GO
/****** Object:  Database [DigitalBank]    Script Date: 27/10/2023 10:22:01 p. m. ******/
CREATE DATABASE [DigitalBank]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DigitalBank', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DigitalBank.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DigitalBank_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DigitalBank_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DigitalBank] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DigitalBank].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DigitalBank] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DigitalBank] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DigitalBank] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DigitalBank] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DigitalBank] SET ARITHABORT OFF 
GO
ALTER DATABASE [DigitalBank] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DigitalBank] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DigitalBank] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DigitalBank] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DigitalBank] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DigitalBank] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DigitalBank] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DigitalBank] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DigitalBank] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DigitalBank] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DigitalBank] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DigitalBank] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DigitalBank] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DigitalBank] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DigitalBank] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DigitalBank] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DigitalBank] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DigitalBank] SET RECOVERY FULL 
GO
ALTER DATABASE [DigitalBank] SET  MULTI_USER 
GO
ALTER DATABASE [DigitalBank] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DigitalBank] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DigitalBank] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DigitalBank] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DigitalBank] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DigitalBank] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DigitalBank', N'ON'
GO
ALTER DATABASE [DigitalBank] SET QUERY_STORE = OFF
GO
USE [DigitalBank]
GO
/****** Object:  Table [dbo].[RegistroActividades]    Script Date: 27/10/2023 10:22:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistroActividades](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Accion] [nvarchar](50) NULL,
	[TablaAfectada] [nvarchar](50) NULL,
	[FechaRegistro] [datetime] NULL,
	[Usuario] [nvarchar](100) NULL,
	[Detalles] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 27/10/2023 10:22:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[ID] [nvarchar](100) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[FechaNacimiento] [date] NULL,
	[Sexo] [char](1) NULL,
 CONSTRAINT [PK__Usuarios__3214EC27C3811B41] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Usuarios_ID]    Script Date: 27/10/2023 10:22:01 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Usuarios_ID] ON [dbo].[Usuarios]
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarUsuario]    Script Date: 27/10/2023 10:22:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Actualizar
CREATE PROCEDURE [dbo].[ActualizarUsuario]
    @ID NVARCHAR(100),
    @Nombre NVARCHAR(100),
    @FechaNacimiento DATE,
    @Sexo CHAR(1)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE ID = @ID)
    BEGIN
        UPDATE Usuarios
        SET Nombre = @Nombre, FechaNacimiento = @FechaNacimiento, Sexo = @Sexo
        WHERE ID = @ID;
        PRINT 'Usuario actualizada correctamente.';
    END
    ELSE
    BEGIN
        PRINT 'La Usuario con el ID especificado no existe. No se puede actualizar.';
    END
END;

GO
/****** Object:  StoredProcedure [dbo].[CrearUsuario]    Script Date: 27/10/2023 10:22:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento almacenado para CRUD
-- Crear
CREATE PROCEDURE [dbo].[CrearUsuario]
    @ID NVARCHAR(100),
	@Nombre NVARCHAR(100),
    @FechaNacimiento DATE,
    @Sexo CHAR(1)
AS
BEGIN
    INSERT INTO Usuarios (ID, Nombre, FechaNacimiento, Sexo)
    VALUES (@ID, @Nombre, @FechaNacimiento, @Sexo);
END;

GO
/****** Object:  StoredProcedure [dbo].[EliminarUsuario]    Script Date: 27/10/2023 10:22:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Eliminar
CREATE PROCEDURE [dbo].[EliminarUsuario]
    @ID NVARCHAR(100)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE ID = @ID)
    BEGIN
        DELETE FROM Usuarios
        WHERE ID = @ID;
        PRINT 'Usuario eliminada correctamente.';
    END
    ELSE
    BEGIN
        PRINT 'La Usuario con el ID especificado no existe. No se puede eliminar.';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[LeerUsuario]    Script Date: 27/10/2023 10:22:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Leer
CREATE PROCEDURE [dbo].[LeerUsuario]
  @ID NVARCHAR(100)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE ID = @ID)
    BEGIN
        SELECT ID,Nombre, FechaNacimiento, Sexo
        FROM Usuarios
        WHERE ID = @ID;
    END
    ELSE
    BEGIN
        PRINT 'La Usuario con el ID especificado no existe.';
    END
END;

GO
/****** Object:  StoredProcedure [dbo].[ObtenerTotalRegistros]    Script Date: 27/10/2023 10:22:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerTotalRegistros]
  
AS
BEGIN
    
    BEGIN
      SELECT count(*) FROM [DigitalBank].[dbo].[Usuarios]
    END    
END;

GO
/****** Object:  StoredProcedure [dbo].[ObtenerUsuariosPaginados]    Script Date: 27/10/2023 10:22:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerUsuariosPaginados]
    @Pagina INT,
    @TamañoPagina INT
AS
BEGIN
    DECLARE @Offset INT = (@Pagina - 1) * @TamañoPagina;
    
    SELECT ID, Nombre, FechaNacimiento, Sexo
    FROM Usuarios
    ORDER BY ID
    OFFSET @Offset ROWS FETCH NEXT @TamañoPagina ROWS ONLY;
END;
GO
/****** Object:  StoredProcedure [dbo].[RegistrarActividad]    Script Date: 27/10/2023 10:22:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- procedimiento almacenar log (tabla en la base de datos)
CREATE PROCEDURE [dbo].[RegistrarActividad]
	@Accion NVARCHAR(50),
    @TablaAfectada NVARCHAR(50),
    @Usuario NVARCHAR(100),
    @Detalles NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO RegistroActividades (Accion, TablaAfectada, FechaRegistro, Usuario, Detalles)
    VALUES (@Accion, @TablaAfectada, GETDATE(), @Usuario, @Detalles);
END;

GO
USE [master]
GO
ALTER DATABASE [DigitalBank] SET  READ_WRITE 
GO
