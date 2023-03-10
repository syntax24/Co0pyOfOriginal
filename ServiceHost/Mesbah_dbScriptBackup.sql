USE [master]
GO
/****** Object:  Database [Mesbah_db]    Script Date: 11/8/2022 23:40:59 ******/
CREATE DATABASE [Mesbah_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Mesbah_db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSNEW\MSSQL\DATA\Mesbah_db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Mesbah_db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSNEW\MSSQL\DATA\Mesbah_db_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Mesbah_db] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Mesbah_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Mesbah_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Mesbah_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Mesbah_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Mesbah_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Mesbah_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [Mesbah_db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Mesbah_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Mesbah_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Mesbah_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Mesbah_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Mesbah_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Mesbah_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Mesbah_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Mesbah_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Mesbah_db] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Mesbah_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Mesbah_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Mesbah_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Mesbah_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Mesbah_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Mesbah_db] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Mesbah_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Mesbah_db] SET RECOVERY FULL 
GO
ALTER DATABASE [Mesbah_db] SET  MULTI_USER 
GO
ALTER DATABASE [Mesbah_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Mesbah_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Mesbah_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Mesbah_db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Mesbah_db] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Mesbah_db', N'ON'
GO
ALTER DATABASE [Mesbah_db] SET QUERY_STORE = OFF
GO
USE [Mesbah_db]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](100) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](1000) NOT NULL,
	[Mobile] [nvarchar](20) NOT NULL,
	[RoleId] [bigint] NOT NULL,
	[ProfilePhoto] [nvarchar](500) NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[RoleName] [nvarchar](100) NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Boards]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Boards](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[DisputeResolutionPetitionDate] [datetime2](7) NOT NULL,
	[Branch] [nvarchar](max) NULL,
	[BoardChairman] [nvarchar](max) NULL,
	[ExpertReport] [nvarchar](max) NULL,
	[File_Id] [bigint] NOT NULL,
	[BoardType_Id] [int] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Boards] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BoardTypes]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoardTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
 CONSTRAINT [PK_BoardTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contracts]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contracts](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[PersonnelCode] [bigint] NOT NULL,
	[ContractNo] [nvarchar](255) NOT NULL,
	[EmployeeId] [bigint] NOT NULL,
	[EmployerId] [bigint] NOT NULL,
	[WorkshopIds] [bigint] NOT NULL,
	[YearlySalaryId] [bigint] NOT NULL,
	[ContarctStart] [datetime2](7) NOT NULL,
	[ContractEnd] [datetime2](7) NOT NULL,
	[DayliWage] [nvarchar](50) NOT NULL,
	[IsActiveString] [nvarchar](10) NOT NULL,
	[ArchiveCode] [nvarchar](255) NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[ContractType] [nvarchar](20) NOT NULL,
	[GetWorkDate] [datetime2](7) NOT NULL,
	[JobType] [nvarchar](100) NOT NULL,
	[SetContractDate] [datetime2](7) NOT NULL,
	[WorkshopAddress1] [nvarchar](500) NULL,
	[WorkshopAddress2] [nvarchar](500) NULL,
	[JobTypeId] [bigint] NOT NULL,
	[MandatoryHoursid] [bigint] NULL,
	[AgreementSalary] [nvarchar](50) NULL,
	[ConsumableItems] [nvarchar](50) NOT NULL,
	[HousingAllowance] [nvarchar](50) NOT NULL,
	[WorkingHoursWeekly] [nvarchar](10) NOT NULL,
	[FamilyAllowance] [nvarchar](100) NOT NULL,
	[ContractPeriod] [nvarchar](2) NULL,
	[Signature] [nvarchar](1) NULL,
 CONSTRAINT [PK_Contracts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeChildren]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeChildren](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[FName] [nvarchar](255) NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[ParentNationalCode] [nvarchar](10) NULL,
	[EmployeeId] [bigint] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_EmployeeChildren] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[FName] [nvarchar](255) NOT NULL,
	[LName] [nvarchar](255) NOT NULL,
	[FatherName] [nvarchar](255) NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[DateOfIssue] [datetime2](7) NOT NULL,
	[PlaceOfIssue] [nvarchar](50) NULL,
	[NationalCode] [nvarchar](10) NOT NULL,
	[IdNumber] [nvarchar](20) NULL,
	[Gender] [nvarchar](10) NOT NULL,
	[Nationality] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[City] [nvarchar](100) NULL,
	[State] [nvarchar](100) NULL,
	[IsActive] [bit] NOT NULL,
	[IsActiveString] [nvarchar](10) NULL,
	[MaritalStatus] [nvarchar](10) NULL,
	[MilitaryService] [nvarchar](100) NULL,
	[LevelOfEducation] [nvarchar](100) NULL,
	[FieldOfStudy] [nvarchar](255) NULL,
	[BankCardNumber] [nvarchar](50) NULL,
	[BankBranch] [nvarchar](100) NULL,
	[InsuranceCode] [nvarchar](10) NULL,
	[InsuranceHistoryByYear] [nvarchar](10) NULL,
	[InsuranceHistoryByMonth] [nvarchar](10) NULL,
	[NumberOfChildren] [nvarchar](10) NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[OfficePhone] [nvarchar](50) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employers]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employers](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[FName] [nvarchar](255) NOT NULL,
	[LName] [nvarchar](255) NOT NULL,
	[ContractingPartyId] [bigint] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Gender] [nvarchar](10) NOT NULL,
	[Nationalcode] [nvarchar](10) NOT NULL,
	[IdNumber] [nvarchar](20) NOT NULL,
	[Nationality] [nvarchar](50) NOT NULL,
	[FatherName] [nvarchar](255) NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[DateOfIssue] [datetime2](7) NOT NULL,
	[PlaceOfIssue] [nvarchar](50) NULL,
	[RegisterId] [nvarchar](15) NOT NULL,
	[NationalId] [nvarchar](15) NOT NULL,
	[EmployerLName] [nvarchar](255) NOT NULL,
	[IsLegal] [nvarchar](10) NOT NULL,
	[Phone] [nvarchar](50) NULL,
	[AgentPhone] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[EservicePassword] [nvarchar](100) NULL,
	[EserviceUserName] [nvarchar](100) NULL,
	[MclsPassword] [nvarchar](100) NULL,
	[MclsUserName] [nvarchar](100) NULL,
	[SanaPassword] [nvarchar](100) NULL,
	[SanaUserName] [nvarchar](100) NULL,
	[TaxOfficeUserName] [nvarchar](100) NULL,
	[TaxOfficepassword] [nvarchar](100) NULL,
	[EmployerNo] [nvarchar](100) NULL,
	[FullName] [nvarchar](255) NULL,
 CONSTRAINT [PK_Employers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Files]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Files](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[ArchiveNo] [bigint] NOT NULL,
	[ClientVisitDate] [datetime2](7) NOT NULL,
	[ProceederReference] [nvarchar](max) NULL,
	[Reqester] [bigint] NOT NULL,
	[Summoned] [bigint] NOT NULL,
	[Client] [int] NOT NULL,
	[FileClass] [nvarchar](max) NULL,
	[HasMandate] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Files] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Holidayitems]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Holidayitems](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[Holidaydate] [datetime2](7) NOT NULL,
	[HolidayId] [bigint] NOT NULL,
	[HolidayYear] [nvarchar](4) NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Holidayitems] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Holidays]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Holidays](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[Year] [nvarchar](4) NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Holidays] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jobs]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jobs](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[JobName] [nvarchar](255) NULL,
	[JobCode] [nvarchar](100) NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Jobs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[karfarmahhaa]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[karfarmahhaa](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Family] [nvarchar](100) NOT NULL,
	[NationalCode] [nvarchar](10) NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_karfarmahhaa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MandatoryHours]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MandatoryHours](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[Year] [int] NOT NULL,
	[Farvardin] [float] NOT NULL,
	[Ordibehesht] [float] NOT NULL,
	[Khordad] [float] NOT NULL,
	[Tir] [float] NOT NULL,
	[Mordad] [float] NOT NULL,
	[Shahrivar] [float] NOT NULL,
	[Mehr] [float] NOT NULL,
	[Aban] [float] NOT NULL,
	[Azar] [float] NOT NULL,
	[Dey] [float] NOT NULL,
	[Bahman] [float] NOT NULL,
	[Esfand] [float] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_MandatoryHours] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PenaltyTitles]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PenaltyTitles](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[FromDate] [datetime2](7) NOT NULL,
	[ToDate] [datetime2](7) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Day] [nvarchar](max) NULL,
	[PaidAmount] [nvarchar](max) NULL,
	[RemainingAmount] [nvarchar](max) NULL,
	[Petition_Id] [bigint] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_PenaltyTitles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalContractingParties]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalContractingParties](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[FName] [nvarchar](255) NOT NULL,
	[LName] [nvarchar](255) NOT NULL,
	[Nationalcode] [nvarchar](10) NOT NULL,
	[IdNumber] [nvarchar](20) NOT NULL,
	[Phone] [nvarchar](50) NULL,
	[AgentPhone] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[IsLegal] [nvarchar](10) NOT NULL,
	[NationalId] [nvarchar](15) NOT NULL,
	[RegisterId] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_PersonalContractingParties] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personalhhaa]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personalhhaa](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Family] [nvarchar](100) NOT NULL,
	[NationalCode] [nvarchar](10) NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Personalhhaa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Petitions]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Petitions](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[PetitionIssuanceDate] [datetime2](7) NOT NULL,
	[NotificationPetitionDate] [datetime2](7) NOT NULL,
	[TotalPenalty] [nvarchar](max) NULL,
	[TotalPenaltyTitles] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[BoardType_Id] [int] NOT NULL,
	[File_Id] [bigint] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Petitions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProceedingSessions]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProceedingSessions](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Time] [nvarchar](max) NULL,
	[Board_Id] [bigint] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ProceedingSessions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolePermissions]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePermissions](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[RoleId] [bigint] NOT NULL,
 CONSTRAINT [PK_RolePermissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TextManager_Bill]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TextManager_Bill](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[SubjectBill] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Contact] [nvarchar](max) NULL,
	[Appointed] [nvarchar](max) NULL,
	[ProcessingStage] [nvarchar](max) NULL,
	[Status] [tinyint] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TextManager_Bill] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TextManager_Contact]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TextManager_Contact](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[NameContact] [nvarchar](max) NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TextManager_Contact] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TextManager_Module]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TextManager_Module](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[NameSubModule] [nvarchar](max) NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TextManager_Module] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TextManager_ModuleTextManager]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TextManager_ModuleTextManager](
	[ModuleId] [bigint] NOT NULL,
	[TextManagerId] [bigint] NOT NULL,
 CONSTRAINT [PK_TextManager_ModuleTextManager] PRIMARY KEY CLUSTERED 
(
	[TextManagerId] ASC,
	[ModuleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TextManager_OriginalTitle]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TextManager_OriginalTitle](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](60) NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TextManager_OriginalTitle] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TextManager_Subtitle]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TextManager_Subtitle](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[Subtitle] [nvarchar](60) NOT NULL,
	[OriginalTitle_Id] [bigint] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TextManager_Subtitle] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TextManager_TextManager]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TextManager_TextManager](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[NoteNumber] [int] NOT NULL,
	[SubjectTextManager] [nvarchar](max) NULL,
	[NumberTextManager] [int] NOT NULL,
	[DateTextManager] [datetime2](7) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Paragraph] [nvarchar](500) NOT NULL,
	[Status] [tinyint] NOT NULL,
	[OriginalTitle_Id] [bigint] NOT NULL,
	[Subtitles_Id] [bigint] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TextManager_TextManager] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkHistories]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkHistories](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[FromDate] [datetime2](7) NOT NULL,
	[ToDate] [datetime2](7) NOT NULL,
	[WorkingHoursPerDay] [int] NULL,
	[WorkingHoursPerWeek] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[Petition_Id] [bigint] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_WorkHistories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkingHours]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkingHours](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[ShiftWork] [nvarchar](2) NULL,
	[ContractNo] [nvarchar](100) NULL,
	[NumberOfWorkingDays] [nvarchar](15) NULL,
	[NumberOfFriday] [nvarchar](15) NULL,
	[TotalHoursesH] [nvarchar](15) NULL,
	[TotalHoursesM] [nvarchar](2) NULL,
	[OverTimeWorkH] [nvarchar](15) NULL,
	[OverTimeWorkM] [nvarchar](2) NULL,
	[OverNightWorkH] [nvarchar](10) NULL,
	[OverNightWorkM] [nvarchar](2) NULL,
	[WeeklyWorkingTime] [nvarchar](10) NULL,
	[ContractId] [bigint] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_WorkingHours] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkingHoursItems]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkingHoursItems](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[DayOfWork] [nvarchar](1) NULL,
	[Start1] [nvarchar](5) NULL,
	[End1] [nvarchar](5) NULL,
	[RestTime] [nvarchar](2) NULL,
	[Start2] [nvarchar](5) NULL,
	[End2] [nvarchar](5) NULL,
	[Start3] [nvarchar](5) NULL,
	[End3] [nvarchar](5) NULL,
	[ComplexStart] [nvarchar](5) NULL,
	[ComplexEnd] [nvarchar](5) NULL,
	[WorkingHoursId] [bigint] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_WorkingHoursItems] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkshopeAccounts]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkshopeAccounts](
	[WorkshopId] [bigint] NOT NULL,
	[AccountId] [bigint] NOT NULL,
 CONSTRAINT [PK_WorkshopeAccounts] PRIMARY KEY CLUSTERED 
(
	[WorkshopId] ASC,
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkshopeEmployers]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkshopeEmployers](
	[WorkshopId] [bigint] NOT NULL,
	[EmployerId] [bigint] NOT NULL,
 CONSTRAINT [PK_WorkshopeEmployers] PRIMARY KEY CLUSTERED 
(
	[WorkshopId] ASC,
	[EmployerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workshops]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workshops](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[WorkshopName] [nvarchar](255) NOT NULL,
	[InsuranceCode] [nvarchar](100) NULL,
	[IsActive] [bit] NOT NULL,
	[IsActiveString] [nvarchar](10) NULL,
	[TypeOfOwnership] [nvarchar](100) NULL,
	[ArchiveCode] [nvarchar](100) NULL,
	[AgentName] [nvarchar](100) NULL,
	[AgentPhone] [nvarchar](50) NULL,
	[State] [nvarchar](100) NULL,
	[City] [nvarchar](100) NULL,
	[Address] [nvarchar](500) NULL,
	[TypeOfInsuranceSend] [nvarchar](100) NULL,
	[TypeOfContract] [nvarchar](100) NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[WorkshopFullName] [nvarchar](255) NULL,
	[WorkshopSureName] [nvarchar](255) NULL,
	[ContractTerm] [nvarchar](10) NULL,
 CONSTRAINT [PK_Workshops] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[YearlyItems]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[YearlyItems](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[ItemName] [nvarchar](255) NULL,
	[ItemValue] [float] NOT NULL,
	[ValueType] [nvarchar](10) NULL,
	[ParentConnectionId] [int] NOT NULL,
	[YearlySalaryId] [bigint] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_YearlyItems] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[YearlySalariess]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[YearlySalariess](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[Year] [nvarchar](10) NULL,
	[ConnectionId] [int] NOT NULL,
 CONSTRAINT [PK_YearlySalariess] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[YearlySalaryTitles]    Script Date: 11/8/2022 23:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[YearlySalaryTitles](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title1] [nvarchar](255) NULL,
	[Title2] [nvarchar](255) NULL,
	[Title3] [nvarchar](255) NULL,
	[Title4] [nvarchar](255) NULL,
	[Title5] [nvarchar](255) NULL,
	[Title6] [nvarchar](255) NULL,
	[Title7] [nvarchar](255) NULL,
	[Title8] [nvarchar](255) NULL,
	[Title9] [nvarchar](255) NULL,
	[Title10] [nvarchar](255) NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_YearlySalaryTitles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200708092428_initDatabase', N'5.0.0-preview.6.20312.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200708141448_ProductAdded', N'5.0.0-preview.6.20312.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200711052743_ProductPictureAdded', N'5.0.0-preview.6.20312.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200711075558_SlideAdded', N'5.0.0-preview.6.20312.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200712093245_LinkAddedToSlide', N'5.0.0-preview.6.20312.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211104131051_init_1', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211122165226_Init2', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211123195652_test', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211130171628_MyMigration', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211202144707_RoleAdded', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211205171953_Permission', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211207180611_LegalAndPersonalToOne', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211212192247_LNamInstedLegalName', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211223224759_EmployerAdd', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211230072344_sana', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220112193140_AddEmployerNo', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220113201934_Workshop', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220114191718_AddresUpTo500', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220127204547_EmployeeAndChildren', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220209152251_AddEmployeeOfficePhone', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220211162404_idnumberFalse', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220216162008_AddYearlySalary', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220219201738_salary', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220219224223_AddYear', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220220210415_AddConnectionId', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220222194505_YearlyItems', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220226154752_YearlySalarytitle', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220308201405_EmployersAndWorkshopFullName', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220313130424_addContract', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220313134718_addWorkshopMapping', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220321130238_ContractAddFildes', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220321135713_ContractAddNewFildes', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220321192408_jobAndConnections', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220325163540_WorkshopEmployers', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220326015554_ContractTermAdd', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220326042821_InsurancCodeAllowNull', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220406161942_MandatoryHours', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220503174032_Holidays', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220504134952_AddHolidayItems', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220712161409_contractNewItmsAdd', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220712171850_ContractNullable', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220719080045_initialKarfarma', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220719083425_initialPersonal', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220719192639_familyAlowance', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220801213946_add contractOeriod', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220811162136_SignaureAddContrat', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220824200802_WorkingHourAdd', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220825073124_WorkingHoursItemsAdd', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220825075624_RelationContratWorkingHoursAndWorkigHoursItems', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221015182242_AddRoleName', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221022165855_WorkshopAccountAdd', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221025213153_prvandehProject', N'5.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20221104213243_TextManaerAding', N'5.0.11')
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([id], [Fullname], [Username], [Password], [Mobile], [RoleId], [ProfilePhoto], [CreationDate], [RoleName]) VALUES (2, N'صادق فرخی', N'sadegh63', N'10000.wVJfDdfXsvzxDJ91sEzmnA==.KjgeZy00VOsI0B6rUVH0qNa5Wob+Jhp3a46RcnmlCP4=', N'09114221321', 1, N'profilePhotos/2021-12-02-19-22-18-sadegh63.jpg', CAST(N'2021-12-02T19:22:18.8650285' AS DateTime2), N'مدیر سیستم')
INSERT [dbo].[Accounts] ([id], [Fullname], [Username], [Password], [Mobile], [RoleId], [ProfilePhoto], [CreationDate], [RoleName]) VALUES (3, N'سید حسن مصباح', N'admin@21400', N'10000.5CVkU7XGI6a0AaftGqqVxA==.eqUXBlZlqxUxw5kXQsV6L152yuVRNL8I8MnX+6WMcUc=', N'09111485044', 1, N'profilePhotos/2021-12-03-12-29-55-logo.png', CAST(N'2021-12-03T12:29:55.8155553' AS DateTime2), N'مدیر سیستم')
INSERT [dbo].[Accounts] ([id], [Fullname], [Username], [Password], [Mobile], [RoleId], [ProfilePhoto], [CreationDate], [RoleName]) VALUES (4, N'محمد', N'mohamad', N'10000.2DLWkrtbc7eBwiaNP9lnhw==./gAcUXxZXsLi9TE+FnzU2OL9TW5RcB4YfVMJ27/Ia88=', N'09112222222', 10, N'profilePhotos/2022-11-07-01-24-53-Screenshot (01).jpg', CAST(N'2021-12-03T20:06:52.0980642' AS DateTime2), N'تست 4')
INSERT [dbo].[Accounts] ([id], [Fullname], [Username], [Password], [Mobile], [RoleId], [ProfilePhoto], [CreationDate], [RoleName]) VALUES (5, N'نوید', N'محمدی', N'10000.547CtPNiQY4j5FLzrEb6+A==.VAkdHwX4g8XjpN6Gq6JqE3OqOCtJ+9ETvwCxcZsL+YQ=', N'09112321145', 12, N'', CAST(N'2022-10-22T19:51:17.9184970' AS DateTime2), N'تست دیتابیس')
INSERT [dbo].[Accounts] ([id], [Fullname], [Username], [Password], [Mobile], [RoleId], [ProfilePhoto], [CreationDate], [RoleName]) VALUES (6, N'بابک', N'تست', N'10000.1YKlAr0QQyKp/ttzTt33ww==.uNVRimdQooiUq9aT2FYDOAVMMXBLic7iran0M6xucOw=', N'09114567898', 7, N'profilePhotos/2022-11-07-01-26-09-Screenshot (01).jpg', CAST(N'2022-11-07T01:26:25.7888051' AS DateTime2), N'تست 2')
SET IDENTITY_INSERT [dbo].[Accounts] OFF
SET IDENTITY_INSERT [dbo].[BoardTypes] ON 

INSERT [dbo].[BoardTypes] ([Id], [Title]) VALUES (1, N'تشخیص')
INSERT [dbo].[BoardTypes] ([Id], [Title]) VALUES (2, N'حل اختلاف')
SET IDENTITY_INSERT [dbo].[BoardTypes] OFF
SET IDENTITY_INSERT [dbo].[Contracts] ON 

INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (63, 1, N'5/1/01/4', 10107, 20034, 89, 66, CAST(N'2022-06-22T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'true', N'5', CAST(N'2022-07-12T22:48:41.5006508' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-06-22T00:00:00.0000000' AS DateTime2), N'گیلان-اسكلك-تستمنتیب', N'رشت - گلسار', 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'24 - 12', N'', N'12', N'1')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (66, 2, N'5/2/01/4', 10108, 20034, 89, 66, CAST(N'2022-06-22T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'5', CAST(N'2022-07-13T00:04:14.2804351' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-06-22T00:00:00.0000000' AS DateTime2), N'گیلان-اسكلك-تستمنتیب', N'رشت - مطهری', 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'24 - 12', N'', N'1', N'1')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (67, 1, N'3/1/01/5', 10107, 12, 87, 66, CAST(N'2022-07-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-08-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'true', N'3', CAST(N'2022-07-14T04:51:54.6434966' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-07-23T00:00:00.0000000' AS DateTime2), N'رشت معلم', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'24 - 12', N'', N'1', N'1')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (86, 1, N'3/1/01/6', 10107, 12, 87, 65, CAST(N'2022-08-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-09-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'true', N'3', CAST(N'2022-08-26T02:06:22.8748077' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-08-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'44', N'0', N'1', N'1')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (87, 1, N'3/1/01/7', 10107, 12, 87, 65, CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-08-26T02:08:20.4617555' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'44', N'0', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (88, 1, N'3/1/01/8', 10107, 12, 87, 65, CAST(N'2022-10-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-11-21T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-08-26T02:09:41.2625788' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-10-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'24 - 12', N'0', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (89, 1, N'3/1/01/9', 10107, 12, 87, 65, CAST(N'2022-11-22T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-21T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-08-26T02:11:32.9369351' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-11-22T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'24 - 24', N'0', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (90, 1, N'3/1/01/10', 10107, 12, 87, 65, CAST(N'2022-12-22T00:00:00.0000000' AS DateTime2), CAST(N'2023-01-20T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-08-26T02:12:58.4604511' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-12-22T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'36 - 12', N'0', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (91, 1, N'5/1/01/11', 10107, 20034, 89, 65, CAST(N'2023-01-21T00:00:00.0000000' AS DateTime2), CAST(N'2023-02-19T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'5', CAST(N'2022-08-26T02:38:20.7234607' AS DateTime2), N'موقت', CAST(N'2022-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2023-01-21T00:00:00.0000000' AS DateTime2), N'گیلان-اسكلك-تستمنتیب', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'48 - 24', N'0', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (92, 2, N'3/2/01/8', 10109, 12, 87, 65, CAST(N'2022-10-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-11-21T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-08-26T02:42:26.6264023' AS DateTime2), N'موقت', CAST(N'2022-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-10-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'24 - 12', N'8٬359٬500', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (93, 2, N'3/2/01/6', 10109, 12, 87, 65, CAST(N'2022-08-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-09-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'true', N'3', CAST(N'2022-08-26T02:59:47.5135668' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-08-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'44', N'8٬359٬500', N'1', N'1')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (94, 2, N'3/2/01/7', 10109, 12, 87, 65, CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-08-26T03:00:36.9626540' AS DateTime2), N'موقت', CAST(N'2022-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'24 - 24', N'8٬359٬500', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (95, 2, N'3/2/01/9', 10109, 12, 87, 65, CAST(N'2022-11-22T00:00:00.0000000' AS DateTime2), CAST(N'2022-12-21T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-08-26T03:01:47.4977156' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-11-22T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'48 - 24', N'8٬359٬500', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (96, 2, N'3/2/01/10', 10109, 12, 87, 65, CAST(N'2022-12-22T00:00:00.0000000' AS DateTime2), CAST(N'2023-01-20T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-08-26T03:02:52.9285324' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-12-22T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'24 - 12', N'8٬359٬500', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (97, 1, N'3/1/01/3', 10107, 12, 87, 65, CAST(N'2022-05-22T00:00:00.0000000' AS DateTime2), CAST(N'2022-06-21T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'true', N'3', CAST(N'2022-08-28T21:14:27.6577563' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-05-22T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'24 - 12', N'0', N'1', N'1')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (99, 2, N'3/2/01/4', 10109, 12, 87, 65, CAST(N'2022-06-22T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'true', N'3', CAST(N'2022-08-28T21:21:53.3504622' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-06-22T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'24 - 12', N'8٬359٬500', N'1', N'1')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (100, 3, N'3/3/01/5', 10108, 12, 87, 65, CAST(N'2022-07-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'true', N'3', CAST(N'2022-08-29T23:12:47.4072978' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-07-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'24 - 12', N'0', N'1', N'1')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (107, 2, N'3/2/01/11', 10109, 12, 87, 65, CAST(N'2023-01-21T00:00:00.0000000' AS DateTime2), CAST(N'2023-02-19T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-09-02T00:33:57.7394563' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2023-01-21T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'24 - 12', N'8٬359٬500', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (111, 2, N'3/2/01/12', 10109, 12, 87, 102, CAST(N'2023-02-20T00:00:00.0000000' AS DateTime2), CAST(N'2023-03-20T00:00:00.0000000' AS DateTime2), N'1٬330٬525', N'false', N'3', CAST(N'2022-09-08T17:30:54.7949934' AS DateTime2), N'موقت', CAST(N'2022-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2023-02-20T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬117٬326', N'5٬252٬387', N'42', N'7٬983٬151', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (112, 2, N'3/2/01/12', 10109, 12, 87, 102, CAST(N'2023-02-20T00:00:00.0000000' AS DateTime2), CAST(N'2023-03-20T00:00:00.0000000' AS DateTime2), N'1٬330٬525', N'false', N'3', CAST(N'2022-09-08T20:36:26.1619412' AS DateTime2), N'موقت', CAST(N'2022-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2023-02-20T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬117٬326', N'5٬252٬387', N'42', N'7٬983٬151', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (113, 2, N'3/2/01/7', 10109, 12, 87, 65, CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-09-16T08:13:00.2235199' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'44', N'8٬359٬500', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (114, 2, N'3/2/01/7', 10109, 12, 87, 65, CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-09-16T08:13:00.2210273' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'44', N'8٬359٬500', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (115, 1, N'3/1/01/7', 10107, 12, 87, 65, CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-09-16T08:13:02.0373667' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'44', N'0', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (116, 1, N'3/1/01/7', 10107, 12, 87, 65, CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-09-16T08:13:02.0372112' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'44', N'0', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (117, 2, N'3/2/01/7', 10109, 12, 87, 65, CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-09-16T08:14:26.5681054' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'44', N'8٬359٬500', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (118, 2, N'3/2/01/7', 10109, 12, 87, 65, CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-09-16T08:14:26.5682973' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'44', N'8٬359٬500', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (119, 1, N'3/1/01/7', 10107, 12, 87, 65, CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-09-16T08:14:27.6716833' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'44', N'0', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (120, 2, N'3/2/01/7', 10109, 12, 87, 65, CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-09-16T08:22:47.0452100' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'44', N'8٬359٬500', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (121, 2, N'3/2/01/7', 10109, 12, 87, 65, CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-09-16T08:22:47.0452056' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'44', N'8٬359٬500', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (151, 2, N'3/2/01/7', 10109, 12, 87, 65, CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-09-16T10:01:38.9807578' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'44', N'8٬359٬500', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (152, 2, N'3/2/01/7', 10109, 12, 87, 65, CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-09-16T10:01:38.9807621' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'44', N'8٬359٬500', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (153, 1, N'3/1/01/7', 10107, 12, 87, 65, CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-09-16T10:01:40.6834923' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'44', N'0', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (154, 1, N'3/1/01/7', 10107, 12, 87, 65, CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-09-16T10:30:31.6398447' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'44', N'0', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (155, 1, N'3/1/01/7', 10107, 12, 87, 65, CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-09-16T10:30:31.6398410' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'44', N'0', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (167, 2, N'3/2/01/7', 10109, 12, 87, 65, CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-09-16T22:17:12.3215397' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'44', N'8٬359٬500', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (168, 2, N'3/2/01/7', 10109, 12, 87, 65, CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-09-16T22:17:12.3215353' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'44', N'8٬359٬500', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (169, 1, N'3/1/01/7', 10107, 12, 87, 65, CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-09-16T22:17:13.9297408' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'44', N'0', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (170, 1, N'3/1/01/7', 10107, 12, 87, 65, CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-09-16T22:17:13.9320650' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'44', N'0', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (181, 2, N'3/2/01/7', 10109, 12, 87, 65, CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-09-16T23:38:40.8293723' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'44', N'8٬359٬500', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (182, 1, N'3/1/01/7', 10107, 12, 87, 65, CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'false', N'3', CAST(N'2022-09-16T23:38:42.7231125' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'44', N'0', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (183, 2, N'3/2/01/7', 10109, 12, 87, 65, CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'true', N'3', CAST(N'2022-09-16T23:40:54.0105152' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'44', N'8٬359٬500', N'1', N'1')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (184, 1, N'3/1/01/7', 10107, 12, 87, 65, CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-22T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'true', N'3', CAST(N'2022-09-16T23:40:55.2501845' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-09-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'44', N'0', N'1', N'1')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (185, 1, N'3/1/01/8', 10107, 12, 87, 65, CAST(N'2022-10-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-11-21T00:00:00.0000000' AS DateTime2), N'0', N'true', N'3', CAST(N'2022-09-16T23:42:28.9525353' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-10-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'0', N'0', N'0', N'0', N'1', N'1')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (186, 2, N'3/2/01/8', 10109, 12, 87, 65, CAST(N'2022-10-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-11-21T00:00:00.0000000' AS DateTime2), N'0', N'true', N'3', CAST(N'2022-09-16T23:42:29.8144523' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-10-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'0', N'0', N'0', N'0', N'1', N'1')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (187, 2, N'3/2/01/9', 10109, 12, 87, 65, CAST(N'2022-11-22T00:00:00.0000000' AS DateTime2), CAST(N'2023-01-20T00:00:00.0000000' AS DateTime2), N'0', N'false', N'3', CAST(N'2022-09-17T06:50:00.2511005' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-11-22T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'0', N'0', N'0', N'0', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (188, 1, N'3/1/01/9', 10107, 12, 87, 65, CAST(N'2022-11-22T00:00:00.0000000' AS DateTime2), CAST(N'2023-01-20T00:00:00.0000000' AS DateTime2), N'0', N'false', N'3', CAST(N'2022-09-17T06:50:02.1980230' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-11-22T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'0', N'0', N'0', N'0', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (189, 4, N'3/4/00/1', 10110, 12, 87, 102, CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-20T00:00:00.0000000' AS DateTime2), N'845٬314', N'false', N'3', CAST(N'2022-09-19T03:22:40.5680404' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'59٬781٬719', N'44٬836٬289', N'42', N'0', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (190, 4, N'3/4/00/1', 10110, 12, 87, 102, CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-20T00:00:00.0000000' AS DateTime2), N'845٬314', N'false', N'3', CAST(N'2022-09-19T03:22:40.5680472' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'59٬781٬719', N'44٬836٬289', N'42', N'0', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (191, 4, N'3/4/00/1', 10110, 12, 87, 102, CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-20T00:00:00.0000000' AS DateTime2), N'845٬314', N'true', N'3', CAST(N'2022-09-19T03:34:00.7896478' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'59٬781٬719', N'44٬836٬289', N'42', N'0', N'1', N'1')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (192, 4, N'3/4/01/8', 10110, 12, 87, 102, CAST(N'2022-10-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-11-21T00:00:00.0000000' AS DateTime2), N'1٬330٬525', N'true', N'3', CAST(N'2022-09-20T06:28:04.2988788' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-10-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬117٬326', N'5٬252٬387', N'42', N'0', N'1', N'0')
INSERT [dbo].[Contracts] ([id], [PersonnelCode], [ContractNo], [EmployeeId], [EmployerId], [WorkshopIds], [YearlySalaryId], [ContarctStart], [ContractEnd], [DayliWage], [IsActiveString], [ArchiveCode], [CreationDate], [ContractType], [GetWorkDate], [JobType], [SetContractDate], [WorkshopAddress1], [WorkshopAddress2], [JobTypeId], [MandatoryHoursid], [AgreementSalary], [ConsumableItems], [HousingAllowance], [WorkingHoursWeekly], [FamilyAllowance], [ContractPeriod], [Signature]) VALUES (193, 3, N'3/3/01/8', 10108, 12, 87, 65, CAST(N'2022-10-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-11-21T00:00:00.0000000' AS DateTime2), N'1٬393٬250', N'true', N'3', CAST(N'2022-09-20T06:28:06.5465215' AS DateTime2), N'موقت', CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'کارگر ساده', CAST(N'2022-10-23T00:00:00.0000000' AS DateTime2), N'--', NULL, 189, NULL, N'0', N'8٬500٬000', N'5٬500٬000', N'24 - 12', N'0', N'1', N'1')
SET IDENTITY_INSERT [dbo].[Contracts] OFF
SET IDENTITY_INSERT [dbo].[EmployeeChildren] ON 

INSERT [dbo].[EmployeeChildren] ([id], [FName], [DateOfBirth], [ParentNationalCode], [EmployeeId], [CreationDate]) VALUES (154, N'محمد', CAST(N'2011-03-25T00:00:00.0000000' AS DateTime2), N'2650321210', 10109, CAST(N'2022-07-19T20:29:06.7261532' AS DateTime2))
INSERT [dbo].[EmployeeChildren] ([id], [FName], [DateOfBirth], [ParentNationalCode], [EmployeeId], [CreationDate]) VALUES (155, N'علیرضا', CAST(N'2004-10-22T00:00:00.0000000' AS DateTime2), N'2650321210', 10109, CAST(N'2022-07-19T20:29:06.8283899' AS DateTime2))
SET IDENTITY_INSERT [dbo].[EmployeeChildren] OFF
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([id], [FName], [LName], [FatherName], [DateOfBirth], [DateOfIssue], [PlaceOfIssue], [NationalCode], [IdNumber], [Gender], [Nationality], [Phone], [Address], [City], [State], [IsActive], [IsActiveString], [MaritalStatus], [MilitaryService], [LevelOfEducation], [FieldOfStudy], [BankCardNumber], [BankBranch], [InsuranceCode], [InsuranceHistoryByYear], [InsuranceHistoryByMonth], [NumberOfChildren], [CreationDate], [OfficePhone]) VALUES (10107, N'صادق', N'فرخی', NULL, CAST(N'1922-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1922-01-01T00:00:00.0000000' AS DateTime2), NULL, N'2669318622', N'123', N'مرد', N'ایرانی', NULL, N'تست', N'اكبرآباد', N'تهران', 1, N'true', N'متاهل', N'مشمول', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'0', CAST(N'2022-03-28T04:14:17.8182880' AS DateTime2), NULL)
INSERT [dbo].[Employees] ([id], [FName], [LName], [FatherName], [DateOfBirth], [DateOfIssue], [PlaceOfIssue], [NationalCode], [IdNumber], [Gender], [Nationality], [Phone], [Address], [City], [State], [IsActive], [IsActiveString], [MaritalStatus], [MilitaryService], [LevelOfEducation], [FieldOfStudy], [BankCardNumber], [BankBranch], [InsuranceCode], [InsuranceHistoryByYear], [InsuranceHistoryByMonth], [NumberOfChildren], [CreationDate], [OfficePhone]) VALUES (10108, N'محمد', N'تستی', NULL, CAST(N'1922-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1922-01-01T00:00:00.0000000' AS DateTime2), NULL, N'2581658339', NULL, N'مرد', N'ایرانی', NULL, N'kjkjj', N'اشكنان ـ اهل', N'فارس', 1, N'true', N'متاهل', N'مشمول', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'0', CAST(N'2022-03-28T08:19:07.0735692' AS DateTime2), NULL)
INSERT [dbo].[Employees] ([id], [FName], [LName], [FatherName], [DateOfBirth], [DateOfIssue], [PlaceOfIssue], [NationalCode], [IdNumber], [Gender], [Nationality], [Phone], [Address], [City], [State], [IsActive], [IsActiveString], [MaritalStatus], [MilitaryService], [LevelOfEducation], [FieldOfStudy], [BankCardNumber], [BankBranch], [InsuranceCode], [InsuranceHistoryByYear], [InsuranceHistoryByMonth], [NumberOfChildren], [CreationDate], [OfficePhone]) VALUES (10109, N'علی', N'تست زاده', N'تستا', CAST(N'1981-04-04T00:00:00.0000000' AS DateTime2), CAST(N'1981-04-19T00:00:00.0000000' AS DateTime2), N'رشت', N'2650321210', N'65655655', N'مرد', N'ایرانی', N'09115664545', N'تگلباغ نماز - کوچه دریا', N'رشت', N'گیلان', 1, N'true', N'متاهل', N'مشمول', N'دیپلم', N'عمران', NULL, NULL, NULL, N'2', NULL, N'2', CAST(N'2022-07-19T20:29:05.1422817' AS DateTime2), NULL)
INSERT [dbo].[Employees] ([id], [FName], [LName], [FatherName], [DateOfBirth], [DateOfIssue], [PlaceOfIssue], [NationalCode], [IdNumber], [Gender], [Nationality], [Phone], [Address], [City], [State], [IsActive], [IsActiveString], [MaritalStatus], [MilitaryService], [LevelOfEducation], [FieldOfStudy], [BankCardNumber], [BankBranch], [InsuranceCode], [InsuranceHistoryByYear], [InsuranceHistoryByMonth], [NumberOfChildren], [CreationDate], [OfficePhone]) VALUES (10110, N'مهرزاد', N'تست', NULL, CAST(N'1922-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1922-01-01T00:00:00.0000000' AS DateTime2), NULL, N'2581680441', N'65654444', N'مرد', N'ایرانی', NULL, N'زعفرانیه - کوچه 25 - بلاک 12', N'ادران', N'تهران', 1, N'true', N'مجرد', N'مشمول', N'سیکل', NULL, NULL, NULL, NULL, NULL, NULL, N'0', CAST(N'2022-09-16T02:46:58.4081850' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Employees] OFF
SET IDENTITY_INSERT [dbo].[Employers] ON 

INSERT [dbo].[Employers] ([id], [FName], [LName], [ContractingPartyId], [IsActive], [Gender], [Nationalcode], [IdNumber], [Nationality], [FatherName], [DateOfBirth], [DateOfIssue], [PlaceOfIssue], [RegisterId], [NationalId], [EmployerLName], [IsLegal], [Phone], [AgentPhone], [Address], [CreationDate], [EservicePassword], [EserviceUserName], [MclsPassword], [MclsUserName], [SanaPassword], [SanaUserName], [TaxOfficeUserName], [TaxOfficepassword], [EmployerNo], [FullName]) VALUES (11, N'رضا', N'سعیدی', 30340, 1, N'مرد', N'2581569931', N'1354', N'ایرانی', NULL, CAST(N'2022-01-04T00:00:00.0000000' AS DateTime2), CAST(N'2022-01-11T00:00:00.0000000' AS DateTime2), NULL, N'*', N'*', N'*', N'حقیقی', NULL, NULL, N'true', CAST(N'2021-12-24T22:31:56.6153240' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'12', N'رضا سعیدی')
INSERT [dbo].[Employers] ([id], [FName], [LName], [ContractingPartyId], [IsActive], [Gender], [Nationalcode], [IdNumber], [Nationality], [FatherName], [DateOfBirth], [DateOfIssue], [PlaceOfIssue], [RegisterId], [NationalId], [EmployerLName], [IsLegal], [Phone], [AgentPhone], [Address], [CreationDate], [EservicePassword], [EserviceUserName], [MclsPassword], [MclsUserName], [SanaPassword], [SanaUserName], [TaxOfficeUserName], [TaxOfficepassword], [EmployerNo], [FullName]) VALUES (12, N'تستی', N'تست حقوقی 1', 30423, 1, N'مرد', N'2581628073', N'999999', N'ایرانی', NULL, CAST(N'2001-03-25T00:00:00.0000000' AS DateTime2), CAST(N'2001-04-10T00:00:00.0000000' AS DateTime2), NULL, N'7117', N'98876543214', N'تستی', N'حقوقی', NULL, NULL, N'true', CAST(N'2021-12-25T01:49:31.5754691' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'11', N'تست حقوقی 1')
INSERT [dbo].[Employers] ([id], [FName], [LName], [ContractingPartyId], [IsActive], [Gender], [Nationalcode], [IdNumber], [Nationality], [FatherName], [DateOfBirth], [DateOfIssue], [PlaceOfIssue], [RegisterId], [NationalId], [EmployerLName], [IsLegal], [Phone], [AgentPhone], [Address], [CreationDate], [EservicePassword], [EserviceUserName], [MclsPassword], [MclsUserName], [SanaPassword], [SanaUserName], [TaxOfficeUserName], [TaxOfficepassword], [EmployerNo], [FullName]) VALUES (17, N'تستی', N'تست حقوقی', 30423, 1, N'مرد', N'2581628073', N'999999', N'ایرانی', NULL, CAST(N'1984-03-26T00:00:00.0000000' AS DateTime2), CAST(N'2001-04-10T00:00:00.0000000' AS DateTime2), NULL, N'52589', N'10201020103', N'تستی', N'حقوقی', NULL, NULL, N'true', CAST(N'2021-12-25T01:49:31.5754691' AS DateTime2), NULL, NULL, N'test1', N'test', NULL, NULL, NULL, NULL, NULL, N'تست حقوقی')
INSERT [dbo].[Employers] ([id], [FName], [LName], [ContractingPartyId], [IsActive], [Gender], [Nationalcode], [IdNumber], [Nationality], [FatherName], [DateOfBirth], [DateOfIssue], [PlaceOfIssue], [RegisterId], [NationalId], [EmployerLName], [IsLegal], [Phone], [AgentPhone], [Address], [CreationDate], [EservicePassword], [EserviceUserName], [MclsPassword], [MclsUserName], [SanaPassword], [SanaUserName], [TaxOfficeUserName], [TaxOfficepassword], [EmployerNo], [FullName]) VALUES (20029, N'صادق', N'تست 44', 30321, 1, N'مرد', N'2581627972', N'1444', N'ایرانی', NULL, CAST(N'1981-03-22T00:00:00.0000000' AS DateTime2), CAST(N'1981-04-25T00:00:00.0000000' AS DateTime2), NULL, N'*', N'*', N'*', N'حقیقی', NULL, NULL, N'true', CAST(N'2022-01-12T01:11:28.3573883' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'333', N'صادق تست 44')
INSERT [dbo].[Employers] ([id], [FName], [LName], [ContractingPartyId], [IsActive], [Gender], [Nationalcode], [IdNumber], [Nationality], [FatherName], [DateOfBirth], [DateOfIssue], [PlaceOfIssue], [RegisterId], [NationalId], [EmployerLName], [IsLegal], [Phone], [AgentPhone], [Address], [CreationDate], [EservicePassword], [EserviceUserName], [MclsPassword], [MclsUserName], [SanaPassword], [SanaUserName], [TaxOfficeUserName], [TaxOfficepassword], [EmployerNo], [FullName]) VALUES (20030, N'صادق', N'تست 55', 30321, 0, N'مرد', N'2581604948', N'333555', N'ایرانی', NULL, CAST(N'1986-04-12T00:00:00.0000000' AS DateTime2), CAST(N'1986-06-15T00:00:00.0000000' AS DateTime2), NULL, N'*', N'*', N'*', N'حقیقی', NULL, NULL, N'false', CAST(N'2022-01-12T01:52:18.3503203' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'b-31', N'صادق تست 55')
INSERT [dbo].[Employers] ([id], [FName], [LName], [ContractingPartyId], [IsActive], [Gender], [Nationalcode], [IdNumber], [Nationality], [FatherName], [DateOfBirth], [DateOfIssue], [PlaceOfIssue], [RegisterId], [NationalId], [EmployerLName], [IsLegal], [Phone], [AgentPhone], [Address], [CreationDate], [EservicePassword], [EserviceUserName], [MclsPassword], [MclsUserName], [SanaPassword], [SanaUserName], [TaxOfficeUserName], [TaxOfficepassword], [EmployerNo], [FullName]) VALUES (20031, N'صادق', N'فرخی', 30321, 0, N'مرد', N'2669318622', N'150', N'ایرانی', N'شمس', CAST(N'1984-04-23T00:00:00.0000000' AS DateTime2), CAST(N'1984-04-23T00:00:00.0000000' AS DateTime2), N'فومن', N'*', N'*', N'*', N'حقیقی', NULL, NULL, N'false', CAST(N'2022-01-29T00:36:46.6417934' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'13', N'صادق فرخی')
INSERT [dbo].[Employers] ([id], [FName], [LName], [ContractingPartyId], [IsActive], [Gender], [Nationalcode], [IdNumber], [Nationality], [FatherName], [DateOfBirth], [DateOfIssue], [PlaceOfIssue], [RegisterId], [NationalId], [EmployerLName], [IsLegal], [Phone], [AgentPhone], [Address], [CreationDate], [EservicePassword], [EserviceUserName], [MclsPassword], [MclsUserName], [SanaPassword], [SanaUserName], [TaxOfficeUserName], [TaxOfficepassword], [EmployerNo], [FullName]) VALUES (20032, N'سعید', N'سعیدی', 30321, 1, N'مرد', N'2581680441', N'654654', N'ایرانی', N'm', CAST(N'1922-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1922-01-01T00:00:00.0000000' AS DateTime2), N'nmnm', N'*', N'*', N'*', N'حقیقی', NULL, NULL, N'true', CAST(N'2022-02-06T23:55:12.3676578' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'سعید سعیدی')
INSERT [dbo].[Employers] ([id], [FName], [LName], [ContractingPartyId], [IsActive], [Gender], [Nationalcode], [IdNumber], [Nationality], [FatherName], [DateOfBirth], [DateOfIssue], [PlaceOfIssue], [RegisterId], [NationalId], [EmployerLName], [IsLegal], [Phone], [AgentPhone], [Address], [CreationDate], [EservicePassword], [EserviceUserName], [MclsPassword], [MclsUserName], [SanaPassword], [SanaUserName], [TaxOfficeUserName], [TaxOfficepassword], [EmployerNo], [FullName]) VALUES (20033, N'میلاد', N'صمیمی', 30321, 0, N'مرد', N'2581591625', N'15677', N'ایرانی', NULL, CAST(N'2022-03-07T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-15T00:00:00.0000000' AS DateTime2), NULL, N'*', N'*', N'*', N'حقیقی', NULL, NULL, N'false', CAST(N'2022-03-09T00:19:51.4738628' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'میلاد صمیمی')
INSERT [dbo].[Employers] ([id], [FName], [LName], [ContractingPartyId], [IsActive], [Gender], [Nationalcode], [IdNumber], [Nationality], [FatherName], [DateOfBirth], [DateOfIssue], [PlaceOfIssue], [RegisterId], [NationalId], [EmployerLName], [IsLegal], [Phone], [AgentPhone], [Address], [CreationDate], [EservicePassword], [EserviceUserName], [MclsPassword], [MclsUserName], [SanaPassword], [SanaUserName], [TaxOfficeUserName], [TaxOfficepassword], [EmployerNo], [FullName]) VALUES (20034, N'محمد', N'دادهپردازان', 30321, 1, N'مرد', N'2581600438', N'65498', N'ایرانی', NULL, CAST(N'1922-01-01T00:00:00.0000000' AS DateTime2), CAST(N'1922-01-01T00:00:00.0000000' AS DateTime2), NULL, N'1232', N'12345678898', N'سیبسیب', N'حقوقی', NULL, NULL, N'true', CAST(N'2022-03-09T00:23:37.3338434' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'دادهپردازان')
SET IDENTITY_INSERT [dbo].[Employers] OFF
SET IDENTITY_INSERT [dbo].[Files] ON 

INSERT [dbo].[Files] ([id], [ArchiveNo], [ClientVisitDate], [ProceederReference], [Reqester], [Summoned], [Client], [FileClass], [HasMandate], [Description], [CreationDate]) VALUES (5, 1, CAST(N'2022-10-24T00:00:00.0000000' AS DateTime2), NULL, 10107, 11, 0, N'asdasd', 0, NULL, CAST(N'2022-10-27T20:10:30.0197449' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Files] OFF
SET IDENTITY_INSERT [dbo].[Holidayitems] ON 

INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (701, CAST(N'2022-03-21T00:00:00.0000000' AS DateTime2), 38, N'1401', CAST(N'2022-05-13T17:32:56.5489778' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (702, CAST(N'2022-03-24T00:00:00.0000000' AS DateTime2), 38, N'1401', CAST(N'2022-05-13T17:32:56.7378459' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (703, CAST(N'2022-04-02T00:00:00.0000000' AS DateTime2), 38, N'1401', CAST(N'2022-05-13T17:32:56.7454935' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (704, CAST(N'2022-04-23T00:00:00.0000000' AS DateTime2), 38, N'1401', CAST(N'2022-05-13T17:32:56.7510795' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (705, CAST(N'2022-05-03T00:00:00.0000000' AS DateTime2), 38, N'1401', CAST(N'2022-05-13T17:32:56.7554312' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (706, CAST(N'2022-05-04T00:00:00.0000000' AS DateTime2), 38, N'1401', CAST(N'2022-05-13T17:32:56.7603037' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (707, CAST(N'2022-06-04T00:00:00.0000000' AS DateTime2), 38, N'1401', CAST(N'2022-05-13T17:32:56.7652562' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (708, CAST(N'2022-06-05T00:00:00.0000000' AS DateTime2), 38, N'1401', CAST(N'2022-05-13T17:32:56.7715928' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (709, CAST(N'2022-07-10T00:00:00.0000000' AS DateTime2), 38, N'1401', CAST(N'2022-05-13T17:32:56.7781474' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (710, CAST(N'2022-07-18T00:00:00.0000000' AS DateTime2), 38, N'1401', CAST(N'2022-05-13T17:32:56.7850791' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (711, CAST(N'2022-08-07T00:00:00.0000000' AS DateTime2), 38, N'1401', CAST(N'2022-05-13T17:32:56.7906250' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (712, CAST(N'2022-08-08T00:00:00.0000000' AS DateTime2), 38, N'1401', CAST(N'2022-05-13T17:32:56.7952534' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (713, CAST(N'2022-09-17T00:00:00.0000000' AS DateTime2), 38, N'1401', CAST(N'2022-05-13T17:32:56.8004823' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (714, CAST(N'2022-09-25T00:00:00.0000000' AS DateTime2), 38, N'1401', CAST(N'2022-05-13T17:32:56.8077447' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (715, CAST(N'2022-09-26T00:00:00.0000000' AS DateTime2), 38, N'1401', CAST(N'2022-05-13T17:32:56.8129224' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (716, CAST(N'2022-10-04T00:00:00.0000000' AS DateTime2), 38, N'1401', CAST(N'2022-05-13T17:32:56.8189335' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (717, CAST(N'2022-10-13T00:00:00.0000000' AS DateTime2), 38, N'1401', CAST(N'2022-05-13T17:32:56.8249142' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (718, CAST(N'2022-12-27T00:00:00.0000000' AS DateTime2), 38, N'1401', CAST(N'2022-05-13T17:32:56.8303563' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (719, CAST(N'2023-02-04T00:00:00.0000000' AS DateTime2), 38, N'1401', CAST(N'2022-05-13T17:32:56.8353486' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (720, CAST(N'2023-02-11T00:00:00.0000000' AS DateTime2), 38, N'1401', CAST(N'2022-05-13T17:32:56.8402259' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (721, CAST(N'2023-02-18T00:00:00.0000000' AS DateTime2), 38, N'1401', CAST(N'2022-05-13T17:32:56.8443703' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (722, CAST(N'2023-03-08T00:00:00.0000000' AS DateTime2), 38, N'1401', CAST(N'2022-05-13T17:32:56.8489310' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (723, CAST(N'2023-03-20T00:00:00.0000000' AS DateTime2), 38, N'1401', CAST(N'2022-05-13T17:32:56.8553487' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (747, CAST(N'2023-04-19T00:00:00.0000000' AS DateTime2), 39, N'1402', CAST(N'2022-05-18T18:50:41.5519100' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (748, CAST(N'2023-03-22T00:00:00.0000000' AS DateTime2), 39, N'1402', CAST(N'2022-05-18T18:50:41.5599668' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (749, CAST(N'2023-03-23T00:00:00.0000000' AS DateTime2), 39, N'1402', CAST(N'2022-05-18T18:50:41.5660611' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (750, CAST(N'2023-04-01T00:00:00.0000000' AS DateTime2), 39, N'1402', CAST(N'2022-05-18T18:50:41.5711425' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (751, CAST(N'2023-04-02T00:00:00.0000000' AS DateTime2), 39, N'1402', CAST(N'2022-05-18T18:50:41.5755325' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (752, CAST(N'2023-04-12T00:00:00.0000000' AS DateTime2), 39, N'1402', CAST(N'2022-05-18T18:50:41.5819827' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (753, CAST(N'2023-04-22T00:00:00.0000000' AS DateTime2), 39, N'1402', CAST(N'2022-05-18T18:50:41.5867750' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (754, CAST(N'2023-04-23T00:00:00.0000000' AS DateTime2), 39, N'1402', CAST(N'2022-05-18T18:50:41.5915757' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (755, CAST(N'2023-05-16T00:00:00.0000000' AS DateTime2), 39, N'1402', CAST(N'2022-05-18T18:50:41.5982897' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (756, CAST(N'2023-06-04T00:00:00.0000000' AS DateTime2), 39, N'1402', CAST(N'2022-05-18T18:50:41.6032617' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (757, CAST(N'2023-06-05T00:00:00.0000000' AS DateTime2), 39, N'1402', CAST(N'2022-05-18T18:50:41.6087576' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (758, CAST(N'2023-06-29T00:00:00.0000000' AS DateTime2), 39, N'1402', CAST(N'2022-05-18T18:50:41.6150129' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (759, CAST(N'2023-07-27T00:00:00.0000000' AS DateTime2), 39, N'1402', CAST(N'2022-05-18T18:50:41.6207780' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (760, CAST(N'2023-09-06T00:00:00.0000000' AS DateTime2), 39, N'1402', CAST(N'2022-05-18T18:50:41.6260041' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (761, CAST(N'2023-09-14T00:00:00.0000000' AS DateTime2), 39, N'1402', CAST(N'2022-05-18T18:50:41.6351016' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (762, CAST(N'2023-09-23T00:00:00.0000000' AS DateTime2), 39, N'1402', CAST(N'2022-05-18T18:50:41.6404296' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (763, CAST(N'2023-10-02T00:00:00.0000000' AS DateTime2), 39, N'1402', CAST(N'2022-05-18T18:50:41.6458760' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (764, CAST(N'2023-12-16T00:00:00.0000000' AS DateTime2), 39, N'1402', CAST(N'2022-05-18T18:50:41.6523794' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (765, CAST(N'2024-01-24T00:00:00.0000000' AS DateTime2), 39, N'1402', CAST(N'2022-05-18T18:50:41.6671094' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (766, CAST(N'2024-02-07T00:00:00.0000000' AS DateTime2), 39, N'1402', CAST(N'2022-05-18T18:50:41.6741631' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (767, CAST(N'2024-02-11T00:00:00.0000000' AS DateTime2), 39, N'1402', CAST(N'2022-05-18T18:50:41.6839835' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (768, CAST(N'2024-02-25T00:00:00.0000000' AS DateTime2), 39, N'1402', CAST(N'2022-05-18T18:50:41.6910853' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (769, CAST(N'2024-03-19T00:00:00.0000000' AS DateTime2), 39, N'1402', CAST(N'2022-05-18T18:50:41.6989247' AS DateTime2))
INSERT [dbo].[Holidayitems] ([id], [Holidaydate], [HolidayId], [HolidayYear], [CreationDate]) VALUES (770, CAST(N'2023-03-25T00:00:00.0000000' AS DateTime2), 39, N'1402', CAST(N'2022-05-18T18:50:41.7045895' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Holidayitems] OFF
SET IDENTITY_INSERT [dbo].[Holidays] ON 

INSERT [dbo].[Holidays] ([id], [Year], [CreationDate]) VALUES (1, N'1400', CAST(N'2022-05-04T20:10:51.0376554' AS DateTime2))
INSERT [dbo].[Holidays] ([id], [Year], [CreationDate]) VALUES (38, N'1401', CAST(N'2022-05-12T20:43:35.9362757' AS DateTime2))
INSERT [dbo].[Holidays] ([id], [Year], [CreationDate]) VALUES (39, N'1402', CAST(N'2022-05-18T18:48:15.8113423' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Holidays] OFF
SET IDENTITY_INSERT [dbo].[Jobs] ON 

INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (189, N'کارگر ساده', N'24032', CAST(N'2022-03-22T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (190, N'بازاریاب', N'1018', CAST(N'2022-03-23T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (191, N'کارشناس بازاریاب فروش 1', N'33390', CAST(N'2022-03-24T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (192, N'انباردار', N'33119', CAST(N'2022-03-25T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (193, N'منشی', N'27122', CAST(N'2022-03-26T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (194, N'ویزیتور', N'29032', CAST(N'2022-03-27T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (195, N'صندوق دار', N'16015', CAST(N'2022-03-28T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (196, N'فروشنده', N'22020', CAST(N'2022-03-29T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (197, N'استادکار درجه 2', N'137', CAST(N'2022-03-30T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (198, N'کارفرما', N'24398', CAST(N'2022-03-31T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (199, N'مدیر', N'27075', CAST(N'2022-04-01T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (200, N'سرپرست', N'14039', CAST(N'2022-04-02T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (201, N'اموردفتری', N'240', CAST(N'2022-04-03T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (202, N'کارمند', N'24043', CAST(N'2022-04-04T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (203, N'مسئول', N'27084', CAST(N'2022-04-05T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (204, N'مدیرعامل', N'27079', CAST(N'2022-04-06T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (205, N'رئیس هیئت مدیره', N'11015', CAST(N'2022-04-07T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (206, N'عضو هیئت مدیره', N'20010', CAST(N'2022-04-08T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (207, N'کارشناس', N'24019', CAST(N'2022-04-09T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (208, N'مربی', N'27081', CAST(N'2022-04-10T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (209, N'مدرس', N'27073', CAST(N'2022-04-11T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (210, N'اپراتور کامپیوتر', N'97', CAST(N'2022-04-12T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (211, N'متصدی', N'27051', CAST(N'2022-04-13T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (212, N'تکنسین', N'3021', CAST(N'2022-04-14T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (213, N'استادکار', N'131', CAST(N'2022-04-15T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (214, N'نصاب', N'28029', CAST(N'2022-04-16T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (215, N'حسابدار', N'7005', CAST(N'2022-04-17T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (216, N'راننده', N'11007', CAST(N'2022-04-18T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (217, N'نگهبان', N'28047', CAST(N'2022-04-19T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (218, N'رئیس', N'11014', CAST(N'2022-04-20T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (219, N'مهندس', N'27151', CAST(N'2022-04-21T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (220, N'مدیرفروش', N'27270', CAST(N'2022-04-22T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (221, N'کارشناس فنی', N'32829', CAST(N'2022-04-23T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (222, N'مسئول فنی', N'27098', CAST(N'2022-04-24T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (223, N'کارگر فنی', N'24036', CAST(N'2022-04-25T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (224, N'کارپرداز', N'24007', CAST(N'2022-04-26T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (225, N'خدمتگزار', N'8009', CAST(N'2022-04-27T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (226, N'کارشناس حقوق', N'35426', CAST(N'2022-04-28T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (227, N'شاطر', N'15005', CAST(N'2022-04-29T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (228, N'نان پهن کن (وابر)', N'29001', CAST(N'2022-04-30T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (229, N'خمیر گیر', N'8027', CAST(N'2022-05-01T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (230, N'پادو', N'2004', CAST(N'2022-05-02T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (231, N'بسته بند', N'1108', CAST(N'2022-05-03T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (232, N'چونه گیر', N'6026', CAST(N'2022-05-04T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (233, N'فردار', N'22009', CAST(N'2022-05-05T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (234, N'نان پخش کن', N'28009', CAST(N'2022-05-06T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (235, N'نان پز', N'28010', CAST(N'2022-05-07T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (236, N'وردست', N'29014', CAST(N'2022-05-08T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (237, N'پیش خدمت 1', N'36061', CAST(N'2022-05-09T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (238, N'اپراتور میکسر', N'36607', CAST(N'2022-05-10T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (239, N'راننده تراک میکسر', N'36701', CAST(N'2022-05-11T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (240, N'میکسرچی', N'27203', CAST(N'2022-05-12T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (241, N'راننده جرثقیل', N'11009', CAST(N'2022-05-13T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (242, N'راننده خودرو سبک', N'33802', CAST(N'2022-05-14T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (243, N'راننده خودرو سنگین', N'34873', CAST(N'2022-05-15T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (244, N'راننده خودرو نیمه سنگین', N'37368', CAST(N'2022-05-16T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (245, N'راننده لیفتراک', N'35433', CAST(N'2022-05-17T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (246, N'راننده لیفتراک درجه1', N'37522', CAST(N'2022-05-18T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (247, N'راننده نقلیه سبک', N'35446', CAST(N'2022-05-19T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (248, N'راننده نقلیه سنگین', N'35395', CAST(N'2022-05-20T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (249, N'کارگر خدمات', N'34410', CAST(N'2022-05-21T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (250, N'کارشناس تاسیسات', N'35813', CAST(N'2022-05-22T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (251, N'تکنسین برق', N'33485', CAST(N'2022-05-23T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (252, N'کارگر تاسیسات', N'24350', CAST(N'2022-05-24T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (253, N'چرخکار', N'6009', CAST(N'2022-05-25T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (254, N'کارگر جرثقیل', N'24029', CAST(N'2022-05-26T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (255, N'دفتردار', N'9031', CAST(N'2022-05-27T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (256, N'اجاق کار', N'108', CAST(N'2022-05-28T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (257, N'استاد کار خلیفه', N'135', CAST(N'2022-05-29T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (258, N'روغنکار', N'kf0174', CAST(N'2022-05-30T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (259, N'تعمبرکار پمپ انژکتور', N'1111111111', CAST(N'2022-05-31T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (260, N'نظافتچی', N'28038', CAST(N'2022-06-01T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (261, N'پیک', N'2072', CAST(N'2022-06-02T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (262, N'کارگر متفرقه', N'24033', CAST(N'2022-06-03T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (263, N'کمدساز', N'24087', CAST(N'2022-06-04T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (264, N'درب و پنجره ساز', N'9013', CAST(N'2022-06-05T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (265, N'راننده میکسر', N'Bb0069', CAST(N'2022-06-06T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (266, N'راننده لودر', N'11052', CAST(N'2022-06-07T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (267, N'اپراتور جرثقیل درجه 1', N'37488', CAST(N'2022-06-08T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (268, N'سوهان کار', N'14150', CAST(N'2022-06-09T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (269, N'تراشکار درجه 2', N'3030', CAST(N'2022-06-10T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (270, N'مسئول پخش و فروش', N'27002', CAST(N'2022-06-11T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (271, N'نانوا 1', N'36867', CAST(N'2022-06-12T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (272, N'مدیر تولید', N'27078', CAST(N'2022-06-13T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (273, N'کمک نانوا', N'24311', CAST(N'2022-06-14T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (274, N'حسابدار 2 ( حسابداری فروش )', N'33725', CAST(N'2022-06-15T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (275, N'حسابدار ارشد 1', N'35471', CAST(N'2022-06-16T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (276, N'کارمند دفتری 1 ( بازاریاب و فروش )', N'33959', CAST(N'2022-06-17T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (277, N'کارشناس مسئول امور شبکه', N'37959', CAST(N'2022-06-18T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (278, N'كمك حسابدار6', N'2416', CAST(N'2022-06-19T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (279, N'مامور وصول', N'27228', CAST(N'2022-06-20T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (280, N'مشاور', N'27100', CAST(N'2022-06-21T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (281, N'متصدی فنی 1', N'37966', CAST(N'2022-06-22T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (282, N'کمک فروشنده', N'24234', CAST(N'2022-06-23T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (283, N'ظرفشور', N'19001', CAST(N'2022-06-24T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (284, N'کباب پز', N'24051', CAST(N'2022-06-25T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (285, N'حسابگر', N'7007', CAST(N'2022-06-26T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (286, N'سایر کارگران', N'14179', CAST(N'2022-06-27T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (287, N'سرایدار', N'14029', CAST(N'2022-06-28T02:25:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (288, N'چلو پز', N'6020', CAST(N'2022-06-29T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (289, N'کنترل کیفیت 2', N'34840', CAST(N'2022-06-30T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (290, N'مکانیک 1', N'36489', CAST(N'2022-07-01T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (291, N'تخته زن', N'3017', CAST(N'2022-07-02T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (292, N'استادکار صافکار', N'274', CAST(N'2022-07-03T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (293, N'پذیرش', N'2020', CAST(N'2022-07-04T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (294, N'تعمیرکار', N'3057', CAST(N'2022-07-05T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (295, N'باطری ساز', N'1030', CAST(N'2022-07-06T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (296, N'امدادگر', N'195', CAST(N'2022-07-07T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (297, N'جلوبندی ساز', N'5021', CAST(N'2022-07-08T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (298, N'استادکار نقاش', N'273', CAST(N'2022-07-09T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (299, N'راننده وانت', N'11011', CAST(N'2022-07-10T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (300, N'کارشناس فروش', N'34529', CAST(N'2022-07-11T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (301, N'فروشنده قصاب', N'22024', CAST(N'2022-07-12T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (302, N'پیش خدمت', N'2069', CAST(N'2022-07-13T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (303, N'آشپز', N'51', CAST(N'2022-07-14T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (304, N'کارگر عمومی بتن ساز و بتن ریز', N'41606', CAST(N'2022-07-15T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (305, N'اپراتور', N'94', CAST(N'2022-07-16T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (306, N'امور بازرگانی', N'211', CAST(N'2022-07-17T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (307, N'امور مالی و اداری', N'251', CAST(N'2022-07-18T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (308, N'کمک انباردار', N'24109', CAST(N'2022-07-19T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (309, N'کارمند اداری 1', N'33428', CAST(N'2022-07-20T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (310, N'کارشناس کامپیوتر', N'33338', CAST(N'2022-07-21T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (311, N'سرپرست فروش', N'39144', CAST(N'2022-07-22T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (312, N'کارگر پمپ انتقال بتون', N'GA1509', CAST(N'2022-07-23T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (313, N'متصدی دراگلاین', N'GA1506', CAST(N'2022-07-24T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (314, N'راننده ماشین آلات سنگین 055', N'36706', CAST(N'2022-07-25T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (315, N'سرپرست کارگاه', N'14041', CAST(N'2022-07-26T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (316, N'کارخانه 1 کارمند اداری', N'33938', CAST(N'2022-07-27T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (317, N'آبدارچی  و نظافتچی', N'6', CAST(N'2022-07-28T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (318, N'اپراتور بتن ساز', N'72912', CAST(N'2022-07-29T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (319, N'نعمیرات جاری 1 مکانیک', N'34280', CAST(N'2022-07-30T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (320, N'کمک بتن ساز', N'24119', CAST(N'2022-07-31T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (321, N'امور اجرائی', N'202', CAST(N'2022-08-01T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (322, N'گارسون', N'25003', CAST(N'2022-08-02T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (323, N'فیزیوتراپ', N'22033', CAST(N'2022-08-03T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (324, N'موزع', N'27139', CAST(N'2022-08-04T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (325, N'مشاور حقوقی', N'52433', CAST(N'2022-08-05T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (326, N'راننده 3', N'52791', CAST(N'2022-08-06T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (327, N'مسئول ایمنی و بهداشت', N'32904', CAST(N'2022-08-07T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (328, N'دفتر فنی', N'9062', CAST(N'2022-08-08T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (329, N'انفورماتیک', N'38142', CAST(N'2022-08-09T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (330, N'کارگر انبار', N'24122', CAST(N'2022-08-10T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (331, N'رئیس حسابداری مالی', N'33764', CAST(N'2022-08-11T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (332, N'مدیر انبارها', N'36558', CAST(N'2022-08-12T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (333, N'مدیر مالی', N'34235', CAST(N'2022-08-13T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (334, N'تلمبه چی', N'3082', CAST(N'2022-08-14T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (335, N'اپراتور پجینگ بتن سازی', N'32716', CAST(N'2022-08-15T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (336, N'وکیل', N'29025', CAST(N'2022-08-16T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (337, N'امور اداری', N'203', CAST(N'2022-08-17T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (338, N'کارشناس مالی', N'33871', CAST(N'2022-08-18T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (339, N'مدیر امور اداری ومالی', N'27237', CAST(N'2022-08-19T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (340, N'رئیس آموزش و توسعه', N'38542', CAST(N'2022-08-20T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (341, N'توزیع کننده کالا', N'3107', CAST(N'2022-08-21T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (342, N'کارمند امور عمومی', N'24358', CAST(N'2022-08-22T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (343, N'کارشناس نرم افزار کامپیوتر', N'33022', CAST(N'2022-08-23T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (344, N'تکنسین نقشه کشی و طراحی', N'33715', CAST(N'2022-08-24T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (345, N'نقشه کش', N'37175', CAST(N'2022-08-25T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (346, N'تکنسین نقشه برداری', N'35534', CAST(N'2022-08-26T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (347, N'کمک حسابدار', N'24165', CAST(N'2022-08-27T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (348, N'طراح', N'18003', CAST(N'2022-08-28T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (349, N'بستنی ساز', N'1106', CAST(N'2022-08-29T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (350, N'تحصیل دار', N'3011', CAST(N'2022-08-30T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (351, N'باغبان', N'1031', CAST(N'2022-08-31T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (352, N'دامپزشک', N'9007', CAST(N'2022-09-01T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (353, N'کارشناس مهندسی', N'33023', CAST(N'2022-09-02T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (354, N'جانشین مدیر کارخانه', N'44434', CAST(N'2022-09-03T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (355, N'کمک آشپز', N'24098', CAST(N'2022-09-04T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (356, N'سرآشپز', N'14021', CAST(N'2022-09-05T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (357, N'سالن دار', N'14012', CAST(N'2022-09-06T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (358, N'سرپرست وصول اجناس', N'37053', CAST(N'2022-09-07T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (359, N'کمک تعمیرکار', N'24148', CAST(N'2022-09-08T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (360, N'مدیرداخلی', N'27208', CAST(N'2022-09-09T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (361, N'نسخه خوان', N'28026', CAST(N'2022-09-10T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (362, N'نسخه پیچ', N'28025', CAST(N'2022-09-11T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (363, N'متصدی تدارکات', N'27215', CAST(N'2022-09-12T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (364, N'صافکار', N'16001', CAST(N'2022-09-13T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (365, N'مهندسی مکانیک درجه 1', N'771778', CAST(N'2022-09-14T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (366, N'حسابداراتوسرویس', N'7021', CAST(N'2022-09-15T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (367, N'باسکول چی', N'1028', CAST(N'2022-09-16T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (368, N'کارمنددفتری(مالی)', N'33976', CAST(N'2022-09-17T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (369, N'مهندس مکانیک', N'45280', CAST(N'2022-09-18T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (370, N'مهندس کنترل کیفیت', N'27186', CAST(N'2022-09-19T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (371, N'مدیر بازرگانی', N'27076', CAST(N'2022-09-20T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (372, N'اپراتورپمپ بتن', N'36581', CAST(N'2022-09-21T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (373, N'تراشکاردرجه1', N'3031', CAST(N'2022-09-22T02:25:00.0000000' AS DateTime2))
INSERT [dbo].[Jobs] ([id], [JobName], [JobCode], [CreationDate]) VALUES (374, N'پیشکار', N'2071', CAST(N'2022-09-23T02:25:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Jobs] OFF
SET IDENTITY_INSERT [dbo].[karfarmahhaa] ON 

INSERT [dbo].[karfarmahhaa] ([Id], [Name], [Family], [NationalCode], [CreationDate]) VALUES (1, N'علی', N'رضایی2', N'55', CAST(N'2022-08-10T14:31:07.8889049' AS DateTime2))
INSERT [dbo].[karfarmahhaa] ([Id], [Name], [Family], [NationalCode], [CreationDate]) VALUES (2, N'dsfsddsf', N'sdfsdf', N'34', CAST(N'2022-08-10T14:44:02.0333151' AS DateTime2))
INSERT [dbo].[karfarmahhaa] ([Id], [Name], [Family], [NationalCode], [CreationDate]) VALUES (3, N'jkhjh', N'lkl;k', N'7897', CAST(N'2022-08-10T14:47:53.2720770' AS DateTime2))
INSERT [dbo].[karfarmahhaa] ([Id], [Name], [Family], [NationalCode], [CreationDate]) VALUES (4, N'xcdas', N'sdasd', N'23', CAST(N'2022-08-10T14:56:32.4951327' AS DateTime2))
INSERT [dbo].[karfarmahhaa] ([Id], [Name], [Family], [NationalCode], [CreationDate]) VALUES (5, N'asas', N'23', N'22', CAST(N'2022-08-10T14:57:34.3849361' AS DateTime2))
INSERT [dbo].[karfarmahhaa] ([Id], [Name], [Family], [NationalCode], [CreationDate]) VALUES (6, N'asas', N'asas', N'445', CAST(N'2022-08-10T15:09:18.6709122' AS DateTime2))
INSERT [dbo].[karfarmahhaa] ([Id], [Name], [Family], [NationalCode], [CreationDate]) VALUES (7, N'khjkljh', N'kjhjkh', N'4154', CAST(N'2022-08-10T15:11:46.5684900' AS DateTime2))
INSERT [dbo].[karfarmahhaa] ([Id], [Name], [Family], [NationalCode], [CreationDate]) VALUES (8, N'cvgbcv', N'cvbcv', N'3434', CAST(N'2022-08-10T15:17:05.0559758' AS DateTime2))
INSERT [dbo].[karfarmahhaa] ([Id], [Name], [Family], [NationalCode], [CreationDate]) VALUES (9, N'1kjghkjhkj', N'ghfghgh', N'1651', CAST(N'2022-08-10T15:21:59.3878727' AS DateTime2))
SET IDENTITY_INSERT [dbo].[karfarmahhaa] OFF
SET IDENTITY_INSERT [dbo].[MandatoryHours] ON 

INSERT [dbo].[MandatoryHours] ([id], [Year], [Farvardin], [Ordibehesht], [Khordad], [Tir], [Mordad], [Shahrivar], [Mehr], [Aban], [Azar], [Dey], [Bahman], [Esfand], [CreationDate]) VALUES (1, 1400, 256.12, 254.25, 4545, 4545, 4545, 4545, 4545, 4545, 4545, 4545, 4545, 4545, CAST(N'2022-04-06T21:37:22.6221896' AS DateTime2))
SET IDENTITY_INSERT [dbo].[MandatoryHours] OFF
SET IDENTITY_INSERT [dbo].[PersonalContractingParties] ON 

INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30321, N'ایاد', N'سهرابی', N'4219567992', N'272', N'9112222222', NULL, N'test', CAST(N'2021-10-23T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30322, N'زهرا', N'رضا زاده کاشانی', N'2063327335', N'123', N'', N'', N'', CAST(N'2021-10-24T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30323, N'ابراهیم', N'ابراهیمی خناچاه', N'2591358941', N'930', N'', N'', N'', CAST(N'2021-10-25T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30324, N'مجید', N'ذات پرور', N'2590835833', N'42', N'', N'', N'', CAST(N'2021-10-26T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30325, N'دانیال', N'کهنی', N'2580725687', N'2580725687', N'', N'', N'', CAST(N'2021-10-27T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30326, N'سهیل', N'لاهیجی کلاچاهی', N'5180011833', N'0', N'', N'', N'', CAST(N'2021-10-28T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30327, N'جواد', N'نباتی', N'2595971417', N'3730', N'', N'', N'', CAST(N'2021-10-29T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30328, N'حسین', N'صابر زعیمیان', N'2593753110', N'240', N'', N'', N'', CAST(N'2021-10-30T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30329, N'رحیله', N'حسینی بلوچی', N'2591568618', N'1017', N'', N'', N'', CAST(N'2021-10-31T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30330, N'حسن', N'هویدائی فر', N'2590773560', N'36256', N'', N'', N'', CAST(N'2021-11-01T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30331, N'حمیدرضا', N'بهروزفر', N'2739248032', N'342', N'', N'', N'', CAST(N'2021-11-02T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30332, N'شیرین', N'قاسمی', N'68334745', N'3811', N'', N'', N'', CAST(N'2021-11-03T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30333, N'محمد', N'غلام نژاد هندخاله', N'2679719574', N'20', N'', N'', N'', CAST(N'2021-11-04T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30334, N'سکینه', N'میرزائی مقدم بوئینی', N'2668412390', N'1151', N'', N'', N'', CAST(N'2021-11-05T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30335, N'رضا', N'پورعلی اکبر', N'2594339067', N'1368', N'', N'', N'', CAST(N'2021-11-06T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30336, N'محبوب', N'خورسندجو', N'2593045019', N'1549', N'', N'', N'', CAST(N'2021-11-07T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30337, N'ابراهیم - جواد', N'فلاح دوست خسمخی - عابدین زاده احمد گورابی', N'2669509721', N'22', N'', N'', N'', CAST(N'2021-11-08T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30338, N'مهرداد', N'عباسی', N'2591194270', N'2535', N'', N'', N'', CAST(N'2021-11-09T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30339, N'حسین', N'نوزاد آج بیشه', N'2595836242', N'9219', N'', N'', N'', CAST(N'2021-11-10T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30340, N'فرزاد', N'بطی', N'534819176', N'8122', N'', N'', N'', CAST(N'2021-11-11T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30341, N'محمدرضا', N'تقی زاد عدلی', N'76349543', N'2484', N'', N'', N'', CAST(N'2021-11-12T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30342, N'حمید رضا', N'گلدانی گشتی', N'2580192786', N'0', N'', N'', N'', CAST(N'2021-11-13T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30343, N'حسین', N'کهنی', N'5189399125', N'1853', N'', N'', N'', CAST(N'2021-11-14T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30344, N'علی اصغر', N'اسمعیل دوست کیاسرائی', N'5188828871', N'4298', N'', N'', N'', CAST(N'2021-11-15T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30345, N'حسین', N'رجاء بهشتی', N'2594085960', N'253', N'', N'', N'', CAST(N'2021-11-16T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30346, N'میثم', N'حافظی امشل', N'2730140379', N'2730140379', N'', N'', N'', CAST(N'2021-11-17T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30347, N'علیرضا', N'رازی زاده', N'2594421723', N'1046', N'', N'', N'', CAST(N'2021-11-18T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30348, N'شهروز', N'کهنی', N'2580222480', N'0', N'', N'', N'', CAST(N'2021-11-19T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30349, N'سامان', N'گلزارنیا', N'74890735', N'9676', N'', N'', N'', CAST(N'2021-11-20T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30350, N'امین', N'معصومیان', N'2659850569', N'48', N'', N'', N'', CAST(N'2021-11-21T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30351, N'شهرام', N'مولودی راد', N'2668063957', N'11886', N'', N'', N'', CAST(N'2021-11-22T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30352, N'علیرضا', N'رضی ساجدی', N'2721518216', N'158', N'', N'', N'', CAST(N'2021-11-23T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30353, N'حمید', N'امینی باغی', N'5189295001', N'573', N'', N'', N'', CAST(N'2021-11-24T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30354, N'کمیل', N'حسین زاده', N'2669308368', N'265', N'', N'', N'', CAST(N'2021-11-25T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30355, N'سهیل', N'لطفی', N'3242197275', N'3242197275', N'', N'', N'', CAST(N'2021-11-26T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30356, N'محمد باقر', N'غمزدائیان', N'2593727829', N'705', N'', N'', N'', CAST(N'2021-11-27T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30357, N'سیده زهرا', N'میر طرقی خواجکینی', N'5180101298', N'5180101298', N'', N'', N'', CAST(N'2021-11-28T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30358, N'رضا', N'رمضانی چلارسی', N'2593860138', N'812', N'', N'', N'', CAST(N'2021-11-29T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30359, N'حامد', N'همتی', N'2593782641', N'1150', N'', N'', N'', CAST(N'2021-11-30T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30360, N'سید رضا', N'موسوی زاده', N'1639691804', N'8', N'', N'', N'', CAST(N'2021-12-01T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30361, N'سید یوسف', N'طیبی کرباسدهی', N'2592251219', N'578', N'', N'', N'', CAST(N'2021-12-02T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30362, N'غلامرضا', N'ابراهیمی خناچاه', N'2591363714', N'135', N'', N'', N'', CAST(N'2021-12-03T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30363, N'اسماعیل', N'صدقی فر', N'2594494471', N'1300', N'', N'', N'', CAST(N'2021-12-04T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30364, N'سمانه', N'پاکدل مجد', N'2580574956', N'0', N'', N'', N'', CAST(N'2021-12-05T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30365, N'علیرضا', N'محمودی', N'2591177740', N'33606', N'', N'', N'', CAST(N'2021-12-06T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30366, N'محمد', N'اقازاده کماکلی', N'2580310541', N'2580310541', N'', N'', N'', CAST(N'2021-12-07T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30367, N'رضا', N'روشن ضمیر مدبری', N'2580138005', N'2580138005', N'', N'', N'', CAST(N'2021-12-08T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30368, N'عباس', N'ناصحی جورشری', N'2594883026', N'51', N'', N'', N'', CAST(N'2021-12-09T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30369, N'مصطفی', N'لطفی پیربازاری', N'2592097521', N'354', N'', N'', N'', CAST(N'2021-12-10T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30370, N'محمدمهدی', N'رخشان', N'2593342390', N'2593342390', N'', N'', N'', CAST(N'2021-12-11T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30371, N'رحیم', N'بلند پور', N'2593022086', N'4311', N'', N'', N'', CAST(N'2021-12-12T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30372, N'علی', N'یاسایی', N'69166137', N'7124', N'', N'', N'', CAST(N'2021-12-13T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30373, N'موسی', N'رنجبر پیر بستی', N'2595237667', N'60', N'', N'', N'', CAST(N'2021-12-14T01:31:00.0000000' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30374, N'*', N'مارلیک کار شمال', N'*', N'*', N'', N'', N'', CAST(N'2021-10-23T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720271508', N'15188')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30375, N'*', N'داده پردازان سورن ایرانیان', N'*', N'*', N'', N'', N'', CAST(N'2021-10-24T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720302615', N'18153')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30376, N'*', N'افزار داده سامانه', N'*', N'*', N'', N'', N'', CAST(N'2021-10-25T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720239131', N'10958')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30377, N'*', N'کاسانه گیلان', N'*', N'*', N'', N'', N'', CAST(N'2021-10-26T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720168220', N'3362')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30378, N'*', N'عمران اندیش گیلوار', N'*', N'*', N'', N'', N'', CAST(N'2021-10-27T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720198199', N'6432')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30379, N'*', N'شتاب خودرو گیل', N'*', N'*', N'', N'', N'', CAST(N'2021-10-28T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720294947', N'17475')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30380, N'*', N'شکوفه موتور گیلان', N'*', N'*', N'', N'', N'', CAST(N'2021-10-29T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720178508', N'4415')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30381, N'*', N'پاک سماء شمال', N'*', N'*', N'', N'', N'', CAST(N'2021-10-30T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720303635', N'18247')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30382, N'*', N'پاس گستر کاسپین', N'*', N'*', N'', N'', N'', CAST(N'2021-10-31T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720265393', N'14598')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30383, N'*', N'پارسیس سگال پویا', N'*', N'*', N'', N'', N'', CAST(N'2021-11-01T01:31:00.0000000' AS DateTime2), N'حقوقی', N'14005493939', N'19521')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30384, N'*', N'مانی تجارت گیل', N'*', N'*', N'', N'', N'', CAST(N'2021-11-02T01:31:00.0000000' AS DateTime2), N'حقوقی', N'14007773740', N'21310')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30385, N'*', N'نان اوران سبز شمال', N'*', N'*', N'', N'', N'', CAST(N'2021-11-03T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720278519', N'15873')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30386, N'*', N'هیوا نو آوران داده گستر', N'*', N'*', N'', N'', N'', CAST(N'2021-11-04T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720297477', N'17703')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30387, N'*', N'سلامت گستر سانیار', N'*', N'*', N'', N'', N'', CAST(N'2021-11-05T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720249797', N'12056')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30388, N'*', N'ژرف افلاک شریف', N'*', N'*', N'', N'', N'', CAST(N'2021-11-06T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720229764', N'9901')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30389, N'*', N'پیشگامان الکترو نوآوری گیل', N'*', N'*', N'', N'', N'', CAST(N'2021-11-07T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10860005281', N'13600')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30390, N'*', N'نور داد مهرگستر کاسپین', N'*', N'*', N'', N'', N'', CAST(N'2021-11-08T01:31:00.0000000' AS DateTime2), N'حقوقی', N'14009970584', N'1727')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30391, N'*', N'طرح و نقش ساباط سازان خزر', N'*', N'*', N'', N'', N'', CAST(N'2021-11-09T01:31:00.0000000' AS DateTime2), N'حقوقی', N'14005134095', N'19282')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30392, N'*', N'شاهین کالای گیل', N'*', N'*', N'', N'', N'', CAST(N'2021-11-10T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720254248', N'12511')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30393, N'*', N'فرهنگ گستر نخبگان', N'*', N'*', N'', N'', N'', CAST(N'2021-11-11T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720266760', N'14727')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30394, N'*', N'قائم پخش آدرین', N'*', N'*', N'', N'', N'', CAST(N'2021-11-12T01:31:00.0000000' AS DateTime2), N'حقوقی', N'14006229103', N'210')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30395, N'*', N'آرنگ پخش نوین کاسپین', N'*', N'*', N'', N'', N'', CAST(N'2021-11-13T01:31:00.0000000' AS DateTime2), N'حقوقی', N'14006976224', N'20636')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30396, N'*', N'یکتا تجارت گیل', N'*', N'*', N'', N'', N'', CAST(N'2021-11-14T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720299217', N'17852')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30397, N'*', N'تولیدی اکسیر رشد کاسپین', N'*', N'*', N'', N'', N'', CAST(N'2021-11-15T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720216879', N'8578')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30398, N'*', N'کهن سرویس وارنا', N'*', N'*', N'', N'', N'', CAST(N'2021-11-16T01:31:00.0000000' AS DateTime2), N'حقوقی', N'14009102317', N'22309')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30399, N'*', N'پایا بتن سپیدرود', N'*', N'*', N'', N'', N'', CAST(N'2021-11-17T01:31:00.0000000' AS DateTime2), N'حقوقی', N'14004238237', N'18826')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30400, N'*', N'سلامت گستر سانیار', N'*', N'*', N'', N'', N'', CAST(N'2021-11-18T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720249797', N'12056')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30401, N'*', N'پوریا پلاست کاسپین خزر', N'*', N'*', N'', N'', N'', CAST(N'2021-11-19T01:31:00.0000000' AS DateTime2), N'حقوقی', N'14009274720', N'22427')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30402, N'*', N'گیل پخش اطلس آرا', N'*', N'*', N'', N'', N'', CAST(N'2021-11-20T01:31:00.0000000' AS DateTime2), N'حقوقی', N'14007538724', N'21099')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30403, N'*', N'نمایندگی بیمه سفیران آرامش طلوع فردا', N'*', N'*', N'', N'', N'', CAST(N'2021-11-21T01:31:00.0000000' AS DateTime2), N'حقوقی', N'14009379867', N'22526')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30404, N'*', N'کاروس پرور خطه سبز', N'*', N'*', N'', N'', N'', CAST(N'2021-11-22T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720266073', N'14662')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30405, N'*', N'شرکت صنایع بسته بندی سفید رود اشرفیه', N'*', N'*', N'', N'', N'', CAST(N'2021-11-23T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720089199', N'683')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30406, N'*', N'کارآفرینان شایسته فاخر', N'*', N'*', N'', N'', N'', CAST(N'2021-11-24T01:31:00.0000000' AS DateTime2), N'حقوقی', N'14008804054', N'1634')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30407, N'*', N'ساینا دوین شرق', N'*', N'*', N'', N'', N'', CAST(N'2021-11-25T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10380320796', N'16482')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30408, N'*', N'تولیدی صنعتی برهان نیروی شمال', N'*', N'*', N'', N'', N'', CAST(N'2021-11-26T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720280229', N'16037')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30409, N'*', N'شرکت پارس گفتمان معماری شهر', N'*', N'*', N'', N'', N'', CAST(N'2021-11-27T01:31:00.0000000' AS DateTime2), N'حقوقی', N'14008319280', N'21713')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30410, N'*', N'به پخش اطلس سلامت کاسپین', N'*', N'*', N'', N'', N'', CAST(N'2021-11-28T01:31:00.0000000' AS DateTime2), N'حقوقی', N'14009484241', N'22618')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30411, N'*', N'ایده آل بتن زحمتکش', N'*', N'*', N'', N'', N'', CAST(N'2021-11-29T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720283177', N'16337')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30412, N'*', N'ماندگار بتن زحمتکش', N'*', N'*', N'', N'', N'', CAST(N'2021-11-30T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720231250', N'10053')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30413, N'*', N'پارس پاکت خزر گلسار', N'*', N'*', N'', N'', N'', CAST(N'2021-12-01T01:31:00.0000000' AS DateTime2), N'حقوقی', N'14009800947', N'18254')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30414, N'*', N'سیب سامانه', N'*', N'*', N'', N'', N'', CAST(N'2021-12-02T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720194896', N'6107')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30415, N'*', N'پیشخوان خدمات دولت و بخش عمومی گلسار رشت', N'*', N'*', N'', N'', N'', CAST(N'2021-12-03T01:31:00.0000000' AS DateTime2), N'حقوقی', N'14008783321', N'22056')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30416, N'*', N'ماموت سامانه گیلان', N'*', N'*', N'', N'', N'', CAST(N'2021-12-04T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720252056', N'12288')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30417, N'*', N'شرکت حقوقی مجازی', N'*', N'*', N'', N'', N'', CAST(N'2021-12-05T01:31:00.0000000' AS DateTime2), N'حقوقی', N'11223344556', N'21265')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30418, N'*', N'ریواس سیستم پارس', N'*', N'*', N'', N'', N'', CAST(N'2021-12-06T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720226611', N'9573')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30419, N'*', N'شرکت ساختمانی خزر مرآت', N'*', N'*', N'', N'', N'', CAST(N'2021-12-07T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720163663', N'2915')
GO
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30420, N'*', N'گیل همراه سبز', N'*', N'*', N'', N'', N'', CAST(N'2021-12-08T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720202982', N'6932')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30421, N'*', N'آسا اکسیژن آرکا', N'*', N'*', N'', N'', N'', CAST(N'2021-12-09T01:31:00.0000000' AS DateTime2), N'حقوقی', N'14008650139', N'54784')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30422, N'*', N'همیار انرژی گستر مهر', N'*', N'*', N'', N'', N'', CAST(N'2021-12-10T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720305962', N'18466')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30423, N'*', N'سیال  سامانه اندیشه', N'*', N'*', N'', N'', N'', CAST(N'2021-12-11T01:31:00.0000000' AS DateTime2), N'حقوقی', N'10720261917', N'14261')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30424, N'*', N'تستی', N'*', N'*', NULL, NULL, NULL, CAST(N'2021-12-09T21:22:00.0000000' AS DateTime2), N'حقوقی', N'23564568974', N'1231')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (30426, N'*', N'تست 2', N'*', N'*', NULL, NULL, NULL, CAST(N'2021-12-12T22:59:43.6091908' AS DateTime2), N'حقوقی', N'12125498765', N'12321211')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (40321, N'صادق', N'فرخی2', N'2581658339', N'565654', NULL, NULL, NULL, CAST(N'2022-01-20T23:00:17.0075431' AS DateTime2), N'حقیقی', N'*', N'*')
INSERT [dbo].[PersonalContractingParties] ([id], [FName], [LName], [Nationalcode], [IdNumber], [Phone], [AgentPhone], [Address], [CreationDate], [IsLegal], [NationalId], [RegisterId]) VALUES (40322, N'صادق', N'فرخی', N'2669318622', N'150', NULL, NULL, NULL, CAST(N'2022-01-29T00:35:31.7937810' AS DateTime2), N'حقیقی', N'*', N'*')
SET IDENTITY_INSERT [dbo].[PersonalContractingParties] OFF
SET IDENTITY_INSERT [dbo].[Petitions] ON 

INSERT [dbo].[Petitions] ([id], [PetitionIssuanceDate], [NotificationPetitionDate], [TotalPenalty], [TotalPenaltyTitles], [Description], [BoardType_Id], [File_Id], [CreationDate]) VALUES (8, CAST(N'2022-10-23T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-23T00:00:00.0000000' AS DateTime2), N'12311', N'500', NULL, 1, 5, CAST(N'2022-10-27T22:25:11.0287396' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Petitions] OFF
SET IDENTITY_INSERT [dbo].[RolePermissions] ON 

INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (1, 100, 9)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (2, 101, 9)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (3, 10110, 9)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (4, 10111, 9)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (5, 10112, 9)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (6, 0, 9)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (7, 0, 9)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (8, 0, 9)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (9, 0, 9)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (10, 0, 9)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (11, 0, 9)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (12, 0, 9)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (13, 0, 9)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (14, 0, 9)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (15, 0, 9)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (46, 100, 10)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (47, 101, 10)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (48, 10110, 10)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (49, 10111, 10)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (50, 10112, 10)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (51, 102, 10)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (52, 10210, 10)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (53, 10211, 10)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (54, 10212, 10)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (55, 10213, 10)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (56, 10214, 10)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (57, 10216, 10)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (662, 100, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (663, 10314, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (664, 10315, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (665, 10316, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (666, 104, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (667, 10410, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (668, 10411, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (669, 10412, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (670, 10414, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (671, 10415, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (672, 10416, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (673, 105, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (674, 10510, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (675, 10511, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (676, 10512, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (677, 10514, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (678, 10312, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (679, 10311, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (680, 10310, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (681, 103, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (682, 101, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (683, 10110, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (684, 10111, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (685, 10112, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (686, 10113, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (687, 10114, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (688, 10115, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (689, 10515, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (690, 10116, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (691, 10210, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (692, 10211, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (693, 10212, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (694, 10213, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (695, 10214, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (696, 10215, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (697, 10216, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (698, 102, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (699, 10516, 12)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (700, 600, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (701, 400, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (702, 10411, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (703, 10410, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (704, 104, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (705, 10316, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (706, 10315, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (707, 10314, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (708, 10312, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (709, 10311, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (710, 10310, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (711, 103, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (712, 10216, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (713, 10412, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (714, 10214, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (715, 10212, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (716, 10211, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (717, 10210, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (718, 102, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (719, 10115, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (720, 10114, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (721, 10113, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (722, 10112, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (723, 10111, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (724, 10110, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (725, 101, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (726, 10213, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (727, 10414, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (728, 10415, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (729, 10416, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (730, 306, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (731, 305, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (732, 304, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (733, 303, 1)
GO
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (734, 302, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (735, 301, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (736, 300, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (737, 20118, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (738, 20117, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (739, 20116, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (740, 20115, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (741, 20114, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (742, 20113, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (743, 20112, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (744, 20111, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (745, 20110, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (746, 201, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (747, 200, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (748, 10516, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (749, 10515, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (750, 10514, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (751, 10512, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (752, 10511, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (753, 10510, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (754, 105, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (755, 500, 1)
INSERT [dbo].[RolePermissions] ([Id], [Code], [RoleId]) VALUES (756, 100, 1)
SET IDENTITY_INSERT [dbo].[RolePermissions] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([id], [Name], [CreationDate]) VALUES (1, N'مدیر سیستم', CAST(N'2021-12-02T19:18:26.2603589' AS DateTime2))
INSERT [dbo].[Roles] ([id], [Name], [CreationDate]) VALUES (2, N'کاربر عادی', CAST(N'2021-12-03T20:05:48.5632082' AS DateTime2))
INSERT [dbo].[Roles] ([id], [Name], [CreationDate]) VALUES (4, N'میلاد دلیری', CAST(N'2022-10-14T18:19:42.8638602' AS DateTime2))
INSERT [dbo].[Roles] ([id], [Name], [CreationDate]) VALUES (6, N'تست', CAST(N'2022-10-14T18:36:23.4066688' AS DateTime2))
INSERT [dbo].[Roles] ([id], [Name], [CreationDate]) VALUES (7, N'تست 2', CAST(N'2022-10-14T18:39:15.5405114' AS DateTime2))
INSERT [dbo].[Roles] ([id], [Name], [CreationDate]) VALUES (8, N'تیت', CAST(N'2022-10-14T18:58:21.1651552' AS DateTime2))
INSERT [dbo].[Roles] ([id], [Name], [CreationDate]) VALUES (9, N'تست3', CAST(N'2022-10-14T19:14:00.5701603' AS DateTime2))
INSERT [dbo].[Roles] ([id], [Name], [CreationDate]) VALUES (10, N'تست 4', CAST(N'2022-10-14T19:22:56.5386743' AS DateTime2))
INSERT [dbo].[Roles] ([id], [Name], [CreationDate]) VALUES (11, N'تست 5', CAST(N'2022-10-14T19:33:33.8180593' AS DateTime2))
INSERT [dbo].[Roles] ([id], [Name], [CreationDate]) VALUES (12, N'تست دیتابیس', CAST(N'2022-10-22T19:50:16.5584661' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[TextManager_Contact] ON 

INSERT [dbo].[TextManager_Contact] ([id], [NameContact], [CreationDate]) VALUES (1, N'علی محمدی', CAST(N'2022-11-05T19:48:20.1308942' AS DateTime2))
SET IDENTITY_INSERT [dbo].[TextManager_Contact] OFF
SET IDENTITY_INSERT [dbo].[TextManager_Module] ON 

INSERT [dbo].[TextManager_Module] ([id], [NameSubModule], [CreationDate]) VALUES (1, N'قرارداد تست', CAST(N'2022-11-05T19:44:42.5711815' AS DateTime2))
SET IDENTITY_INSERT [dbo].[TextManager_Module] OFF
INSERT [dbo].[TextManager_ModuleTextManager] ([ModuleId], [TextManagerId]) VALUES (1, 1)
SET IDENTITY_INSERT [dbo].[TextManager_OriginalTitle] ON 

INSERT [dbo].[TextManager_OriginalTitle] ([id], [Title], [CreationDate]) VALUES (1, N'تست 1', CAST(N'2022-11-05T19:43:48.5747854' AS DateTime2))
SET IDENTITY_INSERT [dbo].[TextManager_OriginalTitle] OFF
SET IDENTITY_INSERT [dbo].[TextManager_Subtitle] ON 

INSERT [dbo].[TextManager_Subtitle] ([id], [Subtitle], [OriginalTitle_Id], [CreationDate]) VALUES (1, N'بخش تستی 1', 1, CAST(N'2022-11-05T19:44:16.2711961' AS DateTime2))
SET IDENTITY_INSERT [dbo].[TextManager_Subtitle] OFF
SET IDENTITY_INSERT [dbo].[TextManager_TextManager] ON 

INSERT [dbo].[TextManager_TextManager] ([id], [NoteNumber], [SubjectTextManager], [NumberTextManager], [DateTextManager], [Description], [Paragraph], [Status], [OriginalTitle_Id], [Subtitles_Id], [CreationDate]) VALUES (1, 123, N'نننن', 20, CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), N'شسیشسیشسی', N'شسیشسی', 0, 1, 1, CAST(N'2022-11-05T19:45:36.8418837' AS DateTime2))
SET IDENTITY_INSERT [dbo].[TextManager_TextManager] OFF
SET IDENTITY_INSERT [dbo].[WorkHistories] ON 

INSERT [dbo].[WorkHistories] ([id], [FromDate], [ToDate], [WorkingHoursPerDay], [WorkingHoursPerWeek], [Description], [Petition_Id], [CreationDate]) VALUES (5, CAST(N'2022-10-24T00:00:00.0000000' AS DateTime2), CAST(N'2022-10-24T00:00:00.0000000' AS DateTime2), 12, NULL, NULL, 8, CAST(N'2022-10-27T22:39:16.5710261' AS DateTime2))
SET IDENTITY_INSERT [dbo].[WorkHistories] OFF
SET IDENTITY_INSERT [dbo].[WorkingHours] ON 

INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (15, N'1', N'3/1/01/6', N'17', N'4', N'294', NULL, N'169', N'20', N'21', NULL, N'44', 86, CAST(N'2022-08-26T02:06:23.4171398' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (16, N'2', N'3/1/01/7', N'26', NULL, N'351', NULL, N'160', N'20', N'39', NULL, N'44', 87, CAST(N'2022-08-26T02:08:20.4762228' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (17, N'5', N'3/1/01/8', N'19', N'4', N'240', NULL, N'49', N'20', N'80', NULL, N'24 - 12', 88, CAST(N'2022-08-26T02:09:41.2779828' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (18, N'6', N'3/1/01/9', N'15', N'4', N'360', NULL, N'169', N'20', N'120', NULL, N'24 - 24', 89, CAST(N'2022-08-26T02:11:32.9603392' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (19, N'7', N'3/1/01/10', N'15', N'5', N'180', NULL, N'4', NULL, N'45', NULL, N'36 - 12', 90, CAST(N'2022-08-26T02:12:58.4893183' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (20, N'8', N'5/1/01/11', N'10', N'3', N'240', NULL, N'71', N'20', N'80', NULL, N'48 - 24', 91, CAST(N'2022-08-26T02:38:21.3784163' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (21, N'5', N'3/2/01/8', N'18', N'4', N'240', NULL, N'49', N'20', N'80', NULL, N'24 - 12', 92, CAST(N'2022-08-26T02:42:26.6886838' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (22, N'1', N'3/2/01/6', N'26', NULL, N'338', NULL, N'147', N'20', N'104', NULL, N'44', 93, CAST(N'2022-08-26T02:59:47.5434404' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (23, N'6', N'3/2/01/7', N'15', N'5', N'360', NULL, N'206', NULL, N'120', NULL, N'24 - 24', 94, CAST(N'2022-08-26T03:00:36.9838303' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (24, N'8', N'3/2/01/9', N'10', N'2', N'240', NULL, N'49', N'20', N'80', NULL, N'48 - 24', 95, CAST(N'2022-08-26T03:01:47.5208797' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (25, N'5', N'3/2/01/10', N'19', N'5', N'240', NULL, N'64', NULL, N'80', NULL, N'24 - 12', 96, CAST(N'2022-08-26T03:02:52.9434324' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (26, N'5', N'3/1/01/3', N'20', N'4', N'252', NULL, N'68', N'40', N'80', NULL, N'24 - 12', 97, CAST(N'2022-08-28T21:14:28.3718099' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (28, N'5', N'3/2/01/4', N'19', N'5', N'252', NULL, N'76', NULL, N'80', NULL, N'24 - 12', 99, CAST(N'2022-08-28T21:21:53.3754482' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (29, N'5', N'3/3/01/5', N'57', N'13', N'732', NULL, N'204', NULL, N'248', NULL, N'24 - 12', 100, CAST(N'2022-08-29T23:12:48.0239371' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (36, N'5', N'3/2/01/11', N'18', N'4', N'240', N'', N'71', N'20', N'80', N'', N'24 - 12', 107, CAST(N'2022-09-02T00:33:58.2799637' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (37, N'1', N'3/2/01/12', N'23', NULL, N'161', NULL, NULL, NULL, NULL, NULL, N'42', 111, CAST(N'2022-09-08T17:31:10.3282076' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (38, N'1', N'3/2/01/12', N'23', NULL, N'161', NULL, NULL, NULL, NULL, NULL, N'42', 112, CAST(N'2022-09-08T20:36:26.6754221' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (39, N'1', N'3/2/01/7', N'', N'0', N'', N'', N'', N'', N'', N'', N'44', 113, CAST(N'2022-09-16T08:13:00.8229790' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (40, N'1', N'3/2/01/7', N'', N'0', N'', N'', N'', N'', N'', N'', N'44', 114, CAST(N'2022-09-16T08:13:00.8229753' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (41, N'1', N'3/1/01/7', N'', N'0', N'', N'', N'', N'', N'', N'', N'44', 115, CAST(N'2022-09-16T08:13:02.0453937' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (42, N'1', N'3/1/01/7', N'', N'0', N'', N'', N'', N'', N'', N'', N'44', 116, CAST(N'2022-09-16T08:13:02.0479866' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (43, N'1', N'3/2/01/7', N'', N'0', N'', N'', N'', N'', N'', N'', N'44', 117, CAST(N'2022-09-16T08:14:26.6031797' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (44, N'1', N'3/2/01/7', N'', N'0', N'', N'', N'', N'', N'', N'', N'44', 118, CAST(N'2022-09-16T08:14:26.6031798' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (45, N'1', N'3/1/01/7', N'', N'0', N'', N'', N'', N'', N'', N'', N'44', 119, CAST(N'2022-09-16T08:14:27.6773100' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (46, N'1', N'3/2/01/7', N'', N'0', N'', N'', N'', N'', N'', N'', N'44', 120, CAST(N'2022-09-16T08:22:47.6801187' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (47, N'1', N'3/2/01/7', N'', N'0', N'', N'', N'', N'', N'', N'', N'44', 121, CAST(N'2022-09-16T08:22:47.6801208' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (77, N'1', N'3/2/01/7', N'', N'0', N'', N'', N'', N'', N'', N'', N'44', 151, CAST(N'2022-09-16T10:01:39.5308951' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (78, N'1', N'3/2/01/7', N'', N'0', N'', N'', N'', N'', N'', N'', N'44', 152, CAST(N'2022-09-16T10:01:39.5308924' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (79, N'1', N'3/1/01/7', N'', N'0', N'', N'', N'', N'', N'', N'', N'44', 153, CAST(N'2022-09-16T10:01:40.6908653' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (80, N'1', N'3/1/01/7', N'', N'0', N'', N'', N'', N'', N'', N'', N'44', 155, CAST(N'2022-09-16T10:30:32.3520785' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (81, N'1', N'3/1/01/7', N'', N'0', N'', N'', N'', N'', N'', N'', N'44', 154, CAST(N'2022-09-16T10:30:32.3520747' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (93, N'1', N'3/2/01/7', N'', N'0', N'', N'', N'', N'', N'', N'', N'44', 168, CAST(N'2022-09-16T22:17:12.8109165' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (94, N'1', N'3/2/01/7', N'', N'0', N'', N'', N'', N'', N'', N'', N'44', 167, CAST(N'2022-09-16T22:17:12.8109201' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (95, N'1', N'3/1/01/7', N'', N'0', N'', N'', N'', N'', N'', N'', N'44', 169, CAST(N'2022-09-16T22:17:13.9389008' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (96, N'1', N'3/1/01/7', N'', N'0', N'', N'', N'', N'', N'', N'', N'44', 170, CAST(N'2022-09-16T22:17:13.9395939' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (107, N'1', N'3/2/01/7', N'', N'0', N'', N'', N'', N'', N'', N'', N'44', 181, CAST(N'2022-09-16T23:38:41.5107176' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (108, N'1', N'3/1/01/7', N'', N'0', N'', N'', N'', N'', N'', N'', N'44', 182, CAST(N'2022-09-16T23:38:42.7289816' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (109, N'1', N'3/2/01/7', N'', N'0', N'', N'', N'', N'', N'', N'', N'44', 183, CAST(N'2022-09-16T23:40:54.2597709' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (110, N'1', N'3/1/01/7', N'', N'0', N'', N'', N'', N'', N'', N'', N'44', 184, CAST(N'2022-09-16T23:40:55.2578926' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (111, N'1', N'3/1/01/8', N'', N'0', N'', N'', N'', N'', N'', N'', N'0', 185, CAST(N'2022-09-16T23:42:28.9664447' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (112, N'1', N'3/2/01/8', N'', N'0', N'', N'', N'', N'', N'', N'', N'0', 186, CAST(N'2022-09-16T23:42:29.8179918' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (113, N'1', N'3/2/01/9', N'', N'0', N'', N'', N'', N'', N'', N'', N'0', 187, CAST(N'2022-09-17T06:50:00.7304827' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (114, N'1', N'3/1/01/9', N'', N'0', N'', N'', N'', N'', N'', N'', N'0', 188, CAST(N'2022-09-17T06:50:02.2041042' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (115, N'1', N'3/4/00/1', N'313', NULL, N'2191', NULL, NULL, NULL, NULL, NULL, N'42', 189, CAST(N'2022-09-19T03:22:41.1432063' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (116, N'1', N'3/4/00/1', N'313', NULL, N'2191', NULL, NULL, NULL, NULL, NULL, N'42', 190, CAST(N'2022-09-19T03:22:41.1432037' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (117, N'1', N'3/4/00/1', N'313', NULL, N'2191', NULL, NULL, NULL, NULL, NULL, N'42', 191, CAST(N'2022-09-19T03:34:01.0504861' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (118, N'1', N'3/4/01/8', N'', N'0', N'', N'', N'', N'', N'', N'', N'42', 192, CAST(N'2022-09-20T06:28:04.8223756' AS DateTime2))
INSERT [dbo].[WorkingHours] ([id], [ShiftWork], [ContractNo], [NumberOfWorkingDays], [NumberOfFriday], [TotalHoursesH], [TotalHoursesM], [OverTimeWorkH], [OverTimeWorkM], [OverNightWorkH], [OverNightWorkM], [WeeklyWorkingTime], [ContractId], [CreationDate]) VALUES (119, N'5', N'3/3/01/8', N'18', N'4', N'240', N'', N'49', N'20', N'80', N'', N'24 - 12', 193, CAST(N'2022-09-20T06:28:06.5549839' AS DateTime2))
SET IDENTITY_INSERT [dbo].[WorkingHours] OFF
SET IDENTITY_INSERT [dbo].[WorkingHoursItems] ON 

INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (14, N'0', N'8:00', N'23:00', N'01', NULL, NULL, NULL, NULL, NULL, NULL, 15, CAST(N'2022-08-26T02:06:23.5468618' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (15, N'1', N'8:00', N'23:00', N'01', NULL, NULL, NULL, NULL, NULL, NULL, 15, CAST(N'2022-08-26T02:06:23.6551890' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (16, N'2', N'8:00', N'23:00', N'01', NULL, NULL, NULL, NULL, NULL, NULL, 15, CAST(N'2022-08-26T02:06:23.6698169' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (17, N'3', N'8:00', N'23:00', N'01', NULL, NULL, NULL, NULL, NULL, NULL, 15, CAST(N'2022-08-26T02:06:23.6726712' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (18, N'6', N'8:00', N'23:00', N'01', NULL, NULL, NULL, NULL, NULL, NULL, 15, CAST(N'2022-08-26T02:06:23.6861320' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (19, N'0', N'8:00', N'12:00', NULL, N'14:00', N'23:30', NULL, NULL, NULL, NULL, 16, CAST(N'2022-08-26T02:08:20.4831847' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (20, N'1', N'8:00', N'12:00', NULL, N'14:00', N'23:30', NULL, NULL, NULL, NULL, 16, CAST(N'2022-08-26T02:08:20.4917020' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (21, N'2', N'8:00', N'12:00', NULL, N'14:00', N'23:30', NULL, NULL, NULL, NULL, 16, CAST(N'2022-08-26T02:08:20.4962478' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (22, N'3', N'8:00', N'12:00', NULL, N'14:00', N'23:30', NULL, NULL, NULL, NULL, 16, CAST(N'2022-08-26T02:08:20.4994918' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (23, N'4', N'8:00', N'12:00', NULL, N'14:00', N'23:30', NULL, NULL, NULL, NULL, 16, CAST(N'2022-08-26T02:08:20.5077386' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (24, N'5', N'8:00', N'12:00', NULL, N'14:00', N'23:30', NULL, NULL, NULL, NULL, 16, CAST(N'2022-08-26T02:08:20.5112374' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (25, N'7', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'8:00', N'20:00', 17, CAST(N'2022-08-26T02:09:41.2885270' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (26, N'7', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'15:00', N'15:00', 18, CAST(N'2022-08-26T02:11:32.9711779' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (27, N'7', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'13:00', N'1:00', 19, CAST(N'2022-08-26T02:12:58.5029087' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (28, N'7', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'14:00', N'14:00', 20, CAST(N'2022-08-26T02:38:21.4974396' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (29, N'7', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'18:00', N'6:00', 21, CAST(N'2022-08-26T02:42:26.7043348' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (30, N'0', N'13:00', N'2:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 22, CAST(N'2022-08-26T02:59:47.5573813' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (31, N'1', N'13:00', N'2:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 22, CAST(N'2022-08-26T02:59:47.5659888' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (32, N'2', N'13:00', N'2:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 22, CAST(N'2022-08-26T02:59:47.5687630' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (33, N'3', N'13:00', N'2:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 22, CAST(N'2022-08-26T02:59:47.5732320' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (34, N'4', N'13:00', N'2:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 22, CAST(N'2022-08-26T02:59:47.5768877' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (35, N'5', N'13:00', N'2:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 22, CAST(N'2022-08-26T02:59:47.5803942' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (36, N'7', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'15:00', N'15:00', 23, CAST(N'2022-08-26T03:00:36.9934807' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (37, N'7', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'16:00', N'16:00', 24, CAST(N'2022-08-26T03:01:47.5462502' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (38, N'7', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1:00', N'13:00', 25, CAST(N'2022-08-26T03:02:52.9488559' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (39, N'7', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'8:00', N'20:00', 26, CAST(N'2022-08-28T21:14:28.5044995' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (41, N'7', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'8:00', N'20:00', 28, CAST(N'2022-08-28T21:21:53.3915308' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (42, N'7', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'18:00', N'6:00', 29, CAST(N'2022-08-29T23:12:48.1262773' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (49, N'7', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'1:00', N'13:00', 36, CAST(N'2022-09-02T00:33:58.3625673' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (50, N'0', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 37, CAST(N'2022-09-08T17:31:10.4800733' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (51, N'1', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 37, CAST(N'2022-09-08T17:31:10.5822299' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (52, N'2', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 37, CAST(N'2022-09-08T17:31:10.5923077' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (53, N'3', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 37, CAST(N'2022-09-08T17:31:10.5958545' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (54, N'4', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 37, CAST(N'2022-09-08T17:31:10.5996939' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (55, N'5', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 37, CAST(N'2022-09-08T17:31:10.6049804' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (56, N'0', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 38, CAST(N'2022-09-08T20:36:26.7678093' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (57, N'1', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 38, CAST(N'2022-09-08T20:36:26.8343736' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (58, N'2', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 38, CAST(N'2022-09-08T20:36:26.8391035' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (59, N'3', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 38, CAST(N'2022-09-08T20:36:26.8429776' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (60, N'4', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 38, CAST(N'2022-09-08T20:36:26.8458556' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (61, N'5', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 38, CAST(N'2022-09-08T20:36:26.8483588' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (63, N'0', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 115, CAST(N'2022-09-19T03:22:41.2548889' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (64, N'0', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 116, CAST(N'2022-09-19T03:22:41.2548919' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (65, N'1', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 116, CAST(N'2022-09-19T03:22:41.3547615' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (66, N'1', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 115, CAST(N'2022-09-19T03:22:41.3547615' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (67, N'2', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 115, CAST(N'2022-09-19T03:22:41.3640441' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (68, N'2', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 116, CAST(N'2022-09-19T03:22:41.3640441' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (69, N'3', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 115, CAST(N'2022-09-19T03:22:41.3714359' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (70, N'3', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 116, CAST(N'2022-09-19T03:22:41.3714359' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (71, N'4', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 115, CAST(N'2022-09-19T03:22:41.3774265' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (72, N'4', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 116, CAST(N'2022-09-19T03:22:41.3774265' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (73, N'5', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 115, CAST(N'2022-09-19T03:22:41.3826189' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (74, N'5', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 116, CAST(N'2022-09-19T03:22:41.3826189' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (75, N'0', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 117, CAST(N'2022-09-19T03:34:01.1633099' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (76, N'1', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 117, CAST(N'2022-09-19T03:34:01.2329743' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (77, N'2', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 117, CAST(N'2022-09-19T03:34:01.2374472' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (78, N'3', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 117, CAST(N'2022-09-19T03:34:01.2407455' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (79, N'4', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 117, CAST(N'2022-09-19T03:34:01.2451897' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (80, N'5', N'8:00', N'15:00', N'0', NULL, NULL, NULL, NULL, NULL, NULL, 117, CAST(N'2022-09-19T03:34:01.2497441' AS DateTime2))
INSERT [dbo].[WorkingHoursItems] ([id], [DayOfWork], [Start1], [End1], [RestTime], [Start2], [End2], [Start3], [End3], [ComplexStart], [ComplexEnd], [WorkingHoursId], [CreationDate]) VALUES (81, N'7', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'18:00', N'6:00', 119, CAST(N'2022-09-20T06:28:06.5638489' AS DateTime2))
SET IDENTITY_INSERT [dbo].[WorkingHoursItems] OFF
INSERT [dbo].[WorkshopeAccounts] ([WorkshopId], [AccountId]) VALUES (87, 2)
INSERT [dbo].[WorkshopeAccounts] ([WorkshopId], [AccountId]) VALUES (87, 3)
INSERT [dbo].[WorkshopeAccounts] ([WorkshopId], [AccountId]) VALUES (111, 2)
INSERT [dbo].[WorkshopeAccounts] ([WorkshopId], [AccountId]) VALUES (111, 3)
INSERT [dbo].[WorkshopeAccounts] ([WorkshopId], [AccountId]) VALUES (111, 4)
INSERT [dbo].[WorkshopeAccounts] ([WorkshopId], [AccountId]) VALUES (111, 5)
INSERT [dbo].[WorkshopeAccounts] ([WorkshopId], [AccountId]) VALUES (112, 2)
INSERT [dbo].[WorkshopeAccounts] ([WorkshopId], [AccountId]) VALUES (112, 3)
INSERT [dbo].[WorkshopeAccounts] ([WorkshopId], [AccountId]) VALUES (112, 4)
INSERT [dbo].[WorkshopeAccounts] ([WorkshopId], [AccountId]) VALUES (113, 2)
INSERT [dbo].[WorkshopeAccounts] ([WorkshopId], [AccountId]) VALUES (113, 3)
INSERT [dbo].[WorkshopeEmployers] ([WorkshopId], [EmployerId]) VALUES (86, 11)
INSERT [dbo].[WorkshopeEmployers] ([WorkshopId], [EmployerId]) VALUES (89, 11)
INSERT [dbo].[WorkshopeEmployers] ([WorkshopId], [EmployerId]) VALUES (103, 11)
INSERT [dbo].[WorkshopeEmployers] ([WorkshopId], [EmployerId]) VALUES (87, 12)
INSERT [dbo].[WorkshopeEmployers] ([WorkshopId], [EmployerId]) VALUES (89, 12)
INSERT [dbo].[WorkshopeEmployers] ([WorkshopId], [EmployerId]) VALUES (102, 12)
INSERT [dbo].[WorkshopeEmployers] ([WorkshopId], [EmployerId]) VALUES (103, 12)
INSERT [dbo].[WorkshopeEmployers] ([WorkshopId], [EmployerId]) VALUES (106, 12)
INSERT [dbo].[WorkshopeEmployers] ([WorkshopId], [EmployerId]) VALUES (107, 12)
INSERT [dbo].[WorkshopeEmployers] ([WorkshopId], [EmployerId]) VALUES (110, 12)
INSERT [dbo].[WorkshopeEmployers] ([WorkshopId], [EmployerId]) VALUES (112, 12)
INSERT [dbo].[WorkshopeEmployers] ([WorkshopId], [EmployerId]) VALUES (89, 17)
INSERT [dbo].[WorkshopeEmployers] ([WorkshopId], [EmployerId]) VALUES (102, 17)
INSERT [dbo].[WorkshopeEmployers] ([WorkshopId], [EmployerId]) VALUES (103, 17)
INSERT [dbo].[WorkshopeEmployers] ([WorkshopId], [EmployerId]) VALUES (106, 17)
INSERT [dbo].[WorkshopeEmployers] ([WorkshopId], [EmployerId]) VALUES (109, 17)
INSERT [dbo].[WorkshopeEmployers] ([WorkshopId], [EmployerId]) VALUES (89, 20029)
INSERT [dbo].[WorkshopeEmployers] ([WorkshopId], [EmployerId]) VALUES (105, 20029)
INSERT [dbo].[WorkshopeEmployers] ([WorkshopId], [EmployerId]) VALUES (108, 20029)
INSERT [dbo].[WorkshopeEmployers] ([WorkshopId], [EmployerId]) VALUES (107, 20032)
INSERT [dbo].[WorkshopeEmployers] ([WorkshopId], [EmployerId]) VALUES (111, 20032)
INSERT [dbo].[WorkshopeEmployers] ([WorkshopId], [EmployerId]) VALUES (113, 20032)
INSERT [dbo].[WorkshopeEmployers] ([WorkshopId], [EmployerId]) VALUES (89, 20034)
INSERT [dbo].[WorkshopeEmployers] ([WorkshopId], [EmployerId]) VALUES (108, 20034)
SET IDENTITY_INSERT [dbo].[Workshops] ON 

INSERT [dbo].[Workshops] ([id], [WorkshopName], [InsuranceCode], [IsActive], [IsActiveString], [TypeOfOwnership], [ArchiveCode], [AgentName], [AgentPhone], [State], [City], [Address], [TypeOfInsuranceSend], [TypeOfContract], [CreationDate], [WorkshopFullName], [WorkshopSureName], [ContractTerm]) VALUES (85, N'تست', N'123121', 0, N'false', NULL, N'b-1', N'تست', N'091145647897', N'گیلان', N'اسكلك', NULL, N'ارسال لیست بیمه عادی', N'1', CAST(N'2022-03-26T00:31:47.6693803' AS DateTime2), N'تست (رشت)', N'رشت', NULL)
INSERT [dbo].[Workshops] ([id], [WorkshopName], [InsuranceCode], [IsActive], [IsActiveString], [TypeOfOwnership], [ArchiveCode], [AgentName], [AgentPhone], [State], [City], [Address], [TypeOfInsuranceSend], [TypeOfContract], [CreationDate], [WorkshopFullName], [WorkshopSureName], [ContractTerm]) VALUES (86, N'تستی', N'68497', 0, N'false', N'545646', N'b-2', N'jsjas', N'95564564', N'فارس', NULL, NULL, N'ارسال لیست بیمه عادی', N'a', CAST(N'2022-03-26T00:32:40.3892301' AS DateTime2), N'تستی (سییس)', N'سییس', N'1')
INSERT [dbo].[Workshops] ([id], [WorkshopName], [InsuranceCode], [IsActive], [IsActiveString], [TypeOfOwnership], [ArchiveCode], [AgentName], [AgentPhone], [State], [City], [Address], [TypeOfInsuranceSend], [TypeOfContract], [CreationDate], [WorkshopFullName], [WorkshopSureName], [ContractTerm]) VALUES (87, N'تستتت', N'5456465', 1, N'true', N'4654654', N'3', N'نمکتت', N'98987', NULL, NULL, NULL, N'ارسال لیست بیمه عادی', N'a', CAST(N'2022-03-26T02:26:10.3641340' AS DateTime2), N'تستتت (تهران)', N'تهران', N'1')
INSERT [dbo].[Workshops] ([id], [WorkshopName], [InsuranceCode], [IsActive], [IsActiveString], [TypeOfOwnership], [ArchiveCode], [AgentName], [AgentPhone], [State], [City], [Address], [TypeOfInsuranceSend], [TypeOfContract], [CreationDate], [WorkshopFullName], [WorkshopSureName], [ContractTerm]) VALUES (88, N'test', N'23123', 1, N'true', NULL, N'4', N'sdfsdf', N'8489498', NULL, NULL, NULL, N'ارسال لیست بیمه عادی', N'تنظیم قرارداد بصورت استاندارد', CAST(N'2022-03-26T03:31:40.3938794' AS DateTime2), N'test', NULL, NULL)
INSERT [dbo].[Workshops] ([id], [WorkshopName], [InsuranceCode], [IsActive], [IsActiveString], [TypeOfOwnership], [ArchiveCode], [AgentName], [AgentPhone], [State], [City], [Address], [TypeOfInsuranceSend], [TypeOfContract], [CreationDate], [WorkshopFullName], [WorkshopSureName], [ContractTerm]) VALUES (89, N'تست555', N'234234', 1, N'true', NULL, N'5', N'یبسی', N'8489498', N'گیلان', N'اسكلك', N'تستمنتیب', N'ارسال لیست بیمه عادی', N'a', CAST(N'2022-03-26T03:33:15.9381333' AS DateTime2), N'تست555', NULL, N'1')
INSERT [dbo].[Workshops] ([id], [WorkshopName], [InsuranceCode], [IsActive], [IsActiveString], [TypeOfOwnership], [ArchiveCode], [AgentName], [AgentPhone], [State], [City], [Address], [TypeOfInsuranceSend], [TypeOfContract], [CreationDate], [WorkshopFullName], [WorkshopSureName], [ContractTerm]) VALUES (102, N'121211', N'6756', 1, N'true', NULL, N'6', N'657567', NULL, NULL, NULL, NULL, N'ارسال لیست بیمه عادی', N'تنظیم قرارداد بصورت استاندارد', CAST(N'2022-03-26T05:33:18.1090252' AS DateTime2), N'121211', NULL, NULL)
INSERT [dbo].[Workshops] ([id], [WorkshopName], [InsuranceCode], [IsActive], [IsActiveString], [TypeOfOwnership], [ArchiveCode], [AgentName], [AgentPhone], [State], [City], [Address], [TypeOfInsuranceSend], [TypeOfContract], [CreationDate], [WorkshopFullName], [WorkshopSureName], [ContractTerm]) VALUES (103, N'6778', N'78678', 1, N'true', NULL, N'7', N'6786786', NULL, NULL, NULL, NULL, N'ارسال لیست بیمه عادی', N'a', CAST(N'2022-03-26T05:38:32.8311266' AS DateTime2), N'6778', NULL, N'1')
INSERT [dbo].[Workshops] ([id], [WorkshopName], [InsuranceCode], [IsActive], [IsActiveString], [TypeOfOwnership], [ArchiveCode], [AgentName], [AgentPhone], [State], [City], [Address], [TypeOfInsuranceSend], [TypeOfContract], [CreationDate], [WorkshopFullName], [WorkshopSureName], [ContractTerm]) VALUES (105, N'fgdfg', N'ss', 1, N'true', NULL, N'8', N'dfgdfg', NULL, NULL, NULL, NULL, NULL, N'a', CAST(N'2022-03-26T09:00:13.0574301' AS DateTime2), N'fgdfg', NULL, N'1')
INSERT [dbo].[Workshops] ([id], [WorkshopName], [InsuranceCode], [IsActive], [IsActiveString], [TypeOfOwnership], [ArchiveCode], [AgentName], [AgentPhone], [State], [City], [Address], [TypeOfInsuranceSend], [TypeOfContract], [CreationDate], [WorkshopFullName], [WorkshopSureName], [ContractTerm]) VALUES (106, N'67567', NULL, 1, N'true', NULL, N'9', N'555555555555', NULL, NULL, NULL, NULL, NULL, N'a', CAST(N'2022-03-26T16:03:28.2875442' AS DateTime2), N'67567', NULL, N'1')
INSERT [dbo].[Workshops] ([id], [WorkshopName], [InsuranceCode], [IsActive], [IsActiveString], [TypeOfOwnership], [ArchiveCode], [AgentName], [AgentPhone], [State], [City], [Address], [TypeOfInsuranceSend], [TypeOfContract], [CreationDate], [WorkshopFullName], [WorkshopSureName], [ContractTerm]) VALUES (107, N'fgddfg11', NULL, 1, N'true', NULL, N'10', N'dfgdfsdf', NULL, N'گیلان', N'اسالم', NULL, NULL, N'a', CAST(N'2022-03-26T16:06:48.9625815' AS DateTime2), N'fgddfg11', NULL, N'1')
INSERT [dbo].[Workshops] ([id], [WorkshopName], [InsuranceCode], [IsActive], [IsActiveString], [TypeOfOwnership], [ArchiveCode], [AgentName], [AgentPhone], [State], [City], [Address], [TypeOfInsuranceSend], [TypeOfContract], [CreationDate], [WorkshopFullName], [WorkshopSureName], [ContractTerm]) VALUES (108, N'یببب', NULL, 1, N'true', NULL, N'11', N'یبیب', NULL, N'خوزستان', N'انديمشك', N'aedfasd', NULL, N'a', CAST(N'2022-03-28T07:53:46.2149814' AS DateTime2), N'یببب', NULL, N'1')
INSERT [dbo].[Workshops] ([id], [WorkshopName], [InsuranceCode], [IsActive], [IsActiveString], [TypeOfOwnership], [ArchiveCode], [AgentName], [AgentPhone], [State], [City], [Address], [TypeOfInsuranceSend], [TypeOfContract], [CreationDate], [WorkshopFullName], [WorkshopSureName], [ContractTerm]) VALUES (109, N'ghjhgj', NULL, 1, N'true', NULL, N'12', N'hjhjgj', NULL, N'خوزستان', N'اهواز', N'سیبتمسیب', NULL, N'a', CAST(N'2022-03-28T08:07:09.3321718' AS DateTime2), N'ghjhgj', NULL, N'1')
INSERT [dbo].[Workshops] ([id], [WorkshopName], [InsuranceCode], [IsActive], [IsActiveString], [TypeOfOwnership], [ArchiveCode], [AgentName], [AgentPhone], [State], [City], [Address], [TypeOfInsuranceSend], [TypeOfContract], [CreationDate], [WorkshopFullName], [WorkshopSureName], [ContractTerm]) VALUES (110, N'سیس', NULL, 1, N'true', NULL, N'13', N'رضا تست', NULL, NULL, NULL, NULL, NULL, N'a', CAST(N'2022-08-09T18:43:27.7421179' AS DateTime2), N'سیس (سس)', N'سس', N'1')
INSERT [dbo].[Workshops] ([id], [WorkshopName], [InsuranceCode], [IsActive], [IsActiveString], [TypeOfOwnership], [ArchiveCode], [AgentName], [AgentPhone], [State], [City], [Address], [TypeOfInsuranceSend], [TypeOfContract], [CreationDate], [WorkshopFullName], [WorkshopSureName], [ContractTerm]) VALUES (111, N'تست رشت', NULL, 1, N'true', NULL, N'14', N'احمد احمدی', N'09114567894', N'آذربایجان شرقی', N'اسكو', N'رشت', NULL, N'a', CAST(N'2022-10-22T22:55:38.6608742' AS DateTime2), N'تست رشت (گیلان)', N'گیلان', N'1')
INSERT [dbo].[Workshops] ([id], [WorkshopName], [InsuranceCode], [IsActive], [IsActiveString], [TypeOfOwnership], [ArchiveCode], [AgentName], [AgentPhone], [State], [City], [Address], [TypeOfInsuranceSend], [TypeOfContract], [CreationDate], [WorkshopFullName], [WorkshopSureName], [ContractTerm]) VALUES (112, N'تست فومن', NULL, 1, N'true', NULL, N'15', N'احمد احمدی', NULL, N'خوزستان', N'اهواز', N'شسیشس', NULL, N'a', CAST(N'2022-10-22T23:05:16.7008719' AS DateTime2), N'تست فومن (گیلان)', N'گیلان', N'1')
INSERT [dbo].[Workshops] ([id], [WorkshopName], [InsuranceCode], [IsActive], [IsActiveString], [TypeOfOwnership], [ArchiveCode], [AgentName], [AgentPhone], [State], [City], [Address], [TypeOfInsuranceSend], [TypeOfContract], [CreationDate], [WorkshopFullName], [WorkshopSureName], [ContractTerm]) VALUES (113, N'همراه اول', NULL, 1, N'true', NULL, N'16', N'رستایی', NULL, NULL, NULL, NULL, NULL, N'a', CAST(N'2022-10-23T00:49:42.7718347' AS DateTime2), N'همراه اول', NULL, N'1')
SET IDENTITY_INSERT [dbo].[Workshops] OFF
SET IDENTITY_INSERT [dbo].[YearlyItems] ON 

INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (486, N'مزد روزانه', 885165, NULL, 1, 65, CAST(N'2022-03-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (487, N'کمک هزینه اقلام', 6000000, NULL, 1, 65, CAST(N'2022-03-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (488, N'کمک هزینه مسکن', 4500000, NULL, 1, 65, CAST(N'2022-03-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (489, N'پایه سنوات', 46667, NULL, 1, 65, CAST(N'2022-03-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (490, N'مبلغ مزد ثابت', 82785, NULL, 1, 65, CAST(N'2022-03-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (491, N'درصد مزد ثابت', 26, N'Percentage', 1, 65, CAST(N'2022-03-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (492, N'مزد روزانه', 636809, NULL, 2, 66, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (493, N'کمک هزینه اقلام', 4000000, NULL, 2, 66, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (494, N'کمک هزینه مسکن', 3000000, NULL, 2, 66, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (495, N'پایه سنوات', 33333, NULL, 2, 66, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (496, N'مبلغ مزد ثابت', 55338, NULL, 2, 66, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (497, N'درصد مزد ثابت', 15, N'Percentage', 2, 66, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (498, N'مزد روزانه', 370423, NULL, 4, 67, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (499, N'کمک هزینه اقلام', 1100000, NULL, 4, 67, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (500, N'کمک هزینه مسکن', 400000, NULL, 4, 67, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (501, N'پایه سنوات', 17000, NULL, 4, 67, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (502, N'مبلغ مزد ثابت', 28208, NULL, 4, 67, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (503, N'درصد مزد ثابت', 10.4, N'Percentage', 4, 67, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (504, N'مزد روزانه', 309977, NULL, 5, 68, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (505, N'کمک هزینه اقلام', 1100000, NULL, 5, 68, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (506, N'کمک هزینه مسکن', 400000, NULL, 5, 68, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (507, N'پایه سنوات', 17000, NULL, 5, 68, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (508, N'مبلغ مزد ثابت', 6768, NULL, 5, 68, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (509, N'درصد مزد ثابت', 12, N'Percentage', 5, 68, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (510, N'مزد روزانه', 270722, NULL, 6, 69, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (511, N'کمک هزینه اقلام', 1100000, NULL, 6, 69, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (512, N'کمک هزینه مسکن', 400000, NULL, 6, 69, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (513, N'پایه سنوات', 10000, NULL, 6, 69, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (514, N'مبلغ مزد ثابت', 0, NULL, 6, 69, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (515, N'درصد مزد ثابت', 14, N'Percentage', 6, 69, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (516, N'مزد روزانه', 270722, NULL, 7, 70, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (517, N'کمک هزینه اقلام', 1100000, NULL, 7, 70, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (518, N'کمک هزینه مسکن', 200000, NULL, 7, 70, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (519, N'پایه سنوات', 10000, NULL, 7, 70, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (520, N'مبلغ مزد ثابت', 0, NULL, 7, 70, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (521, N'درصد مزد ثابت', 14, N'Percentage', 7, 70, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (522, N'مزد روزانه', 237475, NULL, 8, 71, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (523, N'کمک هزینه اقلام', 1100000, NULL, 8, 71, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (524, N'کمک هزینه مسکن', 200000, NULL, 8, 71, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (525, N'پایه سنوات', 10000, NULL, 8, 71, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (526, N'مبلغ مزد ثابت', 0, NULL, 8, 71, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (527, N'درصد مزد ثابت', 17, N'Percentage', 8, 71, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (528, N'مزد روزانه', 202970, NULL, 9, 72, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (529, N'کمک هزینه اقلام', 800000, NULL, 9, 72, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (530, N'کمک هزینه مسکن', 200000, NULL, 9, 72, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (531, N'پایه سنوات', 5000, NULL, 9, 72, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (532, N'مبلغ مزد ثابت', 21110, NULL, 9, 72, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (533, N'درصد مزد ثابت', 12, N'Percentage', 9, 72, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (534, N'مزد روزانه', 129900, NULL, 11, 73, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (535, N'کمک هزینه اقلام', 350000, NULL, 11, 73, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (536, N'کمک هزینه مسکن', 100000, NULL, 11, 73, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (537, N'پایه سنوات', 2500, NULL, 11, 73, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (538, N'مبلغ مزد ثابت', 12093, NULL, 11, 73, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (539, N'درصد مزد ثابت', 7, N'Percentage', 11, 73, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (540, N'مزد روزانه', 110100, NULL, 12, 74, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (541, N'کمک هزینه اقلام', 280000, NULL, 12, 74, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (542, N'کمک هزینه مسکن', 100000, NULL, 12, 74, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (543, N'پایه سنوات', 2000, NULL, 12, 74, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (544, N'مبلغ مزد ثابت', 3040, NULL, 12, 74, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (545, N'درصد مزد ثابت', 6, N'Percentage', 12, 74, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (546, N'مزد روزانه', 101000, NULL, 13, 75, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (547, N'کمک هزینه اقلام', 200000, NULL, 13, 75, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (548, N'کمک هزینه مسکن', 100000, NULL, 13, 75, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (549, N'پایه سنوات', 2000, NULL, 13, 75, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (550, N'مبلغ مزد ثابت', 7011, NULL, 13, 75, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (551, N'درصد مزد ثابت', 7, N'Percentage', 13, 75, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (552, N'مزد روزانه', 87840, NULL, 14, 76, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (553, N'کمک هزینه اقلام', 100000, NULL, 14, 76, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (554, N'کمک هزینه مسکن', 100000, NULL, 14, 76, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (555, N'پایه سنوات', 1250, NULL, 14, 76, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (556, N'مبلغ مزد ثابت', 10980, NULL, 14, 76, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (557, N'درصد مزد ثابت', 5, N'Percentage', 14, 76, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (558, N'مزد روزانه', 73200, NULL, 15, 77, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (559, N'کمک هزینه اقلام', 100000, NULL, 15, 77, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (560, N'کمک هزینه مسکن', 100000, NULL, 15, 77, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (561, N'پایه سنوات', 1250, NULL, 15, 77, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (562, N'مبلغ مزد ثابت', 9150, NULL, 15, 77, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (563, N'درصد مزد ثابت', 5, N'Percentage', 15, 77, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (564, N'مزد روزانه', 61000, NULL, 16, 78, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (565, N'کمک هزینه اقلام', 100000, NULL, 16, 78, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (566, N'کمک هزینه مسکن', 100000, NULL, 16, 78, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (567, N'پایه سنوات', 1250, NULL, 16, 78, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (568, N'مبلغ مزد ثابت', 0, NULL, 16, 78, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (569, N'درصد مزد ثابت', 10, N'Percentage', 16, 78, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (570, N'مزد روزانه', 162375, NULL, 17, 79, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (571, N'کمک هزینه اقلام', 350000, NULL, 17, 79, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (572, N'کمک هزینه مسکن', 200000, NULL, 17, 79, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (573, N'پایه سنوات', 3000, NULL, 17, 79, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (574, N'مبلغ مزد ثابت', 19485, NULL, 17, 79, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (575, N'درصد مزد ثابت', 10, N'Percentage', 17, 79, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (576, N'مزد روزانه', 505627, NULL, 18, 80, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (577, N'کمک هزینه اقلام', 1900000, NULL, 18, 80, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (578, N'کمک هزینه مسکن', 1000000, NULL, 18, 80, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (579, N'پایه سنوات', 23333, NULL, 18, 80, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (580, N'مبلغ مزد ثابت', 87049, NULL, 18, 80, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (581, N'درصد مزد ثابت', 13, N'Percentage', 18, 80, CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (582, N'مزد روزانه', 162375, NULL, 19, 81, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (583, N'کمک هزینه اقلام', 500000, NULL, 19, 81, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (584, N'کمک هزینه مسکن', 200000, NULL, 19, 81, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (585, N'پایه سنوات', 3000, NULL, 19, 81, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (586, N'مبلغ مزد ثابت', 19485, NULL, 19, 81, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (587, N'درصد مزد ثابت', 10, N'Percentage', 19, 81, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (588, N'مزد روزانه', 60000, NULL, 20, 82, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (589, N'کمک هزینه اقلام', 100000, NULL, 20, 82, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (590, N'کمک هزینه مسکن', 100000, NULL, 20, 82, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (591, N'پایه سنوات', 1250, NULL, 20, 82, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (592, N'مبلغ مزد ثابت', 5000, NULL, 20, 82, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (593, N'درصد مزد ثابت', 10, N'Percentage', 20, 82, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (594, N'مزد روزانه', 40864, NULL, 21, 83, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (595, N'کمک هزینه اقلام', 40000, NULL, 21, 83, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (596, N'کمک هزینه مسکن', 100000, NULL, 21, 83, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (597, N'پایه سنوات', 1020, NULL, 21, 83, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (598, N'مبلغ مزد ثابت', 5330, NULL, 21, 83, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (599, N'درصد مزد ثابت', 0, N'Percentage', 21, 83, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (600, N'مزد روزانه', 40864, NULL, 22, 84, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (601, N'کمک هزینه اقلام', 40000, NULL, 22, 84, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (602, N'کمک هزینه مسکن', 60000, NULL, 22, 84, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (603, N'پایه سنوات', 1020, NULL, 22, 84, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (604, N'مبلغ مزد ثابت', 5330, NULL, 22, 84, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (605, N'درصد مزد ثابت', 0, N'Percentage', 22, 84, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (606, N'مزد روزانه', 35534, NULL, 23, 85, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (607, N'کمک هزینه اقلام', 20000, NULL, 23, 85, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (608, N'کمک هزینه مسکن', 60000, NULL, 23, 85, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (609, N'پایه سنوات', 900, NULL, 23, 85, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (610, N'مبلغ مزد ثابت', 7088, NULL, 23, 85, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (611, N'درصد مزد ثابت', 0, N'Percentage', 23, 85, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (612, N'مزد روزانه', 28446, NULL, 24, 86, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (613, N'کمک هزینه اقلام', 10000, NULL, 24, 86, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (614, N'کمک هزینه مسکن', 60000, NULL, 24, 86, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (615, N'پایه سنوات', 710, NULL, 24, 86, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (616, N'مبلغ مزد ثابت', 4000, NULL, 24, 86, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (617, N'درصد مزد ثابت', 5, N'Percentage', 24, 86, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (618, N'مزد روزانه', 28466, NULL, 25, 87, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (619, N'کمک هزینه اقلام', 10000, NULL, 25, 87, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (620, N'کمک هزینه مسکن', 12000, NULL, 25, 87, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (621, N'پایه سنوات', 710, NULL, 25, 87, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (622, N'مبلغ مزد ثابت', 4000, NULL, 25, 87, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (623, N'درصد مزد ثابت', 5, N'Percentage', 25, 87, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (624, N'مزد روزانه', 23282, NULL, 26, 88, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (625, N'کمک هزینه اقلام', 10000, NULL, 26, 88, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (626, N'کمک هزینه مسکن', 12000, NULL, 26, 88, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (627, N'پایه سنوات', 580, NULL, 26, 88, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (628, N'مبلغ مزد ثابت', 3500, NULL, 26, 88, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (629, N'درصد مزد ثابت', 4.5, N'Percentage', 26, 88, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (630, N'مزد روزانه', 18930, NULL, 27, 89, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (631, N'کمک هزینه اقلام', 10000, NULL, 27, 89, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (632, N'کمک هزینه مسکن', 12000, NULL, 27, 89, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (633, N'پایه سنوات', 470, NULL, 27, 89, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (634, N'مبلغ مزد ثابت', 2900, NULL, 27, 89, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (635, N'درصد مزد ثابت', 5, N'Percentage', 27, 89, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (636, N'مزد روزانه', 15267, NULL, 28, 90, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (637, N'کمک هزینه اقلام', 10000, NULL, 28, 90, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (638, N'کمک هزینه مسکن', 12000, NULL, 28, 90, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (639, N'پایه سنوات', 380, NULL, 28, 90, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (640, N'مبلغ مزد ثابت', 2000, NULL, 28, 90, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (641, N'درصد مزد ثابت', 10, N'Percentage', 28, 90, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (642, N'مزد روزانه', 12061, NULL, 29, 91, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (643, N'کمک هزینه اقلام', 10000, NULL, 29, 91, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (644, N'کمک هزینه مسکن', 12000, NULL, 29, 91, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (645, N'پایه سنوات', 210, NULL, 29, 91, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (646, N'مبلغ مزد ثابت', 0, NULL, 29, 91, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (647, N'درصد مزد ثابت', 20, N'Percentage', 29, 91, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (648, N'مزد روزانه', 10051, NULL, 30, 92, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (649, N'کمک هزینه اقلام', 7000, NULL, 30, 92, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (650, N'کمک هزینه مسکن', 12000, NULL, 30, 92, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (651, N'پایه سنوات', 150, NULL, 30, 92, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (652, N'مبلغ مزد ثابت', 0, NULL, 30, 92, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (653, N'درصد مزد ثابت', 18.5, N'Percentage', 30, 92, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (654, N'مزد روزانه', 8482, NULL, 31, 93, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (655, N'کمک هزینه اقلام', 7000, NULL, 31, 93, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (656, N'کمک هزینه مسکن', 12000, NULL, 31, 93, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (657, N'پایه سنوات', 125, NULL, 31, 93, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (658, N'مبلغ مزد ثابت', 0, NULL, 31, 93, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (659, N'درصد مزد ثابت', 22.8, N'Percentage', 31, 93, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (660, N'مزد روزانه', 6907, NULL, 32, 94, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (661, N'کمک هزینه اقلام', 7000, NULL, 32, 94, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (662, N'کمک هزینه مسکن', 12000, NULL, 32, 94, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (663, N'پایه سنوات', 125, NULL, 32, 94, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (664, N'مبلغ مزد ثابت', 1200, NULL, 32, 94, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (665, N'درصد مزد ثابت', 10, N'Percentage', 32, 94, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (666, N'مزد روزانه', 6907, NULL, 33, 95, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (667, N'کمک هزینه اقلام', 7000, NULL, 33, 95, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (668, N'کمک هزینه مسکن', 4000, NULL, 33, 95, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (669, N'پایه سنوات', 125, NULL, 33, 95, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (670, N'مبلغ مزد ثابت', 1200, NULL, 33, 95, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (671, N'درصد مزد ثابت', 10, N'Percentage', 33, 95, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (672, N'مزد روزانه', 5333, NULL, 34, 96, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (673, N'کمک هزینه اقلام', 7000, NULL, 34, 96, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (674, N'کمک هزینه مسکن', 4000, NULL, 34, 96, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (675, N'پایه سنوات', 100, NULL, 34, 96, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (676, N'مبلغ مزد ثابت', 1050, NULL, 34, 96, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (677, N'درصد مزد ثابت', 10, N'Percentage', 34, 96, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (678, N'مزد روزانه', 3894, NULL, 35, 97, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (679, N'کمک هزینه اقلام', 7000, NULL, 35, 97, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (680, N'کمک هزینه مسکن', 4000, NULL, 35, 97, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (681, N'پایه سنوات', 80, NULL, 35, 97, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (682, N'مبلغ مزد ثابت', 600, NULL, 35, 97, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (683, N'درصد مزد ثابت', 10, N'Percentage', 35, 97, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (684, N'مزد روزانه', 2994, NULL, 36, 98, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (685, N'کمک هزینه اقلام', 7000, NULL, 36, 98, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (686, N'کمک هزینه مسکن', 4000, NULL, 36, 98, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (687, N'پایه سنوات', 60, NULL, 36, 98, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (688, N'مبلغ مزد ثابت', 500, NULL, 36, 98, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (689, N'درصد مزد ثابت', 10, N'Percentage', 36, 98, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (690, N'مزد روزانه', 2267, NULL, 37, 99, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (691, N'کمک هزینه اقلام', 7000, NULL, 37, 99, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (692, N'کمک هزینه مسکن', 4000, NULL, 37, 99, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (693, N'پایه سنوات', 60, NULL, 37, 99, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (694, N'مبلغ مزد ثابت', 600, NULL, 37, 99, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (695, N'درصد مزد ثابت', 0, N'Percentage', 37, 99, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (696, N'مزد روزانه', 1667, NULL, 38, 100, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (697, N'کمک هزینه اقلام', 7000, NULL, 38, 100, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (698, N'کمک هزینه مسکن', 4000, NULL, 38, 100, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (699, N'پایه سنوات', 60, NULL, 38, 100, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (700, N'مبلغ مزد ثابت', 667, NULL, 38, 100, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (701, N'درصد مزد ثابت', 0, N'Percentage', 38, 100, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (702, N'مزد روزانه', 611809, NULL, 39, 101, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (703, N'کمک هزینه اقلام', 4000000, NULL, 39, 101, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (704, N'کمک هزینه مسکن', 1000000, NULL, 39, 101, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (705, N'پایه سنوات', 58333, NULL, 39, 101, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (706, N'مبلغ مزد ثابت', 30338, NULL, 39, 101, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (707, N'درصد مزد ثابت', 15, N'Percentage', 39, 101, CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (708, N'مزد روزانه', 1393250, NULL, 40, 102, CAST(N'2022-03-10T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (709, N'کمک هزینه اقلام', 8500000, NULL, 40, 102, CAST(N'2022-03-10T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (710, N'کمک هزینه مسکن', 5500000, NULL, 40, 102, CAST(N'2022-03-10T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (711, N'پایه سنوات', 70000, NULL, 40, 102, CAST(N'2022-03-10T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (712, N'مبلغ مزد ثابت', 171722, NULL, 40, 102, CAST(N'2022-03-10T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (713, N'درصد مزد ثابت', 38, N'Percentage', 40, 102, CAST(N'2022-03-10T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (714, N'مزد روزانه', 1400000, NULL, 41, 103, CAST(N'2022-09-01T18:19:22.3163328' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (715, N'کمک هزینه اقلام', 9500000, NULL, 41, 103, CAST(N'2022-09-01T18:19:22.4196119' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (716, N'کمک هزینه مسکن', 7500000, NULL, 41, 103, CAST(N'2022-09-01T18:19:22.4268803' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (717, N'پایه سنوات', 850000, NULL, 41, 103, CAST(N'2022-09-01T18:19:22.4308011' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (718, N'مبلغ مزد ثابت', 191000, NULL, 41, 103, CAST(N'2022-09-01T18:19:22.4344776' AS DateTime2))
INSERT [dbo].[YearlyItems] ([id], [ItemName], [ItemValue], [ValueType], [ParentConnectionId], [YearlySalaryId], [CreationDate]) VALUES (719, N'درصد مزد ثابت', 40, N'Percentage', 41, 103, CAST(N'2022-09-01T18:19:22.4381088' AS DateTime2))
SET IDENTITY_INSERT [dbo].[YearlyItems] OFF
SET IDENTITY_INSERT [dbo].[YearlySalariess] ON 

INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (65, CAST(N'2021-03-21T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-01T00:00:00.0000000' AS DateTime2), N'1400', 1)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (66, CAST(N'2020-06-21T00:00:00.0000000' AS DateTime2), CAST(N'2021-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2), N'1399', 2)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (67, CAST(N'2018-03-21T00:00:00.0000000' AS DateTime2), CAST(N'2019-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2), N'1397', 4)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (68, CAST(N'2017-03-21T00:00:00.0000000' AS DateTime2), CAST(N'2018-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2), N'1396', 5)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (69, CAST(N'2016-09-22T00:00:00.0000000' AS DateTime2), CAST(N'2017-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2), N'1395', 6)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (70, CAST(N'2016-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2016-09-21T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2), N'1395', 7)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (71, CAST(N'2015-03-21T00:00:00.0000000' AS DateTime2), CAST(N'2016-03-19T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2), N'1394', 8)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (72, CAST(N'2014-03-21T00:00:00.0000000' AS DateTime2), CAST(N'2015-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2), N'1393', 9)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (73, CAST(N'2012-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2013-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2), N'1391', 11)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (74, CAST(N'2011-03-21T00:00:00.0000000' AS DateTime2), CAST(N'2012-03-19T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2), N'1390', 12)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (75, CAST(N'2010-03-21T00:00:00.0000000' AS DateTime2), CAST(N'2011-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2), N'1389', 13)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (76, CAST(N'2009-03-21T00:00:00.0000000' AS DateTime2), CAST(N'2010-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2), N'1388', 14)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (77, CAST(N'2008-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2009-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2), N'1387', 15)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (78, CAST(N'2007-03-21T00:00:00.0000000' AS DateTime2), CAST(N'2008-03-19T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2), N'1386', 16)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (79, CAST(N'2013-03-21T00:00:00.0000000' AS DateTime2), CAST(N'2013-07-22T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2), N'1392', 17)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (80, CAST(N'2019-03-21T00:00:00.0000000' AS DateTime2), CAST(N'2020-03-19T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-04T00:00:00.0000000' AS DateTime2), N'1398', 18)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (81, CAST(N'2013-07-23T00:00:00.0000000' AS DateTime2), CAST(N'2014-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2), N'1392', 19)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (82, CAST(N'2006-03-21T00:00:00.0000000' AS DateTime2), CAST(N'2007-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2), N'1385', 20)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (83, CAST(N'2005-07-24T00:00:00.0000000' AS DateTime2), CAST(N'2006-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2), N'1384', 21)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (84, CAST(N'2005-03-21T00:00:00.0000000' AS DateTime2), CAST(N'2005-07-22T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2), N'1384', 22)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (85, CAST(N'2004-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2005-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2), N'1383', 23)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (86, CAST(N'2004-03-09T00:00:00.0000000' AS DateTime2), CAST(N'2004-03-19T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2), N'1382', 24)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (87, CAST(N'2003-03-21T00:00:00.0000000' AS DateTime2), CAST(N'2004-03-08T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2), N'1382', 25)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (88, CAST(N'2002-03-21T00:00:00.0000000' AS DateTime2), CAST(N'2003-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2), N'1381', 26)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (89, CAST(N'2001-03-21T00:00:00.0000000' AS DateTime2), CAST(N'2002-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2), N'1380', 27)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (90, CAST(N'2000-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2001-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2), N'1379', 28)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (91, CAST(N'1999-03-21T00:00:00.0000000' AS DateTime2), CAST(N'2000-03-19T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2), N'1378', 29)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (92, CAST(N'1998-03-21T00:00:00.0000000' AS DateTime2), CAST(N'1999-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2), N'1377', 30)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (93, CAST(N'1997-03-21T00:00:00.0000000' AS DateTime2), CAST(N'1998-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2), N'1376', 31)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (94, CAST(N'1996-04-10T00:00:00.0000000' AS DateTime2), CAST(N'1997-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2), N'1375', 32)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (95, CAST(N'1996-03-20T00:00:00.0000000' AS DateTime2), CAST(N'1996-04-09T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2), N'1375', 33)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (96, CAST(N'1995-03-21T00:00:00.0000000' AS DateTime2), CAST(N'1996-03-19T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2), N'1374', 34)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (97, CAST(N'1994-03-21T00:00:00.0000000' AS DateTime2), CAST(N'1995-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2), N'1373', 35)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (98, CAST(N'1993-03-21T00:00:00.0000000' AS DateTime2), CAST(N'1994-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2), N'1372', 36)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (99, CAST(N'1992-03-21T00:00:00.0000000' AS DateTime2), CAST(N'1993-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2), N'1371', 37)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (100, CAST(N'1991-03-21T00:00:00.0000000' AS DateTime2), CAST(N'1992-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2), N'1370', 38)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (101, CAST(N'2020-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2020-06-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-05T00:00:00.0000000' AS DateTime2), N'1399', 39)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (102, CAST(N'2022-03-21T00:00:00.0000000' AS DateTime2), CAST(N'2023-03-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-03-10T00:00:00.0000000' AS DateTime2), N'1401', 40)
INSERT [dbo].[YearlySalariess] ([id], [StartDate], [EndDate], [CreationDate], [Year], [ConnectionId]) VALUES (103, CAST(N'2023-03-21T00:00:00.0000000' AS DateTime2), CAST(N'2024-03-19T00:00:00.0000000' AS DateTime2), CAST(N'2022-09-01T18:19:20.8489302' AS DateTime2), N'1402', 41)
SET IDENTITY_INSERT [dbo].[YearlySalariess] OFF
SET IDENTITY_INSERT [dbo].[YearlySalaryTitles] ON 

INSERT [dbo].[YearlySalaryTitles] ([id], [Title1], [Title2], [Title3], [Title4], [Title5], [Title6], [Title7], [Title8], [Title9], [Title10], [CreationDate]) VALUES (14, N'مزد روزانه', N'کمک هزینه اقلام', N'کمک هزینه مسکن', N'پایه سنوات', N'مبلغ مزد ثابت', N'درصد مزد ثابت', NULL, NULL, NULL, NULL, CAST(N'2022-03-01T21:03:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[YearlySalaryTitles] OFF
/****** Object:  Index [IX_Accounts_RoleId]    Script Date: 11/8/2022 23:41:00 ******/
CREATE NONCLUSTERED INDEX [IX_Accounts_RoleId] ON [dbo].[Accounts]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Boards_BoardType_Id]    Script Date: 11/8/2022 23:41:00 ******/
CREATE NONCLUSTERED INDEX [IX_Boards_BoardType_Id] ON [dbo].[Boards]
(
	[BoardType_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Boards_File_Id]    Script Date: 11/8/2022 23:41:00 ******/
CREATE NONCLUSTERED INDEX [IX_Boards_File_Id] ON [dbo].[Boards]
(
	[File_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Contracts_EmployeeId]    Script Date: 11/8/2022 23:41:00 ******/
CREATE NONCLUSTERED INDEX [IX_Contracts_EmployeeId] ON [dbo].[Contracts]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Contracts_EmployerId]    Script Date: 11/8/2022 23:41:00 ******/
CREATE NONCLUSTERED INDEX [IX_Contracts_EmployerId] ON [dbo].[Contracts]
(
	[EmployerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Contracts_JobTypeId]    Script Date: 11/8/2022 23:41:00 ******/
CREATE NONCLUSTERED INDEX [IX_Contracts_JobTypeId] ON [dbo].[Contracts]
(
	[JobTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Contracts_MandatoryHoursid]    Script Date: 11/8/2022 23:41:00 ******/
CREATE NONCLUSTERED INDEX [IX_Contracts_MandatoryHoursid] ON [dbo].[Contracts]
(
	[MandatoryHoursid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Contracts_WorkshopIds]    Script Date: 11/8/2022 23:41:00 ******/
CREATE NONCLUSTERED INDEX [IX_Contracts_WorkshopIds] ON [dbo].[Contracts]
(
	[WorkshopIds] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Contracts_YearlySalaryId]    Script Date: 11/8/2022 23:41:00 ******/
CREATE NONCLUSTERED INDEX [IX_Contracts_YearlySalaryId] ON [dbo].[Contracts]
(
	[YearlySalaryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeChildren_EmployeeId]    Script Date: 11/8/2022 23:41:00 ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeChildren_EmployeeId] ON [dbo].[EmployeeChildren]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Employers_ContractingPartyId]    Script Date: 11/8/2022 23:41:00 ******/
CREATE NONCLUSTERED INDEX [IX_Employers_ContractingPartyId] ON [dbo].[Employers]
(
	[ContractingPartyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Holidayitems_HolidayId]    Script Date: 11/8/2022 23:41:00 ******/
CREATE NONCLUSTERED INDEX [IX_Holidayitems_HolidayId] ON [dbo].[Holidayitems]
(
	[HolidayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PenaltyTitles_Petition_Id]    Script Date: 11/8/2022 23:41:00 ******/
CREATE NONCLUSTERED INDEX [IX_PenaltyTitles_Petition_Id] ON [dbo].[PenaltyTitles]
(
	[Petition_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Petitions_BoardType_Id]    Script Date: 11/8/2022 23:41:00 ******/
CREATE NONCLUSTERED INDEX [IX_Petitions_BoardType_Id] ON [dbo].[Petitions]
(
	[BoardType_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Petitions_File_Id]    Script Date: 11/8/2022 23:41:00 ******/
CREATE NONCLUSTERED INDEX [IX_Petitions_File_Id] ON [dbo].[Petitions]
(
	[File_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProceedingSessions_Board_Id]    Script Date: 11/8/2022 23:41:00 ******/
CREATE NONCLUSTERED INDEX [IX_ProceedingSessions_Board_Id] ON [dbo].[ProceedingSessions]
(
	[Board_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RolePermissions_RoleId]    Script Date: 11/8/2022 23:41:00 ******/
CREATE NONCLUSTERED INDEX [IX_RolePermissions_RoleId] ON [dbo].[RolePermissions]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TextManager_ModuleTextManager_ModuleId]    Script Date: 11/8/2022 23:41:00 ******/
CREATE NONCLUSTERED INDEX [IX_TextManager_ModuleTextManager_ModuleId] ON [dbo].[TextManager_ModuleTextManager]
(
	[ModuleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TextManager_Subtitle_OriginalTitle_Id]    Script Date: 11/8/2022 23:41:00 ******/
CREATE NONCLUSTERED INDEX [IX_TextManager_Subtitle_OriginalTitle_Id] ON [dbo].[TextManager_Subtitle]
(
	[OriginalTitle_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_WorkHistories_Petition_Id]    Script Date: 11/8/2022 23:41:00 ******/
CREATE NONCLUSTERED INDEX [IX_WorkHistories_Petition_Id] ON [dbo].[WorkHistories]
(
	[Petition_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_WorkingHours_ContractId]    Script Date: 11/8/2022 23:41:00 ******/
CREATE NONCLUSTERED INDEX [IX_WorkingHours_ContractId] ON [dbo].[WorkingHours]
(
	[ContractId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_WorkingHoursItems_WorkingHoursId]    Script Date: 11/8/2022 23:41:00 ******/
CREATE NONCLUSTERED INDEX [IX_WorkingHoursItems_WorkingHoursId] ON [dbo].[WorkingHoursItems]
(
	[WorkingHoursId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_WorkshopeEmployers_EmployerId]    Script Date: 11/8/2022 23:41:00 ******/
CREATE NONCLUSTERED INDEX [IX_WorkshopeEmployers_EmployerId] ON [dbo].[WorkshopeEmployers]
(
	[EmployerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_YearlyItems_YearlySalaryId]    Script Date: 11/8/2022 23:41:00 ******/
CREATE NONCLUSTERED INDEX [IX_YearlyItems_YearlySalaryId] ON [dbo].[YearlyItems]
(
	[YearlySalaryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contracts] ADD  DEFAULT (N'') FOR [ContractNo]
GO
ALTER TABLE [dbo].[Contracts] ADD  DEFAULT (N'') FOR [IsActiveString]
GO
ALTER TABLE [dbo].[Contracts] ADD  DEFAULT (N'') FOR [ArchiveCode]
GO
ALTER TABLE [dbo].[Contracts] ADD  DEFAULT (N'') FOR [ContractType]
GO
ALTER TABLE [dbo].[Contracts] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [GetWorkDate]
GO
ALTER TABLE [dbo].[Contracts] ADD  DEFAULT (N'') FOR [JobType]
GO
ALTER TABLE [dbo].[Contracts] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [SetContractDate]
GO
ALTER TABLE [dbo].[Contracts] ADD  DEFAULT (CONVERT([bigint],(0))) FOR [JobTypeId]
GO
ALTER TABLE [dbo].[Contracts] ADD  DEFAULT (N'') FOR [ConsumableItems]
GO
ALTER TABLE [dbo].[Contracts] ADD  DEFAULT (N'') FOR [HousingAllowance]
GO
ALTER TABLE [dbo].[Contracts] ADD  DEFAULT (N'') FOR [FamilyAllowance]
GO
ALTER TABLE [dbo].[PersonalContractingParties] ADD  DEFAULT (N'') FOR [IsLegal]
GO
ALTER TABLE [dbo].[PersonalContractingParties] ADD  DEFAULT (N'') FOR [NationalId]
GO
ALTER TABLE [dbo].[PersonalContractingParties] ADD  DEFAULT (N'') FOR [RegisterId]
GO
ALTER TABLE [dbo].[YearlySalariess] ADD  DEFAULT ((0)) FOR [ConnectionId]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Roles_RoleId]
GO
ALTER TABLE [dbo].[Boards]  WITH CHECK ADD  CONSTRAINT [FK_Boards_BoardTypes_BoardType_Id] FOREIGN KEY([BoardType_Id])
REFERENCES [dbo].[BoardTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Boards] CHECK CONSTRAINT [FK_Boards_BoardTypes_BoardType_Id]
GO
ALTER TABLE [dbo].[Boards]  WITH CHECK ADD  CONSTRAINT [FK_Boards_Files_File_Id] FOREIGN KEY([File_Id])
REFERENCES [dbo].[Files] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Boards] CHECK CONSTRAINT [FK_Boards_Files_File_Id]
GO
ALTER TABLE [dbo].[Contracts]  WITH CHECK ADD  CONSTRAINT [FK_Contracts_Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Contracts] CHECK CONSTRAINT [FK_Contracts_Employees_EmployeeId]
GO
ALTER TABLE [dbo].[Contracts]  WITH CHECK ADD  CONSTRAINT [FK_Contracts_Employers_EmployerId] FOREIGN KEY([EmployerId])
REFERENCES [dbo].[Employers] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Contracts] CHECK CONSTRAINT [FK_Contracts_Employers_EmployerId]
GO
ALTER TABLE [dbo].[Contracts]  WITH CHECK ADD  CONSTRAINT [FK_Contracts_Jobs_JobTypeId] FOREIGN KEY([JobTypeId])
REFERENCES [dbo].[Jobs] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Contracts] CHECK CONSTRAINT [FK_Contracts_Jobs_JobTypeId]
GO
ALTER TABLE [dbo].[Contracts]  WITH CHECK ADD  CONSTRAINT [FK_Contracts_MandatoryHours_MandatoryHoursid] FOREIGN KEY([MandatoryHoursid])
REFERENCES [dbo].[MandatoryHours] ([id])
GO
ALTER TABLE [dbo].[Contracts] CHECK CONSTRAINT [FK_Contracts_MandatoryHours_MandatoryHoursid]
GO
ALTER TABLE [dbo].[Contracts]  WITH CHECK ADD  CONSTRAINT [FK_Contracts_Workshops_WorkshopIds] FOREIGN KEY([WorkshopIds])
REFERENCES [dbo].[Workshops] ([id])
GO
ALTER TABLE [dbo].[Contracts] CHECK CONSTRAINT [FK_Contracts_Workshops_WorkshopIds]
GO
ALTER TABLE [dbo].[Contracts]  WITH CHECK ADD  CONSTRAINT [FK_Contracts_YearlySalariess_YearlySalaryId] FOREIGN KEY([YearlySalaryId])
REFERENCES [dbo].[YearlySalariess] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Contracts] CHECK CONSTRAINT [FK_Contracts_YearlySalariess_YearlySalaryId]
GO
ALTER TABLE [dbo].[EmployeeChildren]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeChildren_Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeChildren] CHECK CONSTRAINT [FK_EmployeeChildren_Employees_EmployeeId]
GO
ALTER TABLE [dbo].[Employers]  WITH CHECK ADD  CONSTRAINT [FK_Employers_PersonalContractingParties_ContractingPartyId] FOREIGN KEY([ContractingPartyId])
REFERENCES [dbo].[PersonalContractingParties] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Employers] CHECK CONSTRAINT [FK_Employers_PersonalContractingParties_ContractingPartyId]
GO
ALTER TABLE [dbo].[Holidayitems]  WITH CHECK ADD  CONSTRAINT [FK_Holidayitems_Holidays_HolidayId] FOREIGN KEY([HolidayId])
REFERENCES [dbo].[Holidays] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Holidayitems] CHECK CONSTRAINT [FK_Holidayitems_Holidays_HolidayId]
GO
ALTER TABLE [dbo].[PenaltyTitles]  WITH CHECK ADD  CONSTRAINT [FK_PenaltyTitles_Petitions_Petition_Id] FOREIGN KEY([Petition_Id])
REFERENCES [dbo].[Petitions] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PenaltyTitles] CHECK CONSTRAINT [FK_PenaltyTitles_Petitions_Petition_Id]
GO
ALTER TABLE [dbo].[Petitions]  WITH CHECK ADD  CONSTRAINT [FK_Petitions_BoardTypes_BoardType_Id] FOREIGN KEY([BoardType_Id])
REFERENCES [dbo].[BoardTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Petitions] CHECK CONSTRAINT [FK_Petitions_BoardTypes_BoardType_Id]
GO
ALTER TABLE [dbo].[Petitions]  WITH CHECK ADD  CONSTRAINT [FK_Petitions_Files_File_Id] FOREIGN KEY([File_Id])
REFERENCES [dbo].[Files] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Petitions] CHECK CONSTRAINT [FK_Petitions_Files_File_Id]
GO
ALTER TABLE [dbo].[ProceedingSessions]  WITH CHECK ADD  CONSTRAINT [FK_ProceedingSessions_Boards_Board_Id] FOREIGN KEY([Board_Id])
REFERENCES [dbo].[Boards] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProceedingSessions] CHECK CONSTRAINT [FK_ProceedingSessions_Boards_Board_Id]
GO
ALTER TABLE [dbo].[RolePermissions]  WITH CHECK ADD  CONSTRAINT [FK_RolePermissions_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RolePermissions] CHECK CONSTRAINT [FK_RolePermissions_Roles_RoleId]
GO
ALTER TABLE [dbo].[TextManager_ModuleTextManager]  WITH CHECK ADD  CONSTRAINT [FK_TextManager_ModuleTextManager_TextManager_Module_ModuleId] FOREIGN KEY([ModuleId])
REFERENCES [dbo].[TextManager_Module] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TextManager_ModuleTextManager] CHECK CONSTRAINT [FK_TextManager_ModuleTextManager_TextManager_Module_ModuleId]
GO
ALTER TABLE [dbo].[TextManager_ModuleTextManager]  WITH CHECK ADD  CONSTRAINT [FK_TextManager_ModuleTextManager_TextManager_TextManager_TextManagerId] FOREIGN KEY([TextManagerId])
REFERENCES [dbo].[TextManager_TextManager] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TextManager_ModuleTextManager] CHECK CONSTRAINT [FK_TextManager_ModuleTextManager_TextManager_TextManager_TextManagerId]
GO
ALTER TABLE [dbo].[TextManager_Subtitle]  WITH CHECK ADD  CONSTRAINT [FK_TextManager_Subtitle_TextManager_OriginalTitle_OriginalTitle_Id] FOREIGN KEY([OriginalTitle_Id])
REFERENCES [dbo].[TextManager_OriginalTitle] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TextManager_Subtitle] CHECK CONSTRAINT [FK_TextManager_Subtitle_TextManager_OriginalTitle_OriginalTitle_Id]
GO
ALTER TABLE [dbo].[WorkHistories]  WITH CHECK ADD  CONSTRAINT [FK_WorkHistories_Petitions_Petition_Id] FOREIGN KEY([Petition_Id])
REFERENCES [dbo].[Petitions] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WorkHistories] CHECK CONSTRAINT [FK_WorkHistories_Petitions_Petition_Id]
GO
ALTER TABLE [dbo].[WorkingHours]  WITH CHECK ADD  CONSTRAINT [FK_WorkingHours_Contracts_ContractId] FOREIGN KEY([ContractId])
REFERENCES [dbo].[Contracts] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WorkingHours] CHECK CONSTRAINT [FK_WorkingHours_Contracts_ContractId]
GO
ALTER TABLE [dbo].[WorkingHoursItems]  WITH CHECK ADD  CONSTRAINT [FK_WorkingHoursItems_WorkingHours_WorkingHoursId] FOREIGN KEY([WorkingHoursId])
REFERENCES [dbo].[WorkingHours] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WorkingHoursItems] CHECK CONSTRAINT [FK_WorkingHoursItems_WorkingHours_WorkingHoursId]
GO
ALTER TABLE [dbo].[WorkshopeAccounts]  WITH CHECK ADD  CONSTRAINT [FK_WorkshopeAccounts_Workshops_WorkshopId] FOREIGN KEY([WorkshopId])
REFERENCES [dbo].[Workshops] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WorkshopeAccounts] CHECK CONSTRAINT [FK_WorkshopeAccounts_Workshops_WorkshopId]
GO
ALTER TABLE [dbo].[WorkshopeEmployers]  WITH CHECK ADD  CONSTRAINT [FK_WorkshopeEmployers_Employers_EmployerId] FOREIGN KEY([EmployerId])
REFERENCES [dbo].[Employers] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WorkshopeEmployers] CHECK CONSTRAINT [FK_WorkshopeEmployers_Employers_EmployerId]
GO
ALTER TABLE [dbo].[WorkshopeEmployers]  WITH CHECK ADD  CONSTRAINT [FK_WorkshopeEmployers_Workshops_WorkshopId] FOREIGN KEY([WorkshopId])
REFERENCES [dbo].[Workshops] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WorkshopeEmployers] CHECK CONSTRAINT [FK_WorkshopeEmployers_Workshops_WorkshopId]
GO
ALTER TABLE [dbo].[YearlyItems]  WITH CHECK ADD  CONSTRAINT [FK_YearlyItems_YearlySalariess_YearlySalaryId] FOREIGN KEY([YearlySalaryId])
REFERENCES [dbo].[YearlySalariess] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[YearlyItems] CHECK CONSTRAINT [FK_YearlyItems_YearlySalariess_YearlySalaryId]
GO
USE [master]
GO
ALTER DATABASE [Mesbah_db] SET  READ_WRITE 
GO
