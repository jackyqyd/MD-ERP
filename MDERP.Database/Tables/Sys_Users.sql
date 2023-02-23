CREATE TABLE [dbo].[Sys_Users]
(
	[U_Id] BIGINT NOT NULL IDENTITY(1,1), 
    [U_UserName] NVARCHAR(50) NOT NULL, 
    [U_Password] NVARCHAR(50) NOT NULL, 
    [U_IsAdmin] BIT NOT NULL, 
    [U_Status] INT NOT NULL, 
    [U_LastLoginTime] DATETIME NULL
)
