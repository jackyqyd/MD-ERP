CREATE TABLE [dbo].[Sys_EmployeeInfo]
(
	[E_Id] NVARCHAR(32) NOT NULL, 
    [E_Name] NVARCHAR(50) NOT NULL, 
    [E_Gender] INT NOT NULL, 
    [E_Birthday] DATETIME NOT NULL, 
    [E_Continent] NVARCHAR(32) NOT NULL, 
    [E_Country] NVARCHAR(32) NOT NULL, 
    [E_StateProvince] NVARCHAR(32) NOT NULL, 
    [E_City] NVARCHAR(32) NOT NULL, 
    [E_DetailAddress] NVARCHAR(200) NOT NULL, 
    [E_IsMarried] INT NOT NULL, 
    [E_Education] NVARCHAR(32) NOT NULL, 
    [E_Cellphone] NVARCHAR(50) NOT NULL, 
    [E_LandLine] NVARCHAR(20) NULL, 
    [E_Fax] NVARCHAR(20) NULL, 
    [E_Email] NVARCHAR(50) NOT NULL, 
    [E_CreateDate] DATETIME NOT NULL, 
    [E_IsDel] INT NOT NULL, 
    [E_IsLock] INT NOT NULL
)
