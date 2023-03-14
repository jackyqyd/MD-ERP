CREATE TABLE [dbo].[Sys_Users]
(
	[U_Id] NVARCHAR(32) NOT NULL, 
    [U_UserName] NVARCHAR(50) NOT NULL, 
    [U_Password] NVARCHAR(50) NOT NULL, 
    [U_IsAdmin] INT NOT NULL, 
    [U_Status] INT NOT NULL, 
    [U_LastLoginTime] DATETIME NULL
)
