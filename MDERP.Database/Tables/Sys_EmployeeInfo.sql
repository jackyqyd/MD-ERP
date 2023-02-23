CREATE TABLE [dbo].[Sys_EmployeeInfo]
(
	[E_Id] BIGINT NOT NULL IDENTITY(1,1), 
    [E_FirstName] NVARCHAR(50) NOT NULL, 
    [E_MiddleName] NVARCHAR(50) NOT NULL, 
    [E_LastName] NVARCHAR(50) NOT NULL, 
    [E_Gender] BIT NOT NULL, 
    [E_Birthday] DATETIME NOT NULL, 
    [E_Continent] BIGINT NOT NULL, 
    [E_Country] BIGINT NOT NULL, 
    [E_StateProvince] BIGINT NOT NULL, 
    [E_City] BIGINT NOT NULL, 
    [E_DetailAddress] NVARCHAR(200) NOT NULL, 
    [E_IsMarried] BIT NOT NULL, 
    [E_Education] BIGINT NOT NULL, 
    [E_Cellphone] NVARCHAR(50) NOT NULL, 
    [E_LandLine] NVARCHAR(20) NULL, 
    [E_Fax] NVARCHAR(20) NULL, 
    [E_Email] NVARCHAR(50) NOT NULL, 
    [E_CreateDate] DATETIME NOT NULL, 
    [E_IsDel] BIT NOT NULL, 
    [E_IsLock] BIT NOT NULL
)
